using System;

namespace BaseProjectANC.Domain.Models.EntitySample.Events
{
    public class AtualizarEntitySampleEvent : BaseEntitySampleEvent
    {
        public AtualizarEntitySampleEvent(Guid id,string descricao)
        {
            this.Id = id;
            this.Descricao = descricao;
        }
    }
}
