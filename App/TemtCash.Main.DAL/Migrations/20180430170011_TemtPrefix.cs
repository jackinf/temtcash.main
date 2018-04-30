using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TemtCash.Main.DAL.Migrations
{
    public partial class TemtPrefix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicences_Companies_CompanyId",
                table: "CompanyLicences");

            migrationBuilder.DropForeignKey(
                name: "FK_CompanyLicences_Stores_StoreId",
                table: "CompanyLicences");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Stores_StoreId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_DayPeriodItems_Companies_CompanyId",
                table: "DayPeriodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_DayPeriodItems_Stores_StoreId",
                table: "DayPeriodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoicePaymentTypes_Invoices_InvoiceId",
                table: "InvoicePaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRow_Invoices_InvoiceId",
                table: "InvoiceRow");

            migrationBuilder.DropForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Companies_CompanyId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategories_Stores_StoreId",
                table: "ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductUnits_Companies_CompanyId",
                table: "ProductUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Companies_CompanyId",
                table: "Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Suppliers_Companies_CompanyId",
                table: "Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItems_Companies_CompanyId",
                table: "WarehouseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItems_Products_ProductId",
                table: "WarehouseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_WarehouseItems_Stores_StoreId",
                table: "WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Stores",
                table: "Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductUnits",
                table: "ProductUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InvoicePaymentTypes",
                table: "InvoicePaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoChannelMessagesSeen",
                table: "InfoChannelMessagesSeen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoChannelMessages",
                table: "InfoChannelMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InfoChannelMessageProfiles",
                table: "InfoChannelMessageProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DayPeriodItems",
                table: "DayPeriodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Customers",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CompanyLicences",
                table: "CompanyLicences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Companies",
                table: "Companies");

            migrationBuilder.RenameTable(
                name: "WarehouseItems",
                newName: "Temt_WarehouseItems");

            migrationBuilder.RenameTable(
                name: "Suppliers",
                newName: "Temt_Suppliers");

            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "Temt_Stores");

            migrationBuilder.RenameTable(
                name: "ProductUnits",
                newName: "Temt_ProductUnits");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Temt_Products");

            migrationBuilder.RenameTable(
                name: "ProductCategories",
                newName: "Temt_ProductCategories");

            migrationBuilder.RenameTable(
                name: "Invoices",
                newName: "Temt_Invoices");

            migrationBuilder.RenameTable(
                name: "InvoiceRow",
                newName: "Temt_InvoiceRow");

            migrationBuilder.RenameTable(
                name: "InvoicePaymentTypes",
                newName: "Temt_InvoicePaymentTypes");

            migrationBuilder.RenameTable(
                name: "InfoChannelMessagesSeen",
                newName: "Temt_InfoChannelMessagesSeen");

            migrationBuilder.RenameTable(
                name: "InfoChannelMessages",
                newName: "Temt_InfoChannelMessages");

            migrationBuilder.RenameTable(
                name: "InfoChannelMessageProfiles",
                newName: "Temt_InfoChannelMessageProfiles");

            migrationBuilder.RenameTable(
                name: "DayPeriodItems",
                newName: "Temt_DayPeriodItems");

            migrationBuilder.RenameTable(
                name: "Customers",
                newName: "Temt_Customers");

            migrationBuilder.RenameTable(
                name: "CompanyLicences",
                newName: "Temt_CompanyLicences");

            migrationBuilder.RenameTable(
                name: "Companies",
                newName: "Temt_Companies");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItems_StoreId",
                table: "Temt_WarehouseItems",
                newName: "IX_Temt_WarehouseItems_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItems_ProductId",
                table: "Temt_WarehouseItems",
                newName: "IX_Temt_WarehouseItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_WarehouseItems_CompanyId",
                table: "Temt_WarehouseItems",
                newName: "IX_Temt_WarehouseItems_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Suppliers_CompanyId",
                table: "Temt_Suppliers",
                newName: "IX_Temt_Suppliers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Stores_CompanyId",
                table: "Temt_Stores",
                newName: "IX_Temt_Stores_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductUnits_CompanyId",
                table: "Temt_ProductUnits",
                newName: "IX_Temt_ProductUnits_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_StoreId",
                table: "Temt_Products",
                newName: "IX_Temt_Products_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Temt_Products",
                newName: "IX_Temt_Products_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CompanyId",
                table: "Temt_Products",
                newName: "IX_Temt_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_StoreId",
                table: "Temt_ProductCategories",
                newName: "IX_Temt_ProductCategories_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_ParentId",
                table: "Temt_ProductCategories",
                newName: "IX_Temt_ProductCategories_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategories_CompanyId",
                table: "Temt_ProductCategories",
                newName: "IX_Temt_ProductCategories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_StoreId",
                table: "Temt_Invoices",
                newName: "IX_Temt_Invoices_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CustomerId",
                table: "Temt_Invoices",
                newName: "IX_Temt_Invoices_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Invoices_CompanyId",
                table: "Temt_Invoices",
                newName: "IX_Temt_Invoices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRow_ProductId",
                table: "Temt_InvoiceRow",
                newName: "IX_Temt_InvoiceRow_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoiceRow_InvoiceId",
                table: "Temt_InvoiceRow",
                newName: "IX_Temt_InvoiceRow_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_InvoicePaymentTypes_InvoiceId",
                table: "Temt_InvoicePaymentTypes",
                newName: "IX_Temt_InvoicePaymentTypes_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_DayPeriodItems_StoreId",
                table: "Temt_DayPeriodItems",
                newName: "IX_Temt_DayPeriodItems_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_DayPeriodItems_CompanyId",
                table: "Temt_DayPeriodItems",
                newName: "IX_Temt_DayPeriodItems_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_StoreId",
                table: "Temt_Customers",
                newName: "IX_Temt_Customers_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_CompanyId",
                table: "Temt_Customers",
                newName: "IX_Temt_Customers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLicences_StoreId",
                table: "Temt_CompanyLicences",
                newName: "IX_Temt_CompanyLicences_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_CompanyLicences_CompanyId",
                table: "Temt_CompanyLicences",
                newName: "IX_Temt_CompanyLicences_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_WarehouseItems",
                table: "Temt_WarehouseItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Suppliers",
                table: "Temt_Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Stores",
                table: "Temt_Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_ProductUnits",
                table: "Temt_ProductUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Products",
                table: "Temt_Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_ProductCategories",
                table: "Temt_ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Invoices",
                table: "Temt_Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_InvoiceRow",
                table: "Temt_InvoiceRow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_InvoicePaymentTypes",
                table: "Temt_InvoicePaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_InfoChannelMessagesSeen",
                table: "Temt_InfoChannelMessagesSeen",
                columns: new[] { "InfoChannelMessageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_InfoChannelMessages",
                table: "Temt_InfoChannelMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_InfoChannelMessageProfiles",
                table: "Temt_InfoChannelMessageProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_DayPeriodItems",
                table: "Temt_DayPeriodItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Customers",
                table: "Temt_Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_CompanyLicences",
                table: "Temt_CompanyLicences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Temt_Companies",
                table: "Temt_Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_CompanyLicences_Temt_Companies_CompanyId",
                table: "Temt_CompanyLicences",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_CompanyLicences_Temt_Stores_StoreId",
                table: "Temt_CompanyLicences",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Customers_Temt_Companies_CompanyId",
                table: "Temt_Customers",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Customers_Temt_Stores_StoreId",
                table: "Temt_Customers",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_DayPeriodItems_Temt_Companies_CompanyId",
                table: "Temt_DayPeriodItems",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_DayPeriodItems_Temt_Stores_StoreId",
                table: "Temt_DayPeriodItems",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_InvoicePaymentTypes_Temt_Invoices_InvoiceId",
                table: "Temt_InvoicePaymentTypes",
                column: "InvoiceId",
                principalTable: "Temt_Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_InvoiceRow_Temt_Invoices_InvoiceId",
                table: "Temt_InvoiceRow",
                column: "InvoiceId",
                principalTable: "Temt_Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_InvoiceRow_Temt_Products_ProductId",
                table: "Temt_InvoiceRow",
                column: "ProductId",
                principalTable: "Temt_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Invoices_Temt_Companies_CompanyId",
                table: "Temt_Invoices",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Invoices_Temt_Customers_CustomerId",
                table: "Temt_Invoices",
                column: "CustomerId",
                principalTable: "Temt_Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Invoices_Temt_Stores_StoreId",
                table: "Temt_Invoices",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_ProductCategories_Temt_Companies_CompanyId",
                table: "Temt_ProductCategories",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_ProductCategories_Temt_ProductCategories_ParentId",
                table: "Temt_ProductCategories",
                column: "ParentId",
                principalTable: "Temt_ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_ProductCategories_Temt_Stores_StoreId",
                table: "Temt_ProductCategories",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Products_Temt_Companies_CompanyId",
                table: "Temt_Products",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Products_Temt_ProductCategories_ProductCategoryId",
                table: "Temt_Products",
                column: "ProductCategoryId",
                principalTable: "Temt_ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Products_Temt_Stores_StoreId",
                table: "Temt_Products",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_ProductUnits_Temt_Companies_CompanyId",
                table: "Temt_ProductUnits",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Stores_Temt_Companies_CompanyId",
                table: "Temt_Stores",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_Suppliers_Temt_Companies_CompanyId",
                table: "Temt_Suppliers",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Companies_CompanyId",
                table: "Temt_WarehouseItems",
                column: "CompanyId",
                principalTable: "Temt_Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Products_ProductId",
                table: "Temt_WarehouseItems",
                column: "ProductId",
                principalTable: "Temt_Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Stores_StoreId",
                table: "Temt_WarehouseItems",
                column: "StoreId",
                principalTable: "Temt_Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Temt_CompanyLicences_Temt_Companies_CompanyId",
                table: "Temt_CompanyLicences");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_CompanyLicences_Temt_Stores_StoreId",
                table: "Temt_CompanyLicences");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Customers_Temt_Companies_CompanyId",
                table: "Temt_Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Customers_Temt_Stores_StoreId",
                table: "Temt_Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_DayPeriodItems_Temt_Companies_CompanyId",
                table: "Temt_DayPeriodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_DayPeriodItems_Temt_Stores_StoreId",
                table: "Temt_DayPeriodItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_InvoicePaymentTypes_Temt_Invoices_InvoiceId",
                table: "Temt_InvoicePaymentTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_InvoiceRow_Temt_Invoices_InvoiceId",
                table: "Temt_InvoiceRow");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_InvoiceRow_Temt_Products_ProductId",
                table: "Temt_InvoiceRow");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Invoices_Temt_Companies_CompanyId",
                table: "Temt_Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Invoices_Temt_Customers_CustomerId",
                table: "Temt_Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Invoices_Temt_Stores_StoreId",
                table: "Temt_Invoices");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_ProductCategories_Temt_Companies_CompanyId",
                table: "Temt_ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_ProductCategories_Temt_ProductCategories_ParentId",
                table: "Temt_ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_ProductCategories_Temt_Stores_StoreId",
                table: "Temt_ProductCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Products_Temt_Companies_CompanyId",
                table: "Temt_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Products_Temt_ProductCategories_ProductCategoryId",
                table: "Temt_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Products_Temt_Stores_StoreId",
                table: "Temt_Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_ProductUnits_Temt_Companies_CompanyId",
                table: "Temt_ProductUnits");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Stores_Temt_Companies_CompanyId",
                table: "Temt_Stores");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_Suppliers_Temt_Companies_CompanyId",
                table: "Temt_Suppliers");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Companies_CompanyId",
                table: "Temt_WarehouseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Products_ProductId",
                table: "Temt_WarehouseItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Temt_WarehouseItems_Temt_Stores_StoreId",
                table: "Temt_WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_WarehouseItems",
                table: "Temt_WarehouseItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Suppliers",
                table: "Temt_Suppliers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Stores",
                table: "Temt_Stores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_ProductUnits",
                table: "Temt_ProductUnits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Products",
                table: "Temt_Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_ProductCategories",
                table: "Temt_ProductCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Invoices",
                table: "Temt_Invoices");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_InvoiceRow",
                table: "Temt_InvoiceRow");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_InvoicePaymentTypes",
                table: "Temt_InvoicePaymentTypes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_InfoChannelMessagesSeen",
                table: "Temt_InfoChannelMessagesSeen");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_InfoChannelMessages",
                table: "Temt_InfoChannelMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_InfoChannelMessageProfiles",
                table: "Temt_InfoChannelMessageProfiles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_DayPeriodItems",
                table: "Temt_DayPeriodItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Customers",
                table: "Temt_Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_CompanyLicences",
                table: "Temt_CompanyLicences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Temt_Companies",
                table: "Temt_Companies");

            migrationBuilder.RenameTable(
                name: "Temt_WarehouseItems",
                newName: "WarehouseItems");

            migrationBuilder.RenameTable(
                name: "Temt_Suppliers",
                newName: "Suppliers");

            migrationBuilder.RenameTable(
                name: "Temt_Stores",
                newName: "Stores");

            migrationBuilder.RenameTable(
                name: "Temt_ProductUnits",
                newName: "ProductUnits");

            migrationBuilder.RenameTable(
                name: "Temt_Products",
                newName: "Products");

            migrationBuilder.RenameTable(
                name: "Temt_ProductCategories",
                newName: "ProductCategories");

            migrationBuilder.RenameTable(
                name: "Temt_Invoices",
                newName: "Invoices");

            migrationBuilder.RenameTable(
                name: "Temt_InvoiceRow",
                newName: "InvoiceRow");

            migrationBuilder.RenameTable(
                name: "Temt_InvoicePaymentTypes",
                newName: "InvoicePaymentTypes");

            migrationBuilder.RenameTable(
                name: "Temt_InfoChannelMessagesSeen",
                newName: "InfoChannelMessagesSeen");

            migrationBuilder.RenameTable(
                name: "Temt_InfoChannelMessages",
                newName: "InfoChannelMessages");

            migrationBuilder.RenameTable(
                name: "Temt_InfoChannelMessageProfiles",
                newName: "InfoChannelMessageProfiles");

            migrationBuilder.RenameTable(
                name: "Temt_DayPeriodItems",
                newName: "DayPeriodItems");

            migrationBuilder.RenameTable(
                name: "Temt_Customers",
                newName: "Customers");

            migrationBuilder.RenameTable(
                name: "Temt_CompanyLicences",
                newName: "CompanyLicences");

            migrationBuilder.RenameTable(
                name: "Temt_Companies",
                newName: "Companies");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_WarehouseItems_StoreId",
                table: "WarehouseItems",
                newName: "IX_WarehouseItems_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_WarehouseItems_ProductId",
                table: "WarehouseItems",
                newName: "IX_WarehouseItems_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_WarehouseItems_CompanyId",
                table: "WarehouseItems",
                newName: "IX_WarehouseItems_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Suppliers_CompanyId",
                table: "Suppliers",
                newName: "IX_Suppliers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Stores_CompanyId",
                table: "Stores",
                newName: "IX_Stores_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_ProductUnits_CompanyId",
                table: "ProductUnits",
                newName: "IX_ProductUnits_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Products_StoreId",
                table: "Products",
                newName: "IX_Products_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Products_ProductCategoryId",
                table: "Products",
                newName: "IX_Products_ProductCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Products_CompanyId",
                table: "Products",
                newName: "IX_Products_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_ProductCategories_StoreId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_ProductCategories_ParentId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_ParentId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_ProductCategories_CompanyId",
                table: "ProductCategories",
                newName: "IX_ProductCategories_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Invoices_StoreId",
                table: "Invoices",
                newName: "IX_Invoices_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Invoices_CustomerId",
                table: "Invoices",
                newName: "IX_Invoices_CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Invoices_CompanyId",
                table: "Invoices",
                newName: "IX_Invoices_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_InvoiceRow_ProductId",
                table: "InvoiceRow",
                newName: "IX_InvoiceRow_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_InvoiceRow_InvoiceId",
                table: "InvoiceRow",
                newName: "IX_InvoiceRow_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_InvoicePaymentTypes_InvoiceId",
                table: "InvoicePaymentTypes",
                newName: "IX_InvoicePaymentTypes_InvoiceId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_DayPeriodItems_StoreId",
                table: "DayPeriodItems",
                newName: "IX_DayPeriodItems_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_DayPeriodItems_CompanyId",
                table: "DayPeriodItems",
                newName: "IX_DayPeriodItems_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Customers_StoreId",
                table: "Customers",
                newName: "IX_Customers_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_Customers_CompanyId",
                table: "Customers",
                newName: "IX_Customers_CompanyId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_CompanyLicences_StoreId",
                table: "CompanyLicences",
                newName: "IX_CompanyLicences_StoreId");

            migrationBuilder.RenameIndex(
                name: "IX_Temt_CompanyLicences_CompanyId",
                table: "CompanyLicences",
                newName: "IX_CompanyLicences_CompanyId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WarehouseItems",
                table: "WarehouseItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Suppliers",
                table: "Suppliers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Stores",
                table: "Stores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductUnits",
                table: "ProductUnits",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategories",
                table: "ProductCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invoices",
                table: "Invoices",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoiceRow",
                table: "InvoiceRow",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InvoicePaymentTypes",
                table: "InvoicePaymentTypes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoChannelMessagesSeen",
                table: "InfoChannelMessagesSeen",
                columns: new[] { "InfoChannelMessageId", "UserId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoChannelMessages",
                table: "InfoChannelMessages",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InfoChannelMessageProfiles",
                table: "InfoChannelMessageProfiles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DayPeriodItems",
                table: "DayPeriodItems",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Customers",
                table: "Customers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CompanyLicences",
                table: "CompanyLicences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Companies",
                table: "Companies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicences_Companies_CompanyId",
                table: "CompanyLicences",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompanyLicences_Stores_StoreId",
                table: "CompanyLicences",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Companies_CompanyId",
                table: "Customers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Stores_StoreId",
                table: "Customers",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_DayPeriodItems_Companies_CompanyId",
                table: "DayPeriodItems",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DayPeriodItems_Stores_StoreId",
                table: "DayPeriodItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoicePaymentTypes_Invoices_InvoiceId",
                table: "InvoicePaymentTypes",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRow_Invoices_InvoiceId",
                table: "InvoiceRow",
                column: "InvoiceId",
                principalTable: "Invoices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InvoiceRow_Products_ProductId",
                table: "InvoiceRow",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Companies_CompanyId",
                table: "Invoices",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Customers_CustomerId",
                table: "Invoices",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Invoices_Stores_StoreId",
                table: "Invoices",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Companies_CompanyId",
                table: "ProductCategories",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategories_Stores_StoreId",
                table: "ProductCategories",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Companies_CompanyId",
                table: "Products",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductCategories_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId",
                principalTable: "ProductCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Stores_StoreId",
                table: "Products",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductUnits_Companies_CompanyId",
                table: "ProductUnits",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Companies_CompanyId",
                table: "Stores",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suppliers_Companies_CompanyId",
                table: "Suppliers",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Companies_CompanyId",
                table: "WarehouseItems",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Products_ProductId",
                table: "WarehouseItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_WarehouseItems_Stores_StoreId",
                table: "WarehouseItems",
                column: "StoreId",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
