using Microsoft.EntityFrameworkCore.Migrations;

namespace car_service.Migrations
{
    public partial class addCheckServiceItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "CheckServiceItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CheckId = table.Column<int>(nullable: false),
                    ServiceId = table.Column<int>(nullable: false),
                    ExpendableMaterialId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckServiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckServiceItem_Check_CheckId",
                        column: x => x.CheckId,
                        principalTable: "Check",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckServiceItem_ExpendableMaterial_ExpendableMaterialId",
                        column: x => x.ExpendableMaterialId,
                        principalTable: "ExpendableMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CheckServiceItem_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });


            migrationBuilder.CreateIndex(
                name: "IX_CheckServiceItem_CheckId",
                table: "CheckServiceItem",
                column: "CheckId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckServiceItem_ExpendableMaterialId",
                table: "CheckServiceItem",
                column: "ExpendableMaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CheckServiceItem_ServiceId",
                table: "CheckServiceItem",
                column: "ServiceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckServiceItem");

            migrationBuilder.DropIndex(
                name: "IX_Service_CategoryId",
                table: "Service");

            migrationBuilder.CreateIndex(
                name: "IX_Service_CategoryId",
                table: "Service",
                column: "CategoryId");
        }
    }
}
