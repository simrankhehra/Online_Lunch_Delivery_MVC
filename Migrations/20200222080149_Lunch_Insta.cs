using Microsoft.EntityFrameworkCore.Migrations;

namespace Online_Lunch_Delivery_MVC.Migrations
{
    public partial class Lunch_Insta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryAgent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LunchPack",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LunchPack", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OnlineDelivery",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeliveryAgentId = table.Column<int>(nullable: false),
                    LunchPackId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false),
                    NumberOfPacks = table.Column<int>(nullable: false),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OnlineDelivery", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OnlineDelivery_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineDelivery_DeliveryAgent_DeliveryAgentId",
                        column: x => x.DeliveryAgentId,
                        principalTable: "DeliveryAgent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OnlineDelivery_LunchPack_LunchPackId",
                        column: x => x.LunchPackId,
                        principalTable: "LunchPack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OnlineDelivery_CustomerId",
                table: "OnlineDelivery",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineDelivery_DeliveryAgentId",
                table: "OnlineDelivery",
                column: "DeliveryAgentId");

            migrationBuilder.CreateIndex(
                name: "IX_OnlineDelivery_LunchPackId",
                table: "OnlineDelivery",
                column: "LunchPackId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OnlineDelivery");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "DeliveryAgent");

            migrationBuilder.DropTable(
                name: "LunchPack");
        }
    }
}
