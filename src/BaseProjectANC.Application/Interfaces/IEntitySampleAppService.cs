using BaseProjectANC.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace BaseProjectANC.Application.Interfaces
{
    public interface IEntitySampleAppService
    {
        void Criar(EntitySampleViewModel entitySampleViewModel);

        void Criar(List<EntitySampleViewModel> entitySampleViewModel);

        void Atualizar(EntitySampleViewModel entitySampleViewModel);

        void Deletar(Guid id);

        void Reativar(Guid id);

        IEnumerable<EntitySampleViewModel> TrazerTodos();

        IEnumerable<EntitySampleViewModel> TrazerTodosAtivos();

        IEnumerable<EntitySampleViewModel> TrazerTodosDeletados();

        EntitySampleViewModel TrazerPorId(Guid id);

        EntitySampleViewModel TrazerAtivoPorId(Guid id);

        EntitySampleViewModel TrazerDeletadoPorId(Guid id);

    }
}
