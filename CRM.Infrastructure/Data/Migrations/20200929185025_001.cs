using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Infrastructure.Data.Migrations
{
    public partial class _001 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "Companies",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        TaxpayerNumber = table.Column<string>(type: "varchar(15)", nullable: false),
            //        Name = table.Column<string>(type: "varchar(127)", nullable: false),
            //        City = table.Column<string>(type: "varchar(127)", nullable: true),
            //        Street = table.Column<string>(type: "varchar(127)", nullable: true),
            //        ZipCode = table.Column<string>(type: "varchar(15)", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Companies", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Products",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        Name = table.Column<string>(type: "varchar(127)", nullable: false),
            //        Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Products", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Salesmen",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        FirstName = table.Column<string>(type: "varchar(127)", nullable: false),
            //        LastName = table.Column<string>(type: "varchar(127)", nullable: false),
            //        Phone = table.Column<string>(type: "varchar(15)", nullable: true),
            //        Email = table.Column<string>(type: "varchar(127)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Salesmen", x => x.Id);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Contacts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        FirstName = table.Column<string>(type: "varchar(127)", nullable: false),
            //        LastName = table.Column<string>(type: "varchar(127)", nullable: false),
            //        Phone = table.Column<string>(type: "varchar(15)", nullable: true),
            //        Email = table.Column<string>(type: "varchar(127)", nullable: false),
            //        CompanyId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Contacts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Contacts_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Activities",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        Name = table.Column<string>(type: "varchar(127)", nullable: false),
            //        Description = table.Column<string>(type: "varchar(255)", nullable: true),
            //        StartDate = table.Column<DateTime>(nullable: false),
            //        EndDate = table.Column<DateTime>(nullable: false),
            //        Type = table.Column<string>(nullable: false),
            //        ContactId = table.Column<int>(nullable: false),
            //        SalesmanId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Activities", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Activities_Contacts_ContactId",
            //            column: x => x.ContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Activities_Salesmen_SalesmanId",
            //            column: x => x.SalesmanId,
            //            principalTable: "Salesmen",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Deals",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        Name = table.Column<string>(type: "varchar(127)", nullable: false),
            //        TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
            //        Stage = table.Column<string>(nullable: false),
            //        Description = table.Column<string>(type: "varchar(255)", nullable: true),
            //        ContactId = table.Column<int>(nullable: false),
            //        CompanyId = table.Column<int>(nullable: false),
            //        SalesmanId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Deals", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_Deals_Companies_CompanyId",
            //            column: x => x.CompanyId,
            //            principalTable: "Companies",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Deals_Contacts_ContactId",
            //            column: x => x.ContactId,
            //            principalTable: "Contacts",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_Deals_Salesmen_SalesmanId",
            //            column: x => x.SalesmanId,
            //            principalTable: "Salesmen",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "DealProducts",
            //    columns: table => new
            //    {
            //        Id = table.Column<int>(nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: false),
            //        UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
            //        DealId = table.Column<int>(nullable: false),
            //        ProductId = table.Column<int>(nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_DealProducts", x => x.Id);
            //        table.ForeignKey(
            //            name: "FK_DealProducts_Deals_DealId",
            //            column: x => x.DealId,
            //            principalTable: "Deals",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_DealProducts_Products_ProductId",
            //            column: x => x.ProductId,
            //            principalTable: "Products",
            //            principalColumn: "Id",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            //migrationBuilder.InsertData(
            //    table: "Companies",
            //    columns: new[] { "Id", "City", "Created Date", "Name", "Street", "TaxpayerNumber", "Updated Date", "ZipCode" },
            //    values: new object[,]
            //    {
            //        { 1, "Portland", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "The Stones", "35", "9173848217", null, "3121" },
            //        { 2, "New York", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Newman Corp.", "5", "34539292923", null, "23232" },
            //        { 3, "Denver", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Tech-Mech Inc.", "12", "34534545345", null, "54211" },
            //        { 4, "New Heaven", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Mills & Johnes", "91", "9876983453", null, "30100" }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Products",
            //    columns: new[] { "Id", "Created Date", "Name", "Price", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Digital Marketing", 10000.0m, null },
            //        { 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Branding", 20000.0m, null },
            //        { 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Content Creation", 30000.0m, null },
            //        { 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Strategic Planning", 40000.0m, null },
            //        { 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Rebranding", 10000.0m, null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Salesmen",
            //    columns: new[] { "Id", "Created Date", "Email", "FirstName", "LastName", "Phone", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "lee.johnes@sales.com", "Lee", "Johnes", "500500500", null },
            //        { 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "amanda.rodrigez@sales.com", "Amanda", "Rodrigez", "100100100", null },
            //        { 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "emanuela.kozminsky@sales.com", "Emanuela", "Kozminsky", "200200200", null },
            //        { 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "ivo.willson@sales.com", "Ivo", "Willson", "300300300", null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Contacts",
            //    columns: new[] { "Id", "CompanyId", "Created Date", "Email", "FirstName", "LastName", "Phone", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "emma.stone@stones.com", "Emma", "Stone", "32131221311", null },
            //        { 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "john@newman.com", "John", "Newman", "123123123", null },
            //        { 3, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "adam@newman.com", "Adam", "Newman", "423123123", null },
            //        { 4, 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "michel@tech-mech.com", "Michel", "Mech", "34525234", null },
            //        { 5, 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "abel@mills-johnes.com", "Abel", "Mills", "76432342", null },
            //        { 6, 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "kate@mills-johnes.com", "Kate", "Johnes", "76432341", null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Activities",
            //    columns: new[] { "Id", "ContactId", "Created Date", "Description", "EndDate", "Name", "SalesmanId", "StartDate", "Type", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 16, 14, 30, 0, 0, DateTimeKind.Unspecified), "Onboarding meeting", 1, new DateTime(2020, 10, 16, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
            //        { 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation Call", 2, new DateTime(2020, 10, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
            //        { 4, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 3, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
            //        { 3, 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), "Onboarding call", 3, new DateTime(2020, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), "Call", null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "Deals",
            //    columns: new[] { "Id", "CompanyId", "ContactId", "Created Date", "Description", "Name", "SalesmanId", "Stage", "TotalAmount", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 2, 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "The Stones Project X", 2, "Ongoing", 929301.0m, null },
            //        { 3, 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "The Stones Project Y", 3, "New", 20039499.0m, null },
            //        { 1, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project", 1, "New", 1000000.0m, null },
            //        { 4, 4, 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Mills & Johnes Rebranding Project", 3, "New", 10000.0m, null }
            //    });

            //migrationBuilder.InsertData(
            //    table: "DealProducts",
            //    columns: new[] { "Id", "Created Date", "DealId", "ProductId", "Updated Date" },
            //    values: new object[,]
            //    {
            //        { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, null },
            //        { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 3, null },
            //        { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, 4, null },
            //        { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, null },
            //        { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 2, null },
            //        { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, null },
            //        { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, 4, null },
            //        { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, 5, null }
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Activities_ContactId",
            //    table: "Activities",
            //    column: "ContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Activities_SalesmanId",
            //    table: "Activities",
            //    column: "SalesmanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Companies_TaxpayerNumber",
            //    table: "Companies",
            //    column: "TaxpayerNumber",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contacts_CompanyId",
            //    table: "Contacts",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Contacts_FirstName_LastName",
            //    table: "Contacts",
            //    columns: new[] { "FirstName", "LastName" });

            //migrationBuilder.CreateIndex(
            //    name: "IX_DealProducts_DealId",
            //    table: "DealProducts",
            //    column: "DealId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_DealProducts_ProductId",
            //    table: "DealProducts",
            //    column: "ProductId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deals_CompanyId",
            //    table: "Deals",
            //    column: "CompanyId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deals_ContactId",
            //    table: "Deals",
            //    column: "ContactId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Deals_SalesmanId",
            //    table: "Deals",
            //    column: "SalesmanId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Products_Name",
            //    table: "Products",
            //    column: "Name",
            //    unique: true);

            //migrationBuilder.CreateIndex(
            //    name: "IX_Salesmen_FirstName_LastName",
            //    table: "Salesmen",
            //    columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "DealProducts");

            migrationBuilder.DropTable(
                name: "Deals");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Salesmen");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
