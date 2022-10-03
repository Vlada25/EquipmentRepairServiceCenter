﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EquipmentRepairServiceCenter.Database.Migrations
{
    public partial class InitDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: true),
                    WorkExperienceInYears = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RepairingModels",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specifications = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ParticularQualities = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhotoUrl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairingModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ServicedStores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServicedStores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SpareParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Functions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EquipmentType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpareParts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Faults",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepairingModelId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RepairingMethods = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faults", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Faults_RepairingModels_RepairingModelId",
                        column: x => x.RepairingModelId,
                        principalTable: "RepairingModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EquipmentSerialNumber = table.Column<int>(type: "int", nullable: false),
                    EquipmentReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ServicedStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Guarantee = table.Column<bool>(type: "bit", nullable: false),
                    GuaranteePeriodInMonth = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Faults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_People_ClientId",
                        column: x => x.ClientId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_People_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "People",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Orders_ServicedStores_ServicedStoreId",
                        column: x => x.ServicedStoreId,
                        principalTable: "ServicedStores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsedSpareParts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FaultId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SparePartId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsedSpareParts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsedSpareParts_Faults_FaultId",
                        column: x => x.FaultId,
                        principalTable: "Faults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsedSpareParts_SpareParts_SparePartId",
                        column: x => x.SparePartId,
                        principalTable: "SpareParts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7ed9e6ee-9b68-48d9-8a23-ca759c443820", "a1cdf64d-fa8b-4201-b8ee-28390adcd5d5", "Employee", "EMPLOYEE" },
                    { "afdf3f49-b3fd-4dec-aa7f-2a5a6507828c", "5b837cdf-0b03-439f-af59-616cbb1b4fc4", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RepairingModels",
                columns: new[] { "Id", "Manufacturer", "Name", "ParticularQualities", "PhotoUrl", "Specifications", "Type" },
                values: new object[,]
                {
                    { new Guid("048cca28-58fc-4818-807f-392255df48ad"), "ASUS", "Iron ASUS", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 1.5, Water tank volume: 300 ml, Continuous steam: 35 g/min", 6 },
                    { new Guid("0cc319fc-218f-4037-91bb-14b55f541f99"), "Samsung", "Headphones Samsung", "Color: white, Design: covering the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("0e003852-74c8-4390-8b4b-3a2b01e841ba"), "Panasonyc", "Coffee Machine Panasonyc", "Color: silver, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l", 1 },
                    { new Guid("0fde6612-e6cb-4f60-b968-252ca99fa851"), "Samsung", "Refrigerator Samsung", "Color: white, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("0fe5ca99-8dee-4656-b217-a57958d87d5d"), "Philips", "Headphones Philips", "Color: lime, Design: covering the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("1990fec2-a89b-4274-b24f-409a6b28b574"), "ASUS", "Television ASUS", "Color: black, Number of USB inputs: 2, Screen shape: curved", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("1ca657cc-b83b-4158-9240-4ed99e45ceda"), "Panasonyc", "Television Panasonyc", "Color: black, Number of USB inputs: 2, Screen shape: curved", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("2190a78e-d861-421f-abee-b110a2c65dce"), "Philips", "Headphones Philips", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("21f693c7-ff21-4c3e-a03e-c3895ebe3ca1"), "Samsung", "Computer Samsung", "Color: black, Material: plastic, Screen diagonal: 14.7", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i7, Number of Cores: 4", 3 },
                    { new Guid("24d10670-356a-4941-b162-02f9bc3aa052"), "Panasonyc", "Television Panasonyc", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("3a9bb162-551c-49e5-a1e8-3040f7b1b7d8"), "Apple", "Refrigerator Apple", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator, Cameras: refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("3f4da1b1-cb9f-465a-a91d-6169b840b3e0"), "Atlant", "Electric Kettle Atlant", "Color: black, Water level indication: yes, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2400, Water volume: 2, Heating element: closed", 7 },
                    { new Guid("437bbc94-1f60-4e20-aaed-1f054e5bfb9a"), "Atlant", "Telephone Atlant", "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 6, Number of SIM cards: 2, Camera Resolution: 48 MP", 4 },
                    { new Guid("4898c0e5-7938-4192-88f7-3e77e6e7fef1"), "Sony", "Refrigerator Sony", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator, Cameras: refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("52455425-8ada-4955-b06c-036ada439e14"), "Sony", "Iron Sony", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 },
                    { new Guid("527f5426-32f1-464e-9731-adcad3dd5061"), "Panasonyc", "Coffee Machine Panasonyc", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l", 1 },
                    { new Guid("552c9eac-9d3f-4390-9b3c-372729a43ad2"), "Panasonyc", "Coffee Machine Panasonyc", "Color: silver, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l", 1 },
                    { new Guid("7bc1d632-d391-4663-9ac4-dc4938e1ed3b"), "Philips", "Iron Philips", "Color: black, Automatic shutdown: yes", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 },
                    { new Guid("7da9871e-dfc7-4dae-af7d-01e7758ee80c"), "Apple", "Telephone Apple", "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 4, Number of SIM cards: 2, Camera Resolution: 24 MP", 4 },
                    { new Guid("81052d2c-eb44-4fee-b466-4d1b0b51f09e"), "ASUS", "Electric Kettle ASUS", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2400, Water volume: 2, Heating element: closed", 7 },
                    { new Guid("8467290a-3a56-447a-96fb-087ccbfcc1be"), "Sony", "Headphones Sony", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 30 Ohm, Sensitivity: 90 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("87172c62-0917-4b28-995b-ac26a51e2df4"), "Philips", "Headphones Philips", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("87dac0e6-31d1-44f1-bf90-977a206926ff"), "ASUS", "Iron ASUS", "Color: darkblue, Automatic shutdown: yes", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 },
                    { new Guid("8b8efa6c-1172-4180-a72a-67eb76a2c159"), "Atlant", "Refrigerator Atlant", "Color: white, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("96661ad6-bb0e-4a50-bf1c-c32d0430e2c6"), "Atlant", "Computer Atlant", "Color: black, Material: plastic, Screen diagonal: 14.7", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i3, Number of Cores: 2", 3 },
                    { new Guid("9728171c-59b1-450d-b1fa-71efbbba7439"), "Xiaomi", "Computer Xiaomi", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i3, Number of Cores: 2", 3 },
                    { new Guid("9eaa9328-4334-4e86-badd-0043019a09f2"), "Samsung", "Refrigerator Samsung", "Color: golden, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("a13704c6-6d92-4e20-b4e5-a61cd9d5c5bb"), "Samsung", "Computer Samsung", "Color: pink, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i3, Number of Cores: 2", 3 },
                    { new Guid("a5c176a5-9364-4027-877d-5a96c153cffa"), "Atlant", "Coffee Machine Atlant", "Color: golden, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l", 1 },
                    { new Guid("a6cbd39a-ed84-4179-a434-3551d0858085"), "Panasonyc", "Electric Kettle Panasonyc", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2200, Water volume: 1.8, Heating element: closed", 7 },
                    { new Guid("a8522252-4c56-4cb3-bca3-2a712f3bc4f4"), "Apple", "Computer Apple", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i7, Number of Cores: 4", 3 },
                    { new Guid("ae8be060-f98c-4e76-b011-7b039cbb2ac8"), "ASUS", "Television ASUS", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("af4c5043-470c-445f-b8f1-1fc782272d95"), "Atlant", "Computer Atlant", "Color: pink, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i7, Number of Cores: 4", 3 },
                    { new Guid("b1d8a291-f49b-4da7-ace0-a76b52313f4f"), "Philips", "Headphones Philips", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("b5d959b8-f6a2-40e1-9daa-4c7197cfed3a"), "Apple", "Television Apple", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 49, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("b7e7485f-eb8a-4111-9923-2da55872caff"), "Sony", "Refrigerator Sony", "Color: golden, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator, Cameras: refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("bdac1ab6-d74d-4a35-b3f7-877b26eddcf1"), "Xiaomi", "Television Xiaomi", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("c9423614-03ba-44a2-a562-524cd5b5d7ce"), "ASUS", "Television ASUS", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 50, Permission: Ultra HD 4K-3840x2160 pix, Matrix frequency: 60 Hz", 2 },
                    { new Guid("ca53d453-0ed5-44e8-8c4c-56b1df6c3c90"), "Xiaomi", "Iron Xiaomi", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 },
                    { new Guid("dc3fadde-c72d-4e7f-84a3-5e860d204eb2"), "ASUS", "Iron ASUS", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 }
                });

            migrationBuilder.InsertData(
                table: "RepairingModels",
                columns: new[] { "Id", "Manufacturer", "Name", "ParticularQualities", "PhotoUrl", "Specifications", "Type" },
                values: new object[,]
                {
                    { new Guid("dd27760b-6c37-4a30-92a7-393775715d1c"), "Apple", "Telephone Apple", "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 6, Number of SIM cards: 2, Camera Resolution: 48 MP", 4 },
                    { new Guid("df8079d6-e050-4efb-be11-258c57947a4c"), "Sony", "Coffee Machine Sony", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("df9b0bfa-3c72-43d5-8f64-959bf0ab6231"), "Philips", "Coffee Machine Philips", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("e1394d87-a78b-47f0-9886-27093d61775e"), "Apple", "Telephone Apple", "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 4, Number of SIM cards: 2, Camera Resolution: 24 MP", 4 },
                    { new Guid("e166a581-cfde-44de-b1ee-518b195d9782"), "Apple", "Coffee Machine Apple", "Color: silver, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1450 W, Temperature control: yes, Remote control: no, Water tank: 1.8 l", 1 },
                    { new Guid("e37e1c0f-7218-4d2a-8ea6-a8283afc765e"), "Philips", "Coffee Machine Philips", "Color: golden, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("e7fd6440-6250-4c26-ae89-936501106ab8"), "Xiaomi", "Electric Kettle Xiaomi", "Color: white, Water level indication: no, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2200, Water volume: 1.8, Heating element: closed", 7 },
                    { new Guid("f2b7bbb4-f72e-459f-8bf1-8478f96701cc"), "Atlant", "Electric Kettle Atlant", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2200, Water volume: 1.8, Heating element: closed", 7 },
                    { new Guid("f9a8bd0f-a178-426a-a808-74962cf2a279"), "ASUS", "Computer ASUS", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i3, Number of Cores: 2", 3 },
                    { new Guid("fa55f04f-ee50-4812-a3ec-3cf26840674d"), "Apple", "Iron Apple", "Color: black, Automatic shutdown: yes", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 }
                });

            migrationBuilder.InsertData(
                table: "ServicedStores",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0828d798-a506-4d9c-af78-7788d1b9ef62"), "Brest, Pervomaiskaya, 47", "Elektrosila", "+375 (29) 8052525" },
                    { new Guid("11e1ff47-4b9f-4db3-9949-7852ae3e67cb"), "Grodno, Solnechnaya, 25", "Big World", "+375 (29) 4502229" },
                    { new Guid("22ab4487-2d84-4a59-9efb-0386ee2a2050"), "Baranovichi, Volkova, 22", "5 Element", "+375 (29) 4374695" },
                    { new Guid("2601d53d-79cc-4e0e-a62e-74dc937108b0"), "Shklov, Rabochiaya, 8", "Povorot", "+375 (29) 9824399" },
                    { new Guid("35bdd3c2-b5ea-49f6-8820-3389c600eb7f"), "Shklov, Uritskogo, 30", "All For Home", "+375 (29) 9630176" },
                    { new Guid("483d7a19-0c64-48f9-9420-1d8427dc4267"), "Mogilev, Shosseynaya, 26", "Technosila Plus", "+375 (29) 8882301" },
                    { new Guid("4c1949ce-62fd-43de-8b49-c0965d47d65c"), "Mogilev, Pervomaiskaya, 24", "Mediamax", "+375 (29) 4270331" },
                    { new Guid("4d9643e0-a5c0-45da-b2e2-a8d0005a25dc"), "Grodno, Rabochiaya, 32", "Deal Tech", "+375 (29) 5399398" },
                    { new Guid("508acd8d-038e-48e2-b59f-8b85eca3b010"), "Grodno, Rabochiaya, 9", "Your Tech", "+375 (29) 1078761" },
                    { new Guid("59a201be-9624-43d7-bc4c-4d33cee13eb1"), "Zhlobin, Polevaya, 30", "Fora Plus", "+375 (29) 5354469" },
                    { new Guid("8d3e4e1b-b452-4ca5-9fd5-d0726b1088d4"), "Mogilev, Barykina, 24", "Integral", "+375 (29) 3889139" },
                    { new Guid("a34d1d5f-665b-447d-9e04-4dc4623baaba"), "Slonim, Kozlova, 34", "Atlant Store", "+375 (29) 1422277" },
                    { new Guid("a5843541-628a-4202-82f8-467f7563892b"), "Zhlobin, Rabochiaya, 33", "Smail Bel", "+375 (29) 1123690" },
                    { new Guid("a95f0cd6-f657-4cde-b244-13ae7e34c8bc"), "Minsk, Kozlova, 35", "Zeon", "+375 (29) 1594739" },
                    { new Guid("aec951be-c98d-4266-a1d7-8d5b0dc56184"), "Rechica, Kozlova, 37", "TocLine", "+375 (29) 6274102" },
                    { new Guid("d40860c7-d14c-4ca0-863e-2a1de6c65b58"), "Shklov, Polevaya, 4", "Btv777", "+375 (29) 9188845" }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e"), 0, "It is worth buying a thermostat (thermal relay) for a refrigerator if the refrigerator turns off, the temperature inside is too low or high.", "Refrigerator thermostat", 49m },
                    { new Guid("01808061-ab67-41d3-84db-386476b07982"), 7, "To heat water.", "Heating element", 112m },
                    { new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 44m },
                    { new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d"), 0, "It is worth buying a thermostat (thermal relay) for a refrigerator if the refrigerator turns off, the temperature inside is too low or high.", "Refrigerator thermostat", 314m },
                    { new Guid("07435856-3a86-4445-920c-194c05f30bf2"), 5, "Provides connect with device.", "Cable", 255m },
                    { new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776"), 5, "Provides connecting with device.", "Plug", 326m },
                    { new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 318m },
                    { new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7"), 3, "Socket - a connector into which the central processor is inserted.", "Cochet", 342m },
                    { new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d"), 4, "Shows image.", "Display", 202m },
                    { new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8"), 1, "Pump water into the coffee machine", "Pump", 200m },
                    { new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f"), 7, "To turn on/off the kettle.", "Button", 317m },
                    { new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c"), 5, "Provides sound output.", "Speaker", 70m },
                    { new Guid("160ae278-a2b7-43d9-b344-c292f675e36c"), 1, "Pump water into the coffee machine", "Pump", 75m },
                    { new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e"), 6, "To connecting with electric web.", "Electric wire", 120m },
                    { new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 152m },
                    { new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 212m }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("1f204390-6649-40b9-b6eb-22c61fdd49bf"), 5, "Provides connect with device.", "Cable", 96m },
                    { new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 300m },
                    { new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736"), 6, "To control heating.", "Thermostat", 147m },
                    { new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea"), 4, "A battery that provides autonomous operation of a mobile phone (it can be nickel-metal hydride, lithium-ion or lithium-polymer).", "Battery", 175m },
                    { new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 247m },
                    { new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583"), 6, "To control heating.", "Thermostat", 269m },
                    { new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8"), 6, "To keep water", "Chamber for water", 38m },
                    { new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 243m },
                    { new Guid("32537a20-8617-4a11-8799-87c758b59a29"), 6, "To control heating.", "Thermostat", 222m },
                    { new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468"), 7, "To connect with electric web.", "Cable", 313m },
                    { new Guid("3669feb0-a50e-433b-a374-935381190815"), 7, "To connect with electric web.", "Cable", 200m },
                    { new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 164m },
                    { new Guid("41e4a0d8-5801-487a-b650-ee757856edf1"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 148m },
                    { new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 69m },
                    { new Guid("43ffc7c4-9a48-4756-8cdb-995287f99951"), 6, "To control heating.", "Thermostat", 81m },
                    { new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d"), 6, "To keep water", "Chamber for water", 314m },
                    { new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 283m },
                    { new Guid("511990ad-edc2-423b-ae09-88307240828e"), 6, "To control heating.", "Thermostat", 295m },
                    { new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33"), 7, "To turn on/off the kettle.", "Button", 31m },
                    { new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7"), 3, "Socket - a connector into which the central processor is inserted.", "Cochet", 329m },
                    { new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 128m },
                    { new Guid("592bdf00-210a-4732-8605-b3370baee69a"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 276m },
                    { new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 175m },
                    { new Guid("5b678467-974c-440b-844a-dec3aa124a74"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 211m },
                    { new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955"), 1, "Heat water to the required temperature.", "Boiler", 218m },
                    { new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8"), 7, "To connect with electric web.", "Cable", 174m },
                    { new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7"), 6, "To connecting with electric web.", "Electric wire", 266m },
                    { new Guid("62201585-629a-43cc-a837-c72ad82bb061"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 90m },
                    { new Guid("62d2abec-672d-476c-8a84-22f21c27f41c"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 105m },
                    { new Guid("6477628b-d309-40c8-868e-dda79fe2241d"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 54m },
                    { new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 207m },
                    { new Guid("65c4a088-c532-4f8f-9dfc-5b26e507a58c"), 5, "Provides connecting with device.", "Plug", 192m },
                    { new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 250m },
                    { new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7"), 1, "Pump water into the coffee machine", "Pump", 56m },
                    { new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0"), 6, "To connecting with electric web.", "Electric wire", 266m },
                    { new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 338m },
                    { new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c"), 1, "Pump water into the coffee machine", "Pump", 73m },
                    { new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c"), 7, "To connect with electric web.", "Cable", 326m },
                    { new Guid("7aa1d99a-9b90-41d3-8795-5bc21f298d06"), 5, "Provides sound output.", "Speaker", 235m },
                    { new Guid("7baa5596-e2d7-4b50-b902-dcd007b07174"), 5, "Provides connecting with device.", "Plug", 98m },
                    { new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 297m },
                    { new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7"), 6, "To keep water", "Chamber for water", 113m }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8"), 1, "Heat water to the required temperature.", "Boiler", 261m },
                    { new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8"), 0, "It is worth buying a thermostat (thermal relay) for a refrigerator if the refrigerator turns off, the temperature inside is too low or high.", "Refrigerator thermostat", 167m },
                    { new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 273m },
                    { new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b"), 1, "Pump water into the coffee machine", "Pump", 248m },
                    { new Guid("992b1044-27f3-439c-9caf-520c6bcb2656"), 1, "Pump water into the coffee machine", "Pump", 339m },
                    { new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 296m },
                    { new Guid("a527ba61-6fe2-44a6-a18e-20c5fa7e252c"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 85m },
                    { new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2"), 4, "A battery that provides autonomous operation of a mobile phone (it can be nickel-metal hydride, lithium-ion or lithium-polymer).", "Battery", 340m },
                    { new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0"), 6, "To connecting with electric web.", "Electric wire", 276m },
                    { new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8"), 2, "Shows image.", "Screen", 268m },
                    { new Guid("a878ad72-36e4-445c-a43f-0e15af493544"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 48m },
                    { new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f"), 7, "To connect with electric web.", "Cable", 170m },
                    { new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 278m },
                    { new Guid("adeae8bd-383b-4958-954e-010e4514d9a7"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 288m },
                    { new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb"), 5, "Provides connecting with device.", "Plug", 270m },
                    { new Guid("b24e50d4-d732-481d-99a7-61395c4daa58"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 124m },
                    { new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 149m },
                    { new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1"), 5, "Provides connect with device.", "Cable", 63m },
                    { new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50"), 6, "To keep water", "Chamber for water", 194m },
                    { new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8"), 1, "Heat water to the required temperature.", "Boiler", 215m },
                    { new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17"), 7, "To turn on/off the kettle.", "Button", 297m },
                    { new Guid("be422b50-87b2-488e-a8e3-c99bfb049489"), 6, "To keep water", "Chamber for water", 193m },
                    { new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 328m },
                    { new Guid("c1954a32-18b7-467d-a231-5119cb59127a"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 140m },
                    { new Guid("c9f96a22-c635-4110-81ca-c61546b697eb"), 5, "Provides connect with device.", "Cable", 239m },
                    { new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 342m },
                    { new Guid("d88f38e8-f392-424c-9c7e-1eb1bd8b9567"), 5, "Provides connect with device.", "Cable", 78m },
                    { new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b"), 2, "Shows image.", "Screen", 176m },
                    { new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115"), 7, "To turn on/off the kettle.", "Button", 320m },
                    { new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 346m },
                    { new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 255m },
                    { new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 54m },
                    { new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938"), 5, "Provides sound output.", "Speaker", 267m },
                    { new Guid("ee227512-f74f-45a9-81d4-ed1161135a40"), 6, "To connecting with electric web.", "Electric wire", 143m },
                    { new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14"), 4, "A battery that provides autonomous operation of a mobile phone (it can be nickel-metal hydride, lithium-ion or lithium-polymer).", "Battery", 142m },
                    { new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da"), 3, "Socket - a connector into which the central processor is inserted.", "Cochet", 158m },
                    { new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 317m },
                    { new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c"), 2, "Shows image.", "Screen", 267m },
                    { new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 214m },
                    { new Guid("fab67452-75c3-4f03-a662-36d980d8ab98"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 265m },
                    { new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5"), 0, "It is worth buying a thermostat (thermal relay) for a refrigerator if the refrigerator turns off, the temperature inside is too low or high.", "Refrigerator thermostat", 40m },
                    { new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 83m }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), "Refrigerator not freezing", 337m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("b7e7485f-eb8a-4111-9923-2da55872caff") },
                    { new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), "The system unit does not turn on, the Power indicator does not light up", 296m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("af4c5043-470c-445f-b8f1-1fc782272d95") },
                    { new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), "The kettle turns off before the water boils", 162m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("3f4da1b1-cb9f-465a-a91d-6169b840b3e0") },
                    { new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), "A frequent malfunction when one earpiece fails", 156m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("0cc319fc-218f-4037-91bb-14b55f541f99") },
                    { new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), "Noisy", 196m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("df9b0bfa-3c72-43d5-8f64-959bf0ab6231") },
                    { new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), "The kettle that is plugged in does not heat the water", 288m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("f2b7bbb4-f72e-459f-8bf1-8478f96701cc") },
                    { new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), "Doesn't respond when turned on", 154m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("0e003852-74c8-4390-8b4b-3a2b01e841ba") },
                    { new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), "Water flows from the kettle", 74m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("e7fd6440-6250-4c26-ae89-936501106ab8") },
                    { new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), "There is no picture on the TV, but there is sound", 253m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("1990fec2-a89b-4274-b24f-409a6b28b574") },
                    { new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), "The system unit does not turn on, the Power indicator does not light up", 49m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("af4c5043-470c-445f-b8f1-1fc782272d95") },
                    { new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), "The kettle turns off before the water boils", 220m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("a6cbd39a-ed84-4179-a434-3551d0858085") },
                    { new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), "The system unit beeps continuously, does not boot/reboot", 229m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("21f693c7-ff21-4c3e-a03e-c3895ebe3ca1") },
                    { new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), "No signal on TV", 260m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("bdac1ab6-d74d-4a35-b3f7-877b26eddcf1") },
                    { new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), "Computer turns on, Power light is on, monitor is blank", 342m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("a8522252-4c56-4cb3-bca3-2a712f3bc4f4") },
                    { new Guid("298e042d-a09a-4932-a2bd-8cc1a6546203"), "A frequent malfunction when one earpiece fails", 280m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("0fe5ca99-8dee-4656-b217-a57958d87d5d") },
                    { new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), "No sound on TV", 168m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("1990fec2-a89b-4274-b24f-409a6b28b574") },
                    { new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), "The system unit beeps continuously, does not boot/reboot", 129m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("af4c5043-470c-445f-b8f1-1fc782272d95") },
                    { new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), "Power cord damage", 44m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("fa55f04f-ee50-4812-a3ec-3cf26840674d") },
                    { new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), "Power cord damage", 197m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("fa55f04f-ee50-4812-a3ec-3cf26840674d") },
                    { new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), "Moisture ingress", 159m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("dd27760b-6c37-4a30-92a7-393775715d1c") },
                    { new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), "A frequent malfunction when one earpiece fails", 40m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("87172c62-0917-4b28-995b-ac26a51e2df4") },
                    { new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), "Heating element damage", 96m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("7bc1d632-d391-4663-9ac4-dc4938e1ed3b") },
                    { new Guid("39424747-fdb2-401d-8305-b8542a10331d"), "Doesn't respond when turned on", 227m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("e166a581-cfde-44de-b1ee-518b195d9782") },
                    { new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), "Noisy", 123m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("df8079d6-e050-4efb-be11-258c57947a4c") },
                    { new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), "Charging goes fast", 71m, "To fully verify its malfunction, you need to measure the battery consumption for some time when the smartphone is not in use.", new Guid("437bbc94-1f60-4e20-aaed-1f054e5bfb9a") },
                    { new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), "Refrigerator is too cold", 211m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("8b8efa6c-1172-4180-a72a-67eb76a2c159") },
                    { new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), "Refrigerator not freezing", 44m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("8b8efa6c-1172-4180-a72a-67eb76a2c159") },
                    { new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), "Refrigerator is too cold", 131m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("b7e7485f-eb8a-4111-9923-2da55872caff") },
                    { new Guid("411ad18e-f258-48f9-a6aa-6df4f98a10ea"), "A frequent malfunction when one earpiece fails", 174m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("87172c62-0917-4b28-995b-ac26a51e2df4") },
                    { new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), "Heating element damage", 340m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("7bc1d632-d391-4663-9ac4-dc4938e1ed3b") },
                    { new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), "Heating element damage", 244m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("048cca28-58fc-4818-807f-392255df48ad") },
                    { new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), "Refrigerator is freezing cold", 247m, "The thermostat must either be replaced or sent in for repair for adjustment. Make sure the seal fits snugly against the door and sides of the refrigerator. If defects are found, the seal must be replaced.", new Guid("4898c0e5-7938-4192-88f7-3e77e6e7fef1") },
                    { new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), "There is no picture on the TV, but there is sound", 323m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("1ca657cc-b83b-4158-9240-4ed99e45ceda") },
                    { new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), "Charging goes fast", 150m, "To fully verify its malfunction, you need to measure the battery consumption for some time when the smartphone is not in use.", new Guid("437bbc94-1f60-4e20-aaed-1f054e5bfb9a") },
                    { new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), "The machine does not heat water", 30m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("df9b0bfa-3c72-43d5-8f64-959bf0ab6231") },
                    { new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), "There is no picture on the TV, but there is sound", 72m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("1990fec2-a89b-4274-b24f-409a6b28b574") },
                    { new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), "Computer turns on, Power light is on, monitor is blank", 135m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("9728171c-59b1-450d-b1fa-71efbbba7439") },
                    { new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), "Noisy", 138m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("a5c176a5-9364-4027-877d-5a96c153cffa") },
                    { new Guid("55ad852d-c675-4df5-a190-4961028c9282"), "No signal on TV", 160m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("bdac1ab6-d74d-4a35-b3f7-877b26eddcf1") },
                    { new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), "No sound on TV", 94m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("b5d959b8-f6a2-40e1-9daa-4c7197cfed3a") },
                    { new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), "Noisy", 338m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("0e003852-74c8-4390-8b4b-3a2b01e841ba") },
                    { new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), "Doesn't respond when turned on", 176m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("552c9eac-9d3f-4390-9b3c-372729a43ad2") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), "Damage to the thermostat", 137m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("048cca28-58fc-4818-807f-392255df48ad") },
                    { new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), "There is no picture on the TV, but there is sound", 182m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("c9423614-03ba-44a2-a562-524cd5b5d7ce") },
                    { new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), "The system unit beeps continuously, does not boot/reboot", 277m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("a13704c6-6d92-4e20-b4e5-a61cd9d5c5bb") },
                    { new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), "The system unit beeps continuously, does not boot/reboot", 308m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("9728171c-59b1-450d-b1fa-71efbbba7439") },
                    { new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), "The machine does not heat water", 329m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("552c9eac-9d3f-4390-9b3c-372729a43ad2") },
                    { new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), "Control system not working", 144m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("0e003852-74c8-4390-8b4b-3a2b01e841ba") },
                    { new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), "Refrigerator not freezing", 85m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("3a9bb162-551c-49e5-a1e8-3040f7b1b7d8") },
                    { new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), "Charging goes fast", 135m, "To fully verify its malfunction, you need to measure the battery consumption for some time when the smartphone is not in use.", new Guid("e1394d87-a78b-47f0-9886-27093d61775e") },
                    { new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), "The system unit does not turn on, the Power indicator does not light up", 224m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("a13704c6-6d92-4e20-b4e5-a61cd9d5c5bb") },
                    { new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), "Refrigerator not freezing", 312m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("8b8efa6c-1172-4180-a72a-67eb76a2c159") },
                    { new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), "The kettle that is plugged in does not heat the water", 129m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("f2b7bbb4-f72e-459f-8bf1-8478f96701cc") },
                    { new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), "No signal on TV", 89m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("bdac1ab6-d74d-4a35-b3f7-877b26eddcf1") },
                    { new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), "Refrigerator not freezing", 256m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("3a9bb162-551c-49e5-a1e8-3040f7b1b7d8") },
                    { new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), "There is no picture on the TV, but there is sound", 210m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("1990fec2-a89b-4274-b24f-409a6b28b574") },
                    { new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 50m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("8467290a-3a56-447a-96fb-087ccbfcc1be") },
                    { new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 320m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("8467290a-3a56-447a-96fb-087ccbfcc1be") },
                    { new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), "Power cord damage", 31m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("dc3fadde-c72d-4e7f-84a3-5e860d204eb2") },
                    { new Guid("a80341c3-d738-4101-809f-cafff4f28336"), "Moisture ingress", 344m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("dd27760b-6c37-4a30-92a7-393775715d1c") },
                    { new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), "Power cord damage", 107m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("048cca28-58fc-4818-807f-392255df48ad") },
                    { new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), "Refrigerator won't turn on", 251m, "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. Remove the terminals from the wires connected to the thermostat and connect them together. If the refrigerator does not turn on and the light inside the refrigerator does not light up, then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.", new Guid("9eaa9328-4334-4e86-badd-0043019a09f2") },
                    { new Guid("acf583ec-d367-4314-80c5-d06b44434928"), "Moisture ingress", 224m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("7da9871e-dfc7-4dae-af7d-01e7758ee80c") },
                    { new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), "Water flows from the kettle", 76m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("e7fd6440-6250-4c26-ae89-936501106ab8") },
                    { new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), "Refrigerator shuts down after a short period of operation", 283m, "Safety relay plate should be checked with an ohmmeter and replaced if a malfunction is detected. Start relay coil also checked with an ohmmeter and if a malfunction is detected, the part is replaced. The compressor motor needs to be replaced, for which you will have to call a refrigerator repairman.", new Guid("9eaa9328-4334-4e86-badd-0043019a09f2") },
                    { new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), "Refrigerator shuts down after a short period of operation", 33m, "Safety relay plate should be checked with an ohmmeter and replaced if a malfunction is detected. Start relay coil also checked with an ohmmeter and if a malfunction is detected, the part is replaced. The compressor motor needs to be replaced, for which you will have to call a refrigerator repairman.", new Guid("4898c0e5-7938-4192-88f7-3e77e6e7fef1") },
                    { new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), "Doesn't respond when turned on", 48m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("e37e1c0f-7218-4d2a-8ea6-a8283afc765e") },
                    { new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), "The kettle turns off before the water boils", 226m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("e7fd6440-6250-4c26-ae89-936501106ab8") },
                    { new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), "Refrigerator is too cold", 236m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("0fde6612-e6cb-4f60-b968-252ca99fa851") },
                    { new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), "Damage to the thermostat", 283m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("87dac0e6-31d1-44f1-bf90-977a206926ff") },
                    { new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), "There is no picture on the TV, but there is sound", 98m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("24d10670-356a-4941-b162-02f9bc3aa052") },
                    { new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), "Damage to the thermostat", 273m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("7bc1d632-d391-4663-9ac4-dc4938e1ed3b") },
                    { new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), "Moisture ingress", 190m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("dd27760b-6c37-4a30-92a7-393775715d1c") },
                    { new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), "No sound on TV", 81m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("bdac1ab6-d74d-4a35-b3f7-877b26eddcf1") },
                    { new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), "Power cord damage", 320m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("ca53d453-0ed5-44e8-8c4c-56b1df6c3c90") },
                    { new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), "Control system not working", 126m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("552c9eac-9d3f-4390-9b3c-372729a43ad2") },
                    { new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), "The machine does not heat water", 204m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("552c9eac-9d3f-4390-9b3c-372729a43ad2") },
                    { new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), "Refrigerator is freezing cold", 122m, "The thermostat must either be replaced or sent in for repair for adjustment. Make sure the seal fits snugly against the door and sides of the refrigerator. If defects are found, the seal must be replaced.", new Guid("b7e7485f-eb8a-4111-9923-2da55872caff") },
                    { new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), "No sound on TV", 168m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("1ca657cc-b83b-4158-9240-4ed99e45ceda") },
                    { new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), "Power cord damage", 233m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("ca53d453-0ed5-44e8-8c4c-56b1df6c3c90") },
                    { new Guid("d892e510-6266-4ce0-8bcb-2043abae12ff"), "Moisture ingress", 230m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("7da9871e-dfc7-4dae-af7d-01e7758ee80c") },
                    { new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), "Refrigerator won't turn on", 114m, "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. Remove the terminals from the wires connected to the thermostat and connect them together. If the refrigerator does not turn on and the light inside the refrigerator does not light up, then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.", new Guid("8b8efa6c-1172-4180-a72a-67eb76a2c159") },
                    { new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), "Refrigerator not freezing", 86m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("3a9bb162-551c-49e5-a1e8-3040f7b1b7d8") },
                    { new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), "No sound on TV", 165m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("c9423614-03ba-44a2-a562-524cd5b5d7ce") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), "No sound on TV", 184m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("ae8be060-f98c-4e76-b011-7b039cbb2ac8") },
                    { new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), "Moisture ingress", 148m, "Immediately after the incident, you need to turn off the gadget and try to dry it (if the battery is removable, then pull it out). Do not use a hair dryer or heat the device in any other way. Otherwise, there is a high risk of burning the electronics, and then even contacting a service center will not help.", new Guid("7da9871e-dfc7-4dae-af7d-01e7758ee80c") },
                    { new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), "The kettle that is plugged in does not heat the water", 189m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("3f4da1b1-cb9f-465a-a91d-6169b840b3e0") },
                    { new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), "Power cord damage", 216m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("dc3fadde-c72d-4e7f-84a3-5e860d204eb2") },
                    { new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), "The kettle turns off before the water boils", 242m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("e7fd6440-6250-4c26-ae89-936501106ab8") },
                    { new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), "The system unit does not turn on, the Power indicator does not light up", 309m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("21f693c7-ff21-4c3e-a03e-c3895ebe3ca1") },
                    { new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), "Charging goes fast", 137m, "To fully verify its malfunction, you need to measure the battery consumption for some time when the smartphone is not in use.", new Guid("e1394d87-a78b-47f0-9886-27093d61775e") },
                    { new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), "The system unit beeps continuously, does not boot/reboot", 124m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("21f693c7-ff21-4c3e-a03e-c3895ebe3ca1") },
                    { new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), "Computer turns on, Power light is on, monitor is blank", 158m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("af4c5043-470c-445f-b8f1-1fc782272d95") },
                    { new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), "Computer turns on, Power light is on, monitor is blank", 236m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("a13704c6-6d92-4e20-b4e5-a61cd9d5c5bb") },
                    { new Guid("f5904a45-8bd1-41ee-979e-f9769b5006c5"), "Heating element damage", 258m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("048cca28-58fc-4818-807f-392255df48ad") },
                    { new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), "Computer turns on, Power light is on, monitor is blank", 190m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("f9a8bd0f-a178-426a-a808-74962cf2a279") },
                    { new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), "The system unit does not turn on, the Power indicator does not light up", 125m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("21f693c7-ff21-4c3e-a03e-c3895ebe3ca1") },
                    { new Guid("fd7482a1-35bb-47b2-99c6-4eefef59cb45"), "The kettle that is plugged in does not heat the water", 75m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("a6cbd39a-ed84-4179-a434-3551d0858085") },
                    { new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), "Damage to the contact", 310m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("0cc319fc-218f-4037-91bb-14b55f541f99") },
                    { new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), "Refrigerator not freezing", 82m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("9eaa9328-4334-4e86-badd-0043019a09f2") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("00866f0a-4382-4f3a-9544-ff321c87fbc2"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("00a0be12-4e0c-42ff-9bd4-cf053f0ad702"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("00b154d9-3ee9-4989-a720-cf2485ab5998"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("00b4edc2-11a0-4fa7-89f7-d0611144d054"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("00bc259d-2f4c-4f18-835f-b29ca46d2c0c"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("01313d62-821e-4b86-b7f1-8e29a23c9059"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("025d6183-efea-4c36-9ee6-bfd5b104d1f8"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("02c7a60e-ae23-4959-bfe4-b16724659436"), new Guid("411ad18e-f258-48f9-a6aa-6df4f98a10ea"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("035d1247-d5a7-4acd-9b49-0256b44b89fe"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("03aa906a-3830-49df-91e6-478016317a17"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("03ed38b8-3d7f-49b1-87cf-fa46cda0e23c"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("0431ded1-b53f-4580-bfce-47b895fea8be"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("32537a20-8617-4a11-8799-87c758b59a29") },
                    { new Guid("04f6cbe9-5a8f-4568-9bc4-741db88bb559"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("05211028-e6ca-4d9d-b9d1-4611a32b9f01"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("32537a20-8617-4a11-8799-87c758b59a29") },
                    { new Guid("0589c578-e8e3-4325-9f62-b2e982195013"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("05a25bec-7f35-4c93-9154-9b7566019bb2"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("05b6b7e2-5149-47f5-8918-6eaae905f4de"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("05defc7e-2241-4c84-9e43-1bacea3b1f96"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("0636bb8b-2699-4a09-a872-03d204671ff6"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("0662a285-e218-49a4-b436-d8279d737a96"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("06681987-9118-4091-bd40-adfa402a1ec1"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("06ebe871-4fbd-49f8-b4cb-392241103007"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("06ee4952-2aca-4021-a6b9-77128d94c828"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("0716edd8-b64f-4b45-aa58-f5aa23c5862b"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("07485baf-4f85-4975-bc2d-6ff00eb0e747"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("078f97b2-4f78-46db-9a3c-56df09e36d80"), new Guid("fd7482a1-35bb-47b2-99c6-4eefef59cb45"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("07a9d3f7-27ed-4293-b611-5734c5252562"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("0822e66e-d162-491b-95b1-2b7e3d2b1828"), new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("0848fca6-d864-4257-89fb-be8550cad0d9"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("08acb36e-4308-4a35-902c-a756a1dfc65c"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("08d788aa-be15-437d-9cee-3ba01a0824e3"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("08e65263-b4a5-470d-8151-272d2f1238e0"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("08f5276b-5dbb-4641-85d1-282f60914c26"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("090b7fc6-cfc2-401e-b0c0-abd82c778d57"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("092ff3ac-67ed-430e-9dde-8b544fab8ad6"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("09336a15-305e-4488-8729-d5d73dd9d680"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("0963d2a8-185e-405b-9bea-36f60fef6696"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("09ed7c3d-6f72-480f-bd32-6a575b72bd4a"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("09f41b48-cc36-42a4-b1e4-ff7837f7306f"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("0a9a2982-2a59-471c-82ae-101fd78b257b"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("0b00158f-02b6-4f5b-9c32-81c83ddd3a61"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("0bdbf639-cc85-40bd-8475-f0302d49ce15"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("0be4edd6-4c68-4257-8405-e9a612da5c40"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("0cb75bba-f76c-4482-bf52-3ad20e2f9dfb"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("0d087500-1827-4e69-ae94-d2c4ec206881"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("0d7699ee-6280-42b6-9b49-cf274ef08cea"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("0db3c0ea-a8ac-4037-83ea-5ebe89182457"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("0e8379bc-2dfa-42ce-8e61-37566b281b63"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("0edf304e-aaf9-436e-aa37-5c718b4aa579"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("0ef14403-20be-4c0a-a84b-765f32bb3568"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("0f0ffc5a-8f9c-47c6-bcae-0b8baaacf758"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("0f16a6d4-a20b-4b87-bb7d-14e4ffe87374"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("0f434900-9a33-4f2e-b28a-7edcbf1f8130"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("0f917124-ba3c-459a-9875-11b4dd879544"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("0f948a3a-b35a-42e5-9b9c-424794d044ee"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("0f975a47-be30-48f0-8c02-e5410bb155a1"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("102c2bd9-91a7-42dd-9880-f740ddf78ccd"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("1037f499-96ad-440e-9d97-57f671cdeb31"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("103f3bdc-7be8-4f21-8d55-edea0bd43ab4"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("10621e38-e124-4b4c-a577-9a4965852b95"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("43ffc7c4-9a48-4756-8cdb-995287f99951") },
                    { new Guid("1064b351-a257-4cc8-8948-c72cd64eb686"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("108782f6-dd73-454c-be4f-01851fa3e13e"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("108f7c24-7515-4b86-b194-b5dfacde91bb"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("10f2a9c0-b600-45ff-81da-55d3aaf33982"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("112b7473-9167-4998-b403-a3fb7a10a8bd"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("11abe4cb-3b91-40b4-a3e9-3995879c6edf"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("121651fc-31bd-4c2b-bd93-465c12cd0bc2"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("1236fd71-7d96-4962-9cd0-d45771b1e561"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("125098f0-4e17-466b-bb50-474b5485a4d1"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("126bda42-f73f-4c22-96c8-7fe7ab6e9caf"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("128e3303-f058-475c-ab85-dc12b86f7cbc"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("129313ba-6ab1-4806-8d53-ed0bf4811519"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("12a4fdeb-a83b-42fb-bebe-421d00ccdfe1"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("12fa3ea5-b3ca-4af4-9e64-c344f42e14c9"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("132f80a7-ed80-4d91-84b8-6d9db32b3012"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("1390b1cf-0609-403e-aad3-7effa3141a11"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("139f3731-6e04-454a-9b1a-856f12f39547"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("13c45305-38fc-4260-828d-6bdab3f27ab5"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("13ea19c3-9453-49ef-9d5c-f9d3041cbeac"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("140637be-0d0c-4b98-b5b3-3ea0075f3d6e"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("14281144-96bc-48c7-ae40-e018ff60fdcb"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("143fada7-5629-4980-b943-4fe86f4b6808"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("1445b8de-ae89-4e32-84df-5c769a6a3fd6"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("146e8abe-fa5f-4fd9-ac19-71cfd19d3e5b"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("15538dd0-285b-4a9c-b5fb-d646c1798dae"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("15bf5eec-e426-4730-8bbb-59c7552ab724"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("160caf25-a70f-4bbb-ad51-89c1cb1fc797"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("167a53cc-c7d2-48eb-93d5-1c72614c9b7f"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("178a255e-5404-4b99-bb98-e2352843a5fb"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("17996bd0-f929-484d-bb32-eb034a8ca13f"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("184a0e73-f74c-441f-8ed7-a04633e762a8"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("188a83eb-9657-4768-aedd-1ed2b1f3a7ba"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("1918af5c-c1cb-4ae6-b8c5-e5ca4e0537ea"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("1f204390-6649-40b9-b6eb-22c61fdd49bf") },
                    { new Guid("194c8b8d-fd93-4674-b751-bf413d27cd00"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("1961df04-4eb5-4b39-b6bf-bd1a3913cffa"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("196ddc4a-e70f-4fe3-99fb-02b228fb30eb"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("197e9a7a-1350-4a69-a55a-5732a332e15c"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("65c4a088-c532-4f8f-9dfc-5b26e507a58c") },
                    { new Guid("1a038664-397e-4ad4-84ca-1932a94fe886"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("1a0533c6-c760-449a-8d3e-659e07ac10fa"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("1a78a0ff-6d6a-4e1f-8a21-b14f877cbc81"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("1a7e9802-8e41-47c1-b8b4-5bb45e798317"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("1acdfff9-ad61-4462-828f-0220f4583994"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("1b156fad-dc86-47cb-b04d-a9be3c9e8f5e"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("1ba8e78e-7231-4c8e-8122-7535a375e12b"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("1c6b4dc8-89c1-4f99-b974-59693290a670"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("1c8b8e73-592e-4a0d-b6fc-614a1c1bb017"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("1d2b4bec-935b-47f0-a3bc-e553035ed367"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("1d33c005-9bcd-446a-8656-c08fb538669e"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("1d3994f6-eb97-4a2d-a9e8-a5d20ef5808d"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("1d5f3e37-4a2f-4959-9ddd-2a4f6de0e533"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("1db89d54-2920-4dd2-b116-f8f21bfbad84"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("1db9c352-01f2-4da6-83ef-1b4d68820514"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("1dbf3375-be2e-4b72-870c-2f540feb6088"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("1e0dd93f-33e3-4dd7-9df9-741c9209f04b"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("1e17a0ac-d419-4a65-9805-7624b1db07e7"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("1e61f82d-ffc2-40a2-aaf9-81d382959380"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("1e6983c2-8ec1-4f83-9fd0-3083769f0966"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("1ed721e1-e6ed-41f8-8fa5-ecc7d997c797"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("1f065451-728b-4639-874e-1a0c45abf09d"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("1f091607-682a-44ef-a7e9-8b02ea071d4b"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("1fb127e2-45d5-489d-a11a-8f68affae416"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("2049df5b-8f9e-4a1c-a813-22340fbccda0"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("204a89c6-450f-41a9-9bef-6e3dca65b608"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("2084c110-529b-48f4-b9f8-27332a7bed15"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("2097cb23-dfba-4bb7-9387-6efe27a19241"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("20abb572-3650-4a7c-a66a-2b269bd5ca55"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("20dec5dd-8143-4ecf-8109-4863854c1a48"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("21480843-f155-4618-b8f1-35c4df716b6d"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("217a781a-3154-42ac-975a-328505f10c50"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("217c2d67-0715-410c-b080-a20ef8486732"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("21fc626f-3709-44c3-88e0-13968af472fe"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("22bafcd8-8fe8-4d24-ac37-085c820e2906"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("22d3402d-5e94-47ba-8db9-6da658d0cb72"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("22e96f50-dcb9-4db3-942c-5e3987b7d866"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("232fb51a-cf5a-4d6f-9c51-d168de24f247"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("2332ef51-2ac7-4560-9adf-b7695274aaa2"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("236a2eeb-a549-4fd0-afad-3a36d22af93c"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("23909979-d594-456e-853a-ede7f3a498e1"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("23b955d9-1c5a-42ad-ae6d-039d9b79e4da"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("a527ba61-6fe2-44a6-a18e-20c5fa7e252c") },
                    { new Guid("23e758b4-25ce-45f1-b8ab-b65b715fe18f"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("23e8538e-275b-45e1-8261-0a1032081202"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("24bf111c-96e1-441d-94fc-51631b74cda7"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("24f5dcd5-e5e9-47b2-b0d4-5fff4871c425"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("254cc4cc-5efc-4e12-8430-22cfeba38f7a"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("257fd05e-a068-4d34-a529-8174ad3eb145"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("2594e22b-bafb-4733-9b57-c01d3519d648"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("25c1d6a0-4b75-4e99-972f-d886bc012e40"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("26074977-979c-447e-9db5-982a701ff9cc"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("26e58a18-6e45-4d4c-b8af-078f53ab56e9"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("271bbee0-d735-41f5-9205-297cb6986a03"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("27222096-45de-41de-a833-edfa18ec4aa0"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("274f56e5-ae55-4bf9-b2d9-fe63cbf8f776"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("27b49ae5-b8ac-4994-b84c-1081d9987797"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("27dd0c45-0d47-451e-b7a1-2aafc5bc5abb"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("281b37c4-b006-4a60-936d-b453f3d444b7"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("2836fb4b-1c04-42e1-96cc-267a8daa2116"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("29b956c0-0eeb-4a30-8ea7-adea9c77b4fb"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("29e4e26c-f3f5-4406-8048-d469acea8484"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("2a1a9d1d-1646-4678-83a4-08681ca54df6"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("2a47e082-6396-48ac-90d6-42b3d8e017f9"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("2a6306fd-b98e-4375-a7dc-e4114f91ce9d"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("2a873e35-bdf5-4f8f-b70d-2872127b31e8"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("2a89d191-8567-49b0-9544-22f035e745e5"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("2a90ad69-2aee-403f-bc95-2229c782ccc7"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("2b290bb4-30ff-4fa0-9e85-b7c85819ffe8"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("2b46b3a4-b88f-4009-88bf-f3bcbdac1b7b"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("2bdf73b8-78bc-426c-b9af-9e35f1b6c247"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("2bf70f55-4ca2-4a17-b6f7-57326b3b5e85"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("2c63700d-aceb-4054-af16-60d1d2103769"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("2c7bef64-8b96-414b-9f31-e63477b38bd6"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("2d15d7ee-0457-4ea5-a96f-deea027af643"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("2d1c9d83-bf0b-435d-bcc4-90657fea8684"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("2d831ff0-0974-4556-ae97-aa30cfe52637"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("2da4972f-af1b-476d-9a3d-934fed4bb130"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("2eb43758-9067-491e-b0a0-829dae4d7589"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("2ee15143-fe75-427e-8cd1-13299fa4c4c9"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("2f3355ec-4f20-48f7-9fa5-30a0987e36fa"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("2f58608a-9eae-430a-a225-b81b7065783c"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("2f73e312-c8c7-4b4c-8f97-b79b4f46f362"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("2f8fddbd-aa02-4aba-b161-294191c20131"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("2fb4c6f8-e664-4a22-a485-7ac53e700977"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("2ffe3124-82dd-492e-8f14-afc0fa286cd1"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("30d824d1-03bb-439f-ab48-775f3e66c409"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("30f694d3-7dec-4bfd-bebe-172532eeae2a"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("31349773-837d-42d7-9b42-b38685f5a613"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("31515237-6276-4d85-a229-89849fb4d07b"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("31b93fb5-4365-4a85-936b-ecb38b5e31da"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("323b9ecc-6272-4507-8fa2-b5947670de3c"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("3250fbd9-f11b-4f8b-9f4a-4cd744e5b2e8"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("3278eb86-9eca-4bf4-b6a9-f41caef704a2"), new Guid("fd7482a1-35bb-47b2-99c6-4eefef59cb45"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("339a700d-4106-422b-b3ae-d78651943a92"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("33a85810-6a2f-4207-9955-26aecccb7c78"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("33b38130-b71a-4a98-ae67-0af56945859e"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("33b594c1-890f-4627-9d9c-66aaa3246459"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("33c30fa3-115f-4713-b399-1e8564e8dc77"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("33ec84c9-7460-44f0-b3be-65ee6539b6f6"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("34093617-eefb-45c5-888c-52ecf2207c60"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("34bcd083-9d75-4489-a2f5-375c069d7684"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("35497c4f-52e0-43f5-9352-c2cfcfc039ae"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("3565ef7d-48f8-46b8-ab60-c2fd7eb8de6a"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("3592e9e4-2fe3-48cd-9035-71a58dce864b"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("359d0a46-6186-46af-b951-e073ba3428d3"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("3656d4ce-296d-4e69-a870-188685fc6e04"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("3656e33c-2a6e-48b6-b5fd-ab683e7d4fe7"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("367bc49b-d6ae-4ec8-9654-14b3fc697ba3"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("36a1e3af-9f6b-49b1-bd7e-f8335c4fdc54"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("37152280-44a1-4ac3-a4ae-7b0328f8bcd0"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("37a5ab58-257d-47e0-a375-6792c135d03b"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("37a81ad4-8f0a-4c2d-bd3e-3a2b0bee3942"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("37e1c2d6-35ab-42cd-ba3d-62a7c2eb4acc"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("37fd126f-7621-4d2f-a630-3f5765b2cdad"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("386014b8-ce99-4d0a-b688-07720578077f"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("38e46ce7-eee4-46e3-9c81-7385d280b1be"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("3947176e-1eef-4a1f-9d8f-9ce2fd966774"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("396507c0-eaf7-4cf6-920c-d7f03a8cff17"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("39919b49-7a57-490f-8aad-53b744d48535"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("39ad7b5e-605e-4104-adab-6964c942b03a"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("3ad192ad-1dcb-4009-8654-b23fb2582bb0"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("3b174229-650e-444f-b6b0-866c12b515b2"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("3b5ab94c-12fc-4606-af0f-66e9a7896573"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("3b742990-8495-4324-ba16-f86079db7635"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("3c328d00-3065-43ad-aa85-f7bb76e22b1d"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("3c9dd1d1-cbba-4fa1-96d4-1efe08e1d434"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("3ce3bcba-3c47-4b39-9f4d-cf60e26c22cb"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("3ce52976-d6db-434d-849a-719efbe4ae7c"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("3d640163-400d-4757-92a0-cdccb7dcb8a8"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("65c4a088-c532-4f8f-9dfc-5b26e507a58c") },
                    { new Guid("3d6f6e63-d1ce-4d70-a8df-c7d6b1281fea"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("3d8aca65-3994-4473-8240-3150780f0d7f"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("3e19306c-2a2c-4e10-9b18-8ee58bfb3e28"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("3e5c50ca-a63e-431a-b854-36da2350c0d3"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("3ec0a533-d627-4fb5-bf39-74aa04758a6a"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("3f204848-bcf8-4eec-b1a7-76fc58907724"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("3f86b506-052d-4cff-a6d8-c96db0e67870"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("3f98f004-1bda-4d15-934e-3d273ba38f53"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("400cbd5a-e7a2-40c7-a45e-ed117373b929"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb") },
                    { new Guid("417b3f63-fe02-4908-bdc1-db8b36031eb1"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("c9f96a22-c635-4110-81ca-c61546b697eb") },
                    { new Guid("41aa8a76-97c8-49a1-85ae-ae8b7203b7f8"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("4205dc0e-3fd6-4001-9e1e-c0c02a40c005"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("422470dd-e9f9-4e66-bab9-a9cfae70bdd1"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("423a8a61-c7aa-4921-88e8-e97555f87223"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("424f7d89-d7cc-4cb9-9123-0fa5e8146dc4"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("4285a17d-7b39-46fb-879f-36687b68936b"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("42ce23d9-814d-4dfe-8a48-3defeda7be62"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("42eb07a5-5e00-4ecf-8192-c5066b225a67"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("435334cb-bbb3-4734-b182-2cf6ec6102b9"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("4368bf54-4e25-4b96-9c98-33c95cf9c2d6"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("43bfcae6-51ab-4efc-b1ac-bb507756aacf"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("43c3bd0c-0efb-4f2d-9e82-d75c56987287"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("43d4d6ea-f9aa-4379-a407-67846905a655"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("442ed17c-b660-4ecd-a1ac-61af179098b6"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("4442b0ab-1e7c-4c23-a0ab-ab57e82fa8b7"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("65c4a088-c532-4f8f-9dfc-5b26e507a58c") },
                    { new Guid("4465687f-54fc-4463-853c-08097dbb42eb"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("a527ba61-6fe2-44a6-a18e-20c5fa7e252c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("44b465fd-655e-4ca2-908e-ed09d87b57ed"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("44bfd308-82c3-43e2-ba40-e4769e360d7f"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("44cefca8-24ce-4dfa-9525-2fc149986846"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("463a56e0-90ad-42cb-92dc-39508e98aba9"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("46f8adfc-944c-493d-97e2-479db282e257"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("471d3ee6-7ab1-4b2e-90a2-f02e083ca8d4"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("476d90ed-aad0-4046-a4ff-c24b3d17b827"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("47a41bcd-43df-431a-aa62-b9c926a9014c"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("47dab0a0-496d-4f28-b1ff-bc7482e011e8"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("4801e11e-bd32-45b1-915b-338fd0096d17"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("483d2810-ae59-4797-a5ec-053dabb05d42"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("4863071f-145b-4251-93a3-f463dc0e03a4"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("4888afcc-c2e6-4f11-8b01-230ead22d0a1"), new Guid("298e042d-a09a-4932-a2bd-8cc1a6546203"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("49ebd342-2bdf-40f2-bdc8-8ae2ef89bdcb"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("4a814199-e211-49aa-9744-30c215ee1e27"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("4aa8bce3-ce79-4812-a71d-774209f30820"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("4b7717a1-81b8-4375-970d-e5d36e5c4bf5"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("4bd617e2-b5df-491b-9716-f2c4fa2a487a"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("4bdf71cd-6627-4cb8-a6b8-c839ca32cbb4"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("4c9789e5-d751-4204-8f09-8e4900a181cd"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("4c99114c-8ebf-4247-ba06-7a3c574a91e7"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("4cf5047e-1ee1-401d-841d-b4c522c8f695"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("4cf7c981-6313-4e47-9c0f-ca0c211fe433"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("4d2496ba-4390-4fab-b6d0-30f84beb040e"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("4d33afc0-5e0c-47a7-86e2-2f2b889f52c0"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("4f4f5e7c-1fbd-4c4b-9b62-f560f9f46c72"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("4f6fa8b7-3bf7-4bd8-b362-c87ba9fcaf94"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("4faab668-2c17-43ba-8378-ed7244406d10"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("50293e64-44c3-400e-b6d9-bfb5b5b5928b"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("504b3548-84ab-4aec-9c64-e13d36ce09c1"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("50bad84e-b889-417e-b0e4-bcd3702ec97b"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("50d7107d-87c2-4db7-b01e-adc30b279e5e"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("50e42096-2d5c-4a0f-aec7-76ef0f3368f0"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("50edecb8-1800-4f06-8993-8e1f33ea09d4"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("51021afb-5092-471e-ac26-331c6f7f1671"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("5123b64a-ccc1-4385-a17a-3c06e43ec68f"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("51258994-28be-409a-b3a6-c67da311b5f0"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("51a3aa8b-59d0-43ec-839d-d41e5abf2f9d"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("51f20d19-c525-4608-a1c4-c71754add03c"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("520e9963-be74-499b-9834-0b67ba642907"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("522911ab-8d4f-432c-85f4-2069b08dcb5f"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("52398734-e18d-4c5a-9f91-25339fa16df5"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("5253334c-7512-4340-a42e-41e73ac9ca16"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("52c74973-47d5-4fc7-8b77-beec886008cb"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("532c093d-1173-4b59-af0d-18588a0d9206"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("53779415-3026-44a2-9c36-d5f86346fa18"), new Guid("298e042d-a09a-4932-a2bd-8cc1a6546203"), new Guid("7aa1d99a-9b90-41d3-8795-5bc21f298d06") },
                    { new Guid("53ce28d7-4bb4-4232-968a-47378a3a8371"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("53f16754-45b7-4905-aa64-e1f1cd309050"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("549e300e-180d-4994-b63b-c82e9d1db435"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("54e04c5d-2805-4adc-b629-9212db98e534"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("54e8774f-623f-4c0e-a5e9-ee0285ab2cb1"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("5529ff1f-cc39-4305-a93b-39e7faf10bc7"), new Guid("f5904a45-8bd1-41ee-979e-f9769b5006c5"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("5536ee91-4f47-45b6-8e44-29e06a776879"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("55379fda-efb1-4b7b-a721-d0da069e475f"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("55559415-3e2c-4ce6-bd7e-3a6c6b3711cd"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("562c6876-d117-4b09-8e38-6e830b3386d1"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("569e969c-6f0d-49f4-acba-43487fdb7d0d"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("56d788f5-3199-42c4-9c5b-d3d41cdce0d1"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("5708b3e0-b1f5-476b-8b08-cb6ad1d2a5c8"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("57975607-5150-4895-bedc-ff85ba9bb742"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("579a0ec4-d600-4e52-a5d9-1bb071c61e26"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("579f1a89-ad29-40e7-8b3a-8c45302e8017"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("585da0f8-38bf-4ba9-a025-79887d4e25a7"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("58a690f7-bbd8-42c8-8306-13480cbd2ba3"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("58bb57c0-bbc4-4bf2-8874-e0bc7d12c148"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("58c84892-e07b-4f34-a14d-03879baeefb4"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("58f6189b-d369-4f8f-a424-c9cc3c12b9d0"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("5918aafd-2170-4d25-9b8a-528352ca8cb2"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("59f57c46-1829-41cd-9504-a4f870b98716"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("5a2cb086-2b2a-4441-bd2a-f0d3c693379d"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("5a399fe1-3afc-4d58-a7f6-be9874dc12fa"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("5a5e16b4-66f3-4f97-acf8-1f2954dd405e"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("5b157811-a4a5-4e33-91e9-47447f64ff6b"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("5b3258c6-c242-4050-a33b-5a3b5bc7c9c0"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("5b48f546-0d0e-40bb-a399-6cd53ea21b2e"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("5b4920ae-9337-4fe2-906b-33cf2992f9f7"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("5bb29854-e45b-4c50-8a05-444105379864"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("5bc62a48-88f0-413a-a571-7320b8cdc42d"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("a878ad72-36e4-445c-a43f-0e15af493544") },
                    { new Guid("5be1163c-756f-4ed1-af89-271bdf12dcc1"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("5bf00527-cd0b-431d-b263-10c9ecdf2775"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb") },
                    { new Guid("5c0e0452-f6de-47ff-87f3-d636ab89dccd"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("5c6a2f0d-a9da-4b6e-b57f-73fbbb5f6be8"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("5c95cc80-61ed-4550-befe-6b3b8d76dd1d"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("5c9da88f-48bb-4d33-a351-1e664e59c7b9"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("5ca58f3d-818c-4f99-bc7d-e83efe91a7a7"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("5cd23f99-37cc-4a17-911d-e200c9dc87bf"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("5cd4d5cb-52ef-42cf-885f-5908456d8d64"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("5ce564fb-fb24-4080-8e57-50229077403a"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("5d0d7abe-a709-4023-ba76-cde0316e9719"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("5d7fb143-700a-4a5d-8bc6-5fa3e1be3de6"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("5de300df-5e87-4d12-ad42-dfb77beaa7a1"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("5e33eb9d-485e-47fb-9e2f-dbdfc4c892b1"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("5e8786b3-99e3-467d-a406-43e7a50986e4"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("5ec5d473-ded0-42c1-98de-96b153420a43"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("5f32656b-22b9-4baa-af1d-cca440034db5"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("5f75fd73-bcca-4416-9ac1-ed3971e6d928"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("5f95e05a-6df7-47f3-9578-dcd26eeee37e"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("5fcd7b9d-e83d-4253-94c1-e9d65384cfc7"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("5fd0f1f3-f05d-47e4-9bb3-63ea2671300d"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("5ffaafa5-8be5-4677-8601-c5d4f25d55c2"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("60552321-b41a-45a6-b2ca-f7e27ea73019"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("607a4589-ce8e-4901-8ced-9c8374c3210d"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("60c9e8da-eae9-4d7a-bfa4-8eece87a85ad"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("61031321-dfb8-424f-9480-2e2f042b43bd"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("61136cfa-b03b-41a2-af39-0aa50c2f709f"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("61407023-b19b-44c8-98bc-5f2eed962b41"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("614c08ab-f916-4d33-babf-986f7b139e21"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("615c465b-eecd-40f5-ba09-59d3cf5c7fa4"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("61603611-4110-4eba-959c-93f6f1c29f42"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("61685d5a-89da-4091-bf5b-5f52d29ba641"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("619ae836-03b0-47fe-95a8-595b8f2b9ba9"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("61ec0cee-e339-4bbd-ac99-ee5772b561a3"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("621b1f6a-dc90-40d1-9586-73259882563e"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("6256642e-1e12-4595-a461-3fbdb2b26e3e"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("628e7219-9c30-4d79-80c7-c477a36a9d48"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("62c20618-ba7f-40a0-969f-9d200b38d0ea"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("6310bcd2-d201-4043-92ac-72b2fd50a996"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("637218d0-2231-48b9-a830-5d1d3466fcf6"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("63ce31be-bf63-4b10-aa23-8a9545674986"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("63dad8c4-3117-426a-8111-3ee2c6c8bbc8"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("63ffff7d-e138-4cad-a9a4-8c543579e288"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("643a031a-6bcc-467c-925e-d822296acf31"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("652ac4c1-eca1-4904-abd0-5f8a17722bd6"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("65aef515-e050-4777-ad3f-bd6c31ab6732"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("65f5f62f-e432-4b97-9771-2b3b402f29c3"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("66135984-2470-4731-9a2b-9c7bd7add0e9"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("6656156e-187a-42be-8f8c-1c17b1d23e49"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("665ce14d-ba41-420b-aad9-df85d2071f66"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("66c80739-cba9-4014-aa0f-ae97e3e190d7"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("67b4fcfc-532c-442c-a52b-c7ed877327f3"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("67b997db-6c73-43bd-b611-efa6464da0f9"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("68b568ad-bfc8-44ca-ae78-89418c72eddc"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("690775f9-7901-47bd-b00c-09556e5dcf41"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("699addf9-28c6-4f94-ab29-9676a64d89f8"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("69dac1b6-5b80-424a-b1d1-798b27bdea91"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("6a8f143e-9ae9-46fc-b301-572553c797c1"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("6aa85a62-4791-4cc3-9254-0671b44c3b0e"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("6aacbb65-3f3a-4c4c-8421-649a7d9698ce"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("6adf9c14-c845-4d09-bcbe-5814da08ba50"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("6ae04b0a-4b6c-4f7e-aa6f-b6285fe46b2e"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("c9f96a22-c635-4110-81ca-c61546b697eb") },
                    { new Guid("6b085f12-7eed-475d-99b4-fec00b6b5a85"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("6b14dfdd-04a0-46e6-8b25-68ce2c8e7cb5"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("6b8b3ee3-10c6-4df4-8219-ba8479965141"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("6bbe7b34-67fe-45c8-b5b7-7d1f8142f4f0"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("6c5cb71d-d228-44c4-b5c6-0356ecd49d76"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("6c5f1788-c5ed-4399-9085-02df3cc4239b"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("6c8a54ab-a98f-4965-9288-3dc13de2764d"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("6c8aabf5-31c1-4209-9b5c-79d45347fdb7"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("6ce41ba7-6a3a-4e17-bf87-fe21742474a2"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("6d2ec853-1739-474e-a8f5-af797c409871"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("6d7119a1-a39a-4437-8538-7d687684403c"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("6db5c76a-f54a-415c-9804-fc9b022a404c"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("6decc589-f6da-4075-8369-8a66b7a477d1"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("6df001af-82fb-4d3c-9667-6efbd694821f"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("6e07057f-77f8-4460-8068-ab02e9862b8b"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("6e5f139b-107c-42ca-b976-162b075adbc5"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("6e788ad1-313b-4f7d-a2bf-782cc9b9601d"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("6f1d6de7-5c22-442a-84aa-22f79fbb839b"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("6f2d6293-1807-488b-b4c9-d92c5d1a7863"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("6f2e1672-b38f-4de4-8f67-6df9bfc47707"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("6f8be047-2f93-4891-a98b-95851407244b"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("6fa4f137-f200-447c-829c-d1647ea87a1e"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("6fadb3ad-a37a-4a8d-b0dd-bbe7f890f197"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("6fb5bbaa-fafa-41d6-96e5-b1e0935b5a95"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("6fb83277-f288-447c-ba5a-d0cfe3505c3b"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("700efc1a-800b-4c02-a351-d487d5e530be"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("704e1817-5216-4154-9f51-bbc5dcbac90b"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("7062fd45-9ffc-4997-b426-d44ca35b7c22"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("709629c0-77b5-4c16-8f92-5abe3a24f5a5"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("70fc28d9-69d2-4f2a-ae15-7c090f89d5a4"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("7133ff38-cf12-4a0f-90db-ac2fa1cb3a9b"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("71b6b26a-aca8-4732-818b-2f82d6c68174"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("71ca327a-bd75-4300-a36e-f9792b78ef85"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("720e9efb-ca07-480e-8c88-f4fa2a29d913"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("72332e13-ec48-41f6-9ab4-271b8b1f9b3c"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("725674b4-8497-4508-8d3a-5c527e5c395d"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("727ffba8-b813-4776-9115-c3d18747e7cb"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("729c58db-c5e3-4f55-a092-2b63250da48a"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("72ba7f3e-a0a9-40d9-a674-633e04b202b1"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("72cc8c84-aa22-4e51-b875-83401e422140"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("72e10662-022e-4993-a268-b178abaef3ed"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("731c25d3-1111-424d-a351-2fabfba2725c"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("7404cf8a-df07-4383-bbd2-6652eae39459"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("74527cce-7aa4-40ff-83e8-4beb0478c857"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("74717852-3058-4dc1-9c16-ec229a62674c"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("74aed8d0-41fa-4f15-9c64-488e7454e8f3"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("752c511c-27fd-45e7-8270-8f3bc4834433"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("758dd793-c539-41b4-88d6-38da3b3063bf"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("75e1548e-6afc-4102-b051-8adae7955f5a"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("75ee2874-768b-4aec-b759-853f57e0e6f9"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("76041216-b085-42ba-a884-d5628fd26670"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("21a87461-4c65-4ae4-8d52-94ebb7ab2736") },
                    { new Guid("768bc67c-f04f-4434-aabf-c73b7313ce33"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("76c08c0d-cd71-4ef0-a739-fe3428db6119"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("77199e7e-1f1b-4a74-b916-615eb1e0c887"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("7767705f-233c-4605-a09c-beb811142c8d"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("77ad3a5c-713b-4a74-93e0-0845619abd1b"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("77d994f9-9ba2-48d5-a7e5-6ab91cc8da37"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("77e22a45-1d73-47fd-a140-c9af678f5bd9"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("786ef813-bdf6-473b-983d-095e41c2a221"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("791aa7ff-6864-4e97-95f2-5565772547a3"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("795ea2aa-c212-4659-ba51-5e2cf6c711ee"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("65c4a088-c532-4f8f-9dfc-5b26e507a58c") },
                    { new Guid("79b1a7d4-934b-48be-a265-d5643a7d8ee9"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("7a421cae-6069-4172-b85f-994de3118f75"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("7a8a2546-d872-4e92-ba2d-7afc3d92ce97"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("7abfc5ae-3750-4234-a2c8-be485cb86066"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("7b02fd6c-4a5b-491b-8d65-64e6468452ec"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("7b0b9736-b17a-423e-9a17-069ace388e58"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("7b2677d6-668f-44a7-bb60-a57f0aa7927d"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("7b4cd63c-e64b-426a-87a4-7c19acacaf72"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("7b5e6451-b945-41d2-8ad3-000259cf3d6f"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("7ba2ec7c-f593-4a16-825f-7f6a1bb60d96"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("7bc56bd6-3cf5-4cbd-8650-ff9957133afa"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("7c113b27-9098-41ff-8785-3a26fd0e0ad9"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("7cd022e9-1065-40c2-a3c0-09970fa02a39"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("7cff63f8-1624-43ec-9820-d9f250d532a5"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("7d2f9db9-0cbf-40a6-a585-0ec70535b247"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("7d4614d6-aaad-412f-852f-a1c42461a5ef"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("7d5c29ff-ca38-4221-b1e3-7a8613cdef12"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("7d755f7a-ea97-44b6-acdb-35b9559037f9"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("7da6d080-5a7b-461e-98a1-cb888acea938"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("7e327feb-d742-4fd2-8b0c-81180e73246e"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("7e658a4a-5cf7-43ff-8712-1a4a1d2d8150"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("7e74a7f6-518f-4ec1-a38f-c0024ed81d3e"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("7f60813d-c6f6-468b-919a-2810161bac57"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("7fbe6fe4-ca8b-4a5f-a19e-dab5a2d3c021"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("80893288-ce15-4eaa-b270-3f891d2d2f24"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("80b3df4d-8c0b-4478-b4c7-93e93d18bcd1"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("80dba747-7e03-40c6-8f67-405c809bf9ed"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("8177f55b-d732-4b28-a7b8-3eb5bce4c64e"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("820909f8-3faa-4f7b-b3cd-30c12a1a4410"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("8266e981-fcb5-4cd9-9c3e-9d1f73bf0b1f"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("82bb8ddf-300d-4ebf-999c-1118e2781bce"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("8361b663-9526-4fcb-961c-f45a0f8961e6"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("836b3118-f238-448d-a20c-953970e1718a"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("8392837b-cca9-45f4-b0a6-49e593918a3c"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("83c6c865-eff5-4595-ab58-54d031bced74"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("83f702ce-8c35-4555-911a-9f8de90e476f"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("84066a6f-6083-4b56-b1e4-6a208341953b"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("84b417c2-6f2d-4c92-b5e2-05542ff8e434"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("84b46dc3-ba71-4c68-929f-993c046b7d75"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("7baa5596-e2d7-4b50-b902-dcd007b07174") },
                    { new Guid("84fce446-9c26-485a-bf05-502e85b3995d"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("85367638-bf96-42b3-80a7-5598945366d5"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("854ce1a3-61f5-4126-a254-a541d01af384"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("855ab040-bdd3-4e92-8cc4-3793af4752d7"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("85a5de5e-ecfd-4835-a72b-6fc3d5307a09"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("85e809d2-2322-4b52-9ce0-b677d4000294"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("868887be-65b8-43a2-80be-ba633a627c5a"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("86b78a81-efa8-4701-909f-102a91f77d81"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("876d1502-ae35-4dc4-baba-57ff7c61ff23"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("879b8a1b-5ba7-47c1-b42b-376bb8bb48aa"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("87a074f9-a180-427b-9761-fbe499b34453"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("43ffc7c4-9a48-4756-8cdb-995287f99951") },
                    { new Guid("883d3678-613a-4449-b3ce-a1fda0a9a1a7"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("88555f9a-f961-4398-96ac-accf510017d7"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("88688215-9b3e-41a1-9f8c-d53338653160"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("88c02ec2-8dab-48c7-9b3f-5b829104acf6"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("8912e238-f97f-4682-93c7-75903001a3cd"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("89d664f5-fdaa-4a7a-b15c-1ea000357da3"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("8a34174c-cdd8-44d4-97b9-d7192ed75564"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("8a56a3b6-43b7-4c0b-b934-04daf526a5a5"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("8a8a44a6-1ac2-4057-bfff-d5722195fe7d"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("8b00ebae-13b1-4ced-98e2-39ec039d0e00"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("8b5a6529-3bf0-4dcc-86b8-3f0a96c8dbbb"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("8b7dca36-8133-4312-9a22-d6a81491e377"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("8bb53070-393f-4dd1-bcf9-b00ac2c922de"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("8bd26b93-2ea2-4e5b-a066-a486bbcf5425"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("8be2055b-bdd1-4ba5-ab2d-4c987b47dcf8"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("8c1494cb-1b04-401d-a06b-71388704b34b"), new Guid("d892e510-6266-4ce0-8bcb-2043abae12ff"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("8c4c562b-06fd-4c8a-8276-24b3de380fe7"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("8c68b21a-bb84-4bc9-a1b3-f8d71fe9e1d4"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("8c9849f6-d86c-4d22-ad00-bd398b21cf88"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("8cb65e49-6d3e-4aa2-baca-3f44ef7e9f8c"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("8cbfc8da-6878-4501-bd54-cf427636fe8e"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("8cfe2360-ba4a-4665-92eb-1a35c78667b8"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("8d0f7292-4589-44ee-8077-7246acb556ea"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb") },
                    { new Guid("8d526832-8751-4838-bb13-95cab4d2eb82"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("8d662431-a7ce-42cc-9c28-2380a41cf641"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("8d6d3b42-2bc4-4318-8cb2-2cfb88d448bd"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("8d81ee1e-da83-481a-9d43-4c15adec2ed0"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("8d93ecd4-55e1-4d37-b0f6-3eefac2eb369"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("8dcb31eb-4f60-4786-a87d-ff91ed1bfee9"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("8e3c6434-9532-4d74-adb8-bd498f37985b"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("8ec1a67c-3dd6-41c8-83fa-21050b104902"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("32537a20-8617-4a11-8799-87c758b59a29") },
                    { new Guid("8f6b2f18-4f74-4e82-b46a-5ef292ccfee3"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("8fafe9bc-af5d-4201-8257-c308bc911ef4"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("8fc9f9dd-8dff-4b62-b5d0-2fde3ce3eb08"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("90542f85-589b-4c1a-96bc-57865c9c0467"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("90df2fc0-6d9a-4459-9640-8cd6e644b391"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("9176a659-6131-4474-b49e-0f6a474b2ec9"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("91a376df-4ae1-4954-a670-b2d8d5adcac8"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("91c6f365-8ad8-4e54-8d0b-135b2ba98790"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("9259bc5c-3318-44e3-a282-e7d665af9b15"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("9260fcac-3fda-402e-889e-9d4fe6fad56f"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("928faca6-84be-4ba2-88f1-4464bb7aafba"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("92ba5768-aece-4dd8-ab87-98e9650dc3b6"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("9307bc81-7588-4eec-882d-27e58af3f158"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("930cc2f2-9a62-4cdc-b06c-572816a2457c"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("93647824-cd5a-4e5e-bab9-bc292430863a"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("936813fb-9f6e-4fb1-8561-4ccbaa9788da"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("93b84546-ba52-43ac-a071-cb9bbd58c8c3"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("d88f38e8-f392-424c-9c7e-1eb1bd8b9567") },
                    { new Guid("93bef201-1eb9-4d91-b86c-426f7364ea01"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("94002344-0174-4344-961b-b00804dae530"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("940d4e6a-c712-4d48-aed7-937a29cc602d"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("9434dd3d-ae41-4365-b377-e246bb9a8224"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("9454b7ed-3e0b-4e65-aede-599964e4f0eb"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115") },
                    { new Guid("948101df-c04a-4f5f-9a67-37622af6e27a"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("948e54f7-27e7-4219-b6a8-86945849ef80"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("949b70e6-1f01-430a-939e-69a1170f546f"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("94b04cb4-17b5-4f68-8f7d-1c97308df492"), new Guid("25653fd9-934f-4cf5-8949-2f0fb1c39c25"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("94c552fa-ef02-47a8-8784-5f30d94c2e99"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("94eedff6-5d32-4856-84dc-af3c3cb27ae8"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("9528a0f0-9809-4d96-adcb-243e31c8b1b6"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("a878ad72-36e4-445c-a43f-0e15af493544") },
                    { new Guid("95474d14-c402-42da-a78b-e6601e741a03"), new Guid("298e042d-a09a-4932-a2bd-8cc1a6546203"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("954ccb2a-f2a7-41df-bf37-fd31ce5fb103"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("967f777f-1316-47ee-98f1-b2396e009d26"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("9697f9e1-5720-42fc-835b-adf7ba3bb33f"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("96befd49-bcde-418b-899b-941824d06f92"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("96cd5217-67a4-405a-b504-3306ce8d83e4"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("96d478b0-266f-45a8-9b58-670636816cee"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("97533cc1-0cbb-4a3e-b545-a13d6468b5a1"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("9766b780-819e-403b-ad3b-6a775a0dde0d"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("979d64bb-63be-426d-8f35-879ed65d2c9f"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("97fa9ac2-a882-47c5-8e48-5adf2e44c41a"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("9806124c-234b-4687-93e2-8f171e09eddf"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("984388b7-852f-4882-88dd-720827c1615a"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("98440c5b-ad21-42aa-bc6c-6e4d5534761c"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("98d246f3-ed8c-4c5d-bc82-cfd19677de96"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("9949465a-fa24-4a65-a266-892d382e5a19"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("99d2d185-2906-4055-b0de-85ef7a69691f"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("99da1bba-fffa-4a59-a1bc-8379bc477146"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("9a26496d-682a-42b6-bfb6-609cf57eb8c5"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("9a572841-1eff-4527-9a17-235c4cb922e6"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("9ae3605e-4956-4382-89ca-b4cec0a7fd41"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("9b2e7d5e-5d00-4605-8285-7d65f305779e"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("9b346f47-56d6-42ee-91ee-06c34f84125c"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("9c09b91c-e40f-4d4f-a8a2-9ce68acfce34"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("9c362c03-eb80-405c-9d34-be74221181a1"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("9c3cefb3-87f0-4a5e-9b67-cddda1de6abb"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("9c9cf259-316a-41b3-85a4-f89d76f276d3"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("9cbd37ec-b0d8-4627-be9c-d3a6546c4c0b"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("9cee99b0-b575-4524-9349-31cfc73260f8"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("9e0813eb-5012-4250-8fdb-c043bbc9058c"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("9e33ec3d-4832-4a70-9107-69765f508c25"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("9eb87817-ed0a-4617-b6e9-005a6a1b8457"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("9ef10e39-a561-4c1e-80dc-96eef63c9c10"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("a018fa92-1fc7-45b8-87da-ca5b8c2ae910"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("a048e18e-a66a-456b-bb39-60e001f50063"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("a05c046e-5919-4155-831f-28d24aa388e2"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("a0c54b73-f0b6-4632-a8a2-ea044820649b"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("a0cf99ea-a9ed-49fb-b5ba-ade1a2be20e9"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("a14d2049-dbfe-443e-87f0-94a4d4d5c22c"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("a2a319e2-0fe3-48a8-9844-b997bd0ec6f3"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("a30d94a8-d9bc-498c-a001-55bcf1b86eed"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("a46dd77a-6ea9-43a5-ad07-ec7c6bd026a9"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("a4858bf0-9161-4235-86f5-351d2f49d87c"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("a4976801-a65f-4a72-a201-3a697e96e9c1"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("a55cdf62-3d28-4879-927c-f3ec623ac33b"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("a6234a2e-64d6-4d90-add9-90c5513440c6"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("a65a5aa0-6b58-45f8-930e-579848c8296a"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("a6903748-b70c-48b6-91e1-e4be9fc0dc2f"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("a692a197-a555-478b-b427-939239e0964f"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("a76bade1-8760-4b15-8133-417aa4a610a0"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("aca2f9b1-06f2-4e3f-8a3e-638fb7c1d35e") },
                    { new Guid("a7a25fa1-72a1-401e-85c4-9359f56f9832"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("a7d389e4-ec05-446f-beba-2fb0b1c38e0d"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("a7f20a43-2489-4f13-8c2c-57cdb68301df"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("a80b985a-dbea-497f-aa55-eb4a45e34b49"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("a89266b8-c632-403b-a455-eed9b5c624d0"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("a8b01c00-e445-4eca-8912-84a1e324fe63"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("a8b63c6b-2002-43f3-9fe0-30b349b000fe"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("a910822c-2bf8-4faf-9c2c-c184246b9dab"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("a9235a60-0c53-4a5b-acce-0198cb52fd05"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("a9644080-816f-49ab-a44d-6e4a27fb94c5"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("a96c5701-6a05-4665-b064-259afef73355"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("a97d3fa3-9d7f-4dc6-a14b-a4b2ae40c3f4"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("a99c7bdc-d785-4ac2-982e-63eb31fc690b"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("a9a77f94-9edf-43e7-ac17-543512007025"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("a9c6194b-192c-49e9-8305-bcdbba5af8f1"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("a9e3810b-a190-4e25-97e2-d3f650d651be"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("a9e9e857-8792-4965-b304-63635eb6809f"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("aa781b8f-172d-433e-938c-5b85d259d391"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("aa89913f-c8d6-4fdc-8c6e-badc4c63cb4e"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("32537a20-8617-4a11-8799-87c758b59a29") },
                    { new Guid("aa8997f7-5265-4a8c-b0ff-2eca8e92d718"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("aa9e0aef-12de-4f66-ba24-ac67196541e2"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("ab2886cd-f78d-4e67-9615-4ad9616aa6a5"), new Guid("1afb7d6e-28ca-4d3a-93d5-3a17d2a19989"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("ab833cad-01b2-4a3f-9bc3-126b37967643"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("abf3f2e5-0995-46b4-8f9e-02aa7cdec974"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("ac0225b7-2186-4292-89cc-5bbdda67dd94"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("aca22d24-dfa9-419f-b2cf-269f84b81c5c"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("acce8d19-1e7d-4c87-9872-0708e2a6886c"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("ad2626cc-bfd6-431b-b79d-5c937af742c8"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("ae096182-a25e-4dc8-bdcb-b860f5c97e44"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("ae260dac-fdd9-450d-b7f8-e11d61dc0bdf"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("ae2df375-2f59-4d03-8dcc-555a4d5d62fb"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("ae2e5e89-cd3c-4b52-b079-c556ff475f9d"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115") },
                    { new Guid("ae492fc9-5ff5-48fb-97aa-3fb7758caa28"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("ae89fd1e-015a-4014-97c2-abdb9ea0a2b6"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("aee2563c-ff66-437e-b4d1-6a0d3111470b"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("aeeb3d05-8be9-463f-ab19-d8d045459940"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("af124ed7-c8ff-441e-a111-85687155cda0"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("aff7d420-f780-459e-be9e-f62230d31e2d"), new Guid("298e042d-a09a-4932-a2bd-8cc1a6546203"), new Guid("1f204390-6649-40b9-b6eb-22c61fdd49bf") },
                    { new Guid("b022c96b-d363-44a6-a773-7247eb394087"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("b022efd2-f8cc-4b66-86f3-cff8f1b19962"), new Guid("f5904a45-8bd1-41ee-979e-f9769b5006c5"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("b09baf5c-af40-4a2f-a203-1c838fd08c9c"), new Guid("fd7482a1-35bb-47b2-99c6-4eefef59cb45"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("b12c3d71-9544-4794-bf8e-e7580796b506"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("b13c808c-c091-45b1-93c4-aeaa1f45db7d"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("b170b71e-3966-464b-8ad3-07a55ce55c70"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("b1f508dc-99ca-4cb3-98d4-f98dff2e0409"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("b212a5f7-8186-4c44-a0c4-c41726327741"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("b21b5f0b-2f09-4339-9028-e5670edb19ba"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("b31e45dd-d903-4cfa-9228-d72409f24c79"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("b347965c-2d93-4856-b26c-2cc60f747178"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("b360ac72-d68b-4ec5-a812-6921d0f7556a"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("b3871a96-bec5-4459-bcf3-e0ef9e361109"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("b3bc54f7-2df1-4046-9395-07d04d4a9262"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("b4207479-1c36-4586-b04c-08a1239dbbe0"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("b457fd8d-c0b7-4c39-a035-1bd3ae284039"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("b496d637-b66a-43a7-a325-e085f5d3502c"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("a8936d79-2046-4d64-abd3-2603eaeca83f") },
                    { new Guid("b4c1a0f9-84db-44f2-a945-9e267a8949e3"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("b4f4a3c0-6df9-4536-8304-49e185eb18fb"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("b5374399-21e5-431b-a208-b0b99bd3a491"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("b543a169-73ac-4d8c-abf2-6fe20378da9a"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("b55e9441-9f22-403a-af2f-c291dda855e7"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("b5961432-c3a8-478a-a27a-c57232545e04"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("b59a12ab-8952-474d-8d86-dad9253e68ba"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("b5bb116c-1ce8-49cf-810f-04bd42ef15f8"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("b5dcfe57-b162-49d6-988a-74e69a4ed09b"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("b64394ec-6a4c-4c4e-a792-30128f11f15b"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("b6672973-272f-4ba3-a093-ae01d3d65fdf"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("b6d2f209-9866-4dce-ab7c-d3fcceebc41a"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("b6fa29d8-21ec-45ce-b747-8ad450163f31"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("b741bf6f-9e75-48d0-b514-54be477031d6"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("b77c2714-673c-45b8-9893-f7fc7af912da"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("b7970a25-42a3-4ff9-af3e-435002fdc642"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("b7c29e97-2722-48e7-94eb-32cae579ad2d"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("b822b02b-dfb3-469d-9aac-58b875c3cc69"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("b8d1b71b-f57f-482c-816d-0509fd70bba6"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("b8dd3549-b237-4d4c-8659-018420c451f6"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("b8e96b62-1e57-48ff-a378-fd0c9f46de52"), new Guid("f5904a45-8bd1-41ee-979e-f9769b5006c5"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("b9304197-925e-4a17-ab20-de0016530ddc"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("b932164f-2064-4ac7-b533-c6183470f452"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("b93d3374-7925-4e7c-a51b-d8d83a7d4f47"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("ba022ca3-9861-4d6a-9892-9aba144a49a7"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("babed7a7-88be-4e97-bc42-a1d7cededd9e"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("bae671a4-2bfe-43bb-bbe2-a4088131936d"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("bb762903-a72b-457c-99a3-9eea82cb3559"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("bb91b3fe-0a72-4dd2-895a-370a4e46f84e"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("bba868c5-f0d0-41ca-b6ed-5b691e1c3af3"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("bbbf5121-6d1c-45b2-8744-2f1383fe4401"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("bbe1e643-3cfc-4165-9df2-8255678053ac"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("bbe72913-e9b1-4dbe-b4cc-44f64cd30a6c"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("bc3356c2-830d-46c4-892f-ed0490997455"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("bc4fdebd-5ce0-4184-867d-741abe945dba"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("bc52c11b-7174-4ebe-8d1a-7b7d27cf0d77"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("bc667891-9e1d-4ad9-acd9-20bc296b6a6c"), new Guid("d892e510-6266-4ce0-8bcb-2043abae12ff"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("bc906e23-a7ce-4201-a0b1-cf0865524bca"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("bcad2de8-5b39-437c-b1b3-43a39d0d7d82"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("bce9c2e9-86e5-47e2-8506-9cf8010527db"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("bcf5c5c2-adef-46e4-8ee5-d4619df71cc0"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("bd2d5613-552b-4379-974a-6119f941e969"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("bd387cc8-92da-490d-8721-0efcee5db619"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115") },
                    { new Guid("bd4f0b5d-be91-4b3d-a86b-3a773731d73f"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("bda0ebb8-2be3-4ffb-99b8-b2aec0ae227e"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("be227b20-d6d8-477f-9f5f-fe02dbd65d00"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("be32a687-60fb-49bc-ac6d-6a4e373241e5"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("be429e91-5638-45f3-9625-853b95017e00"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("be4f6a97-efaa-4a93-a4c1-bbc6445885d6"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("be5c7ca6-df12-489c-a231-caf312a6ad19"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("be720b7d-fbf4-4ee3-a0e9-d4bef14ae854"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("bee948c8-ad18-448b-8226-8498a8514603"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("bef10675-aa00-41a9-a2ff-09293b10e9e3"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("bf235640-4bbd-4b35-8301-77d30e48af58"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("bf6d05dd-18f0-4778-ac23-0898a188e05d"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("bf917768-49a8-4720-8b85-c22027fb6c18"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("bfa4594a-91b4-4b85-bf58-4f94bf8e47dd"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("bfaf2fe6-3cf9-4fa1-bf86-5d7a2bd8744f"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("bfb6b5ea-bd93-4c10-88aa-73741e462ed0"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("9f2f8b53-98e8-41bc-a79c-d454f86d51a1") },
                    { new Guid("bfcc384a-5b2f-4d95-bf6b-feb779023593"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("c0450246-de99-4636-9f3d-0a22632fac1d"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("c09ecf08-a6c7-4265-854a-04ea42a2f007"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("c0f9bdaf-f0c5-44b4-8591-d7b219ffc83d"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("c1158829-395d-48fc-a2f2-5b73f5218b52"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("c14d79c2-083b-44a5-89f2-16b1c55bd7d6"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("c1d9e4b8-5160-425f-989a-7b8bb6f69456"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("c1e33798-0a52-4979-887c-105d4349a184"), new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("c25ba2fc-3c37-4c84-8c84-7ee002a0cea9"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("c2fca300-f29d-470b-8511-ba47e996a0d2"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("c32686a3-d426-4870-aa59-7dc10fc8a146"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("531f34db-dd0f-484a-af6f-d1c0a1405a33") },
                    { new Guid("c330a0a1-dbba-48c9-9b57-9dc00fbfdaed"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("c40d311d-2bfd-4e8b-a028-321c0bc973fa"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("c43ac5a0-8e24-4a5a-8596-faf516bb18a6"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("c47ca40c-4102-4ff3-9e74-4e7eb7476699"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("c4afe71f-c76d-44f6-b1ec-90e16c0bb522"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") },
                    { new Guid("c4d068cc-04e0-40d8-93de-9cc88ce98bb5"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("c4eeb8e0-4193-4cd9-ac87-c84a00f49690"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("50b1510e-1e80-4090-bcfe-6442c1b6299d") },
                    { new Guid("c5189404-4082-4e98-8acf-579b35ca188b"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("fab67452-75c3-4f03-a662-36d980d8ab98") },
                    { new Guid("c560ef2b-0f91-4f0c-9664-b05f8c7cb4a1"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("d88f38e8-f392-424c-9c7e-1eb1bd8b9567") },
                    { new Guid("c5a9a7e6-6b85-4564-ac84-33756bd82b5c"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("c5abfde7-fc87-4af0-9b3a-116b41da9e88"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("c5d18069-d4d7-4014-b7ea-02d7394c5a3b"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("c60cdb5a-5740-4621-b850-d8ee3b8badfd"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("7baa5596-e2d7-4b50-b902-dcd007b07174") },
                    { new Guid("c626f0d1-fce7-45a1-b01f-bc52feaa459a"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("c692fba3-e136-4327-94ad-45ee27503a1a"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("c72bbc0a-8806-4012-bbd9-c041f4b5def5"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("c73480c0-da1a-4b20-b765-4d0b0dec1951"), new Guid("dfe45fa5-3bfa-40af-872a-56dc5195049b"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("c7397914-87e8-4c12-b9bf-5a71c1cd5845"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("c73eeca8-3c7a-4d72-97f9-775bd4b97af5"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("c744c45f-44ce-4bf9-9aa0-9039521eca7b"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("c7cb43cf-9317-457f-82dd-97d09ddc9142"), new Guid("f5904a45-8bd1-41ee-979e-f9769b5006c5"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("c7ec0475-fe40-4fe5-8fc4-c0f6b88112ef"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("c7f5df97-ad01-494c-9e7f-8a19be4c3994"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("c80cb957-29c7-41f9-8271-9a0db37f470b"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("c879cfb9-b081-4b49-8a25-37a0dae5be12"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("c94cfd3e-d70c-4219-ac69-85598994d0c8"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("7baa5596-e2d7-4b50-b902-dcd007b07174") },
                    { new Guid("c975f8e6-adab-4060-b607-2237022f8617"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("c9b0730e-b94b-4b85-aaf9-bfe53fa137ea"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("b3dc9f64-9c77-42db-b533-833ae60091f8") },
                    { new Guid("c9b873d8-2d15-4f25-8765-81aa5e3467cd"), new Guid("865ad9b9-3364-4424-bb00-0c9a3e522d71"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("ca02925c-6817-4779-bc32-f1e6c8364217"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("ca8178ee-4ef0-4ef6-b245-96dcaf280996"), new Guid("cd9ed13f-9c6c-4adc-b21c-8014f3fcf952"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("cab296bb-b7e4-408f-9521-0e57b7ef6c3c"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("cac9e309-1e12-40b6-b42b-3c9354e3f77f"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("caf98c29-78d7-4565-bb2d-e668c04d7053"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("cb282322-460e-44d4-82ab-0b815fd35909"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("cb2e1787-9901-48a6-8ade-bc181ee0feaf"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("cb3e74af-d279-4c68-b59f-aa17b8e260b5"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("cb780ef8-4fd4-4620-bfd8-f46cd620613e"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("cba3be53-5aa1-40db-b2c9-732565b3960e"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("cbd6bd0f-a735-409b-ac48-eec9708db05e"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("cc2dc7f5-0a42-4fe2-a874-fd9824d65322"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("cc92f804-5b71-428d-ab2b-c687e4b3cd33"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("ccad8bb5-5cca-4353-a06c-8233ee4bcbb3"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("cce3fa3f-c9bf-4fe9-8e4f-6f4916b6f37d"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("cd5026f4-4280-4c57-ae36-2c3f828884da"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("cd564d9d-eadd-4274-a6a7-d61d71169fc1"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("ce199da9-5c37-4bab-a0c4-161486951aa0"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("ce41930e-3c5d-44c2-a30a-3805fcede63c"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("ce5012e5-ee15-4c38-ad7d-d47cd5f7a396"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("ce6c85c0-b0a8-47d8-a18e-6cfe9fc3acff"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("ce707fd1-c0e6-4294-8193-f6eed058a0ff"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("cedc6fb7-c64a-4340-89dd-456f03d37392"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("97b3e1f0-0c91-44f3-8d0c-36cb9cb1d23b") },
                    { new Guid("cedfe951-b1e7-4a50-a9e8-0358dd5df703"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb") },
                    { new Guid("cef7ce32-279b-4139-b891-8b5df16daead"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("cf1b07cc-4d4f-4ddd-8363-dba257de76af"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("cf648a38-8c0b-4489-bb2c-14aa99872dea"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("992b1044-27f3-439c-9caf-520c6bcb2656") },
                    { new Guid("cf6c0012-4323-42de-8121-2052341edc72"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("cf884d8e-596f-418c-a194-e4de824ed00d"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("cf91f831-325e-43a8-bc89-b9661aa6ac60"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("cfdc8c65-d346-40b4-a864-a42283f2603b"), new Guid("9444d386-8e1c-4ba6-a46c-2628303f464f"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("cfe266b6-8b07-4723-b5dc-9268b96fa6d8"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("d01abf8d-0c72-4fa4-86f7-666340e82cc3"), new Guid("7a902c5c-f54c-40d9-831a-8a94e078d3e1"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("d0509d10-8d4a-4287-8e97-270646d3a987"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("17281ecf-67ce-4ee3-b1b6-a6ad0763047e") },
                    { new Guid("d0b45f85-ec42-4acf-af1a-896bafb9ab35"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("d0d313e0-cb72-45f2-a3e8-d18fd27749f8"), new Guid("cec82646-1194-4732-aafe-5ba189f63e39"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("d115e3e0-f116-4e2a-afa9-85bb211723cc"), new Guid("cb2821a5-a045-4fbf-9b41-a6e1a20f7bb8"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("d1723a31-519f-4936-89ef-229a1360c8a6"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("d252555f-436c-474d-be78-388b4b4e8c72"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("d25317ae-f75a-4731-afb5-92fba863d66b"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("d25dc368-97ca-4ab9-9f45-52db32937ee5"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("d26019ab-ce23-4e81-b45d-39837ce47811"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("d2967d79-ab85-47d0-8308-b554bd949e17"), new Guid("d11790c0-f3a3-4874-9f76-b5ef965c2040"), new Guid("65707b15-7d02-48a2-a9cc-486e74f25d61") },
                    { new Guid("d2c6d4f0-6e04-4778-be54-b373f8d83538"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("d3a21272-159a-4a7d-a2aa-cd3d053ce9ea"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("d3fab206-5b93-44e1-92a7-c839211c3a0c"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("86a97da7-9e5f-4b4d-967e-e2e672664cc7") },
                    { new Guid("d42a65c9-8ded-4318-b7e6-2c4ee8ab3e83"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("d44fa75e-56f3-4480-bbbc-b58c91ac19e8"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("d478ac2b-8e85-47bf-8510-a0a00d8567e7"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("d48cff88-2f36-408a-83d5-5014a5e7c362"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("d4906b65-96b7-4ad4-9a1a-5f86e761b31c"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("d595b2b9-ab72-47bd-8b32-611052eedb80"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("d6451af7-17ba-418a-af97-6345476ea99d"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("d71cc2c4-b59d-4dce-8089-7b7d0cba5c31"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("d74d4a01-945f-4345-92f4-c210dad2ea25"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("d7838cd2-ad8e-4dbf-b177-7e9c00090d3a"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("d79bf441-e851-4c94-8929-9b0b9d49ff0f"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("d7dc0199-8b36-42dd-807b-6cc926eb7533"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("d87843cf-02f5-4ac6-9fb5-7ab684e82eca"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("d8d6ebfe-9d77-4d53-9748-88f53c35a74c"), new Guid("d05ac51c-2f01-492f-acce-22ce45ab462d"), new Guid("f80db298-ca3b-4227-878a-0aebfbd66efd") },
                    { new Guid("d8e24048-527b-4e14-83f8-6ad88f8dab63"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("f75a99be-6f8a-48db-9f6d-e9c91dbce53c") },
                    { new Guid("d9419896-1cc2-4520-a9a2-2aa63517a625"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("d97c97a9-c466-4c6e-8789-12b0b2d72ea8"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("d9964ab5-6784-4594-8c14-9ab441e96648"), new Guid("39424747-fdb2-401d-8305-b8542a10331d"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("d9ae84fe-e512-46b4-930d-ff790d18b0bf"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("702ce65e-30bc-495f-bdb5-80439b79bf3b") },
                    { new Guid("d9ee9ce0-dc76-478a-b136-7f03d409981a"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("da13fdd1-2a27-4896-92b2-ed3e2f1790b5"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("da469fa2-c697-4414-b017-de0a28e601d0"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("da4c2e75-ade3-44d6-9806-9af0b081ad91"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("da758238-888e-4cf0-8405-bf9142bba82e"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("01e2cdb3-beb1-48df-8eb3-4f90861a0a1a") },
                    { new Guid("da8b47f2-140b-47f5-8d19-4f2a53660915"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("daaad945-89fd-437c-add3-456e82fbc5cc"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("db66b453-73bc-4929-b3ba-f9492716dbf1"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("db937041-abbb-424e-9862-395c475d816d"), new Guid("2f3ed65a-2c9c-4859-bcfd-f69f866e09fd"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("db94a7c4-8f0d-4ae0-b693-1d9c74e1f0e1"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115") },
                    { new Guid("dc6138bc-9630-47be-aeb3-47eb658f06d2"), new Guid("0a2ff23f-6279-4fd1-8bef-93727e159d76"), new Guid("ecd0c4fc-fce2-4d8f-b76a-0dc5508e9938") },
                    { new Guid("dc9827e3-83f8-463b-8c69-962742a9ddde"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("dd0072ac-8b9e-48a0-b11a-e90699bed6a6"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("dd873dba-d40f-4e60-8f21-68c59f917a37"), new Guid("135ba6bd-093e-416b-9016-891aca85ae5d"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("dd975a7e-c82b-43ec-a1b8-68f9718b8612"), new Guid("de039220-32bb-4e17-9577-09e7ab6b396c"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("ddd38660-eeec-4895-aadf-10e4072afb7e"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("dde07d21-4ef2-4a7f-b71f-4177ca6019fb"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("5964a13b-d318-4f5d-abba-1eb9fd998fa8") },
                    { new Guid("dde255cf-6b7f-466e-9d8c-fbe00de284bd"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("323d8527-6f14-4622-9bbc-ed5e758e072e") },
                    { new Guid("de041fb0-4ee9-45f3-b54c-f906afa25992"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("de10e14d-2193-4396-a406-eb87725bb02f"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("a878ad72-36e4-445c-a43f-0e15af493544") },
                    { new Guid("de5d7a5b-871a-4339-a8be-1126fb7448d3"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("25e308f5-4c9d-4d98-aaae-df11ed0ed8ea") },
                    { new Guid("de88880e-0c4b-4b39-baa0-b1e84809bb23"), new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("debef24d-8eeb-4fd8-bb6f-75fe4895e6ea"), new Guid("ee4dc017-cb96-4829-b96e-e7fa49494b52"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("df2c105d-3f04-4d3c-a7e6-d20211c25305"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("df2f934d-56fb-46d4-9e4f-233c42d46697"), new Guid("09fb2c8c-4650-4245-b2dd-288f75b5d75e"), new Guid("78781f6a-b4b5-4023-9be0-ae88f117743c") },
                    { new Guid("e03fdc76-c498-436b-8e39-bc48164126c0"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("e04a856c-7107-417c-b400-0fd4b7e021ae"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("1d75eee6-6a5f-4e40-aab0-8b8bbe930503") },
                    { new Guid("e0b78f20-15fc-47a1-a43a-78bcf9433f2b"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("e0b81d04-72ea-49a7-b6ae-b8e353a5457f"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("e0cffa08-a8a6-45c1-9fb6-106347013cf5"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("01808061-ab67-41d3-84db-386476b07982") },
                    { new Guid("e0de3618-39af-482f-afff-b35c74597d26"), new Guid("ee555564-c43c-44b7-8dd4-a3436a354bbb"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("e0e15dbe-f4e2-4eb2-90c8-3b44ec39ba60"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("e1197bc9-0109-4d6d-b89e-8fd6f93850ec"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("e1d85f81-5ec5-4d99-8be2-2ae1cf299bb1"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("e2150b74-39fa-412c-a557-6d35dfa1e273"), new Guid("2b27c7fd-5e31-4a04-b782-cf8b1a5784b8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("e2202e5b-4912-4c43-aaf8-9276fc19d377"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("e22a9aff-7192-4595-8910-dc789e25a4ac"), new Guid("64dbb21f-8aa8-4edb-8001-57ae84f5ceaa"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("e242c8cf-b5d9-4f85-8b62-ebc64c97eb76"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("e24e0e90-881d-4835-bc94-debd05b49acf"), new Guid("8e1d6736-fbbf-49ea-88f1-240f26d2ff36"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("e285f598-90a1-4a60-8bb5-48346d60109a"), new Guid("411ad18e-f258-48f9-a6aa-6df4f98a10ea"), new Guid("0790ed6f-5fb7-4a92-8ba9-5b21dc166776") },
                    { new Guid("e2ca5729-a355-4328-93d5-8139b5da49d7"), new Guid("8ebdd5be-899d-4aba-b6d9-721b33c80fa4"), new Guid("6df00328-bcc2-4c5f-ac40-62a6f0d7a49e") },
                    { new Guid("e32a28ea-cf31-4917-bbc8-0400ebd47050"), new Guid("3b926e58-50a2-49f9-84c1-441b933ef78d"), new Guid("6477628b-d309-40c8-868e-dda79fe2241d") },
                    { new Guid("e344c806-cff9-4fc8-92d5-449252f7b4d0"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("f246ac06-6e84-416a-b402-c83a1734bc1d") },
                    { new Guid("e34b7e6c-a4fb-4bf8-9fda-da289793e201"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("a527ba61-6fe2-44a6-a18e-20c5fa7e252c") },
                    { new Guid("e35f5341-a9d1-4f8f-8951-39242b5d2f43"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("e3df4981-e5b1-4d00-ae86-5a914a0f3484"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("e3fbd569-41b9-4962-ad1c-da0c008a2144"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("e4582b4e-cfcc-46b1-839e-d83bc4a612dc"), new Guid("05db9199-63b5-42f5-ae3e-b2d73a30989d"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("e4642cae-358d-411c-bca0-784184b1837a"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("e46b553f-ff6b-4684-92da-e9facd2bcbcd"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("e4c58abf-a3ea-4ae2-8bac-7fb36736a8af"), new Guid("337aed3e-b5cf-4957-adfc-7c0ebaa4dcc0"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("e5f9b5cd-659e-4bfe-8361-c39cfbee1925"), new Guid("2d2c863c-8ed7-49de-9599-b6e4d6611aa2"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("e5f9d292-eba5-49f2-9c65-2320a24df216"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("e60323a2-b0b9-4b3c-ab1a-648bfef0de8e"), new Guid("d9306e93-80be-4640-ace6-2fffba2fb466"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("e60d75dd-53e0-40b5-8d01-897016997efb"), new Guid("12aeee25-9e68-4557-ac2a-5e86d3a776a2"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("e61402b7-d776-4e37-ad38-27427b7020ed"), new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), new Guid("dc3287d5-d6a2-4f3e-8f39-59b159570fa4") },
                    { new Guid("e62a3ad8-b2ee-4e97-b1b1-a927f9ce5f9f"), new Guid("b1f59f20-c457-498e-958b-520881e0eaaa"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("e64d55b2-ac3c-4209-8da2-11fb12fa21f8"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("e65109ca-3392-4df0-baae-1c8e3f214fc0"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("b24cc1c9-a972-4dae-8084-d4412a7dcfeb") },
                    { new Guid("e68e247d-1be3-47c0-bde0-2102de7ba9c3"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("e6c30064-d7d0-430b-a90b-1331b7a95027"), new Guid("5a6a3633-b22b-4995-8f3c-b4982467334b"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("e70091ae-088a-4e5e-9a68-aa8ab5c63fd0"), new Guid("d5eb9dfb-6477-46a9-ac2b-9fc004f38c67"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("e757138c-34a0-45a0-b013-784a82cafc21"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("c9f96a22-c635-4110-81ca-c61546b697eb") },
                    { new Guid("e7856d96-5114-4274-97f5-f829df841454"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("07435856-3a86-4445-920c-194c05f30bf2") },
                    { new Guid("e7902c9e-55e1-4f38-a8eb-b1a223ee3925"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("e7d87d40-0d11-4492-b10e-c0f0630928b2"), new Guid("40436945-8ad4-4232-8b83-b0762dddd37b"), new Guid("278ac733-d34b-4ef7-aae2-c8e4bb76f608") },
                    { new Guid("e7e3bad3-2224-4b42-838c-cc3df72bbb61"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("e8406f91-a396-494f-9730-3df6c4a716a2"), new Guid("ce3182d7-7753-4952-a5cf-c56a2e008ac3"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("e84fd578-74c3-4f17-afa3-346d5491746d"), new Guid("e5a995c0-232f-475c-a828-455ea78cc335"), new Guid("3669feb0-a50e-433b-a374-935381190815") },
                    { new Guid("e880f4e4-47eb-4e72-b059-56a4c5d45987"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("8cef9e0b-9eb3-454f-845b-96771eb2cd22") },
                    { new Guid("e8f20ea7-f30b-4ebf-9b0e-239a724613be"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("41e4a0d8-5801-487a-b650-ee757856edf1") },
                    { new Guid("e996b485-c051-41e7-b2cf-23c150237f6f"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("e9b15b84-8393-4839-b57e-40b714b8d028"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("ea16d745-a9c9-44f4-a979-4dfe451ae6b2"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("ea2e6a1a-d40c-4ec5-a2f9-ef8c569b98b2"), new Guid("26280e53-637d-4efa-a411-676439ea0e5e"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("ea4d0f93-2f13-4a27-93ab-9c789270deb8"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("ea5111a1-064a-4abb-a1ba-e2a153bf720f"), new Guid("fa8d7e35-8b83-480f-b8e2-75f98d324c04"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("ea7e4ee1-6b78-4bca-a9fb-4aa3a758aa89"), new Guid("5a80df9f-30ae-4a88-80bc-3b7ec8574ebd"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("ea88bad5-0acc-4fb3-9204-ca018714d0c9"), new Guid("dc47fe62-ca81-4b42-911f-aa59b4b6ad2d"), new Guid("d54d3f69-64c4-4508-9405-21ecf833cda0") },
                    { new Guid("ea8a0152-a59f-42b7-9937-c02398cbfd22"), new Guid("acf583ec-d367-4314-80c5-d06b44434928"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("eab28837-f75a-4d80-b6da-a901a5bdf747"), new Guid("07da2217-6aaa-4ac9-ae44-be6761102efb"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("eadb0f64-ab8f-4bad-8d94-8afb49d60dfc"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("00f7085a-0004-49fa-82ec-8e8aebd5be4e") },
                    { new Guid("eaf2c120-8d29-43d6-8e21-ebfcd7454e52"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("f027e5ff-9f87-4312-acb8-dee0e30e6c14") },
                    { new Guid("eb17cc2f-04c8-4021-afaa-b2b1dc400f07"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("eb710691-db79-45c2-a0be-794b45200d1f"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("3f62ec09-74e8-4952-87e9-fc9bff95d630") },
                    { new Guid("ebb37e6a-21e7-4743-9bbb-47f7f8943185"), new Guid("a9c13753-e13c-4e6f-9ca7-4d566fe91140"), new Guid("2adeaef2-649b-4dcf-a2dc-269c88678583") },
                    { new Guid("ec0def63-287a-455c-9f74-7192c74f519d"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("ec399f81-5e1d-4181-afb8-dbdf8872c76f"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("ec3bcc41-c8a9-4340-a46a-716434563cec"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("ec48693a-323b-4a68-b824-fa1ebc24b94b"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("ec7258cc-a969-4d85-9f85-2aec0b1b1e91"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("059b1c67-b495-4d58-bbb7-2fac6a259b3d") },
                    { new Guid("ecdfb85e-fa6b-4c0f-a3c0-854d775fb7bc"), new Guid("d892e510-6266-4ce0-8bcb-2043abae12ff"), new Guid("b26b0c87-100a-46e0-bd65-3632b09df03e") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("ed38167a-3b15-42c9-8390-553c9352a15c"), new Guid("1c65f386-83b1-469d-95e3-764b7ee388db"), new Guid("2071e17d-0e84-47e3-bbb1-33ec75b058c3") },
                    { new Guid("ed6b7f0f-ef55-4af8-9fda-9c3481c1cca7"), new Guid("f2d8e592-2029-4ccf-8cb8-507dcad3acfb"), new Guid("586a3b61-0304-4335-91dd-d275fbf9c0e7") },
                    { new Guid("ed9ad278-f263-4b78-8660-aa3fb7cd124b"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("896e3df6-58b7-413d-b14e-d0b40aad29d8") },
                    { new Guid("ede22f77-891c-42e8-a64b-942a69f529b9"), new Guid("8efc64df-b5f7-463a-8720-637437ae9025"), new Guid("4388839d-4d63-4c0e-a8ce-5c12e644507a") },
                    { new Guid("ee151840-6bdd-4369-8f60-8ee07c151d5f"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("50eed960-cd27-4fbc-baf1-3cf4aad480e3") },
                    { new Guid("ee173766-e7be-4aea-b787-b20b6923b51a"), new Guid("bed5ac92-4f1a-4965-b9fe-9c88d5503aac"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("ee1b802a-33fc-484a-9c06-6ceafaa83e8b"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("ee227512-f74f-45a9-81d4-ed1161135a40") },
                    { new Guid("eea7f44c-3ead-4d4d-9d40-4cdd5b405349"), new Guid("bf5ef832-3739-4aa5-98fd-b800b139862a"), new Guid("a6a36978-7e05-4470-8478-9c5121dd69d0") },
                    { new Guid("ef277746-0c05-4856-aae2-2927928b6474"), new Guid("f70292e0-2902-4f7b-b0cc-ca20e9759e4f"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("ef5de9b2-c721-4471-a8c9-163888cfd431"), new Guid("a80341c3-d738-4101-809f-cafff4f28336"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("ef654887-27aa-4a83-a56c-29b15ba36cf4"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("ef65838b-9fdd-4a2b-b38b-d6495fdb9b2f"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("76451253-5c1e-4e50-8587-b7f2883b3d8c") },
                    { new Guid("ef90c555-5b22-44de-900b-1be8c04d7d80"), new Guid("44316fda-635d-417e-bd7f-9be32ada8c70"), new Guid("2b8d2f18-0905-448b-bbb1-0ee7fbfcecf8") },
                    { new Guid("ef93e4af-1fee-4274-af1d-6d8109779fc2"), new Guid("38a95fbe-17f5-4d48-b469-d02154e8b1a5"), new Guid("be422b50-87b2-488e-a8e3-c99bfb049489") },
                    { new Guid("efad1a4d-4bf1-49c0-a065-6fc52384b5d2"), new Guid("e1d59703-032c-49d7-9ba4-881ca45193c1"), new Guid("0e708d85-bc77-4d06-b2c1-42bf0757b99d") },
                    { new Guid("efb3a062-9f14-4edd-ace7-213787fe6c21"), new Guid("3fe97507-277b-4748-9e42-c1b65585383c"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("efd53d1b-dc64-4455-b8b6-2f7f2464da50"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("32537a20-8617-4a11-8799-87c758b59a29") },
                    { new Guid("f0823d10-81d6-456b-8b94-13923063555e"), new Guid("edb65387-fe70-4879-9fcd-db9085f96fd6"), new Guid("586ab43f-60dd-4a10-ae25-a7ff197bdd95") },
                    { new Guid("f13640e9-c4f1-4745-a6cf-c8d4551f64a3"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("f1a7bede-b680-4c44-9bb3-3230967e5dfb"), new Guid("365b3878-c5d9-453a-860d-15af2dd389b3"), new Guid("13bf3756-9afb-4688-b3ce-e8dfaee99c6c") },
                    { new Guid("f1c56d09-c4f2-4845-b3df-f039a3c84e89"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("f21a888f-6e77-4cfc-90b4-1ea2cf497977"), new Guid("bd5dd473-790e-45bc-9007-3b098b925072"), new Guid("5e4fbeae-dfcf-4683-8b03-f20f0a460de8") },
                    { new Guid("f320011e-749f-481d-8fa2-320271911509"), new Guid("fff3bc82-7bfd-4865-8ec1-8783b86148d2"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("f321054b-d281-4b40-bbd2-3093f01db4cb"), new Guid("8c80b97b-1447-43d3-8f5a-391a81a30de4"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("f3784150-f715-4ff1-82f6-836aa0541c8e"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("a527ba61-6fe2-44a6-a18e-20c5fa7e252c") },
                    { new Guid("f38d2235-cb2c-449a-9757-93436adca6c4"), new Guid("4df029df-2f77-424a-bdb6-b32d12d721e8"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("f390cc6a-2614-423b-bc10-c2da19c2ac22"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("5b678467-974c-440b-844a-dec3aa124a74") },
                    { new Guid("f3d55c26-ff7e-4336-a781-4ecbbf070363"), new Guid("55ad852d-c675-4df5-a190-4961028c9282"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("f401b95b-d687-4bf1-b68b-e950c4444f7d"), new Guid("ffef3f9d-364a-4ef3-bc38-48ec9c158092"), new Guid("c9f96a22-c635-4110-81ca-c61546b697eb") },
                    { new Guid("f4c967ce-36a4-4980-9c20-53c9049b1a3b"), new Guid("b434b37f-3b61-49b0-b45b-5177a400b6a5"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("f51654a0-eb25-424f-95fa-4edd0a9238ee"), new Guid("895f69b2-d208-4b11-9c98-13e9ac4174da"), new Guid("62201585-629a-43cc-a837-c72ad82bb061") },
                    { new Guid("f5644e03-3ba2-4901-8e35-4998092f770a"), new Guid("54dd3453-c47d-424d-b6a9-05dbb7ac1fa0"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("f583aee9-c604-41fd-81cb-1fa64bf1417a"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("a732e041-7fe3-4eb5-bab5-d591f59b4bf8") },
                    { new Guid("f5ae8d8b-f9db-4fb8-be56-30b079139bda"), new Guid("6281ae27-7a60-42ca-9c69-49df6a275457"), new Guid("db10bb1c-5ab9-4f0e-b094-4ed03a5b224b") },
                    { new Guid("f6891994-e056-4e67-bd34-a085b7401673"), new Guid("cae4b379-8ff6-46d1-a902-88239275b229"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") },
                    { new Guid("f6e1bb2e-9de1-4792-8433-7ea45f3051e7"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("f7170958-80b2-4ffb-8323-5b51dcb112dc"), new Guid("4504b64a-ea0f-46ea-a082-2cce76db7110"), new Guid("5fc96859-8b9d-4ac8-8f9f-9e70547ef5f7") },
                    { new Guid("f73410f9-9c6d-4025-91bf-70483cfd6108"), new Guid("b2e3e44f-1389-443f-b352-3dadc13db980"), new Guid("be5b7ca4-e113-4bf0-a00c-aa6d0acb08b4") },
                    { new Guid("f7b8c324-59d8-4e57-9ce1-bce30eea5b8d"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("b24e50d4-d732-481d-99a7-61395c4daa58") },
                    { new Guid("f8b94e4c-1008-4e5b-bde8-af3fafea82af"), new Guid("fd7482a1-35bb-47b2-99c6-4eefef59cb45"), new Guid("3401ab95-7e95-445c-8a5c-c2a135eb6468") },
                    { new Guid("f8ca24c4-ab2f-4c5f-9cbd-29107eff7577"), new Guid("b2bcbd88-fddd-465d-b2c4-c3b788830958"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("f8caabd3-95ab-4846-a930-b8d2b17cad87"), new Guid("d5144888-f485-4d3a-8496-036cdaba1950"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("f9a4ff47-9f37-4375-8a7e-1cfccb301ce5"), new Guid("11926798-d782-494e-bc78-59b4c6d0e491"), new Guid("dbe4239e-fcd6-4d98-bdbd-375ea288b115") },
                    { new Guid("f9a9ef8b-b8de-4158-8b3a-be384c6e32d2"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("0bc6894a-c062-4876-a57e-96c92fa634a7") },
                    { new Guid("f9d1ac14-3e26-4655-a01e-c59d2a8d15ec"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("dfcdd380-c769-49bf-978d-9ea3ce1983a0") },
                    { new Guid("f9e82b33-8aca-4ee7-b8a6-6e94696b1864"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("adeae8bd-383b-4958-954e-010e4514d9a7") },
                    { new Guid("fa25b515-e7a1-4cf7-82d7-d82a9a48e0fe"), new Guid("ab86ecab-f54c-4d78-9d4b-3b3015b101e9"), new Guid("19924f41-7c8b-4d9a-b4d0-3c684478b9ff") },
                    { new Guid("fa3df100-5cbd-4fe1-b6c2-c9b6eafc8ec2"), new Guid("f1adb69c-db9b-421b-aee5-da715a2b0340"), new Guid("7e0f012d-9fa7-4d4c-bf31-1472987e2346") },
                    { new Guid("fa525016-391b-4e63-ace1-7a8a3e60c06f"), new Guid("27225689-5f9e-441f-b3c3-ceba5ab80221"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("fad2d684-cc55-493b-a19c-4fbc687d6732"), new Guid("9612ec0b-ab27-4489-ad73-45e45030e973"), new Guid("b3270e6b-4f70-482a-b18c-ef65228ce5a1") },
                    { new Guid("fae0f039-e977-4fe6-bbd1-3a9a0aceddf6"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("a878ad72-36e4-445c-a43f-0e15af493544") },
                    { new Guid("fb12220f-1036-400f-84ee-3e03563f69ad"), new Guid("8f02d192-341b-4009-84ef-21a4727745a8"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("fb3d116c-4f29-48a1-8a8b-0506c710d928"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("62d2abec-672d-476c-8a84-22f21c27f41c") },
                    { new Guid("fb43dba1-d9ad-4f12-ad92-4cb416419270"), new Guid("411ad18e-f258-48f9-a6aa-6df4f98a10ea"), new Guid("c9f96a22-c635-4110-81ca-c61546b697eb") },
                    { new Guid("fbd5163c-81a4-4ebb-8b6c-f8fcb9e01019"), new Guid("6454ddbb-b218-4f08-9920-f2422c939166"), new Guid("0c11ae72-e53c-4d4a-8099-10670882a1f7") },
                    { new Guid("fbe39df9-f2c2-49ef-85cf-08a5af62541b"), new Guid("5247b078-4542-4f15-b4f8-9ca5f75e9f99"), new Guid("ffc2b5d5-453b-4f9d-a956-a42063f53ef4") },
                    { new Guid("fbf4ced4-936d-49a2-845d-c093a45bf603"), new Guid("3a89cad3-3ac0-4179-9ae0-4f09651e444f"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("fc156781-24e8-4db8-9767-f173b8f7341b"), new Guid("4cf53495-e7e4-4190-906a-28f9dead6cbc"), new Guid("a679d02c-abd3-4320-a1a1-2e4688fa72c2") },
                    { new Guid("fc30547c-d840-426c-9e99-38fb7f65651c"), new Guid("32b33f55-adf5-4bdb-82a8-b5ecbeb6d23f"), new Guid("511990ad-edc2-423b-ae09-88307240828e") },
                    { new Guid("fc3bd8e2-431c-48b3-b370-21439356c5a3"), new Guid("28e9dae5-b3f4-4f74-85fc-faa55738832e"), new Guid("f05960f3-edd3-4d6a-b7d3-9cf8994ef2da") },
                    { new Guid("fc44be2a-cad5-46c4-9c6c-5c5d0508a265"), new Guid("e53e196d-60bf-4537-a0e9-d02102c2e272"), new Guid("700e6eef-a26f-4a68-bb10-595da9f8d4a0") },
                    { new Guid("fc4df88d-a86f-46f9-95f9-3ef0191731bd"), new Guid("74da3244-54e1-4cd1-88e7-619bb08a8485"), new Guid("5df3fd54-5e28-4edd-b880-971f9cc4a955") },
                    { new Guid("fc53d866-7818-419d-8e4b-3b77ceb5cbb9"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("8bb17fd4-f206-406c-8479-2e8f28a216a8") },
                    { new Guid("fcf124e5-99d4-4848-9a0e-e9839b259199"), new Guid("40424550-4e95-418d-aef8-ac29c9c8f4d9"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("fd29456b-fd5a-4d33-8819-aeaef870d6c8"), new Guid("60455365-0631-4bea-9472-f6ca607c11b3"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("fd2fca4e-3444-4a7d-bf56-c2d7842dca9c"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("138463b9-af7e-49ec-8cbb-3194780fce2f") },
                    { new Guid("fda1e00f-4de6-4ed4-abfe-7d5d21430107"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("ebcbc88b-2437-49b6-b93e-157fbf257639") },
                    { new Guid("fe469b2d-7f12-4be8-afe6-81f977f14585"), new Guid("5c734f2c-d88a-4cc2-801e-f3f108d32c6e"), new Guid("120b3695-da6c-4b12-afb0-4d8f114609f8") },
                    { new Guid("feb18311-1c9b-4dcb-9aaf-70cdc52985c4"), new Guid("0f937c42-7b32-48e1-97ab-2f72bc6e9318"), new Guid("a878ad72-36e4-445c-a43f-0e15af493544") },
                    { new Guid("fedc1780-bbc2-44ae-a750-40ecf3cd370f"), new Guid("6f386921-be9c-4e96-a4fb-a57a1a66ffa9"), new Guid("160ae278-a2b7-43d9-b344-c292f675e36c") },
                    { new Guid("fede4b09-97e2-4742-83f5-f22971f6cdd7"), new Guid("4d16df24-86b5-4b6c-add4-3599418a8e48"), new Guid("6e08d6bd-6f21-4cf8-a893-0e71736c3da7") },
                    { new Guid("ff39aff0-b62d-4234-9b1b-326898329bdd"), new Guid("996cadf7-0d41-4c6e-9b35-ed75dbec16d7"), new Guid("b34f63d9-4e59-4186-a94d-9e003c1e2b50") },
                    { new Guid("ff47cb04-d2dc-42b7-9cca-ffc7c57bcaf6"), new Guid("e1f47bc4-11f4-45c2-a34f-1dca099ce53f"), new Guid("b7171f24-594e-48f2-94d8-a26977aa5f17") },
                    { new Guid("ff5b508d-19a3-421d-9523-dd7af362764b"), new Guid("ce023aa6-f483-498f-9f7b-6a1102cc7e70"), new Guid("592bdf00-210a-4732-8605-b3370baee69a") },
                    { new Guid("ff5ce8b6-c8cb-4e14-8c7a-4df1efe2ebc9"), new Guid("4b903872-1cd7-4a2f-823e-b670420a7831"), new Guid("fb13b4a9-22a4-4d56-968e-adf7cf52c2f5") },
                    { new Guid("ffef52b5-6f85-49fe-94b4-b4742a00dd0e"), new Guid("4c0a4d1a-a913-49ee-a471-57b66c7e300a"), new Guid("c1954a32-18b7-467d-a231-5119cb59127a") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Faults_RepairingModelId",
                table: "Faults",
                column: "RepairingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeId",
                table: "Orders",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_FaultId",
                table: "Orders",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ServicedStoreId",
                table: "Orders",
                column: "ServicedStoreId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSpareParts_FaultId",
                table: "UsedSpareParts",
                column: "FaultId");

            migrationBuilder.CreateIndex(
                name: "IX_UsedSpareParts_SparePartId",
                table: "UsedSpareParts",
                column: "SparePartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "UsedSpareParts");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "ServicedStores");

            migrationBuilder.DropTable(
                name: "Faults");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "RepairingModels");
        }
    }
}
