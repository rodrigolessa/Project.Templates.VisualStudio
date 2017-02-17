using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.Core.Metadata;
using Microsoft.AspNet.Scaffolding.EntityFramework;

using EnvDTE;

namespace NgScaffold.Helpers
{
    public class ScaffoldHelpers
    {
        public string ObterTipo(string t)
        {
            return t
                .Substring(0, 1)
                .ToLower() + t
                    .Substring(1, t.Length - 1);
        }

        /// <summary>
        /// Define os parâmetros do scaffold
        /// </summary>
        /// <param name="entidade"></param>
        /// <param name="namespacePadrao"></param>
        /// <param name="metaData"></param>
        /// <param name="modelNamespace"></param>
        /// <param name="tipoNamespace"></param>
        /// <returns></returns>
        public Dictionary<string, object> Parametros(CodeType entidade, string namespacePadrao, ModelMetadata metaData, string modelNamespace, string tipoNamespace)
        {
            // 
            return new Dictionary<string, object>()
            {
                {"ModelType", entidade},
                {"Namespace", namespacePadrao},
                {"MetadataModel", metaData},
                {"RequiredNamespaces", new HashSet<string>() {
                        entidade.Namespace.FullName, 
                        ObterNamespaceDeOrigem(entidade.Namespace.FullName) + "." + tipoNamespace,
                        modelNamespace
                    }
                }
            };
        }

        private string ObterNamespaceDeOrigem(string p)
        {
            var nomes = p.Split('.');

            if (nomes != null || nomes.Count() > 0)
                return nomes[0];

            return p;
        }
    }
}
