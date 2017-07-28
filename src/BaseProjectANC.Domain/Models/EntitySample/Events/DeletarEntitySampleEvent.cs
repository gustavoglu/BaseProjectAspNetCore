using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Events
{
    public class DeletarEntitySampleEvent : BaseEntitySampleEvent
    {
        public DeletarEntitySampleEvent(Guid id)
        {
            this.Id = id;
            AggregateId = id;

        }
    }
}
