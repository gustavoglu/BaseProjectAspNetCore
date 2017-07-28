using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BaseProjectANC.Infra.Data.Migrations
{
    public partial class inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "entitysample",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AtualizadoEm = table.Column<DateTime>(nullable: true),
                    AtualizadoPor = table.Column<string>(nullable: true),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    CriadoPor = table.Column<string>(nullable: true),
                    Deletado = table.Column<bool>(nullable: true),
                    DeletadoEm = table.Column<DateTime>(nullable: true),
                    DeletadoPor = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(type: "varchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_entitysample", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "entitysample");
        }
    }
}
