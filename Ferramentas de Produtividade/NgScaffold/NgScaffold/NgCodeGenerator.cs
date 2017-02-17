using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.Core.Metadata;
using Microsoft.AspNet.Scaffolding.EntityFramework;

using EnvDTE;

using NgScaffold.UI;
using NgScaffold.Model;
using NgScaffold.Helpers;
using NgScaffold.Extensions;

namespace NgScaffold
{
    public class NgCodeGenerator : CodeGenerator
    {
        ListarEntidadesViewModel _viewModel;
        ScaffoldHelpers _helper;

        public NgCodeGenerator(CodeGenerationContext context, CodeGeneratorInformation information)
            : base(context, information)
        {
            _viewModel = new ListarEntidadesViewModel(Context);
            _helper = new ScaffoldHelpers();
        }

        #region Member of CodeGenerator

        public override void GenerateCode()
        {
            // Obtendo informações do projeto corrente, sempre do tipo ASP.Net MVC, onde foi ativada a extension
            Project projetoCorrente = Context.ActiveProject;

            // Obtendo uma lista de todos os projetos abertos na Instância corrente do Visual Studio. Permite a criação de objetos
            Solution solucao = projetoCorrente.DTE.Solution;

            var listaDeProjetos = new List<Project>();

            // Define uma lista com todos os projetos abertos
            foreach (Project p in solucao.Projects)
            {
                if (p.Kind == Constants.vsProjectKindSolutionItems)
                    listaDeProjetos.AddRange(p.ExtrairSubProjetos());
                else
                    listaDeProjetos.Add(p);
            }

            // Contexto do banco selecionado pelo Programador
            var contextoDoBanco = _viewModel.ContextoDoBancoSelecionado;

            // Lista de Entidades selecionadas pelo Programador
            var listaDeEntidades = _viewModel.ListaDeEntidadesSelecionadas;

            // Define o projeto onde existe o contexto do banco
            Project projetoDoContexto = null;
            foreach (Project p2 in listaDeProjetos)
            {
                if (contextoDoBanco.CodeType.Namespace.FullName.StartsWith(p2.Name + "."))
                {
                    projetoDoContexto = p2;
                    break;
                }
            }

            string namespacePadrao = null;

            string diretorioDaArea = string.Empty;

            if (_viewModel.EhArea)
            {
                //string AreaName = _viewModel.AreaSelecionada;
                //ProjectItem AreaItem = AddArea(projetoCorrente, AreaName);
                //diretorioDaArea = string.Format("Areas\\{0}\\", AreaName);
                //namespacePadrao = AreaItem.GetDefaultNamespace();
            }

            var diretorioRelativo = diretorioDaArea;

            //AddMvcModels(projetoCorrente, diretorioRelativo + "Models\\", namespacePadrao);

            foreach (var entidade in listaDeEntidades.Select(p => p.CodeType))
            {
                // Entity Framework Meta Data
                IEntityFrameworkService efService = (IEntityFrameworkService)Context.ServiceProvider.GetService(typeof(IEntityFrameworkService));

                // Obtem todas as informações da entidade que o Entity possui. Tipos dos campos e relacionamentos
                ModelMetadata efMetadata = efService.AddRequiredEntity(Context, contextoDoBanco.TypeName, entidade.FullName);

                // Adiciona classe de serviço na mesma camada do domínio / entidades
                //AddBLL(projetoDoContexto, entidade, "Service\\", contextoDoBanco, efMetadata);

                NgController(projetoCorrente, entidade, diretorioRelativo, "Controllers", namespacePadrao, efMetadata);

                //AddMvcViews(projetoCorrente, diretorioRelativo + "Views\\", entidade, contextoDoBanco, efMetadata, namespacePadrao);
            }
        }

        public override bool ShowUIAndValidate()
        {
            var janela = new ListarEntidadesView(_viewModel);
            var aberta = janela.ShowDialog();
            if (aberta.HasValue)
                return aberta.Value;

            return false;
        }

        #endregion

        // Criação da camada de Serviço - Domain Service ou BLL (Business Logic Layer)

        /// <summary>
        /// Criação do MVC API Controller
        /// </summary>
        /// <param name="projeto"></param>
        /// <param name="entidade"></param>
        /// <param name="diretorioRelativo"></param>
        /// <param name="template"></param>
        /// <param name="namespacePadrao"></param>
        /// <param name="efMetadata"></param>
        private void NgController(
            Project projeto,
            CodeType entidade,
            string diretorioRelativo,
            string template,
            string namespacePadrao,
            ModelMetadata efMetadata
        )
        {
            diretorioRelativo = diretorioRelativo + template + "\\";

            // Pasta de Modelos
            string namespaceDoModelo = string.Empty;
            if (string.IsNullOrEmpty(namespacePadrao))
                namespaceDoModelo = (projeto.Name + ".Models");
            else
                namespaceDoModelo = namespacePadrao + ".Models";

            // Pastas de Controles
            if (string.IsNullOrEmpty(namespacePadrao))
                namespacePadrao = (projeto.Name + "." + template);
            else
                namespacePadrao += "." + template;

            string tipoDaEntidade = _helper.ObterTipo(entidade.Name);

            string nomeDoController = entidade.Name + template;

            string diretorioDeDestino = Path.Combine(diretorioRelativo, nomeDoController);

            // Define os parâmetros do scaffold
            var parametros = _helper.Parametros(entidade, namespacePadrao, efMetadata, namespaceDoModelo, "Service");

            // Adiciona o template T4.
            this.AddFileFromTemplate(
                projeto,
                diretorioDeDestino,
                template + "\\MVC",
                parametros,
                _viewModel.IgnorarSeExitir);
        }

        // Criação da ViewModel, em um modelo MVVM com AngularJS

        // Criação da View
    }
}
