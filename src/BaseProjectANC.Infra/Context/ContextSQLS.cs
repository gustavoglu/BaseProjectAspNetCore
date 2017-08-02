using BaseProjectANC.Domain.Core.Models;
using BaseProjectANC.Infra.Data.Extensions;
using BaseProjectANC.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BaseProjectANC.Infra.Data.Context
{
    public class ContextSQLS : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var propertys = modelBuilder.Model.GetEntityTypes().SelectMany(t => t.GetProperties());
            var propertysString = propertys.Where(p => p.ClrType == typeof(string));

            foreach (var propertyString in propertysString)
            {
                propertyString.SetMaxLength(200);
            }
            // Maps
            modelBuilder.AddConfiguration(new EntitySampleMap());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }



        public override int SaveChanges()
        {
            var adicionados = ChangeTracker.Entries().Where(a => a.Entity is Entity && a.State == EntityState.Added);
            var atualizados = ChangeTracker.Entries().Where(a => a.Entity is Entity && a.State == EntityState.Modified);
            var deletados = ChangeTracker.Entries().Where(a => a.Entity is Entity && a.State == EntityState.Deleted);

            if (adicionados.Any()) AdicionaEntitys(adicionados);
            if (atualizados.Any()) AtualizaEntitys(atualizados);
            if (deletados.Any()) DeletaEntitys(deletados);

            return base.SaveChanges();
        }


        private void AdicionaEntitys(IEnumerable<EntityEntry> entidadesAdicionadas)
        {
            foreach (var entity in entidadesAdicionadas)
            {
                ((Entity)entity.Entity).CriadoEm = DateTime.Now;
            }
        }

        private void AtualizaEntitys(IEnumerable<EntityEntry> entidadesAtualizadas)
        {
            foreach (var entity in entidadesAtualizadas)
            {
                ((Entity)entity.Entity).AtualizadoEm = DateTime.Now;
            }
        }

        private void DeletaEntitys(IEnumerable<EntityEntry> entidadesDeletadas)
        {
            foreach (var entity in entidadesDeletadas)
            {
                ((Entity)entity.Entity).DeletadoEm = DateTime.Now;
            }
        }
    }
}
