namespace BaseProjectANC.Domain.Models.EntitySample.Validations
{
    public class AtualizarEntitySampleValidation : EntitySampleValidation
    {
        public AtualizarEntitySampleValidation()
        {
            ValidaId();
            ValidaDescricao();
        }
    }
}
