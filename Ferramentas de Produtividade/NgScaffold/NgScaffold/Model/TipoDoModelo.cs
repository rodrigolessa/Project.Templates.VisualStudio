using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EnvDTE;

namespace NgScaffold.Model
{
    /// <summary>
    /// Somente um wrapper de CodeType para atribuir propriedade na grid da View
    /// </summary>
    public class TipoDoModelo
    {
        public TipoDoModelo(CodeType codeType)
        {
            if (codeType == null)
                throw new ArgumentNullException("codeType");

            CodeType = codeType;
            TypeName = codeType.FullName;
            ShortTypeName = codeType.Name;
            DisplayName = (codeType.Namespace == null || String.IsNullOrWhiteSpace(codeType.Namespace.FullName))
                            ? codeType.Name
                            : String.Format(CultureInfo.InvariantCulture, "{0} ({1})", codeType.Name, codeType.Namespace.FullName);

            IsChecked = true;
        }

        public CodeType CodeType { get; set; }

        public string DisplayName { get; set; }

        public string TypeName { get; set; }

        public string ShortTypeName { get; set; }

        public bool IsChecked { get; set; }
    }
}
