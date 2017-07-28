using System;

namespace BaseProjectANC.Domain.Core.Events
{
    public abstract class Message
    {
        public string MessageType { get; set; }

        public Guid AggregateId { get; set; }

        public Message()
        {
            this.MessageType = GetType().Name;
        }
    }
}
