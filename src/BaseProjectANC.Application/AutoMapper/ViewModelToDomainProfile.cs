using AutoMapper;
using BaseProjectANC.Application.ViewModels;
using BaseProjectANC.Domain.Models.EntitySample.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BaseProjectANC.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<EntitySampleViewModel, CriarEntitySampleCommand>()
                .ConstructUsing(e => new CriarEntitySampleCommand(e.Descricao));
            CreateMap<EntitySampleViewModel, AtualizarEntitySampleCommand>()
                .ConstructUsing(e => new AtualizarEntitySampleCommand(e.Id,e.Descricao));
        }
    }
}
