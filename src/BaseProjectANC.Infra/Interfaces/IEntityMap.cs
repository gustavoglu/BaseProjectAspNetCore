using BaseProjectANC.Domain.Core.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseProjectANC.Infra.Data.Interfaces
{
    public interface IEntityMap<T> where T : Entity
    {
        void MappingPropertysBaseEntity(EntityTypeBuilder<T> builder);
    }
}
