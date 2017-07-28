using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BaseProjectANC.Infra.Data.Context;

namespace BaseProjectANC.Infra.Data.Migrations
{
    [DbContext(typeof(ContextSQLS))]
    partial class ContextSQLSModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseProjectANC.Domain.Models.EntitySample.EntitySample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<bool?>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor")
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasColumnType("varchar(150)")
                        .HasMaxLength(150);

                    b.HasKey("Id");

                    b.ToTable("entitysample");
                });
        }
    }
}
