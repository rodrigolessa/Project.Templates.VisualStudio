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

        public NgCodeGenerator(CodeGenerationContext context, CodeGeneratorInformation information)
            : base(context, information)
        {
            _viewModel = new ListarEntidadesViewModel(Context);
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
            var contextoDoBanco = _viewModel.ContextoDeBancoSelecionado;

            // Lista de Entidades selecionadas pelo Programador
            var listaDeEntidades = _viewModel.ListaDeEntidadesSelecionadas;

            // Define o projeto onde estão as entidades selecionadas
            Project projetoDaEntidade = null;

            foreach (Project p1 in listaDeProjetos)
            {
                if (listaDeEntidades[0].CodeType.Namespace.FullName.StartsWith(p1.Name + "."))
                {
                    projetoDaEntidade = p1;
                    break;
                }
            }

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

            var namespacePadrao = string.Empty;

            var diretorioDaArea = string.Empty;

            if (_viewModel.EhArea)
            {
                // TODO: Controlar entidades que devem ser criadas dentro de áreas
                //string AreaName = _viewModel.AreaSelecionada;
                //ProjectItem AreaItem = T4Area(projetoCorrente, nomeDaArea);
                //diretorioDaArea = string.Format("Areas\\{0}\\", nomeDaArea);
                //namespacePadrao = AreaItem.GetDefaultNamespace();
            }

            var diretorioRelativo = diretorioDaArea;

            // Para cada entidade selecionada, cria um Repositório, um Serviço e um MVC ou MVVM
            foreach (var entidade in listaDeEntidades.Select(p => p.CodeType))
            {
                // Entity Framework Meta Data
                // Os VSPackages gerenciados pode usar GetService para obter as interfaces VSSDK COM consultando os assemblies de interoperabilidade
                IEntityFrameworkService efService = (IEntityFrameworkService)Context.ServiceProvider.GetService(typeof(IEntityFrameworkService));

                // Obtem todas as informações da entidade que o Entity possui. Tipos dos campos e relacionamentos
                ModelMetadata efMetadata = efService.AddRequiredEntity(Context, contextoDoBanco.TypeName, entidade.FullName);

                // Adiciona a intreface do repositório na camada do contexto do banco
                RepositorioTipadoInterface(projetoDaEntidade, entidade, contextoDoBanco, efMetadata);

                // Adiciona classe de repositório na camada do contexto do banco
                RepositorioTipado(projetoDoContexto, entidade, contextoDoBanco, efMetadata);

                // Adiciona classe de serviço na mesma camada do domínio / entidades
                ServicoTipado(projetoDaEntidade, entidade, contextoDoBanco, efMetadata);

                NgControle(projetoCorrente, entidade, diretorioRelativo, namespacePadrao, contextoDoBanco, efMetadata);

                NgVisao(projetoCorrente, entidade, diretorioRelativo, namespacePadrao, contextoDoBanco, efMetadata);
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

        /// <summary>
        /// Criação da intreface do repositório na camada de Domínio
        /// </summary>
        /// <param name="projetoDaEntidade"></param>
        /// <param name="entidade"></param>
        /// <param name="contextoDoBanco"></param>
        /// <param name="efMetadata"></param>
        private void RepositorioTipadoInterface(Project projetoDaEntidade, CodeType entidade, TipoDoModelo contextoDoBanco, ModelMetadata efMetadata)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Criação do Repositório na camada de Persistência - Infrastructure.Data
        /// </summary>
        /// <param name="projetoDoContexto"></param>
        /// <param name="entidade"></param>
        /// <param name="contextoDoBanco"></param>
        /// <param name="efMetadata"></param>
        private void RepositorioTipado(Project projetoDoContexto, CodeType entidade, TipoDoModelo contextoDoBanco, ModelMetadata efMetadata)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Criação da camada de Domínio - Domain Service ou BLL (Business Logic Layer)
        /// </summary>
        /// <param name="projetoDoContexto"></param>
        /// <param name="entidade"></param>
        /// <param name="contextoDoBanco"></param>
        /// <param name="efMetadata"></param>
        private void ServicoTipado(Project projeto, CodeType entidade, TipoDoModelo contextoDoBanco, ModelMetadata efMetadata)
        {
            //// Os serviços sempre devem estar no mesmo projeto que as entidades
            //var namespaceDoServico = ScaffoldHelpers.ObterNamespaceAnterior(entidade.Namespace.FullName) + "." + Constantes.Pastas.Servicos;

            //// Get the selected code type
            //var defaultNamespace = (project.Name + ".BLL");

            //string modelTypeVariable = GetTypeVariable(codeType.Name);

            //string BLLName = codeType.Name + "Service";
            //string outputFolderPath = Path.Combine(selectionRelativePath, BLLName);

            //// Setup the scaffolding item creation parameters to be passed into the T4 template.
            //var parameters = new Dictionary<string, object>()
            //{
            //    {"ModelType", codeType},
            //    {"Namespace", defaultNamespace},
            //    {"dbContext", dbContextClass.ShortTypeName},
            //    {"MetadataModel", efMetadata},
            //    {"EntitySetVariable", modelTypeVariable},
            //    {"RequiredNamespaces", new HashSet<string>(){codeType.Namespace.FullName, (project.Name + ".Models")}}
            //};

            //// Add the custom scaffolding item from T4 template.
            //this.AddFileFromTemplate(project,
            //    outputFolderPath,
            //    "BLL",
            //    parameters,
            //    skipIfExists: _viewModel.SkipIfExists);
        }


        /// <summary>
        /// Criação do MVC API Controller
        /// </summary>
        /// <param name="projeto"></param>
        /// <param name="entidade"></param>
        /// <param name="diretorioRelativo"></param>
        /// <param name="namespacePadrao"></param>
        /// <param name="namespaceDoContexto"></param>
        /// <param name="efMetadata"></param>
        private void NgControle(
            Project projeto,
            CodeType entidade,
            string diretorioRelativo,
            string namespacePadrao,
            TipoDoModelo contextoDoBanco,
            ModelMetadata efMetadata
        )
        {
            diretorioRelativo = diretorioRelativo + Constantes.Pastas.Controles + "\\";

            // Pasta de Modelos
            //var namespaceDoModelo = string.Empty;

            //if (string.IsNullOrEmpty(namespacePadrao))
            //    namespaceDoModelo = projeto.Name + "." + Constantes.Pastas.Modelos;
            //else
            //    namespaceDoModelo = namespacePadrao + "." + Constantes.Pastas.Modelos;

            // Os serviços sempre devem estar no mesmo projeto que as entidades
            var namespaceDoServico = ScaffoldHelpers.ObterNamespaceAnterior(entidade.Namespace.FullName) + "." + Constantes.Pastas.Servicos;

            // Pastas de Controles
            if (string.IsNullOrEmpty(namespacePadrao))
                namespacePadrao = (projeto.Name + "." + Constantes.Pastas.Controles);
            else
                namespacePadrao += "." + Constantes.Pastas.Controles;

            string arquivoDeDestino = Path.Combine(diretorioRelativo, entidade.Name + "Controller");

            // Define os parâmetros do scaffold. Modo de transmitir os dados da entidade e o namespace
            var parametros = ScaffoldHelpers.ParametrosDoTemplate(entidade, namespacePadrao, contextoDoBanco, efMetadata, entidade.Namespace.FullName, namespaceDoServico, contextoDoBanco.CodeType.Namespace.FullName);

            // Adiciona a classe base dos controles API com Authorize
            this.AddFileFromTemplate(
                projeto,
                Path.Combine(diretorioRelativo, "SecurityAPIController"),
                Constantes.Pastas.Controles + "\\SecurityAPI",
                ScaffoldHelpers.ParametrosDoTemplate(entidade, namespacePadrao, contextoDoBanco, efMetadata),
                true
            );

            // Adiciona o template T4 do CONTROLE
            this.AddFileFromTemplate(
                projeto,
                arquivoDeDestino,
                Constantes.Pastas.Controles + "\\MVVM",
                parametros,
                _viewModel.IgnorarSeExitir
            );
        }

        // Criação da área

        // Criação da ViewModel, em um modelo MVVM com AngularJS

        /// <summary>
        /// Criação da View usando AngularJS
        /// </summary>
        /// <param name="projetoCorrente"></param>
        /// <param name="entidade"></param>
        /// <param name="diretorioRelativo"></param>
        /// <param name="namespacePadrao"></param>
        /// <param name="contextoDoBanco"></param>
        /// <param name="efMetadata"></param>
        private void NgVisao(Project projeto, CodeType entidade, string diretorioRelativo, string namespacePadrao, TipoDoModelo contextoDoBanco, ModelMetadata efMetadata)
        {
            throw new NotImplementedException();
        }
    }
}
