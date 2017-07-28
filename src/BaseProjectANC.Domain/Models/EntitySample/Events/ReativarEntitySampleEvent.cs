using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Events
{
    public class ReativarEntitySampleEvent : BaseEntitySampleEvent
    {
        public ReativarEntitySampleEvent(Guid id)
        {
            this.Id = id;
            AggregateId = id;
        }
    }
}
