
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sample.template.vs11.Data.Models.Mapping
{
    public class PontoTypeConfiguration : EntityTypeConfiguration<Ponto>
    {
        public PontoTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Ponto");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdFuncionario).HasColumnName("IdFuncionario");
            this.Property(t => t.Dia).HasColumnName("Dia");
            this.Property(t => t.Horas).HasColumnName("Horas");

            // Relationships
            this.HasRequired(t => t.Funcionario)
                .WithMany(t => t.Pontoes)
                .HasForeignKey(d => d.IdFuncionario);

        }
    }
}
