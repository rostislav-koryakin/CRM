using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CRM.Infrastructure.Data.Migrations
{
    public partial class _002 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Contacts_ContactId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Salesmen_SalesmanId",
                table: "Activities");

            migrationBuilder.AddColumn<DateTime>(
                name: "Closing Date",
                table: "Deals",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "DealProducts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Contacts",
                type: "varchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Contacts",
                type: "varchar(127)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Source",
                table: "Contacts",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Companies",
                type: "varchar(127)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Industry",
                table: "Companies",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NoOfEmployees",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Score",
                table: "Companies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Website",
                table: "Companies",
                type: "varchar(127)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContactId", "SalesmanId" },
                values: new object[] { 4, 4 });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ContactId", "Created Date", "Description", "EndDate", "Name", "SalesmanId", "StartDate", "Type", "Updated Date" },
                values: new object[,]
                {
                    { 7, 1, new DateTime(2021, 1, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 1, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation call", 1, new DateTime(2021, 1, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 8, 1, new DateTime(2021, 2, 25, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Proposal call", 1, new DateTime(2021, 2, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 9, 1, new DateTime(2021, 2, 26, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 26, 15, 30, 0, 0, DateTimeKind.Unspecified), "Contact", 1, new DateTime(2021, 2, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null },
                    { 10, 2, new DateTime(2021, 2, 26, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2021, 2, 26, 15, 30, 0, 0, DateTimeKind.Unspecified), "Contact", 2, new DateTime(2021, 2, 26, 13, 30, 0, 0, DateTimeKind.Unspecified), "Call", null }
                });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Country", "Industry", "Website" },
                values: new object[] { "USA", "IT", "www.stones.c" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Country", "Industry", "Website" },
                values: new object[] { "USA", "IT", "www.newman-corp.c" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Country", "Industry", "Website" },
                values: new object[] { "USA", "IT", "www.tech-mech.c" });

            migrationBuilder.UpdateData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Country", "Industry", "Website" },
                values: new object[] { "USA", "Finance", "www.mills-and-jones.c" });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Country", "Created Date", "Industry", "Name", "NoOfEmployees", "Street", "TaxpayerNumber", "Updated Date", "Website", "ZipCode" },
                values: new object[,]
                {
                    { 5, "Denver", "USA", new DateTime(2021, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), "Construction", "GTIcm Corp.", 0, "1", "9000003", null, "www.gitcm.c", "93100" },
                    { 6, "Berlin", "Germany", new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "Health", "PREC Clinic Inc.", 0, "Strauss 12", "9100003", null, "www.prec-clinic.c", "01233" },
                    { 7, "Berlin", "Germany", new DateTime(2021, 1, 3, 8, 30, 0, 0, DateTimeKind.Unspecified), "Health", "Dent Beauty GmbH", 0, "Strauss 14", "9200003", null, "www.dent-beauty-gmbh.c", "01233" }
                });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Position" },
                values: new object[] { "emma.stone@stones.c", "CEO" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Position" },
                values: new object[] { "john@newman.c", "CTO" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "Position", "Source" },
                values: new object[] { "adam@newman.c", "Sales Rep", "Website" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Email", "Position", "Source" },
                values: new object[] { "michel@tech-mech.c", "Sales Rep", "Marketing" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Email", "Position", "Source" },
                values: new object[] { "abel@mills-johnes.c", "Sales Rep", "Marketing" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Description", "Email", "Position", "Source" },
                values: new object[] { "Desc . . .", "kate@mills-johnes.c", "Sales Rep", "Events" });

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Quantity",
                value: 1);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Quantity",
                value: 2);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 7,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "DealProducts",
                keyColumn: "Id",
                keyValue: 8,
                column: "Quantity",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stage",
                value: "Analisis");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 3,
                column: "Stage",
                value: "Offer");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 4,
                column: "Stage",
                value: "Negotiation");

            migrationBuilder.InsertData(
                table: "Deals",
                columns: new[] { "Id", "Closing Date", "CompanyId", "ContactId", "Created Date", "Description", "Name", "SalesmanId", "Stage", "TotalAmount", "Updated Date" },
                values: new object[,]
                {
                    { 5, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project2", 3, "Negotiation", 1000000.0m, null },
                    { 8, new DateTime(2021, 1, 1, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project5", 1, "Closed", 1000000.0m, null },
                    { 6, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project3", 1, "Won", 1000000.0m, null },
                    { 7, null, 2, 2, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description", "Newman Project4", 1, "Invoiced", 1000000.0m, null }
                });

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "lee.johnes@sales.c");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "amanda.rodrigez@sales.c");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "emanuela.kozminsky@sales.c");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "ivo.willson@sales.c");

            migrationBuilder.InsertData(
                table: "Salesmen",
                columns: new[] { "Id", "Created Date", "Email", "FirstName", "LastName", "Phone", "Updated Date" },
                values: new object[,]
                {
                    { 6, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "anna.petersen@sales.c", "Anna", "Petersen", "300100300", null },
                    { 5, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), "daniel.portman@sales.c", "Daniel", "Portman", "300200300", null }
                });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "ContactId", "Created Date", "Description", "EndDate", "Name", "SalesmanId", "StartDate", "Type", "Updated Date" },
                values: new object[,]
                {
                    { 5, 5, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 5, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null },
                    { 6, 6, new DateTime(2020, 9, 16, 8, 30, 0, 0, DateTimeKind.Unspecified), "Description . . .", new DateTime(2020, 10, 25, 15, 30, 0, 0, DateTimeKind.Unspecified), "Negotiation meeting", 6, new DateTime(2020, 10, 25, 13, 30, 0, 0, DateTimeKind.Unspecified), "Meeting", null }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "CompanyId", "Created Date", "Description", "Email", "FirstName", "LastName", "Phone", "Position", "Source", "Updated Date" },
                values: new object[,]
                {
                    { 7, 5, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "jane@gitcm.c", "Jane", "Coyre", "76432347", "Sales Rep", "Marketing", null },
                    { 8, 6, new DateTime(2021, 1, 2, 8, 30, 0, 0, DateTimeKind.Unspecified), null, "georgina@prec-clinic.c", "Georgina", "Murray", "76432348", "Sales Rep", "Marketing", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Contacts_ContactId",
                table: "Activities",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Salesmen_SalesmanId",
                table: "Activities",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Contacts_ContactId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Salesmen_SalesmanId",
                table: "Activities");

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "Closing Date",
                table: "Deals");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "DealProducts");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Position",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Source",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Industry",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "NoOfEmployees",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Score",
                table: "Companies");

            migrationBuilder.DropColumn(
                name: "Website",
                table: "Companies");

            migrationBuilder.UpdateData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ContactId", "SalesmanId" },
                values: new object[] { 2, 3 });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "emma.stone@stones.com");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "john@newman.com");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "adam@newman.com");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "michel@tech-mech.com");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 5,
                column: "Email",
                value: "abel@mills-johnes.com");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 6,
                column: "Email",
                value: "kate@mills-johnes.com");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 2,
                column: "Stage",
                value: "Ongoing");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 3,
                column: "Stage",
                value: "New");

            migrationBuilder.UpdateData(
                table: "Deals",
                keyColumn: "Id",
                keyValue: 4,
                column: "Stage",
                value: "New");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 1,
                column: "Email",
                value: "lee.johnes@sales.com");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "amanda.rodrigez@sales.com");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 3,
                column: "Email",
                value: "emanuela.kozminsky@sales.com");

            migrationBuilder.UpdateData(
                table: "Salesmen",
                keyColumn: "Id",
                keyValue: 4,
                column: "Email",
                value: "ivo.willson@sales.com");

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Contacts_ContactId",
                table: "Activities",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Salesmen_SalesmanId",
                table: "Activities",
                column: "SalesmanId",
                principalTable: "Salesmen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
