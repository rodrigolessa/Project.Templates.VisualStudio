using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

namespace NgScaffold.Extensions
{
    public static class ProjetoExtension
    {
        public static IEnumerable<Project> ExtrairSubProjetos(this Project p)
        {
            var lista = new List<Project>();

            foreach (ProjectItem item in p.ProjectItems)
            {
                var subProjeto = item.SubProject;
                if (subProjeto == null)
                    continue;

                // Se o diretório for em outra solução, Faz uma chamada recursiva
                if (subProjeto.Kind == Constants.vsProjectKindSolutionItems)
                {
                    lista.AddRange(subProjeto.ExtrairSubProjetos());
                }
                else
                {
                    lista.Add(subProjeto);
                }
            }

            return lista;
        }
    }
}
