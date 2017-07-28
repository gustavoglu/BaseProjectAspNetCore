using BaseProjectANC.Domain.Core.Commands;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Commands
{
    public abstract class BaseEntitySampleCommand : Command
    {
        public Guid Id { get; set; }

        public string Descricao { get; set; }

    }
}
