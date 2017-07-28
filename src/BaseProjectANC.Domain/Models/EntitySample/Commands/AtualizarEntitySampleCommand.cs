using BaseProjectANC.Domain.Models.EntitySample.Validations;
using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Commands
{
    public class AtualizarEntitySampleCommand : BaseEntitySampleCommand
    {
        public AtualizarEntitySampleCommand(Guid id,string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }

        public override bool IsValid()
        {
            var validation = new AtualizarEntitySampleValidation().Validate(this);
            return validation.IsValid;
        }
    }
}
