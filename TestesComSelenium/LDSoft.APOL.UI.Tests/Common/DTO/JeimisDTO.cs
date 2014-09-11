using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LDSoft.APOL.UI.Tests.Common.DTO
{
    public class JeimisDTO
    {
        public Nullable<Int32> Id { get; set; }
        public string Nome { get; set; }
        public string Diretorio { get; set; }
        public string Modulo { get; set; }
        public string LinkEditar { get; set; }
        public string LinkExcluir { get; set; }
    }
}
