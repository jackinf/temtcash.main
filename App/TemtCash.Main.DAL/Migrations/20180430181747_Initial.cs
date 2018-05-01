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
                name: "Temt_Companies",
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
                    table.PrimaryKey("PK_Temt_Companies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temt_InfoChannelMessageProfiles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    InfoChannelMessageId = table.Column<int>(nullable: false),
                    Profile = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temt_InfoChannelMessageProfiles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temt_InfoChannelMessages",
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
                    table.PrimaryKey("PK_Temt_InfoChannelMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Temt_InfoChannelMessagesSeen",
                columns: table => new
                {
                    InfoChannelMessageId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temt_InfoChannelMessagesSeen", x => new { x.InfoChannelMessageId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "Temt_ProductUnits",
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
                    table.PrimaryKey("PK_Temt_ProductUnits", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_ProductUnits_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temt_Stores",
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
                    table.PrimaryKey("PK_Temt_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_Stores_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temt_Suppliers",
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
                    table.PrimaryKey("PK_Temt_Suppliers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_Suppliers_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temt_CompanyLicences",
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
                    table.PrimaryKey("PK_Temt_CompanyLicences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_CompanyLicences_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_CompanyLicences_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temt_Customers",
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
                    table.PrimaryKey("PK_Temt_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_Customers_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_Customers_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temt_DayPeriodItems",
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
                    table.PrimaryKey("PK_Temt_DayPeriodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_DayPeriodItems_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_DayPeriodItems_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Temt_ProductCategories",
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
                    table.PrimaryKey("PK_Temt_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_ProductCategories_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_ProductCategories_Temt_ProductCategories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Temt_ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temt_ProductCategories_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temt_Invoices",
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
                    table.PrimaryKey("PK_Temt_Invoices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_Invoices_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_Invoices_Temt_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Temt_Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temt_Invoices_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Temt_Products",
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
                    table.PrimaryKey("PK_Temt_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_Products_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_Products_Temt_ProductCategories_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "Temt_ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temt_Products_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temt_InvoicePaymentTypes",
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
                    table.PrimaryKey("PK_Temt_InvoicePaymentTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_InvoicePaymentTypes_Temt_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Temt_Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Temt_InvoiceRow",
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
                    table.PrimaryKey("PK_Temt_InvoiceRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_InvoiceRow_Temt_Invoices_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Temt_Invoices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_InvoiceRow_Temt_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Temt_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Temt_WarehouseItems",
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
                    table.PrimaryKey("PK_Temt_WarehouseItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Temt_WarehouseItems_Temt_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Temt_Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Temt_WarehouseItems_Temt_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Temt_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Temt_WarehouseItems_Temt_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Temt_Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Temt_CompanyLicences_CompanyId",
                table: "Temt_CompanyLicences",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_CompanyLicences_StoreId",
                table: "Temt_CompanyLicences",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Customers_CompanyId",
                table: "Temt_Customers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Customers_StoreId",
                table: "Temt_Customers",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_DayPeriodItems_CompanyId",
                table: "Temt_DayPeriodItems",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_DayPeriodItems_StoreId",
                table: "Temt_DayPeriodItems",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_InvoicePaymentTypes_InvoiceId",
                table: "Temt_InvoicePaymentTypes",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_InvoiceRow_InvoiceId",
                table: "Temt_InvoiceRow",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_InvoiceRow_ProductId",
                table: "Temt_InvoiceRow",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Invoices_CompanyId",
                table: "Temt_Invoices",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Invoices_CustomerId",
                table: "Temt_Invoices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Invoices_StoreId",
                table: "Temt_Invoices",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_ProductCategories_CompanyId",
                table: "Temt_ProductCategories",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_ProductCategories_ParentId",
                table: "Temt_ProductCategories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_ProductCategories_StoreId",
                table: "Temt_ProductCategories",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Products_CompanyId",
                table: "Temt_Products",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Products_ProductCategoryId",
                table: "Temt_Products",
                column: "ProductCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Products_StoreId",
                table: "Temt_Products",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_ProductUnits_CompanyId",
                table: "Temt_ProductUnits",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Stores_CompanyId",
                table: "Temt_Stores",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_Suppliers_CompanyId",
                table: "Temt_Suppliers",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_WarehouseItems_CompanyId",
                table: "Temt_WarehouseItems",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_WarehouseItems_ProductId",
                table: "Temt_WarehouseItems",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Temt_WarehouseItems_StoreId",
                table: "Temt_WarehouseItems",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Temt_CompanyLicences");

            migrationBuilder.DropTable(
                name: "Temt_DayPeriodItems");

            migrationBuilder.DropTable(
                name: "Temt_InfoChannelMessageProfiles");

            migrationBuilder.DropTable(
                name: "Temt_InfoChannelMessages");

            migrationBuilder.DropTable(
                name: "Temt_InfoChannelMessagesSeen");

            migrationBuilder.DropTable(
                name: "Temt_InvoicePaymentTypes");

            migrationBuilder.DropTable(
                name: "Temt_InvoiceRow");

            migrationBuilder.DropTable(
                name: "Temt_ProductUnits");

            migrationBuilder.DropTable(
                name: "Temt_Suppliers");

            migrationBuilder.DropTable(
                name: "Temt_WarehouseItems");

            migrationBuilder.DropTable(
                name: "Temt_Invoices");

            migrationBuilder.DropTable(
                name: "Temt_Products");

            migrationBuilder.DropTable(
                name: "Temt_Customers");

            migrationBuilder.DropTable(
                name: "Temt_ProductCategories");

            migrationBuilder.DropTable(
                name: "Temt_Stores");

            migrationBuilder.DropTable(
                name: "Temt_Companies");
        }
    }
}
