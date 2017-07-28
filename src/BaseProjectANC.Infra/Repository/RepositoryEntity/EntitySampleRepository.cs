using BaseProjectANC.Domain.Interfaces.RepositoryEntitys;
using BaseProjectANC.Domain.Models.EntitySample;
using BaseProjectANC.Infra.Data.Context;

namespace BaseProjectANC.Infra.Data.Repository.RepositoryEntity
{
    public class EntitySampleRepository : Repository<EntitySample>, IEntitySampleRepository
    {
        public EntitySampleRepository(ContextSQLS db) : base(db)
        {
        }
    }
}
