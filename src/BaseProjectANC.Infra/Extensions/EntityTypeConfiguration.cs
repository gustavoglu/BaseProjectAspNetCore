using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProjectANC.Infra.Data.Extensions
{
    public abstract class EntityTypeConfiguration<T> where T : class
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

    }
}
