using System;

namespace BaseProjectANC.Domain.Core.Events
{
    public abstract class Event : Message
    {
        public DateTime Timestamp { get; set; }

        public Event()
        {
            this.Timestamp = DateTime.Now;
        }
    }
}
