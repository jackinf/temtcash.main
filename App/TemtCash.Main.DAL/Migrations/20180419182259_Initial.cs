using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace TemtCash.Main.DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BusinessArea = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    ClientCode = table.Column<string>(nullable: true),
                    ContactEmail = table.Column<string>(nullable: true),
                    ContactPerson = table.Column<string>(nullable: true),
                    ContactPhone = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    HasStore = table.Column<bool>(nullable: false),
                    InvoiceEmail = table.Column<string>(nullable: true),
                    InvoiceFrequency = table.Column<string>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastInfoUpdateDate = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    PrimaryUserId = table.Column<int>(nullable: false),
                    RegNo = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    ZipCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoChannelMessageProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InfoChannelMessageId = table.Column<int>(nullable: false),
                    Profile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoChannelMessageProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoChannelMessages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Message = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Visible = table.Column<bool>(nullable: true),
                    VisibleForAll = table.Column<bool>(nullable: false),
                    VisibleUntil = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoChannelMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InfoChannelMessagesSeen",
                columns: table => new
                {
                    InfoChannelMessageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoChannelMessagesSeen", x => new { x.InfoChannelMessageId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "ProductUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    LangEn = table.Column<string>(nullable: true),
                    LangEt = table.Column<string>(nullable: false),
                    LangRu = table.Column<string>(nullable: true),
                    Position = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductUnits_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BankAccount = table.Column<string>(nullable: true),
                    BankIban = table.Column<string>(nullable: true),
                    BankSwift = table.Column<string>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CompanyRegNumber = table.Column<string>(nullable: true),
                    CompanyVatNumber = table.Column<string>(nullable: true),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeadlineDays = table.Column<int>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsPerson = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Skype = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    SupType = table.Column<string>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suppliers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompanyLicences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    IsActive = table.Column<bool>(nullable: false),
                    LastCheckedDate = table.Column<DateTime>(nullable: true),
                    LicenceKey = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    ValidToDate = table.Column<DateTime>(nullable: true),
                    ValidToHash = table.Column<string>(nullable: true),
                    Version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompanyLicences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompanyLicences_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompanyLicences_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    IsCompany = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    RegCode = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: true),
                    StoreId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Customers_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DayPeriodItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BeginDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DayBeginSum = table.Column<float>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    EndDate = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayPeriodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayPeriodItems_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DayPeriodItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    Vat = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductCategories_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductCategories_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BonusesUsed = table.Column<int>(nullable: true),
                    BrutoSum = table.Column<float>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CustomerId = table.Column<int>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    DueDate = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    GiftCardSum = table.Column<float>(nullable: true),
                    NetoSum = table.Column<float>(nullable: true),
                    Number = table.Column<string>(nullable: true),
                    SellerId = table.Column<int>(nullable: true),
                    SellerName = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    VatSum = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invoices_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Invoices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Invoices_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DissallowDiscount = table.Column<bool>(nullable: true),
                    EanCode = table.Column<string>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    ProductCategoryId = table.Column<int>(nullable: true),
                    ProductType = table.Column<string>(nullable: true),
                    Status = table.Column<string>(nullable: false),
                    StoreId = table.Column<int>(nullable: true),
                    Unit = table.Column<int>(nullable: true),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UseProductVat = table.Column<bool>(nullable: true),
                    Vat = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Products_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Products_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoicePaymentTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false),
                    Sum = table.Column<float>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoicePaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoicePaymentTypes_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceRow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    Discount = table.Column<int>(nullable: true),
                    DiscountSum = table.Column<float>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    InvoiceId = table.Column<int>(nullable: false),
                    NetoSum = table.Column<float>(nullable: true),
                    Price = table.Column<float>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    Status = table.Column<string>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UsedBonusSum = table.Column<float>(nullable: true),
                    Vat = table.Column<int>(nullable: false),
                    VatSum = table.Column<float>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceRow_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_InvoiceRow_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<float>(nullable: false),
                    CompanyId = table.Column<int>(nullable: false),
                    CreatedBy = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedOn = table.Column<DateTime>(nullable: true),
                    ExternalId = table.Column<int>(nullable: true),
                    ProductId = table.Column<int>(nullable: true),
                    PurchacePrice = table.Column<float>(nullable: false),
                    StoreId = table.Column<int>(nullable: false),
                    UpdatedBy = table.Column<int>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WarehouseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WarehouseItems_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicences_CompanyId",
                table: "CompanyLicences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_CompanyLicences_StoreId",
                table: "CompanyLicences",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CompanyId",
                table: "Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_StoreId",
                table: "Customers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_DayPeriodItems_CompanyId",
                table: "DayPeriodItems",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DayPeriodItems_StoreId",
                table: "DayPeriodItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoicePaymentTypes_InvoiceId",
                table: "InvoicePaymentTypes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceRow_InvoiceId",
                table: "InvoiceRow",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceRow_ProductId",
                table: "InvoiceRow",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CompanyId",
                table: "Invoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_CustomerId",
                table: "Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Invoices_StoreId",
                table: "Invoices",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_CompanyId",
                table: "ProductCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_ParentId",
                table: "ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductCategories_StoreId",
                table: "ProductCategories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_CompanyId",
                table: "Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductCategoryId",
                table: "Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_StoreId",
                table: "Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductUnits_CompanyId",
                table: "ProductUnits",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_CompanyId",
                table: "Stores",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Suppliers_CompanyId",
                table: "Suppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_CompanyId",
                table: "WarehouseItems",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_ProductId",
                table: "WarehouseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItems_StoreId",
                table: "WarehouseItems",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompanyLicences");

            migrationBuilder.DropTable(
                name: "DayPeriodItems");

            migrationBuilder.DropTable(
                name: "InfoChannelMessageProfiles");

            migrationBuilder.DropTable(
                name: "InfoChannelMessages");

            migrationBuilder.DropTable(
                name: "InfoChannelMessagesSeen");

            migrationBuilder.DropTable(
                name: "InvoicePaymentTypes");

            migrationBuilder.DropTable(
                name: "InvoiceRow");

            migrationBuilder.DropTable(
                name: "ProductUnits");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "WarehouseItems");

            migrationBuilder.DropTable(
                name: "Invoices");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "ProductCategories");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Companies");
        }
    }
}
