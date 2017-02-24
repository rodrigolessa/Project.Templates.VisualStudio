using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNet.Scaffolding;
using Microsoft.AspNet.Scaffolding.Core.Metadata;
using Microsoft.AspNet.Scaffolding.EntityFramework;

using EnvDTE;

using NgScaffold.Model;

namespace NgScaffold.Helpers
{
    public static class ScaffoldHelpers
    {
        public static string PrimeiraLetraMaiuscula(string t)
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
        public static Dictionary<string, object> ParametrosDoTemplate(CodeType entidade, string namespacePadrao, TipoDoModelo contextoDoBanco, ModelMetadata metaData, params string[] dependencias)
        {
            var nomeDaEntidade = PrimeiraLetraMaiuscula(entidade.Name);

            return new Dictionary<string, object>()
            {
                {"ModelType", entidade},
                {"Namespace", namespacePadrao},
                {"dbContext", contextoDoBanco.ShortTypeName},
                {"MetadataModel", metaData},
                {"EntitySetVariable", nomeDaEntidade},
                {"RequiredNamespaces", new HashSet<string>(dependencias)}
            };
        }

        public static string ObterNamespaceDeOrigem(string p)
        {
            var nomes = p.Split('.');

            if (nomes != null || nomes.Count() > 0)
                return nomes[0];

            return p;
        }

        public static string ObterNamespaceAnterior(string p)
        {
            var nomes = p.Split('.');

            if (nomes != null || nomes.Count() > 1)
            {
                var anterior = nomes[nomes.Count() - 1];

                p = p.Replace("." + anterior, "");
            }

            return p;
        }

        public static string ObterNamespaceBase(string p)
        {
            var nomes = p.Split('.');
            
            //var n = string.Join(".", nomes.Where(x => !_nomesDeCamadas.Contains(x)));
            var n = string.Empty;

            foreach (string nome in nomes)
            {
                if (Constantes.Camadas.Nomes.Contains(nome))
                    break;

                n += nome + ".";
            }

            if (!string.IsNullOrEmpty(n))
                n = n.Substring(0, n.Length - 1);

            return n;
        }
    }
}