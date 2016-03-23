
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace sample.T4M.Domain.Models.Mapping
{
    public class IntervaloTypeConfiguration : EntityTypeConfiguration<Intervalo>
    {
        public IntervaloTypeConfiguration()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("Intervalo");
            this.Property(t => t.Id).HasColumnName("Id");
            this.Property(t => t.IdPonto).HasColumnName("IdPonto");
            this.Property(t => t.Entrada).HasColumnName("Entrada");
            this.Property(t => t.Saida).HasColumnName("Saida");

            // Relationships
            this.HasRequired(t => t.Ponto)
                .WithMany(t => t.Intervaloes)
                .HasForeignKey(d => d.IdPonto);

        }
    }
}
