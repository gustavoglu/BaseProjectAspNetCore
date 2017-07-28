using BaseProjectANC.Domain.CommandsHandler;
using BaseProjectANC.Domain.Core.Events;
using BaseProjectANC.Domain.Core.UoW;
using BaseProjectANC.Domain.Core.Notifications;
using BaseProjectANC.Domain.Interfaces.RepositoryEntitys;
using BaseProjectANC.Domain.Models.EntitySample.Commands;
using BaseProjectANC.Infra.Data.Context;
using BaseProjectANC.Infra.Data.IoW;
using BaseProjectANC.Infra.Data.Repository.RepositoryEntity;
using Microsoft.Extensions.DependencyInjection;
using BaseProjectANC.Domain.Core.Bus;
using BaseProjectANC.Infra.Bus;
using BaseProjectANC.Domain.Models.EntitySample.Events;
using BaseProjectANC.Domain.EventsHandler;
using AutoMapper;
using BaseProjectANC.Infra.Identity.Services;
using BaseProjectANC.Domain.Interfaces;
using BaseProjectANC.Infra.Identity.Models;

namespace BaseProjectANC.Infra.IoC
{
    public class NativeSimpleInjector
    {

        public static void RegisterDependencys(IServiceCollection services)
        {

            //Application
            services.AddSingleton(Mapper.Configuration);
            services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

            //Domain
            services.AddScoped<IDomainNotificationHandler<DomainNotification>, DomainNotificationHandler>();

            //Dommain Commands
            services.AddScoped<IHandler<CriarEntitySampleCommand>, EntitySampleCommand>();
            services.AddScoped<IHandler<AtualizarEntitySampleCommand>, EntitySampleCommand>();
            services.AddScoped<IHandler<DeletarEntitytSampleCommand>, EntitySampleCommand>();
            services.AddScoped<IHandler<ReativarEntitySampleCommand>, EntitySampleCommand>();

            //Domain Events
            services.AddScoped<IHandler<CriarEntitySampleEvent>, EntitySampleEvent>();
            services.AddScoped<IHandler<AtualizarEntitySampleEvent>, EntitySampleEvent>();
            services.AddScoped<IHandler<DeletarEntitySampleEvent>, EntitySampleEvent>();
            services.AddScoped<IHandler<ReativarEntitySampleEvent>, EntitySampleEvent>();

            //Infra
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ContextSQLS>();
            services.AddScoped<IEntitySampleRepository, EntitySampleRepository>();

            //Infra Bus
            services.AddScoped<IBus, InMemoryBus>();

            //Identity Services
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            //Identity 
            services.AddScoped<IUser, AspNetUser>();

        }
    }
}
