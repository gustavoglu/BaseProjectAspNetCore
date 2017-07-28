using BaseProjectANC.Domain.Core.Events;
using BaseProjectANC.Domain.Models.EntitySample.Events;
using System;

namespace BaseProjectANC.Domain.EventsHandler
{
    public class EntitySampleEvent : IHandler<CriarEntitySampleEvent>, IHandler<AtualizarEntitySampleEvent>, IHandler<DeletarEntitySampleEvent>, IHandler<ReativarEntitySampleEvent>
    {
        public void Handler(CriarEntitySampleEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handler(AtualizarEntitySampleEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handler(DeletarEntitySampleEvent message)
        {
            throw new NotImplementedException();
        }

        public void Handler(ReativarEntitySampleEvent message)
        {
            throw new NotImplementedException();
        }
    }
}
