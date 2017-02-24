using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.EntityFramework;

using NgScaffold.Helpers;

namespace NgScaffold.Model
{
    public class ListarEntidadesViewModel
    {
        public CodeGenerationContext Contexto { get; private set; }

        /// <summary>
        /// Obtendo todos os tipos de Contextos presentes no projeto corrente
        /// </summary>
        public IEnumerable<TipoDoModelo> ListaDeContextosDeBanco
        {
            get
            {
                // https://msdn.microsoft.com/pt-br/library/bb138962.aspx
                // Os VSPackages gerenciados pode usar GetService para obter as interfaces VSSDK COM consultando os assemblies de interoperabilidade
                ICodeTypeService codeTypeService = (ICodeTypeService)Contexto.ServiceProvider.GetService(typeof(ICodeTypeService));

                // Retorna todos os "tipos" classes disponíveis/públicas associados aos projeto corrente
                // Filtro por classes válidas como um tipo de "Contexto"
                return codeTypeService
                    .GetAllCodeTypes(Contexto.ActiveProject)
                    .Where(p => p.IsValidDbContextType())
                    .Select(codeType => new TipoDoModelo(codeType));
            }
        }

        public TipoDoModelo ContextoDeBancoSelecionado { get; set; }

        public string NamespaceSelecionado
        {
            get
            {
                return ContextoDeBancoSelecionado.CodeType.Namespace.FullName;

                //if (ContextoDeBancoSelecionado != null)
                //{
                //    // Exemplo de resultado da propriedade "FullName" = "LDSoft.Apol.Infrastructure.Data.UnitOfWork"
                //    var namespaceReferenteAoContexto = ContextoDeBancoSelecionado.CodeType.Namespace.FullName;

                //    if (!string.IsNullOrEmpty(namespaceReferenteAoContexto))
                //    {
                //        namespaceReferenteAoContexto = namespaceReferenteAoContexto.Replace("." + Constantes.Pastas.ContextosDeBanco, "");

                //        return namespaceReferenteAoContexto;
                //    }
                //}

                //return string.Empty;
            }
        }

        public string NamespaceDominioProvavel
        {
            get
            {
                return ScaffoldHelpers.ObterNamespaceBase(ContextoDeBancoSelecionado.CodeType.Namespace.FullName) + "." + Constantes.Camadas.Dominio;
            }
        }

        public IEnumerable<TipoDoModelo> ListaDeEntidades
        {
            get
            {
                // https://msdn.microsoft.com/pt-br/library/bb138962.aspx
                // Os VSPackages gerenciados pode usar GetService para obter as interfaces VSSDK COM consultando os assemblies de interoperabilidade
                ICodeTypeService codeTypeService = (ICodeTypeService)Contexto.ServiceProvider.GetService(typeof(ICodeTypeService));

                // Retorna todos os "tipos" classes disponíveis/públicas associados aos projeto corrente
                // Filtro por classes válidas como um tipo de "Entidade"
                // E devem pertencer ao mesmo namespace do Contexto do Banco selecionado ou pertencer a um namespace de "Domínio"
                return codeTypeService
                    .GetAllCodeTypes(Contexto.ActiveProject)
                    .Where(
                        codeType => codeType.IsValidWebProjectEntityType()
                        && (
                                codeType.Namespace.FullName == this.NamespaceSelecionado
                            ||  codeType.Namespace.FullName.Contains(this.NamespaceDominioProvavel)
                        )
                    )
                    .Select(codeType => new TipoDoModelo(codeType));
            }
        }

        private List<TipoDoModelo> _listaDeEntidadesSelecionadas;
        public List<TipoDoModelo> ListaDeEntidadesSelecionadas
        {
            get
            {
                return _listaDeEntidadesSelecionadas;
            }
        }

        public bool IgnorarSeExitir { get; set; }

        public bool EhArea { get; set; }

        #region Construtor

        public ListarEntidadesViewModel(CodeGenerationContext context)
        {
            Contexto = context;
            _listaDeEntidadesSelecionadas = new List<TipoDoModelo>();
        }

        #endregion
    }
}