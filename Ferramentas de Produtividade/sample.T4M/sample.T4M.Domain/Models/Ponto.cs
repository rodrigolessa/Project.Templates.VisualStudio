using System;
using System.Collections.Generic;

namespace sample.T4M.Domain.Models
{
    public partial class Ponto
    {
        public Ponto()
        {
            this.Intervaloes = new List<Intervalo>();
        }

        public int Id { get; set; }
        public int IdFuncionario { get; set; }
        public System.DateTime Dia { get; set; }
        public Nullable<System.TimeSpan> Horas { get; set; }
        public virtual Funcionario Funcionario { get; set; }
        public virtual ICollection<Intervalo> Intervaloes { get; set; }
    }
}
