using System;
using System.Collections.Generic;

namespace sample.template.vs11.Data.Models
{
    public partial class IntervalosDeTarefa
    {
        public long Id { get; set; }
        public int IdTarefa { get; set; }
        public Nullable<System.DateTime> Inicio { get; set; }
        public Nullable<System.DateTime> Fim { get; set; }
        public virtual Tarefa Tarefa { get; set; }
    }
}
