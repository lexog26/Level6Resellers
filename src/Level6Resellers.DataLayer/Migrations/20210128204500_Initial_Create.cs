using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Level6Resellers.DataLayer.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CustomerCompanies",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ResellerCompanies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResellerCompanies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    LastName = table.Column<string>(maxLength: 100, nullable: true),
                    Dni = table.Column<string>(maxLength: 30, nullable: false),
                    CustomerCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCustomers_CustomerCompanies_CustomerCompanyId",
                        column: x => x.CustomerCompanyId,
                        principalTable: "CustomerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ResellerCustomer",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    ResellerCompanyId = table.Column<int>(nullable: false),
                    CustomerCompanyId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResellerCustomer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResellerCustomer_CustomerCompanies_CustomerCompanyId",
                        column: x => x.CustomerCompanyId,
                        principalTable: "CustomerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResellerCustomer_ResellerCompanies_ResellerCompanyId",
                        column: x => x.ResellerCompanyId,
                        principalTable: "ResellerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductResellerCustomers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    ResellerCustomerId = table.Column<int>(nullable: false),
                    ResellerId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductResellerCustomers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductResellerCustomers_CustomerCompanies_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductResellerCustomers_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductResellerCustomers_ResellerCustomer_ResellerCustomerId",
                        column: x => x.ResellerCustomerId,
                        principalTable: "ResellerCustomer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductResellerCustomers_ResellerCompanies_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "ResellerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    LastTimeStamp = table.Column<DateTime>(nullable: false),
                    UserCustomerId = table.Column<int>(nullable: false),
                    ResellerId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<string>(nullable: true),
                    ProductResellerCustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Purchases_CustomerCompanies_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "CustomerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_ProductResellerCustomers_ProductResellerCustomerId",
                        column: x => x.ProductResellerCustomerId,
                        principalTable: "ProductResellerCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_ResellerCompanies_ResellerId",
                        column: x => x.ResellerId,
                        principalTable: "ResellerCompanies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Purchases_UserCustomers_UserCustomerId",
                        column: x => x.UserCustomerId,
                        principalTable: "UserCustomers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductResellerCustomers_CustomerId",
                table: "ProductResellerCustomers",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductResellerCustomers_ResellerCustomerId",
                table: "ProductResellerCustomers",
                column: "ResellerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductResellerCustomers_ResellerId",
                table: "ProductResellerCustomers",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductResellerCustomers_ProductId_ResellerCustomerId",
                table: "ProductResellerCustomers",
                columns: new[] { "ProductId", "ResellerCustomerId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_CustomerId",
                table: "Purchases",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductId",
                table: "Purchases",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ProductResellerCustomerId",
                table: "Purchases",
                column: "ProductResellerCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_ResellerId",
                table: "Purchases",
                column: "ResellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Purchases_UserCustomerId",
                table: "Purchases",
                column: "UserCustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_ResellerCustomer_CustomerCompanyId",
                table: "ResellerCustomer",
                column: "CustomerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ResellerCustomer_ResellerCompanyId",
                table: "ResellerCustomer",
                column: "ResellerCompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCustomers_CustomerCompanyId",
                table: "UserCustomers",
                column: "CustomerCompanyId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Purchases");

            migrationBuilder.DropTable(
                name: "ProductResellerCustomers");

            migrationBuilder.DropTable(
                name: "UserCustomers");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ResellerCustomer");

            migrationBuilder.DropTable(
                name: "CustomerCompanies");

            migrationBuilder.DropTable(
                name: "ResellerCompanies");
        }
    }
}
