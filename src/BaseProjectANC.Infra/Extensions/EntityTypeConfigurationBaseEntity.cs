using System;
using BaseProjectANC.Domain.Core.Models;
using BaseProjectANC.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectANC.Infra.Data.Extensions
{
    public abstract class EntityTypeConfigurationBaseEntity<T> : IEntityMap<T> where T : Entity
    {
        public abstract void Map(EntityTypeBuilder<T> builder);

        public void MappingPropertysBaseEntity(EntityTypeBuilder<T> builder)
        {
            builder.Property(e => e.CriadoPor).HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(e => e.DeletadoPor).HasColumnType("varchar(150)").HasMaxLength(150);
            builder.Property(e => e.AtualizadoPor).HasColumnType("varchar(150)").HasMaxLength(150);
        }

        protected EntityTypeConfigurationBaseEntity(ModelBuilder builder)
        {
            MappingPropertysBaseEntity(builder.Entity<T>());
        }
    }
}
