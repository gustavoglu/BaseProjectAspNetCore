using System;
using System.Collections.Generic;
using BaseProjectANC.Application.Interfaces;
using BaseProjectANC.Application.ViewModels;
using BaseProjectANC.Domain.Interfaces.RepositoryEntitys;
using AutoMapper;
using BaseProjectANC.Domain.Core.Bus;
using BaseProjectANC.Domain.Models.EntitySample.Commands;

namespace BaseProjectANC.Application.Services
{
    public class EntitySampleAppService : IEntitySampleAppService
    {
        private readonly IEntitySampleRepository _entitySampleRepository;
        private readonly IMapper _mapper;
        private readonly IBus _bus;

        public EntitySampleAppService(IEntitySampleRepository entitySampleRepository,IMapper mapper,IBus bus)
        {
            this._entitySampleRepository = entitySampleRepository;
            this._mapper = mapper;
            this._bus = bus;
        }

        public void Atualizar(EntitySampleViewModel entitySampleViewModel)
        {
            var atualizarCommand = _mapper.Map<AtualizarEntitySampleCommand>(entitySampleViewModel);
        }

        public void Criar(EntitySampleViewModel entitySampleViewModel)
        {
            var criarCommand = _mapper.Map<CriarEntitySampleCommand>(entitySampleViewModel);
            _bus.SendCommand(criarCommand);
        }

        public void Criar(List<EntitySampleViewModel> entitySampleViewModel)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            var deletarCommand = new DeletarEntitytSampleCommand(id);
            _bus.SendCommand(deletarCommand);
        }

        public void Reativar(Guid id)
        {
            var reativarCommand = new ReativarEntitySampleCommand(id);
            _bus.SendCommand(reativarCommand);
        }

        public EntitySampleViewModel TrazerAtivoPorId(Guid id)
        {
            return _mapper.Map<EntitySampleViewModel>(_entitySampleRepository.TrazerAtivoPorId(id));
        }

        public EntitySampleViewModel TrazerDeletadoPorId(Guid id)
        {
            return _mapper.Map<EntitySampleViewModel>(_entitySampleRepository.TrazerDeletadoPorId(id));
        }

        public EntitySampleViewModel TrazerPorId(Guid id)
        {
            return _mapper.Map<EntitySampleViewModel>(_entitySampleRepository.TrazerPorId(id));
        }

        public IEnumerable<EntitySampleViewModel> TrazerTodos()
        {
            return _mapper.Map<IEnumerable<EntitySampleViewModel>>(_entitySampleRepository.TrazerTodos());
        }

        public IEnumerable<EntitySampleViewModel> TrazerTodosAtivos()
        {
            return _mapper.Map<IEnumerable<EntitySampleViewModel>>(_entitySampleRepository.TrazerTodosAtivos());
        }

        public IEnumerable<EntitySampleViewModel> TrazerTodosDeletados()
        {
            return _mapper.Map<IEnumerable<EntitySampleViewModel>>(_entitySampleRepository.TrazerTodosDeletados());
        }
    }
}
