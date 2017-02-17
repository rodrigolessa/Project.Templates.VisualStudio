using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.EntityFramework;

namespace NgScaffold.Model
{
    public class ListarEntidadesViewModel
    {
        public CodeGenerationContext Contexto { get; private set; }

        List<TipoDoModelo> _listaDeEntidadesSelecionadas;
        public List<TipoDoModelo> ListaDeEntidadesSelecionadas
        {
            get
            {
                return _listaDeEntidadesSelecionadas;
            }
        }

        /// <summary>
        /// Obtendo todos os tipos de Contextos presentes no projeto corrente
        /// </summary>
        public IEnumerable<TipoDoModelo> ContextosDoBanco
        {
            get
            {
                ICodeTypeService codeTypeService = (ICodeTypeService)Contexto.ServiceProvider.GetService(typeof(ICodeTypeService));

                return codeTypeService
                    .GetAllCodeTypes(Contexto.ActiveProject)
                    .Where(p => p.IsValidDbContextType())
                    .Select(codeType => new TipoDoModelo(codeType));
            }
        }

        public IEnumerable<TipoDoModelo> ListaDeEntidades
        {
            get
            {
                ICodeTypeService codeTypeService = (ICodeTypeService)Contexto.ServiceProvider.GetService(typeof(ICodeTypeService));

                return codeTypeService
                    .GetAllCodeTypes(Contexto.ActiveProject)
                    .Where(
                            codeType => codeType.IsValidWebProjectEntityType() &&
                            codeType.Namespace.FullName == ContextoDoBancoSelecionado.CodeType.Namespace.FullName
                    )
                    .Select(codeType => new TipoDoModelo(codeType));
            }
        }

        public TipoDoModelo ContextoDoBancoSelecionado { get; set; }

        public bool IgnorarSeExitir { get; set; }

        public bool EhArea { get; set; }

        public ListarEntidadesViewModel(CodeGenerationContext context)
        {
            Contexto = context;
            _listaDeEntidadesSelecionadas = new List<TipoDoModelo>();
        }
    }
}