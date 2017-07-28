using BaseProjectANC.Domain.Models.EntitySample.Validations;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Commands
{
    public class ReativarEntitySampleCommand : BaseEntitySampleCommand
    {
        public ReativarEntitySampleCommand(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public override bool IsValid()
        {
            var validation = new ReativarEntitySampleValidation().Validate(this);
            return validation.IsValid;
        }
    }
}
