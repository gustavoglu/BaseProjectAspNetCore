using BaseProjectANC.Domain.Models.EntitySample;
using BaseProjectANC.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectANC.Infra.Data.Mappings
{
    public class EntitySampleMap : EntityTypeConfiguration<EntitySample>
    {
        public override void Map(EntityTypeBuilder<EntitySample> builder)
        {
            builder.ToTable("entitysample");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnType("varchar(150)")
                .IsRequired();

        }
    }
}
