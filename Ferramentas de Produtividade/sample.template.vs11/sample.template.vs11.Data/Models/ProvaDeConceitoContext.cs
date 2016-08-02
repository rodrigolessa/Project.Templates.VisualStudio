using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using sample.template.vs11.Data.Models.Mapping;

namespace sample.template.vs11.Data.Models
{
    public partial class ProvaDeConceitoContext : DbContext
    {
        static ProvaDeConceitoContext()
        {
            Database.SetInitializer<ProvaDeConceitoContext>(null);
        }

        public ProvaDeConceitoContext()
            : base("Name=ProvaDeConceitoContext")
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Intervalo> Intervaloes { get; set; }
        public DbSet<IntervalosDeTarefa> IntervalosDeTarefas { get; set; }
        public DbSet<Ponto> Pontoes { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new FuncionarioTypeConfiguration());
            modelBuilder.Configurations.Add(new IntervaloTypeConfiguration());
            modelBuilder.Configurations.Add(new IntervalosDeTarefaTypeConfiguration());
            modelBuilder.Configurations.Add(new PontoTypeConfiguration());
            modelBuilder.Configurations.Add(new TarefaTypeConfiguration());
        }
    }
}
