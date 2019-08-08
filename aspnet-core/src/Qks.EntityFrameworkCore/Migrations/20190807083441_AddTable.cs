using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Qks.Migrations
{
    public partial class AddTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "QksTables",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    DbName = table.Column<string>(maxLength: 50, nullable: true),
                    Namespace = table.Column<string>(maxLength: 200, nullable: true),
                    ServiceName = table.Column<string>(maxLength: 50, nullable: true),
                    DtoName = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorizeName = table.Column<string>(maxLength: 50, nullable: true),
                    GetAllInputName = table.Column<string>(maxLength: 50, nullable: true),
                    CreateInputName = table.Column<string>(maxLength: 50, nullable: true),
                    UpdateInputName = table.Column<string>(maxLength: 50, nullable: true),
                    CreatePermissionName = table.Column<string>(maxLength: 100, nullable: true),
                    GetAllPermissionName = table.Column<string>(maxLength: 100, nullable: true),
                    GetPermissionName = table.Column<string>(maxLength: 100, nullable: true),
                    UpdatePermissionName = table.Column<string>(maxLength: 100, nullable: true),
                    DeletePermissionName = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QksTables", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QksColumns",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreationTime = table.Column<DateTime>(nullable: false),
                    CreatorUserId = table.Column<long>(nullable: true),
                    LastModificationTime = table.Column<DateTime>(nullable: true),
                    LastModifierUserId = table.Column<long>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeleterUserId = table.Column<long>(nullable: true),
                    DeletionTime = table.Column<DateTime>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    FieldName = table.Column<string>(maxLength: 100, nullable: true),
                    Type = table.Column<string>(maxLength: 50, nullable: true),
                    MaxLength = table.Column<int>(nullable: false),
                    IsPrimaryKey = table.Column<bool>(nullable: false),
                    IsAllowNull = table.Column<bool>(nullable: false),
                    TableId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QksColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QksColumns_QksTables_TableId",
                        column: x => x.TableId,
                        principalTable: "QksTables",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QksColumns_TableId",
                table: "QksColumns",
                column: "TableId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QksColumns");

            migrationBuilder.DropTable(
                name: "QksTables");
        }
    }
}
