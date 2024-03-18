using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DGII_Taxpayers.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PersonType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaxPayer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RncID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonTypeId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxPayer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxPayer_PersonType_PersonTypeId",
                        column: x => x.PersonTypeId,
                        principalTable: "PersonType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxReceipt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaxPayerId = table.Column<int>(type: "int", nullable: false),
                    NCF = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Amount = table.Column<double>(type: "float", nullable: false),
                    Itbis18 = table.Column<double>(type: "float", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxReceipt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxReceipt_TaxPayer_TaxPayerId",
                        column: x => x.TaxPayerId,
                        principalTable: "TaxPayer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonType_TypeName",
                table: "PersonType",
                column: "TypeName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayer_PersonTypeId",
                table: "TaxPayer",
                column: "PersonTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxPayer_RncID",
                table: "TaxPayer",
                column: "RncID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipt_NCF",
                table: "TaxReceipt",
                column: "NCF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TaxReceipt_TaxPayerId",
                table: "TaxReceipt",
                column: "TaxPayerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TaxReceipt");

            migrationBuilder.DropTable(
                name: "TaxPayer");

            migrationBuilder.DropTable(
                name: "PersonType");
        }
    }
}
