using BaseProjectANC.Domain.Core.Models;
using BaseProjectANC.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BaseProjectANC.Infra.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void AddConfiguration<T>(this ModelBuilder modelbuilder,EntityTypeConfiguration<T> configuration) where T : class
        {
            configuration.Map(modelbuilder.Entity<T>());
        }

        public static void AddEntityConfiguration<T>(this ModelBuilder modelbuilder, EntityTypeConfigurationBaseEntity<T> configuration) where T : Entity
        {
            configuration.Map(modelbuilder.Entity<T>());
        }
    }
}
