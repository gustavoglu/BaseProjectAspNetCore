using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BaseProjectANC.Infra.Data.Context;

namespace BaseProjectANC.Infra.Data.Migrations
{
    [DbContext(typeof(ContextSQLS))]
    [Migration("20170727225728_inicial")]
    partial class inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BaseProjectANC.Domain.Models.EntitySample.EntitySample", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AtualizadoEm");

                    b.Property<string>("AtualizadoPor");

                    b.Property<DateTime?>("CriadoEm");

                    b.Property<string>("CriadoPor");

                    b.Property<bool?>("Deletado");

                    b.Property<DateTime?>("DeletadoEm");

                    b.Property<string>("DeletadoPor");

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
