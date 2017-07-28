using BaseProjectANC.Domain.Core.Events;
using FluentValidation.Results;
using System;

namespace BaseProjectANC.Domain.Core.Commands
{
    public abstract class Command : Message
    {
        public DateTime Timestamp { get; set; }

        public ValidationResult ValidationResult { get; set; }

        public Command()
        {
            this.Timestamp = DateTime.Now;
        }

        public abstract bool IsValid();
    }
}
