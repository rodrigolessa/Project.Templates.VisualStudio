
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sample.template.vs11.Data.Models.Mapping
{
    public class IntervalosDeTarefaTypeConfiguration : EntityTypeConfiguration<IntervalosDeTarefa>
    {
        public IntervalosDeTarefaTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("IntervalosDeTarefa");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdTarefa).HasColumnName("IdTarefa");
            this.Property(t => t.Inicio).HasColumnName("Inicio");
            this.Property(t => t.Fim).HasColumnName("Fim");

            // Relationships
            this.HasRequired(t => t.Tarefa)
                .WithMany(t => t.IntervalosDeTarefas)
                .HasForeignKey(d => d.IdTarefa);

        }
    }
}
