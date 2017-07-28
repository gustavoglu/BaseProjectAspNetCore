namespace BaseProjectANC.Domain.Models.EntitySample.Events
{
    public class CriarEntitySampleEvent : BaseEntitySampleEvent
    {
        public CriarEntitySampleEvent(string descricao)
        {
            this.Descricao = descricao;
        }
    }
}
