using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Web.Data.Migrations
{
    public partial class _003 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    TaxpayerNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    Name = table.Column<string>(type: "varchar(127)", nullable: false),
                    Website = table.Column<string>(type: "varchar(127)", nullable: true),
                    NoOfEmployees = table.Column<int>(nullable: false),
                    Industry = table.Column<string>(nullable: false),
                    Country = table.Column<string>(type: "varchar(127)", nullable: true),
                    City = table.Column<string>(type: "varchar(127)", nullable: true),
                    Street = table.Column<string>(type: "varchar(127)", nullable: true),
                    ZipCode = table.Column<string>(type: "varchar(15)", nullable: true),
                    Score = table.Column<int>(nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    Name = table.Column<string>(type: "varchar(127)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Salesmen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(127)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(127)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(127)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salesmen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ScoreRules",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    Criteria = table.Column<string>(nullable: false),
                    RelationSymbol = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: false),
                    Points = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScoreRules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    FirstName = table.Column<string>(type: "varchar(127)", nullable: false),
                    LastName = table.Column<string>(type: "varchar(127)", nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", nullable: true),
                    Email = table.Column<string>(type: "varchar(127)", nullable: false),
                    Position = table.Column<string>(type: "varchar(127)", nullable: true),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    Source = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Activities",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    Name = table.Column<string>(type: "varchar(127)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Activities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Activities_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Activities_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deals",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    Name = table.Column<string>(type: "varchar(127)", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Description = table.Column<string>(type: "varchar(255)", nullable: true),
                    ClosingDate = table.Column<DateTime>(name: "Closing Date", nullable: true),
                    Stage = table.Column<string>(nullable: false),
                    ContactId = table.Column<int>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    SalesmanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deals", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Deals_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Deals_Salesmen_SalesmanId",
                        column: x => x.SalesmanId,
                        principalTable: "Salesmen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DealProducts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(name: "Created Date", nullable: true),
                    UpdatedDate = table.Column<DateTime>(name: "Updated Date", nullable: true),
                    DealId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DealProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DealProducts_Deals_DealId",
                        column: x => x.DealId,
                        principalTable: "Deals",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DealProducts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Country", "Created Date", "Industry", "Name", "NoOfEmployees", "Street", "TaxpayerNumber", "Updated Date", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 1, "Portland", "USA", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "IT", "The Stones", 0, "35", "9173848217", null, "www.stones.c", "3121" },
                    { 2, "New York", "USA", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "IT", "Newman Corp.", 0, "5", "34539292923", null, "www.newman-corp.c", "23232" },
                    { 3, "Denver", "USA", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "IT", "Tech-Mech Inc.", 0, "12", "34534545345", null, "www.tech-mech.c", "54211" },
                    { 4, "New Heaven", "USA", new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Finance", "Mills & Johnes", 0, "91", "9876983453", null, "www.mills-and-jones.c", "30100" },
                    { 5, "Denver", "USA", new DateTime(2021, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "Construction", "GTIcm Corp.", 0, "1", "9000003", null, "www.gitcm.c", "93100" },
                    { 6, "Berlin", "Germany", new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "Health", "PREC Clinic Inc.", 0, "Strauss 12", "9100003", null, "www.prec-clinic.c", "01233" },
                    { 7, "Berlin", "Germany", new DateTime(2021, 1, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), "Health", "Dent Beauty GmbH", 0, "Strauss 14", "9200003", null, "www.dent-beauty-gmbh.c", "01233" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Created Date", "Name", "Price", "Updated Date" },
                values: new object[,]
                {
                    { 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Rebranding", 10000.0m, null },
                    { 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Content Creation", 30000.0m, null },
                    { 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Strategic Planning", 40000.0m, null },
                    { 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Digital Marketing", 10000.0m, null },
                    { 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Branding", 20000.0m, null }
                });

            migrationBuilder.InsertData(
                table: "Salesmen",
                columns: new[] { "Id", "Created Date", "Email", "FirstName", "LastName", "Phone", "Updated Date" },
                values: new object[,]
                {
                    { 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "lee.johnes@sales.c", "Lee", "Johnes", "500500500", null },
                    { 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "amanda.rodrigez@sales.c", "Amanda", "Rodrigez", "100100100", null },
                    { 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "emanuela.kozminsky@sales.c", "Emanuela", "Kozminsky", "200200200", null },
                    { 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "ivo.willson@sales.c", "Ivo", "Willson", "300300300", null },
                    { 5, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "daniel.portman@sales.c", "Daniel", "Portman", "300200300", null },
                    { 6, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "anna.petersen@sales.c", "Anna", "Petersen", "300100300", null }
                });

            migrationBuilder.InsertData(
                table: "ScoreRules",
                columns: new[] { "Id", "Created Date", "Criteria", "Points", "RelationSymbol", "Updated Date", "Value" },
                values: new object[,]
                {
                    { 2, null, "Size", 10, "IsGreater", null, "50" },
                    { 1, null, "Industry", 10, "Equals", null, "IT" },
                    { 3, null, "Country", 10, "Equals", null, "USA" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CompanyId", "Created Date", "Description", "Email", "FirstName", "LastName", "Phone", "Position", "Source", "Updated Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "emma.stone@stones.c", "Emma", "Stone", "32131221311", "CEO", "Blog", null },
                    { 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "john@newman.c", "John", "Newman", "123123123", "CTO", "Blog", null },
                    { 3, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "adam@newman.c", "Adam", "Newman", "423123123", "Sales Rep", "Website", null },
                    { 4, 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "michel@tech-mech.c", "Michel", "Mech", "34525234", "Sales Rep", "Marketing", null },
                    { 5, 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "abel@mills-johnes.c", "Abel", "Mills", "76432342", "Sales Rep", "Marketing", null },
                    { 6, 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Desc . . .", "kate@mills-johnes.c", "Kate", "Johnes", "76432341", "Sales Rep", "Events", null },
                    { 7, 5, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "jane@gitcm.c", "Jane", "Coyre", "76432347", "Sales Rep", "Marketing", null },
                    { 8, 6, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "georgina@prec-clinic.c", "Georgina", "Murray", "76432348", "Sales Rep", "Marketing", null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ContactId", "Created Date", "Description", "EndDate", "Name", "SalesmanId", "StartDate", "Type", "Updated Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 16, 14, 30, 0, 0, DateTimeKind.Unspecified), "Onboarding meeting", 1, new DateTime(2020, 10, 16, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
                    { 5, 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 5, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
                    { 4, 4, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 4, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
                    { 3, 3, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 24, 13, 0, 0, 0, DateTimeKind.Unspecified), "Onboarding call", 3, new DateTime(2020, 10, 24, 11, 0, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 10, 2, new DateTime(2021, 2, 26, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 26, 15, 30, 0, 0, DateTimeKind.Unspecified), "Contact", 2, new DateTime(2021, 2, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 23, 8, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation Call", 2, new DateTime(2020, 10, 23, 7, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 6, 6, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 6, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
                    { 9, 1, new DateTime(2021, 2, 26, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 26, 15, 30, 0, 0, DateTimeKind.Unspecified), "Contact", 1, new DateTime(2021, 2, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 8, 1, new DateTime(2021, 2, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Proposal call", 1, new DateTime(2021, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 7, 1, new DateTime(2021, 1, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 1, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation call", 1, new DateTime(2021, 1, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null }
                });

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "Closing Date", "CompanyId", "ContactId", "Created Date", "Description", "Name", "SalesmanId", "Stage", "TotalAmount", "Updated Date" },
                values: new object[,]
                {
                    { 2, null, 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "The Stones Project X", 2, "Analisis", 929301.0m, null },
                    { 4, null, 4, 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Mills & Johnes Rebranding Project", 3, "Negotiation", 10000.0m, null },
                    { 5, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project2", 3, "Negotiation", 1000000.0m, null },
                    { 6, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project3", 1, "Won", 1000000.0m, null },
                    { 7, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project4", 1, "Invoiced", 1000000.0m, null },
                    { 8, new DateTime(2021, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project5", 1, "Closed", 1000000.0m, null },
                    { 3, null, 1, 1, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "The Stones Project Y", 3, "Offer", 1000000.0m, null },
                    { 1, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project", 1, "New", 1000000.0m, null }
                });

            migrationBuilder.InsertData(
                table: "DealProducts",
                columns: new[] { "Id", "Created Date", "DealId", "ProductId", "Quantity", "Updated Date" },
                values: new object[,]
                {
                    { 5, null, 2, 2, 2, null },
                    { 6, null, 3, 3, 3, null },
                    { 7, null, 3, 4, 3, null },
                    { 1, null, 1, 1, 2, null },
                    { 2, null, 1, 2, 1, null },
                    { 3, null, 1, 3, 3, null },
                    { 4, null, 1, 4, 1, null },
                    { 8, null, 4, 5, 3, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ContactId",
                table: "Activities",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_SalesmanId",
                table: "Activities",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Companies_TaxpayerNumber",
                table: "Companies",
                column: "TaxpayerNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_CompanyId",
                table: "Contacts",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_FirstName_LastName",
                table: "Contacts",
                columns: new[] { "FirstName", "LastName" });

            migrationBuilder.CreateIndex(
                name: "IX_DealProducts_DealId",
                table: "DealProducts",
                column: "DealId");

            migrationBuilder.CreateIndex(
                name: "IX_DealProducts_ProductId",
                table: "DealProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_CompanyId",
                table: "Deals",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_ContactId",
                table: "Deals",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_Deals_SalesmanId",
                table: "Deals",
                column: "SalesmanId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Salesmen_FirstName_LastName",
                table: "Salesmen",
                columns: new[] { "FirstName", "LastName" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Activities");

            migrationBuilder.DropTable(
                name: "DealProducts");

            migrationBuilder.DropTable(
                name: "ScoreRules");

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
