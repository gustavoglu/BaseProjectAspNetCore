using BaseProjectANC.Domain.Core.Events;
using BaseProjectANC.Domain.Models.EntitySample.Commands;
using BaseProjectANC.Domain.Core.Bus;
using BaseProjectANC.Domain.Core.UoW;
using BaseProjectANC.Domain.Core.Notifications;
using BaseProjectANC.Domain.Interfaces.RepositoryEntitys;
using BaseProjectANC.Domain.Models.EntitySample;
using static BaseProjectANC.Domain.Models.EntitySample.EntitySample;

namespace BaseProjectANC.Domain.CommandsHandler
{
    public class EntitySampleCommand : CommandHandler, IHandler<CriarEntitySampleCommand>, IHandler<AtualizarEntitySampleCommand>,
                                                       IHandler<DeletarEntitytSampleCommand>, IHandler<ReativarEntitySampleCommand>
    {
        private readonly IBus Bus;
        private readonly IEntitySampleRepository _entitySampleRepository;

        public EntitySampleCommand(IEntitySampleRepository entitySampleRepository, IUnitOfWork uow, IBus bus, IDomainNotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            Bus = bus;
            _entitySampleRepository = entitySampleRepository;
        }

        public void Handler(CriarEntitySampleCommand message)
        {
            if (!message.IsValid()) { NotifyValidationErrors(message); return; }


            EntitySample entity = new EntitySample(message.Descricao);

            //Validações Negocio

            _entitySampleRepository.Criar(entity);

            if (Commit())
            {
                // Envia evento
            }

        }

        public void Handler(AtualizarEntitySampleCommand message)
        {
            if (!message.IsValid()) { NotifyValidationErrors(message); return; }

            EntitySample entity = EntitySampleFactory.EntitySampleFull(message.Id, message.Descricao);

            // Validações Negocio

            _entitySampleRepository.Atualizar(entity);

            if (Commit())
            {
                // Envia evento
            }

        }

        public void Handler(DeletarEntitytSampleCommand message)
        {
            if (!message.IsValid()) { NotifyValidationErrors(message); return; }

            //Validações Negocio

            _entitySampleRepository.Deletar(message.Id);

            if (Commit())
            {
                // Envia Evento
            }
        }

        public void Handler(ReativarEntitySampleCommand message)
        {
            if (!message.IsValid()) { NotifyValidationErrors(message); return; }

            //Validações Negocio

            _entitySampleRepository.Reativar(message.Id);

            if (Commit())
            {
                // Envia Evento
            }
        }
    }
}
