using BaseProjectANC.Domain.Core.Events;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Events
{
    public abstract class BaseEntitySampleEvent : Event
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }
    }
}
