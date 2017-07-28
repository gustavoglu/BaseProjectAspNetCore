using BaseProjectANC.Domain.Models.EntitySample.Validations;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Commands
{
    public class DeletarEntitytSampleCommand : BaseEntitySampleCommand
    {
        public DeletarEntitytSampleCommand(Guid id)
        {
            this.Id = id;
            this.AggregateId = id;
        }

        public override bool IsValid()
        {
            var validation = new DeletarEntitySampleValidation().Validate(this);
            return validation.IsValid;
        }
    }
}
