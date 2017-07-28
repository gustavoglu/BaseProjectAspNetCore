using BaseProjectANC.Domain.Models.EntitySample.Validations;

namespace BaseProjectANC.Domain.Models.EntitySample.Commands
{
    public class CriarEntitySampleCommand : BaseEntitySampleCommand
    {
        public CriarEntitySampleCommand(string descricao)
        {
            this.Descricao = descricao;
        }

        public override bool IsValid()
        {
            var validation = new CriarEntitySampleValidation().Validate(this);
            return validation.IsValid;
        }
    }
}
