using System;
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
                    WorkExperienceInYears = table.Column<int>(type: "int", nullable: true),
                    ServicedStoreId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                    table.ForeignKey(
                        name: "FK_People_ServicedStores_ServicedStoreId",
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b3bf9255-23d8-41af-a75b-9077f523051b", "811f22f8-489e-450f-afe7-54b72b86e0a7", "Employee", "EMPLOYEE" },
                    { "d16e8df4-e393-4d7f-94c9-84fc152d646c", "60c73022-5132-45bd-ba71-3cdb80b4972c", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "RepairingModels",
                columns: new[] { "Id", "Manufacturer", "Name", "ParticularQualities", "PhotoUrl", "Specifications", "Type" },
                values: new object[,]
                {
                    { new Guid("0248db80-db71-46cd-a313-9b0c15003609"), "ASUS", "Refrigerator ASUS", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("13c771cd-33d5-4487-bc95-6f256c7e38d4"), "Xiaomi", "Iron Xiaomi", "Color: black, Automatic shutdown: yes", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 1.5, Water tank volume: 300 ml, Continuous steam: 35 g/min", 6 },
                    { new Guid("13e98f26-6ba2-45ec-ad2e-6ce150592306"), "Xiaomi", "Refrigerator Xiaomi", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("14dc080f-5414-4fe3-80c8-191d6ddbc04a"), "ASUS", "Telephone ASUS", "Color: black, Screen diagonal: 5.9, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 6, Number of SIM cards: 2, Camera Resolution: 48 MP", 4 },
                    { new Guid("16e6cda4-60cc-4c4c-9f3a-e2709a43b7a1"), "Samsung", "Headphones Samsung", "Color: lime, Design: covering the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("1df64f9b-440f-44b4-af6c-0a0c50409849"), "Philips", "Electric Kettle Philips", "Color: white, Water level indication: no, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2100, Water volume: 1.7, Heating element: closed", 7 },
                    { new Guid("1e6f52d2-bc39-419b-b7fe-bd1e6f27d890"), "Xiaomi", "Coffee Machine Xiaomi", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1400 W, Temperature control: no, Remote control: no, Water tank: 1.5 l", 1 },
                    { new Guid("1fcb1b72-f08e-4775-b34c-1617763c9024"), "Atlant", "Coffee Machine Atlant", "Color: golden, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("21f8a5c9-8b58-4075-af40-3c5d1c22e6fb"), "Philips", "Computer Philips", "Color: pink, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i5, Number of Cores: 2", 3 },
                    { new Guid("2ad234f8-0b77-4742-b011-ef0d9afb2b4f"), "Panasonyc", "Electric Kettle Panasonyc", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2400, Water volume: 2, Heating element: closed", 7 },
                    { new Guid("2b3f006a-4f3a-43fc-91de-4470ce1b26fe"), "Apple", "Television Apple", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("2fa6dc0e-32ed-45d7-868e-b8cd5e25d45b"), "Apple", "Headphones Apple", "Color: lime, Design: covering the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("319deac2-0ce2-4714-b261-879392e13d0d"), "Xiaomi", "Refrigerator Xiaomi", "Color: golden, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("360f5e3b-2557-451b-a0f5-2aa6c76e7ec2"), "Philips", "Computer Philips", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i5, Number of Cores: 2", 3 },
                    { new Guid("38565dd0-9041-483c-94e4-04988ae6f986"), "Apple", "Computer Apple", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i7, Number of Cores: 4", 3 },
                    { new Guid("3a65d33c-d810-4cc5-b60a-0009618f602d"), "Xiaomi", "Refrigerator Xiaomi", "Color: white, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("3c5077b2-610d-48cd-a699-4d4256881c2e"), "Xiaomi", "Telephone Xiaomi", "Color: black, Screen diagonal: 5.9, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 4, Number of SIM cards: 1, Camera Resolution: 12 MP", 4 },
                    { new Guid("3d6fa04e-d19d-43a1-96f0-57a7ef94f3f5"), "Samsung", "Coffee Machine Samsung", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1400 W, Temperature control: no, Remote control: no, Water tank: 1.5 l", 1 },
                    { new Guid("3e65a816-caf1-449e-bfa9-0d2fd1d902fd"), "Sony", "Headphones Sony", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 105 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("3ee3c383-30bb-4419-9037-345a895d9ff4"), "Panasonyc", "Electric Kettle Panasonyc", "Color: black, Water level indication: yes, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2100, Water volume: 1.7, Heating element: closed", 7 },
                    { new Guid("4311618c-b965-4db0-a6d2-5c9c525c211d"), "Apple", "Electric Kettle Apple", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2400, Water volume: 2, Heating element: closed", 7 },
                    { new Guid("4445196c-98c3-41c1-bf27-73d783478961"), "Atlant", "Headphones Atlant", "Color: white, Design: covering the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 30 Ohm, Sensitivity: 90 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("478e1408-9726-4c07-96a3-7b6df7491c98"), "Panasonyc", "Telephone Panasonyc", "Color: black, Screen diagonal: 5.9, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 4, Number of SIM cards: 1, Camera Resolution: 12 MP", 4 },
                    { new Guid("48bb1788-400e-467a-b7d7-b1362fe6e2ee"), "Samsung", "Coffee Machine Samsung", "Color: golden, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1400 W, Temperature control: no, Remote control: no, Water tank: 1.5 l", 1 },
                    { new Guid("51ab46a7-71e4-4330-be91-e62cdca52b05"), "ASUS", "Telephone ASUS", "Color: blue, Screen diagonal: 6.0, Screen resolution: 2532×1170", "https://xistore.by/upload/resize/element/83713/e41/3f16ad66ebe52bb7cb8ef6743ea77ddf_482_482_40@x2.jpg", "Number of Cores: 4, Number of SIM cards: 1, Camera Resolution: 12 MP", 4 },
                    { new Guid("591b9d25-75dd-4a84-8f6d-abcca36f413a"), "ASUS", "Refrigerator ASUS", "Color: golden, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("61319b7b-9c21-489f-affe-fd3fd8a9a624"), "Atlant", "Coffee Machine Atlant", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("80ccef16-ce03-45c5-a3b4-0880fa597f98"), "Panasonyc", "Computer Panasonyc", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i5, Number of Cores: 2", 3 },
                    { new Guid("852783ce-0d55-45ed-b211-8446f0561ed7"), "Sony", "Electric Kettle Sony", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2100, Water volume: 1.7, Heating element: closed", 7 },
                    { new Guid("8c1841a4-6b55-48ec-b15b-15143f85eabb"), "Apple", "Television Apple", "Color: black, Number of USB inputs: 2, Screen shape: curved", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("96156ace-d4db-44bb-8bf8-f009c7368000"), "Sony", "Headphones Sony", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("9aa87e62-ee78-4afd-9189-a0858af09849"), "Panasonyc", "Electric Kettle Panasonyc", "Color: black, Water level indication: yes, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2100, Water volume: 1.7, Heating element: closed", 7 },
                    { new Guid("9fd1a7a5-f5ae-487b-9048-0e2de03f1cc3"), "Samsung", "Coffee Machine Samsung", "Color: white, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1500 W, Temperature control: yes, Remote control: yes, Water tank: 2 l", 1 },
                    { new Guid("a9194897-d4fa-4082-a58e-205caf96cfac"), "Samsung", "Television Samsung", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("b7248f0f-5c27-4eca-9ce6-d8a7bf7ded05"), "Philips", "Electric Kettle Philips", "Color: black, Water level indication: yes, Keep warm function: no", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2100, Water volume: 1.7, Heating element: closed", 7 },
                    { new Guid("b7bbe196-15e2-441c-bbb6-946a03d2f2b2"), "Apple", "Television Apple", "Color: black, Number of USB inputs: 2, Screen shape: curved", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("c372c85b-2c1c-4552-84a3-00ab3eaa20c7"), "Panasonyc", "Computer Panasonyc", "Color: silver, Material: plastic, Screen diagonal: 15.6", "https://www.ixbt.com/img/r30/00/02/13/87/lenovov13015.jpg", "Processor brand: Intel, Processor series: Core-i5, Number of Cores: 2", 3 },
                    { new Guid("c5ecb3be-b836-4eb1-9c94-44ad1735c9f0"), "ASUS", "Refrigerator ASUS", "Color: golden, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("c61a2262-d611-4b04-81ff-d8ce8449dc45"), "Atlant", "Coffee Machine Atlant", "Color: silver, black, Material: plastic", "https://m.sila.by/img/catalog2015/img12/tovar120235.jpg", "Power: 1400 W, Temperature control: no, Remote control: no, Water tank: 1.5 l", 1 },
                    { new Guid("ccce86fb-5bb1-46d9-955c-ca7b3656daa5"), "Samsung", "Iron Samsung", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 350 ml, Continuous steam: 50 g/min", 6 }
                });

            migrationBuilder.InsertData(
                table: "RepairingModels",
                columns: new[] { "Id", "Manufacturer", "Name", "ParticularQualities", "PhotoUrl", "Specifications", "Type" },
                values: new object[,]
                {
                    { new Guid("d71ee0d1-866e-4571-97c8-57a78e85ab03"), "Panasonyc", "Electric Kettle Panasonyc", "Color: silver, Water level indication: yes, Keep warm function: yes", "https://images.deal.by/295895806_w640_h640_elektrochajnik-atlanta-ath-2462.jpg", "Power: 2400, Water volume: 2, Heating element: closed", 7 },
                    { new Guid("d8d38c21-7f88-4759-abea-1de7d5f97401"), "Apple", "Television Apple", "Color: black, Number of USB inputs: 1, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("de2d190b-fe3f-4493-ae03-7b6d7cba2212"), "Apple", "Iron Apple", "Color: black, Automatic shutdown: yes", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 320 ml, Continuous steam: 45 g/min", 6 },
                    { new Guid("ecf0fa4e-3691-4c52-9cb0-d107c32db55d"), "Xiaomi", "Refrigerator Xiaomi", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("ed65f7d5-f007-4cc0-b55a-c53a4d1b877e"), "Apple", "Iron Apple", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 1.5, Water tank volume: 300 ml, Continuous steam: 35 g/min", 6 },
                    { new Guid("f083364c-8c2a-433b-af36-c81ef277efa5"), "Apple", "Television Apple", "Color: white, Number of USB inputs: 2, Screen shape: straight", "https://www.creditasia.uz/upload/iblock/e8f/televizor-samsung-ue50au7100-1.png", "Diagonal: 47, Permission: Ultra HD 4K-3420x1960 pix, Matrix frequency: 55 Hz", 2 },
                    { new Guid("f6e3219a-22de-44f6-9830-cd95def7d7d7"), "Samsung", "Headphones Samsung", "Color: black, Design: inserted into the ear", "https://images.deal.by/252995925_besprovodnye-50-bluetooth.jpg", "Impedance: 32 Ohm, Sensitivity: 100 dB, Operating frequency range: 20 Hz - 20 kHz", 5 },
                    { new Guid("f8fbcd15-05b7-434b-9129-9f5e54aa7988"), "Xiaomi", "Refrigerator Xiaomi", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: freezer, Cameras: freezer, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("fd809e9b-9621-42ba-aa9b-57028563e520"), "ASUS", "Refrigerator ASUS", "Color: black, Lighting: LED", "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRVLQxG7-kWRtgJKf4mtrPoaNz2_KY0vCvHBg&usqp=CAU", "Type: refrigerator with freezer, Cameras: freezer, refrigerator, Energy class: A, Noise level: 40 dB", 0 },
                    { new Guid("feab30da-53fa-4671-80aa-f92a9d33d370"), "Apple", "Iron Apple", "Color: purple, Automatic shutdown: no", "https://img.5element.by/import/images/ut/goods/good_cef1d12f-58ed-11e8-80c4-005056840c70/good_img_2b767908-5900-11e8-80c4-005056840c70_600.jpg", "Max Power: 2, Water tank volume: 350 ml, Continuous steam: 50 g/min", 6 }
                });

            migrationBuilder.InsertData(
                table: "ServicedStores",
                columns: new[] { "Id", "Address", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("1a0dc57b-2363-49dc-8741-0d287c374319"), "Bobruisk, Solnechnaya, 49", "Your Tech", "+375 (29) 6762883" },
                    { new Guid("1e8d6eb5-21ee-4f46-9de9-1673266282c8"), "Minsk, Shosseynaya, 41", "Integral", "+375 (29) 5283047" },
                    { new Guid("4e27f414-238a-42a3-91b4-0e6bf26ff197"), "Minsk, Pervomaiskaya, 12", "Elektrosila", "+375 (29) 8908695" },
                    { new Guid("512a193b-dc7c-469f-9af5-001f751de44f"), "Brest, Kozlova, 26", "Fora Plus", "+375 (29) 2487176" },
                    { new Guid("68ab88a5-2470-41e8-9134-68ad89e452f4"), "Gomel, Uritskogo, 44", "Atlant Store", "+375 (29) 5731632" },
                    { new Guid("82c525eb-d804-4045-83a8-4fb5a413ca71"), "Bobruisk, Solnechnaya, 47", "Deal Tech", "+375 (29) 6336763" },
                    { new Guid("97d438f2-4dbb-4064-897f-79041986bad0"), "Bobruisk, Solnechnaya, 2", "Btv777", "+375 (29) 2263236" },
                    { new Guid("a27d292f-7d4e-47c5-8326-ea373520074a"), "Vitebsk, Bakunina, 6", "Technosila Plus", "+375 (29) 7794839" },
                    { new Guid("a95d0cc6-01a2-488e-a56e-ae597e716d53"), "Bobruisk, Solnechnaya, 26", "Big World", "+375 (29) 7233932" },
                    { new Guid("af44ec37-6264-45b5-a00f-6b56f2907748"), "Bobruisk, Kozlova, 26", "All For Home", "+375 (29) 2509640" },
                    { new Guid("b5efcd86-6feb-4002-b4dc-049131f28873"), "Minsk, Shosseynaya, 27", "Povorot", "+375 (29) 2554569" },
                    { new Guid("b94211a9-02c3-4faa-9bf7-bee4bb57dd31"), "Mogilev, Volkova, 33", "Zeon", "+375 (29) 8407224" },
                    { new Guid("c6236074-2aa8-47ad-9e88-92fd63d8acab"), "Vitebsk, Karibskogo, 5", "Smail Bel", "+375 (29) 7644841" },
                    { new Guid("ec9f4116-d68a-4dd9-9803-19db7f14081a"), "Rechica, Shosseynaya, 42", "Mediamax", "+375 (29) 1007340" },
                    { new Guid("ed17d332-2488-43ab-a8fd-c49f3c2d2412"), "Vitebsk, Sovietskaya, 31", "TocLine", "+375 (29) 3324205" },
                    { new Guid("f567f400-663f-4290-b0b9-1c93682846b9"), "Gomel, Uritskogo, 19", "5 Element", "+375 (29) 9760935" }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 169m },
                    { new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c"), 5, "Provides connecting with device.", "Plug", 176m },
                    { new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3"), 6, "To connecting with electric web.", "Electric wire", 250m },
                    { new Guid("04e1bde7-830c-4acd-b66a-729c5d5310b8"), 1, "Pump water into the coffee machine", "Pump", 54m },
                    { new Guid("05816cc7-7e07-4992-be72-a89b39980cb2"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 27m },
                    { new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 280m },
                    { new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2"), 5, "Provides connecting with device.", "Plug", 52m },
                    { new Guid("0ff86592-5099-476f-8166-389c897ef2f5"), 1, "Pump water into the coffee machine", "Pump", 50m },
                    { new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 120m },
                    { new Guid("1230ec95-f42d-4361-ae91-824194359bff"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 314m },
                    { new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3"), 1, "Heat water to the required temperature.", "Boiler", 45m },
                    { new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 185m },
                    { new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 299m },
                    { new Guid("208d3aec-de1a-4832-a980-88ee4b11a763"), 1, "Pump water into the coffee machine", "Pump", 208m },
                    { new Guid("2195b083-3622-4e68-beca-6666738371bc"), 7, "To turn on/off the kettle.", "Button", 106m },
                    { new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586"), 1, "Heat water to the required temperature.", "Boiler", 30m }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("26376905-3136-45fa-b917-a36133aa63fa"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 266m },
                    { new Guid("293e9df9-77df-4658-91e0-ecba0150b2df"), 5, "Provides connecting with device.", "Plug", 213m },
                    { new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 148m },
                    { new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200"), 6, "To keep water", "Chamber for water", 229m },
                    { new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf"), 1, "Pump water into the coffee machine", "Pump", 336m },
                    { new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 321m },
                    { new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980"), 6, "To control heating.", "Thermostat", 70m },
                    { new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 153m },
                    { new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 154m },
                    { new Guid("42d5eca0-6cd1-42ab-b185-133f908507eb"), 6, "To keep water", "Chamber for water", 240m },
                    { new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 157m },
                    { new Guid("45629291-f3d7-41cf-a119-7d2c21472669"), 6, "To control heating.", "Thermostat", 74m },
                    { new Guid("4570822f-c52f-469e-8374-7b3c96e6e98c"), 6, "To keep water", "Chamber for water", 88m },
                    { new Guid("45caaee9-f60d-421e-9913-55eb5b41b7f4"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 226m },
                    { new Guid("463454ef-dcec-4e4b-9628-2b8c84a6eb38"), 4, "A battery that provides autonomous operation of a mobile phone (it can be nickel-metal hydride, lithium-ion or lithium-polymer).", "Battery", 171m },
                    { new Guid("477bdda5-8aa5-46d9-b710-386078c20056"), 5, "Provides connecting with device.", "Plug", 40m },
                    { new Guid("4afca418-af0d-46df-8567-8b280e0821ba"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 193m },
                    { new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037"), 3, "Socket - a connector into which the central processor is inserted.", "Cochet", 128m },
                    { new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9"), 7, "To heat water.", "Heating element", 274m },
                    { new Guid("55944788-a67b-4111-ad4c-6979213845e6"), 6, "To control heating.", "Thermostat", 45m },
                    { new Guid("5c764ded-80d3-498c-a87d-3783174cca8a"), 6, "To keep water", "Chamber for water", 222m },
                    { new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 268m },
                    { new Guid("5c82d9b7-0dd8-4d2a-b7b4-048257c73bc0"), 6, "To keep water", "Chamber for water", 64m },
                    { new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 241m },
                    { new Guid("5e842733-1290-438f-88cc-22121bb1ef22"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 129m },
                    { new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 72m },
                    { new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 339m },
                    { new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7"), 5, "Provides connecting with device.", "Plug", 36m },
                    { new Guid("61647f7d-a28d-4959-9176-6ac539cc0099"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 268m },
                    { new Guid("6484162f-3848-449c-91bb-4b8487eb306f"), 2, "Shows image.", "Screen", 235m },
                    { new Guid("68a5ab67-e774-48a4-8dae-3dd97b3c0dd5"), 6, "To keep water", "Chamber for water", 219m },
                    { new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 147m },
                    { new Guid("71ebfb68-d9fd-455d-9ec8-e3df3900fd17"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 170m },
                    { new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5"), 1, "Pump water into the coffee machine", "Pump", 200m },
                    { new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32"), 5, "Provides connect with device.", "Cable", 41m },
                    { new Guid("77f264c2-2b61-410d-affc-5ea36c232896"), 7, "To turn on/off the kettle.", "Button", 264m },
                    { new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a"), 1, "Heat water to the required temperature.", "Boiler", 201m },
                    { new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0"), 5, "Provides connecting with device.", "Plug", 191m },
                    { new Guid("8074ae5b-9d87-420b-9556-302280538d40"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 96m },
                    { new Guid("8126231a-e1ef-420f-b445-2082755bb12a"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 151m },
                    { new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 209m },
                    { new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a"), 5, "Provides connecting with device.", "Plug", 45m }
                });

            migrationBuilder.InsertData(
                table: "SpareParts",
                columns: new[] { "Id", "EquipmentType", "Functions", "Name", "Price" },
                values: new object[,]
                {
                    { new Guid("8addb550-241d-43f8-882b-ce328401317b"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 336m },
                    { new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00"), 7, "To turn on/off the kettle.", "Button", 116m },
                    { new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0"), 1, "Pump water into the coffee machine", "Pump", 44m },
                    { new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122"), 5, "Provides connecting with device.", "Plug", 220m },
                    { new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 108m },
                    { new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba"), 7, "To turn on/off the kettle.", "Button", 291m },
                    { new Guid("95d72039-eb70-464b-b33d-b7c65228b867"), 6, "To control heating.", "Thermostat", 86m },
                    { new Guid("988bb559-2546-4273-888a-b2caa60d9a11"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 102m },
                    { new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 313m },
                    { new Guid("a71ca591-3d3e-4848-95d7-450c6d5b3c66"), 6, "To control heating.", "Thermostat", 229m },
                    { new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2"), 1, "Allows to prepare a drink from water in a short time.", "Termoblock", 181m },
                    { new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 323m },
                    { new Guid("aad696f7-a0f9-4cfb-b1ad-e92419b2de8d"), 4, "This detail is the heart of the mobile device and ensures the performance of its main functions.", "Electronic board", 312m },
                    { new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e"), 1, "Pump water into the coffee machine", "Pump", 192m },
                    { new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee"), 6, "To keep water", "Chamber for water", 232m },
                    { new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0"), 3, "Socket - a connector into which the central processor is inserted.", "Cochet", 138m },
                    { new Guid("ba85d345-670b-4cff-9505-8a18d1210664"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 83m },
                    { new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580"), 1, "Pump water into the coffee machine", "Pump", 33m },
                    { new Guid("bd79295b-1388-480a-b19b-860d9996cc4e"), 7, "To heat water.", "Heating element", 297m },
                    { new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 85m },
                    { new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b"), 5, "Provides connecting with device.", "Plug", 342m },
                    { new Guid("bfe94f71-5d84-4d22-8533-f68576f82805"), 2, "Contains a television tuner, decoders that amplify video and audio signals.", "Board", 67m },
                    { new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c"), 5, "Provides connect with device.", "Cable", 178m },
                    { new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 326m },
                    { new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a"), 2, "Shows image.", "Screen", 260m },
                    { new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0"), 0, "The control module is responsible for the operation of actuators such as compressor , fan , temperature sensors and others.", "Electronic control unit", 166m },
                    { new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d"), 1, "Pump water into the coffee machine", "Pump", 344m },
                    { new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8"), 6, "To control heating.", "Thermostat", 85m },
                    { new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4"), 3, "Motherboard (system board, mother, mother, mother) - the basis of the computer, combining the components together. On it are soldered connectors for the processor, video cards and expansion cards, outputs to peripheral interfaces and slots for connecting hard drives, SSD.", "Моthеrbоаrd", 293m },
                    { new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8"), 2, "A signal is sent to the antenna connected to the corresponding connector on the case. After that, the received signals are sent to the tuner, where they are amplified and converted into sound and image.", "Antenna", 257m },
                    { new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5"), 6, "To control heating.", "Thermostat", 243m },
                    { new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00"), 5, "Provides sound output.", "Speaker", 42m },
                    { new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d"), 5, "Provides connecting with device.", "Plug", 195m },
                    { new Guid("e12e9b12-b1b8-47f2-b503-9fea9eb73703"), 6, "To control heating.", "Thermostat", 232m },
                    { new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 117m },
                    { new Guid("e4950192-5467-4c28-b6f5-874473e83550"), 7, "To turn on/off the kettle.", "Button", 287m },
                    { new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8"), 0, "Switching on and off of the compressor usually occurs automatically: this protects the motor-compressor from overheating.", "Refrigeratorr compressor motor", 321m },
                    { new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf"), 6, "To control heating.", "Thermostat", 222m },
                    { new Guid("e9128b8c-0324-4e3b-97e7-8f055ee50c20"), 6, "To keep water", "Chamber for water", 79m },
                    { new Guid("f533775e-eb2f-404f-9713-fdf23a59b349"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 100m },
                    { new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee"), 1, "Heat water to the required temperature.", "Boiler", 205m },
                    { new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352"), 3, "Тhе сеntrаl рrосеѕѕіng unіt (СРU, сhір, СРU, ѕtоnе) іѕ thе mаіn раrt оf thе РС, whісh іѕ rеѕроnѕіblе fоr mоѕt соmрutіng рrосеѕѕеѕ. Іt іѕ оn іtѕ bаѕіѕ thаt оthеr соmроnеntѕ аrе mоѕt оftеn ѕеlесtеd, іnсludіng thе mоthеrbоаrd, RАМ, аnd роwеr ѕuррlу.", "CPU", 92m }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), "Refrigerator won't turn on", 192m, "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. Remove the terminals from the wires connected to the thermostat and connect them together. If the refrigerator does not turn on and the light inside the refrigerator does not light up, then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.", new Guid("fd809e9b-9621-42ba-aa9b-57028563e520") },
                    { new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), "The kettle that is plugged in does not heat the water", 202m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("d71ee0d1-866e-4571-97c8-57a78e85ab03") },
                    { new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), "Damage to the thermostat", 135m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("ccce86fb-5bb1-46d9-955c-ca7b3656daa5") },
                    { new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), "Damage to the contact", 42m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("4445196c-98c3-41c1-bf27-73d783478961") },
                    { new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), "Refrigerator not freezing", 310m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("591b9d25-75dd-4a84-8f6d-abcca36f413a") },
                    { new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), "The kettle that is plugged in does not heat the water", 192m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("852783ce-0d55-45ed-b211-8446f0561ed7") },
                    { new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), "There is no picture on the TV, but there is sound", 51m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("8c1841a4-6b55-48ec-b15b-15143f85eabb") },
                    { new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), "Refrigerator not freezing", 295m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("3a65d33c-d810-4cc5-b60a-0009618f602d") },
                    { new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), "Doesn't turn on", 331m, "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, and sometimes the phone simply cannot charge due to a clogged port.", new Guid("478e1408-9726-4c07-96a3-7b6df7491c98") },
                    { new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), "Control system not working", 338m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("61319b7b-9c21-489f-affe-fd3fd8a9a624") },
                    { new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), "Refrigerator not freezing", 311m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("591b9d25-75dd-4a84-8f6d-abcca36f413a") },
                    { new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), "Computer turns on, Power light is on, monitor is blank", 273m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("80ccef16-ce03-45c5-a3b4-0880fa597f98") },
                    { new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), "Control system not working", 222m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("9fd1a7a5-f5ae-487b-9048-0e2de03f1cc3") },
                    { new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), "Computer turns on, Power light is on, monitor is blank", 101m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("38565dd0-9041-483c-94e4-04988ae6f986") },
                    { new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), "The system unit does not turn on, the Power indicator does not light up", 243m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("360f5e3b-2557-451b-a0f5-2aa6c76e7ec2") },
                    { new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), "No sound on TV", 189m, "Try turning up the volume using the buttons on the manual control panel. It is not necessary to buy the original remote control, you can get by with the purchase of a universal device.", new Guid("b7bbe196-15e2-441c-bbb6-946a03d2f2b2") },
                    { new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), "No signal on TV", 116m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("d8d38c21-7f88-4759-abea-1de7d5f97401") },
                    { new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), "A frequent malfunction when one earpiece fails", 66m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("f6e3219a-22de-44f6-9830-cd95def7d7d7") },
                    { new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), "The kettle that is plugged in does not heat the water", 48m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("d71ee0d1-866e-4571-97c8-57a78e85ab03") },
                    { new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), "No signal on TV", 167m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("a9194897-d4fa-4082-a58e-205caf96cfac") },
                    { new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), "Refrigerator is too cold", 95m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("0248db80-db71-46cd-a313-9b0c15003609") },
                    { new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), "The kettle turns off before the water boils", 62m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("4311618c-b965-4db0-a6d2-5c9c525c211d") },
                    { new Guid("2dc72594-653d-4323-8e59-653dbc161032"), "The system unit beeps continuously, does not boot/reboot", 85m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("38565dd0-9041-483c-94e4-04988ae6f986") },
                    { new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), "Refrigerator is too cold", 91m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("0248db80-db71-46cd-a313-9b0c15003609") },
                    { new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), "The kettle turns off before the water boils", 62m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("4311618c-b965-4db0-a6d2-5c9c525c211d") },
                    { new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), "The kettle that is plugged in does not heat the water", 61m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("3ee3c383-30bb-4419-9037-345a895d9ff4") },
                    { new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 112m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("16e6cda4-60cc-4c4c-9f3a-e2709a43b7a1") },
                    { new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), "Doesn't turn on", 165m, "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, and sometimes the phone simply cannot charge due to a clogged port.", new Guid("51ab46a7-71e4-4330-be91-e62cdca52b05") },
                    { new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), "Heating element damage", 302m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("ed65f7d5-f007-4cc0-b55a-c53a4d1b877e") },
                    { new Guid("3baaf643-4573-4e56-8148-8941af31294f"), "Refrigerator not freezing", 294m, "In working condition, the compressor heats up to 65–70 degrees (it is enough to touch it to check). If the compressor remains cold during operation for a long time, the system is depressurized. To fix the problem, you need to call the wizard.", new Guid("3a65d33c-d810-4cc5-b60a-0009618f602d") },
                    { new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), "The system unit beeps continuously, does not boot/reboot", 92m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("80ccef16-ce03-45c5-a3b4-0880fa597f98") },
                    { new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), "Noisy", 147m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("3d6fa04e-d19d-43a1-96f0-57a7ef94f3f5") },
                    { new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), "The system unit beeps continuously, does not boot/reboot", 76m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("360f5e3b-2557-451b-a0f5-2aa6c76e7ec2") },
                    { new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), "Doesn't respond when turned on", 248m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("1e6f52d2-bc39-419b-b7fe-bd1e6f27d890") },
                    { new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), "The machine does not heat water", 278m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("48bb1788-400e-467a-b7d7-b1362fe6e2ee") },
                    { new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), "Doesn't turn on", 166m, "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, and sometimes the phone simply cannot charge due to a clogged port.", new Guid("51ab46a7-71e4-4330-be91-e62cdca52b05") },
                    { new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), "Water flows from the kettle", 251m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("1df64f9b-440f-44b4-af6c-0a0c50409849") },
                    { new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), "Damage to the thermostat", 257m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("13c771cd-33d5-4487-bc95-6f256c7e38d4") },
                    { new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), "The kettle that is plugged in does not heat the water", 235m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("9aa87e62-ee78-4afd-9189-a0858af09849") },
                    { new Guid("5885e933-342b-4620-b118-c8576750264f"), "Damage to the contact", 50m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("3e65a816-caf1-449e-bfa9-0d2fd1d902fd") },
                    { new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), "The kettle that is plugged in does not heat the water", 192m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("852783ce-0d55-45ed-b211-8446f0561ed7") },
                    { new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), "A frequent malfunction when one earpiece fails", 68m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("f6e3219a-22de-44f6-9830-cd95def7d7d7") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), "The system unit beeps continuously, does not boot/reboot", 257m, "Recognize the type of squeak. Fault beep combinations differ from each other, depending on the manufacturer of the motherboard. Here are the most common beeps of several BIOS faults: a) Award Bios1 long, 3 short - video card not detected or defective.", new Guid("38565dd0-9041-483c-94e4-04988ae6f986") },
                    { new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), "Noisy", 50m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("9fd1a7a5-f5ae-487b-9048-0e2de03f1cc3") },
                    { new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), "Damage to the thermostat", 106m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("13c771cd-33d5-4487-bc95-6f256c7e38d4") },
                    { new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), "Heating element damage", 136m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("ccce86fb-5bb1-46d9-955c-ca7b3656daa5") },
                    { new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), "Refrigerator is too cold", 124m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("3a65d33c-d810-4cc5-b60a-0009618f602d") },
                    { new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), "Water flows from the kettle", 79m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("9aa87e62-ee78-4afd-9189-a0858af09849") },
                    { new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), "Refrigerator is freezing cold", 180m, "The thermostat must either be replaced or sent in for repair for adjustment. Make sure the seal fits snugly against the door and sides of the refrigerator. If defects are found, the seal must be replaced.", new Guid("f8fbcd15-05b7-434b-9129-9f5e54aa7988") },
                    { new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), "The kettle that is plugged in does not heat the water", 46m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("d71ee0d1-866e-4571-97c8-57a78e85ab03") },
                    { new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), "The system unit does not turn on, the Power indicator does not light up", 33m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("21f8a5c9-8b58-4075-af40-3c5d1c22e6fb") },
                    { new Guid("837f5655-4596-4124-ab4b-d404f311de50"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 304m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("96156ace-d4db-44bb-8bf8-f009c7368000") },
                    { new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), "Doesn't respond when turned on", 222m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("9fd1a7a5-f5ae-487b-9048-0e2de03f1cc3") },
                    { new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), "Doesn't turn on", 302m, "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, and sometimes the phone simply cannot charge due to a clogged port.", new Guid("14dc080f-5414-4fe3-80c8-191d6ddbc04a") },
                    { new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), "The system unit does not turn on, the Power indicator does not light up", 145m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("c372c85b-2c1c-4552-84a3-00ab3eaa20c7") },
                    { new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), "The kettle turns off before the water boils", 192m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("852783ce-0d55-45ed-b211-8446f0561ed7") },
                    { new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), "Damage to the contact", 88m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("2fa6dc0e-32ed-45d7-868e-b8cd5e25d45b") },
                    { new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), "Damage to the contact", 238m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("2fa6dc0e-32ed-45d7-868e-b8cd5e25d45b") },
                    { new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), "No signal on TV", 325m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("a9194897-d4fa-4082-a58e-205caf96cfac") },
                    { new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), "A frequent malfunction when one earpiece fails", 41m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("4445196c-98c3-41c1-bf27-73d783478961") },
                    { new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), "Refrigerator is too cold", 260m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("0248db80-db71-46cd-a313-9b0c15003609") },
                    { new Guid("9a726541-3470-4956-903e-aa3731482e4e"), "No signal on TV", 308m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("2b3f006a-4f3a-43fc-91de-4470ce1b26fe") },
                    { new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), "A frequent malfunction when one earpiece fails", 49m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("3e65a816-caf1-449e-bfa9-0d2fd1d902fd") },
                    { new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), "Noisy", 165m, "Another malfunction that can occur in a carob coffee maker is an uncharacteristic noise for the device: crackling, whistling or loud hissing. The reason for this may be a clogged filter or mesh in the horn. In this case, you will need to carefully disassemble and clean the structure with the help of special care products for coffee machines and coffee makers, as well as a soft brush, which is often supplied with the device.", new Guid("3d6fa04e-d19d-43a1-96f0-57a7ef94f3f5") },
                    { new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), "A frequent malfunction when one earpiece fails", 197m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("4445196c-98c3-41c1-bf27-73d783478961") },
                    { new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), "Heating element damage", 320m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("ed65f7d5-f007-4cc0-b55a-c53a4d1b877e") },
                    { new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), "Water flows from the kettle", 292m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("2ad234f8-0b77-4742-b011-ef0d9afb2b4f") },
                    { new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), "Refrigerator won't turn on", 30m, "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. Remove the terminals from the wires connected to the thermostat and connect them together. If the refrigerator does not turn on and the light inside the refrigerator does not light up, then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.", new Guid("f8fbcd15-05b7-434b-9129-9f5e54aa7988") },
                    { new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), "A frequent malfunction when one earpiece fails", 266m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("16e6cda4-60cc-4c4c-9f3a-e2709a43b7a1") },
                    { new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), "Doesn't respond when turned on", 296m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("48bb1788-400e-467a-b7d7-b1362fe6e2ee") },
                    { new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), "The kettle that is plugged in does not heat the water", 189m, "As a rule, TEN cannot be repaired. The disk heater is part of the body, it is not advisable to change half of the kettle. In cases where the heater burns out, we advise you to buy a new device.", new Guid("852783ce-0d55-45ed-b211-8446f0561ed7") },
                    { new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), "Power cord damage", 306m, "Attach the end of the tester with the bulb to the plug, and the battery to the other end of the cord. If the light does not come on, then the problem is in the cord. It needs to be shortened and checked again.", new Guid("ccce86fb-5bb1-46d9-955c-ca7b3656daa5") },
                    { new Guid("b29ab598-326c-4873-88de-358f94db58c2"), "The machine does not heat water", 185m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("1fcb1b72-f08e-4775-b34c-1617763c9024") },
                    { new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), "Refrigerator is too cold", 95m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("0248db80-db71-46cd-a313-9b0c15003609") },
                    { new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), "Doesn't respond when turned on", 246m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("c61a2262-d611-4b04-81ff-d8ce8449dc45") },
                    { new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), "Damage to the thermostat", 290m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("ccce86fb-5bb1-46d9-955c-ca7b3656daa5") },
                    { new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), "Refrigerator is too cold", 114m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("13e98f26-6ba2-45ec-ad2e-6ce150592306") },
                    { new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), "Damage to the contact", 218m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("3e65a816-caf1-449e-bfa9-0d2fd1d902fd") },
                    { new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), "Water flows from the kettle", 290m, "The cause of the malfunction is in the glass with the water meter scale. The seals in the body are worn out if the heater is of an open type.", new Guid("2ad234f8-0b77-4742-b011-ef0d9afb2b4f") },
                    { new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), "The machine does not heat water", 125m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("48bb1788-400e-467a-b7d7-b1362fe6e2ee") },
                    { new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), "Damage to the contact", 187m, "The solution to the problem is to solder them in place. In addition, the repair may consist in replacing the plug, taking into account the pinout of the headphones. ", new Guid("96156ace-d4db-44bb-8bf8-f009c7368000") },
                    { new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), "Doesn't respond when turned on", 236m, "Check if the plugs on the shield have been knocked out, if there is light in the house, and if the filters of the device are clogged - perhaps the solution to the problem will be much easier!", new Guid("1e6f52d2-bc39-419b-b7fe-bd1e6f27d890") },
                    { new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), "Control system not working", 50m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("9fd1a7a5-f5ae-487b-9048-0e2de03f1cc3") },
                    { new Guid("d0deb7e1-e3b4-42b5-8ff3-2ddfbba844e4"), "The kettle turns off before the water boils", 254m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("1df64f9b-440f-44b4-af6c-0a0c50409849") }
                });

            migrationBuilder.InsertData(
                table: "Faults",
                columns: new[] { "Id", "Name", "Price", "RepairingMethods", "RepairingModelId" },
                values: new object[,]
                {
                    { new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), "Control system not working", 181m, "In some cases, the search for a defect is forced to remove the control panel - this way you can check the condition of the contacts with a special tester. The cause of the malfunction may be contamination of the mechanical buttons - sunken elements must be removed, cleaned and reinstalled.", new Guid("61319b7b-9c21-489f-affe-fd3fd8a9a624") },
                    { new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 30m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("4445196c-98c3-41c1-bf27-73d783478961") },
                    { new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), "Doesn't turn on", 166m, "There can be many reasons for this most common problem, ranging from failures in the operating system to malfunctioning boards. Also, the reason may be an unsuccessful flashing, and sometimes the phone simply cannot charge due to a clogged port.", new Guid("51ab46a7-71e4-4330-be91-e62cdca52b05") },
                    { new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), "The kettle turns off before the water boils", 121m, "Breakdowns of teapots are different. To find out if the kettle is repairable or not, order a free diagnostic service. The service center master will inspect the device, disassemble and determine the feasibility of repairing. If the appliance is beyond repair or the cost is high, you can safely buy a new kettle.", new Guid("2ad234f8-0b77-4742-b011-ef0d9afb2b4f") },
                    { new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), "Heating element damage", 168m, "The heating element breaks extremely rarely. However, if this still happened, then it is easier to buy a new iron, instead of trying to replace the heating element. You can determine that the breakdown is related specifically to the heating element as follows.", new Guid("feab30da-53fa-4671-80aa-f92a9d33d370") },
                    { new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), "Refrigerator is too cold", 103m, "Quick Freeze button not turned off. To fix the problem, you just need to turn off the fast freeze mode. The thermostat is set to maximum. Move the thermostat to a less intensive cooling position and make sure that it is normally held in this position.", new Guid("c5ecb3be-b836-4eb1-9c94-44ad1735c9f0") },
                    { new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), "There is no picture on the TV, but there is sound", 54m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("8c1841a4-6b55-48ec-b15b-15143f85eabb") },
                    { new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), "Refrigerator won't turn on", 144m, "If the voltage is higher or lower than the specified range, then the refrigerator may simply not turn on. Remove the terminals from the wires connected to the thermostat and connect them together. If the refrigerator does not turn on and the light inside the refrigerator does not light up, then most likely the problem is precisely in the lack of power. Check if everything is in order with the cord, plug and socket.", new Guid("591b9d25-75dd-4a84-8f6d-abcca36f413a") },
                    { new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), "The system unit does not turn on, the Power indicator does not light up", 160m, "Check the connection of the video cables of the monitor. Check the monitor's power cable.", new Guid("c372c85b-2c1c-4552-84a3-00ab3eaa20c7") },
                    { new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), "Damage to the thermostat", 168m, "After the plastic part of the case has been removed, you should consider the thermostat of the iron. In cold mode, the contacts must be closed. If there is a special device, it is better to ring the knot. If there is no device, you can clean the contacts with fine sandpaper, and then plug the iron into the network.", new Guid("feab30da-53fa-4671-80aa-f92a9d33d370") },
                    { new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), "A frequent malfunction when one earpiece fails", 210m, "To repair an earphone, experience is required, so it is better to immediately contact the specialists without doing anything on your own.", new Guid("4445196c-98c3-41c1-bf27-73d783478961") },
                    { new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), "No signal on TV", 155m, "Therefore, you need to start with the diagnosis. When the user determines the reason for the absence of a signal, he will be able to develop the best course of action in accordance with expert recommendations. Start your troubleshooting with a thorough inspection of all connectors. Make sure the wires are not kinked or broken. The condition of the cable directly affects the quality of the broadcast. To avoid such problems, it is extremely important to know how to choose a coaxial cable.", new Guid("a9194897-d4fa-4082-a58e-205caf96cfac") },
                    { new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), "A thin cable can be torn if it is constantly pulled with force or strongly pulled", 112m, "Such a malfunction is more difficult to detect, especially if a budget model is used, which has very thin wires or damage to the driver itself. It is not possible to see the break with the eyes, since the insulation will remain intact. In this case, diagnostics will be required and only then repair of the headphones. ", new Guid("16e6cda4-60cc-4c4c-9f3a-e2709a43b7a1") },
                    { new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), "There is no picture on the TV, but there is sound", 322m, "If the screen does not glow when turned on, then first of all you need to check its connection to the power source, whether the cord has been pulled out of the socket. Check the cable along its entire length for deformation. It also needs to be removed from the nest and inserted again. Make sure the plug is in working order and fits snugly into the socket.", new Guid("a9194897-d4fa-4082-a58e-205caf96cfac") },
                    { new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), "The machine does not heat water", 67m, "In this case, you need to arm yourself with a multimeter and ring the heating element, and then the controller. If there is heating, but it is insufficient, hard water, which provoked the appearance of scale on the heating element, may be to blame. In this case, it is necessary to flush the machine with a special cleaning agent and install a filter cartridge to soften the water. If this operation fails, it is necessary to replace the heating element, which is performed by a service center specialist.", new Guid("1e6f52d2-bc39-419b-b7fe-bd1e6f27d890") },
                    { new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), "Refrigerator shuts down after a short period of operation", 41m, "Safety relay plate should be checked with an ohmmeter and replaced if a malfunction is detected. Start relay coil also checked with an ohmmeter and if a malfunction is detected, the part is replaced. The compressor motor needs to be replaced, for which you will have to call a refrigerator repairman.", new Guid("fd809e9b-9621-42ba-aa9b-57028563e520") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("0091f08c-6bee-4de8-b817-7f5549d2d4e4"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("00f6e340-37ea-4fb9-82aa-7071f46dc632"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("0190aa3b-69a5-4d9f-9bc6-314b4d2047c5"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("0222f0a2-62be-4e77-b099-2451405b1358"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("02893482-39f1-4c9e-9616-6244effbb832"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("95d72039-eb70-464b-b33d-b7c65228b867") },
                    { new Guid("029f2de9-0b34-4274-804c-b20f2c355f6e"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("03196488-3a92-4471-b886-d2960c6c58ee"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("03efccd8-23fc-44a2-8511-3d57fea4356e"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("0454b3d6-73d7-464a-9bb5-91b63c8449c7"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("04c45c21-71bf-474e-8d21-9fc465b1a23a"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("04cb0bce-d4c8-43ed-9446-4318215ae482"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("04dacfdf-dcf1-460a-b20c-4dbdc11f5936"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("054c8225-ebcb-4ce9-a123-5929d7fe6e5b"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("05f0c3d1-a086-4cd7-8934-ff08c949816e"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("05f1495f-93d1-497d-a289-6ca4aa63f9f8"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("062fd63f-1735-4584-a115-1f0753a299fb"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("04e1bde7-830c-4acd-b66a-729c5d5310b8") },
                    { new Guid("06a2f9a6-5a6a-499a-ab65-c2cb17f17c0d"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("06d9979d-d27d-440f-9e60-90409f913ba1"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("074e60dd-af8d-4830-b1b1-0f111ffa317a"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("0777aa1b-5f36-44ea-b178-403202fa02a9"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("07852207-70b4-4061-9009-575b0f80e760"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("078658ba-9c04-4346-adfd-466b3e143986"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("0806ce4a-0ac9-4b21-a2dc-38761b5a1380"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("45caaee9-f60d-421e-9913-55eb5b41b7f4") },
                    { new Guid("0810b18f-d8f9-4040-9bbd-2bb5bf6560e8"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("0875778e-12dc-453a-be69-32aea2665eb2"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("0883e834-fd3e-47d8-b6a2-65af5c01f678"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("09a04c85-0267-4d7a-8c60-7c58a3b31310"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("0a3a9546-4a6b-4960-a246-faf4bac11bed"), new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("0a427094-55f4-4c84-b865-08df69e29047"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("0a574165-4095-48a7-a4d2-aabf0633d50d"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("0b7d3b8b-e7dd-41e8-b4a1-3705f299e503"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("0bc44be7-2f11-435b-875e-6eb3852f6f7e"), new Guid("9a726541-3470-4956-903e-aa3731482e4e"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("0c0fdd9e-c5d6-4a63-b8a5-68e4e041cf18"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("0c949f03-2135-4ab4-95b0-78e0058a00a4"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("0d4612c9-62da-4bd2-b2ff-20036186d865"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("0df48d79-462b-4a23-a725-9a1acb63606d"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("0e483310-f5e5-4d2c-b992-0c9e85eb925c"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("0fb6080c-b4c4-4667-aa43-ef9b7f80266c"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("10488240-6c4e-417f-94a9-e0d51c003094"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("10492915-2df2-4b42-b09c-cd8f655765ad"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("105a2cf1-48ce-42bf-b84b-7b90a9e77bc9"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("106f8b17-7e33-47f4-a04a-3423496d9f20"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("11067609-2fb9-4c04-a79d-42437c3d371e"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("113556c0-40a0-4bbf-811e-560224ca1ce1"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("1156f582-7ade-4e04-948b-69b650ced2f0"), new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), new Guid("e9128b8c-0324-4e3b-97e7-8f055ee50c20") },
                    { new Guid("11a5a21f-d631-46d5-beb3-02fab01a7df1"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("11c04b86-642f-4926-840e-344ffb12ff0d"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("11cbbb4f-f111-4bb6-9236-a4d826ce4cda"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("11ebb5f8-b302-44b2-8f40-583405200f16"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("121b25d7-8ce2-48b6-8b61-04e448469ea7"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("123edbbd-01fe-4014-950c-77e4758604f3"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("12bff7ac-5029-473d-979a-c0ee0e1e7a07"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("13690221-32a7-4958-8117-18f084f1ca8a"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("138240a9-dba7-4519-a245-0059ca29f61e"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("13c4534d-ffe2-4a29-b345-81f861b791ed"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("1404e744-bc0b-4b95-a5f0-41a3038b0e9d"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("14a822f3-1673-497a-8128-93272749ef8e"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("14c9089d-5ec8-46de-bd91-008a497e92d1"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("1535b95c-e492-49ba-bfce-8d5fdb710c18"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("15628e2c-4c7a-49ed-9322-04cd864f0842"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("15a6d605-c5a6-47b6-9c76-cecf66e33289"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("15c83be1-c48c-481e-9ef8-4366a3c09914"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("15e088ae-98eb-41be-a00d-d771e2d03623"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("15e983fa-a01e-4a35-8da6-f6920c63ba9d"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("15f14786-2921-4f01-b14f-b8c5b23d5ca0"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("1622f35b-bc9e-42da-8734-9fd0a284e7d4"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("1636e034-94c7-4f52-b160-bab7ab2db135"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("165cf647-0f9c-4659-972a-722c980eff64"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("16694cfe-956b-4214-8e3e-15745beedfae"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("166f5899-4a42-46b4-a764-10455bd63a64"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("16a560be-e5d5-48b9-8d86-119ff6036c13"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("16acc3ea-3754-4ed0-bd31-5c590f0ae0a7"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("16b30acf-1ca7-4d69-9134-f861530c1503"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("173e47f6-f7d5-44f9-b848-a4f431fcddd9"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("178b2bf1-b208-45e7-be36-e16ff44d9288"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("17bb9c94-d969-4c63-9a52-2ca1b432dee7"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("17d55f6f-6285-4825-8a73-cb44dcd76bb9"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("17ec45d5-8e08-4ca3-beb6-d2eaaeb3f54b"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("18d301a7-11e4-4e7a-8a60-aea040ff9d7e"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("18ef2a1d-8d59-49b0-992d-98191708e5d4"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("199e0c7a-23f6-45c7-baf5-cd4f1095db66"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") },
                    { new Guid("1a2c0885-62fa-43fc-b189-f8a8240862d9"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("1a2dda28-15ea-4179-9246-4d500fb642c7"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("1ac7ba1a-697f-4904-9a04-600d4c4ceedc"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("1ad4f150-92e7-4570-835d-394cd266546a"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("1bdd9fc4-7c69-4458-a0fd-52811fd21c13"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("1bfe2da3-7aa2-48c7-8dbd-37423c5de10b"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("1c138c82-8db9-43ed-945f-df20371f0633"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("1c19267f-9c95-4e96-b037-1dfe7cadaf59"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("8074ae5b-9d87-420b-9556-302280538d40") },
                    { new Guid("1c433321-948e-46fe-ae45-a9569bd944e5"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("1c454eda-f852-452e-be13-edc93c1d2206"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("1c69c810-ac22-4227-ab30-6aabed032534"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("1c6f6a95-f420-4c52-a7e6-1ba7294efd62"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("1cd47cbd-6c76-4e1f-b2da-a34f675a89ce"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("1ce9ddbc-17cd-4c52-8401-b9493ef88afe"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("45caaee9-f60d-421e-9913-55eb5b41b7f4") },
                    { new Guid("1dad35bc-435b-4029-87eb-d827042d323a"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("1ddc9731-1e9a-4191-a264-2d6b6d69130c"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("1e885ca7-e78b-4eef-a140-55b767a0efd6"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("1ebd6f4e-5e6c-45e9-93fe-4c788591a44e"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("1f534690-0f15-41f1-a7b2-0fdee2983bda"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("1f58415c-c2e1-46c2-ac93-6ab386bc1baa"), new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), new Guid("68a5ab67-e774-48a4-8dae-3dd97b3c0dd5") },
                    { new Guid("1fc85aef-4073-4576-a1dd-5e444abb07a8"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("20006511-b481-4010-8a73-f21abcaba6b7"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("2038df7a-43b5-4d17-9e34-0d63068d0a34"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("205c4cc1-64ce-435a-99bf-ba2a0f67cbc4"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("20a911db-e00d-4c13-88a4-02044afce13e"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("21522ac4-a513-4204-96bc-de2754fe05f7"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0") },
                    { new Guid("2212043b-4bed-4f06-a3d6-9f7b9e1c8577"), new Guid("d0deb7e1-e3b4-42b5-8ff3-2ddfbba844e4"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("2247ebc6-6ec5-4cb0-bfc8-630736090222"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("229389f2-0a49-40c8-953e-2b3da2fd0ba5"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("22a68885-59b2-48fe-ac50-98112606f745"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("22be6d6f-5bac-4df5-9378-5b6d63110b61"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("22e0cceb-0b3d-4b48-b529-57409f6d5853"), new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), new Guid("95d72039-eb70-464b-b33d-b7c65228b867") },
                    { new Guid("22f27f18-e880-456e-a739-ff60be611e0e"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("2321ed4b-799a-462b-b897-aef74a6cc095"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("f533775e-eb2f-404f-9713-fdf23a59b349") },
                    { new Guid("2337accf-1f66-4fc8-9416-7d5ef1f8699d"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("23a02cbf-a587-4320-bea2-2a7ef7359b94"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("23b15713-49eb-4892-bcae-cb2d50728bcb"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("23bc3a2e-0b8a-4b6c-8247-2916c720a0f2"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("4570822f-c52f-469e-8374-7b3c96e6e98c") },
                    { new Guid("23f2ffbb-69bd-4f76-b805-ea4c744c3c66"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("2434e3a1-1a20-40d3-bc5b-ea3caad659c4"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("245bf388-838b-48d7-b259-4cd12ac8ef31"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("2517c12d-e15b-4c68-bb85-b86d9df011c7"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("2589c1eb-9bc9-45f1-bb9e-504f4ec78312"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("e12e9b12-b1b8-47f2-b503-9fea9eb73703") },
                    { new Guid("259cb3f3-4f98-42e8-9b33-d6902e3707c3"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("2607c54a-ae6d-4708-a9ab-4cc5b5aa42ab"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("2634452c-f130-40b2-8fbd-ac89b2c422ee"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("26803f2b-df66-4cbe-a311-c39bab95fb58"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("26874322-3e99-44be-8440-3d2e180cb4b7"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("26e8da1b-4cba-4c5f-9205-ff6f1840f79c"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("26f80d68-5387-48cd-a04c-671e1aed8ca8"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("27182ae5-39ab-4030-992c-23923b6308a7"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("2728bfcb-740f-434a-b098-8998490b9c4e"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("463454ef-dcec-4e4b-9628-2b8c84a6eb38") },
                    { new Guid("2751bb58-c46c-42df-a9ec-bfe4ca68a16e"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("276b0c76-1d90-460e-aa3a-f0f7cbba51a5"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("2785b2a4-6900-4268-955a-a1bb184a8461"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("27be643e-5646-43f8-85f8-5d50d9db782f"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("27ddbf32-3960-47aa-9fbb-a8aad263ee64"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("280bbd3e-f14d-4e75-84f9-d075b512bf2a"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("28642f1e-8b2c-455f-95d4-4e93c461f707"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("288afea5-5ff0-48f1-a510-579d5f618a34"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("289d8fb3-e8d8-467a-901b-7db34bf62359"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("291fa533-9c61-4c05-a987-0e21941d4d06"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("2952e92b-5b0f-497d-b298-9fdd5420d386"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("296128ae-1705-41e3-ada1-372d212ecdba"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("29bbac52-ef3a-40e1-ac1b-6bc7042a7703"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("29fdb9e8-d132-4fb2-8b27-c058555ba673"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("2a055547-2f4f-488e-8e10-37536cf75972"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("2a3b72c7-1b3a-4aeb-8663-ed185f532354"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("2a46105e-8b95-4df9-82d6-ec09cfc73bbc"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("e12e9b12-b1b8-47f2-b503-9fea9eb73703") },
                    { new Guid("2a58000d-79ef-4488-beba-08ebd85b9e1d"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("2aa26103-9b7a-44f4-a559-9d7ae496e696"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b") },
                    { new Guid("2aab9d35-1c5c-4a1f-974a-94fc50300487"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("2b7ca826-f8ab-4e7a-93a0-68cddfd58106"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("2b90f5d1-7bd2-4582-9fd3-acaee281bee5"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("2c2b24da-fde4-44b6-9f89-b6ab9c200c8d"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("2ca5417b-109a-4c36-ac3d-7cfa1ccbe022"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("2cca2326-010a-400b-9222-45e8971d59bd"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("2d0ed5aa-ff3e-46aa-b5c4-2c6d932e534c"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("2d2dfc3c-5fc7-4c43-a5cc-f02da6af1d8f"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("2d5e255c-8b5a-40f5-a79f-a6a7bdb905ee"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("2d65652e-c8ed-4de5-9479-59a6f533d1cf"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("2d9401c4-80dc-4399-95f1-9a7a0df5c3b6"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("2dd016fd-9cfa-4bcb-881e-f73750adec4f"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("2e773ef2-d4db-41fc-b374-5edf1045c954"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("2e9d4781-2f4f-4f55-be97-cb5558f8cc4d"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("2f725dba-5485-4de5-bdd3-9c641ba7cfa2"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("2f8cbc35-5c70-43e9-90e8-4cc73d45bd95"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("2fb7182c-1d3f-461b-9ed7-5a3144fc65aa"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("2fe9c484-73ef-4324-aa81-e0673020160d"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("3013c2d8-b754-4f75-82fd-1310a2d54a9b"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("3031856f-bd45-4b84-bd30-b1a0454ff35d"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("308e12a5-517d-412b-bc26-0329d8ede20b"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("30c20cd5-6dbd-432f-a94b-74dacd0c30b1"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("31031c6e-5c69-4878-8b01-786353fbb7b2"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("3115c9aa-52e7-473c-b3e6-98ae0bb332ab"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("3172745e-2f94-43ec-ab64-23f65e9bc32f"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("3178cd79-de12-421d-86af-b9635c7a1ca7"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("3199b46d-2371-490f-b2f1-816dc4b520eb"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("31bd10da-9275-4fee-b5f4-e7816060f169"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") },
                    { new Guid("31c213b1-1a65-411b-8797-7e6b6eb05033"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("31df2c11-3ccc-4bfc-865b-3fe97cbf3d4d"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("31f59db3-74d1-4f6c-bec6-d52d49090702"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("4570822f-c52f-469e-8374-7b3c96e6e98c") },
                    { new Guid("32287e0d-c5bf-47ad-b82d-24734b2624d3"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("32e0aa7b-2afa-4bf9-9475-440b82e29f64"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("32efe5c1-3897-43ad-8708-b416863f11f2"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("335552a5-fece-449c-a6bf-b8c99c4f5ad8"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("3362f421-f180-4275-8186-3a0c3457374d"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("33630739-10d5-4e13-a9e7-a00f08bbc29a"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("337bc4b5-5da5-4665-b7cb-258b28de707d"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("3385794b-0b98-474f-bebe-1de6bb4882d9"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("33e7aac0-1fa0-4f0c-8025-b857ed5222c1"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("34277ca9-11e5-43dc-a590-e2d1c3c8014f"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("343a68a2-d94a-425e-8ea8-f33c764cc169"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("3451e24a-2d24-4411-a80d-03ec6928b3f9"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("35bf7fa0-c6a6-4a0e-adab-fe139445d59a"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("35c2f37c-3818-4538-b62b-8ec7042f0bd2"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0") },
                    { new Guid("35f75024-2cca-417d-b72d-834175a0abb3"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("36245525-3503-42c4-84d3-805843dac1d1"), new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("3648efbe-2d0c-4aff-8e87-8aec32c9005b"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("36726b56-6099-4f79-ab63-309a2d9728db"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("36b6bd27-aab9-4baf-a3aa-2f311af9c9cb"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("3774dc77-0bd2-4612-9dc8-eec6920717ba"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("37ae82bb-171b-45d3-ab9c-fa9acc468155"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("37c72396-e03e-48a6-ab71-89c76e0674f2"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("383ca48c-e555-48e0-90b7-55ae3b54f1fa"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("38739ec0-64ad-468d-9fcc-04f4cdfe8ab6"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("398723e2-0c57-47af-9ec8-9b5d8d5b58eb"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("04e1bde7-830c-4acd-b66a-729c5d5310b8") },
                    { new Guid("39b34053-b795-44a9-ad69-6158d8c41025"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("3aafec7f-986a-4fe7-a457-552ac4273632"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("3b2d7313-3d8a-40dc-b782-5dd4db857492"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("3b8263d6-65d4-4729-9557-53e74b9080f3"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("3c0256a5-1883-427f-a516-c9c8e492bbfb"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("3c3e9107-3b3a-4528-a894-5415565df917"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("3c677468-cf71-4f13-9204-6b48c7963643"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("3c85e247-d4b6-44f9-a679-f6aca7f55466"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("3c86aca4-1e01-49ee-8811-f022ea901a20"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("3cc5a264-cf82-410e-b2e7-c9416d135643"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("3cf00883-c974-4870-8b39-7eb97bda941d"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("3d16a8dc-256d-4587-bb49-86b441674b6f"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("3d614baa-8502-4f3e-83af-f50b687fd4e3"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("3d7343e9-905a-4c65-8185-e9744a42b16b"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("3e03d310-a05a-434d-b26f-131d5767ba16"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("8126231a-e1ef-420f-b445-2082755bb12a") },
                    { new Guid("3e289351-fbd2-429c-ad52-ef3cc640bb8b"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("463454ef-dcec-4e4b-9628-2b8c84a6eb38") },
                    { new Guid("3e707208-5618-4bce-b450-5991e5f99a93"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("3ea0d163-2ae6-4966-90eb-8ead3fe48327"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("3ebaa95a-a62e-4364-9987-8b564e77073d"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("3f237740-a68b-4bd2-a5a1-7097686c7007"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("3f25de78-e8c2-4738-8a7d-2d856766b490"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("3fe09133-9572-49fc-a6d2-0a5101af900b"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("3fe66850-63a0-492b-8c5e-79824895e06a"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("3fecfa1c-392e-43f2-8803-2a19eba14f98"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("400bc469-2f15-43bd-baba-719673cf345b"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("401f9bf7-29b4-4e0f-b2c2-bd0bb3de2481"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("4040c5ae-77c0-4e54-b7d1-fdf993fb2f61"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("405224b1-29ad-42bb-883d-62b9c6a65ed9"), new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("408b798a-a394-41d3-9dcb-2515364c1d31"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("40d783af-1ce6-48f2-a930-0d4d795c2287"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf") },
                    { new Guid("40fa2b61-6cfd-4ae9-8051-4350b2ef24a7"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("415d8603-0ad0-44ae-b328-b55710a040bd"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("4165778e-7c30-432b-b214-15ca60b25a22"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("416fef07-0e98-4537-a4ea-6284f979cd75"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("41d10603-eaac-4b43-b10c-8ded5b62a2ef"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("55944788-a67b-4111-ad4c-6979213845e6") },
                    { new Guid("41d70e06-906b-4481-b768-4616560bdfd6"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("41fa4531-ca89-4a66-a9c5-0202911c7998"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("421685d1-5528-41f9-999f-fdb1f1ef1d22"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("421d0a1d-24db-4e46-9fb7-a4bec7eec8a9"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("42a9a52a-dab8-42ba-b6c1-adfd86522679"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("42bc50fd-4d33-4e77-bf07-18ed8a039362"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("42daed9d-6e16-4b9d-a4c0-609f9d94c925"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("433f3179-eb2c-4b76-8000-43b1d8c26015"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("43c7f4c6-6639-4805-ad3a-88cb42c30d55"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("43f271b6-0b9b-4277-9a8f-e51e38909340"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("43f5874d-ee5f-4a9c-96d2-86ae834a2909"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("441218ed-db95-40c8-b253-c55259488b3e"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("441c0552-38ee-4de6-b424-b07ab8924950"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("44737ace-accc-4501-b041-675a81297b25"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("4473c8a8-f815-4756-ac66-b6a6a538ab86"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("44a4f9fc-b4ec-4407-89aa-65d4ab6b05f4"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("44b1a86c-6dce-4221-b0be-f4e66e20d64e"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("44cccb9f-73a2-4e8f-ba0b-2d70d2fcdd2d"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("456882ad-92d0-4d61-88a7-1186e4781bb2"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("4568c921-2f7f-4108-98a8-337574732d7e"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("465e63f0-16a4-4345-bedb-9d5b61b7f74b"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("467065e3-6e97-4143-b18c-70ee39989a11"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("4677acf8-04c1-4862-82c3-eefe03e40598"), new Guid("d0deb7e1-e3b4-42b5-8ff3-2ddfbba844e4"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("469a1102-1816-4017-aba8-22ec9b5d5dfa"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("46bf651d-6809-414c-84ed-cb7a258c5407"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("46d2e013-ee50-4ae2-b929-72a48562a662"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("46e695a4-1ccc-419b-955d-47df013b9162"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("47117cae-03c1-4e59-a375-7eb46588c9a4"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("47eeb697-8efe-4bdc-9873-fd8208a3cad9"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("48028309-0a3c-4936-9943-bd85857de39e"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("48b1e477-a9e3-459d-9d71-f70468b6aeb2"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("71ebfb68-d9fd-455d-9ec8-e3df3900fd17") },
                    { new Guid("48d155ab-7241-47fa-b512-701041ace6ee"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("4917e02f-9f10-4355-9903-92650f731ba0"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("4928ad3f-6eb4-4c57-a738-7f03d7ae655f"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("492a7c1d-7c9d-4a24-9560-d49603a57018"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("49985bed-15c5-4948-9f1c-4d94df9a762a"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8") },
                    { new Guid("49b356a8-0c03-41bf-8f83-65aee008d1b9"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("4a35e68e-333c-45df-8012-fb686304f0d2"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("42d5eca0-6cd1-42ab-b185-133f908507eb") },
                    { new Guid("4a506724-da8f-4bc5-8bbc-b83dd29f0f54"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("4aa29060-9ba1-4053-8180-0856812a3f73"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("4ac0bd0a-554f-4224-af56-decc3d916bbf"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("4ac13686-0efc-43fd-9c68-192936b59fc9"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("55944788-a67b-4111-ad4c-6979213845e6") },
                    { new Guid("4ac23229-84e3-4316-bf23-d18382436576"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("55944788-a67b-4111-ad4c-6979213845e6") },
                    { new Guid("4aec6589-842f-48f2-b4f3-0ccd1ecd928a"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("4b123e43-28e9-4b97-ab33-92c2e1150a5e"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("4b82aed0-b83a-4fa0-b6a3-d78215638aeb"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("4baeff86-f579-4a74-ac95-2f820273bef2"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("4caba1ea-c6a3-40cd-b12d-6709961729ef"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("4cdf5d73-511c-4361-852e-770f4fd43cc3"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("4d45eb00-5863-4a23-89a7-1cc68f6248dc"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("4d63de77-53d0-4dfd-85d3-d84b2227e29e"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("4d84e2ec-54de-4a48-a506-02decd2fdab3"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("4d89c43f-97e1-4e4c-b5d0-055c593d0df7"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("4db162f1-1e8a-4a51-8198-1130828f57e9"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("4dff2c08-9dba-4fa7-b295-7edc14664ba2"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("4e0f287d-da73-41b0-abba-780ac0d8b8af"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("4e671dc0-511f-44a8-b029-403bafb068bd"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("4e7d6a32-0d23-4b92-ac90-d7d296af041d"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("4e86cfcb-f9e9-4516-8062-c26b2b2d91e0"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("4f0e50e8-4bf4-4aef-9f8e-5576cd7b57ab"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("4f15fc6f-1431-4b7e-b952-ef588090df05"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("4f2723ba-fb8b-4e6d-8957-7b54d2cdc0f5"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("4f3880b0-93c6-43c6-80b4-1c447501b081"), new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("4f436a89-9986-4166-8d87-65b21ba5c895"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("4fbd2c90-81a0-4f06-8744-4ca015cd5ddd"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("50051751-0bad-486f-a321-dacfe66c4183"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("500833b2-886b-4886-9fd3-40d3226e79b5"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("505e59b5-3c93-4335-b053-8b93995b3fea"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("71ebfb68-d9fd-455d-9ec8-e3df3900fd17") },
                    { new Guid("509eea0c-8f7c-42a8-9567-b722b6d86ee3"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("50bdee3a-1c10-41ee-be76-97fa89931c0f"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("521cb696-59ab-4c05-8d37-f3aefc633e5c"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("95d72039-eb70-464b-b33d-b7c65228b867") },
                    { new Guid("52482052-6f81-43a8-98aa-8387daae1f60"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("53560633-db6b-4d2c-8678-bfad1db46c2e"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("539de88f-b2d1-4543-a6cb-ef116f853830"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("53b7ba5d-1682-4cd1-bce7-fde70fc0cdc9"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("540b8993-e4de-4fb2-9e8a-bd2b18bad2df"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("545acd13-bdac-4b75-ac08-e8b189728eea"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("547694b2-00ae-4b10-883e-dfa9d60fab2a"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("54d2828a-b823-42a8-9596-c1070ef5eebb"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("54f9ffb2-371d-4f13-9fd7-7756336aec3e"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("5500df65-d04f-44d1-86a8-33767915bc37"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("5532a843-b451-4096-997b-cf244bc6688d"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("557bd1ef-5035-415b-87c6-33b48d42bfbd"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("55ad694c-d047-4572-87a2-087d5d0c71c4"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("55ba022b-457c-4fb1-b116-1585e9ca5453"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("56661932-9663-4fca-8462-0bd52f143d88"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("5798a4d7-f86a-461d-878d-33fdc9289521"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("57c56e04-d546-495a-931b-7a444de257f9"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("5813968c-1bdd-4fc2-a7b8-d43f595accf5"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("581d6938-f602-4d43-ba14-482bbfb98984"), new Guid("9a726541-3470-4956-903e-aa3731482e4e"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("582b0119-44b8-4bf6-903d-5ec891a36b92"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("584ebcf9-4d7c-4ab2-aa8c-26f9afb34fba"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("5899ae36-b320-4a92-b87e-c8d57dbdf9f9"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("58d4ad97-5907-4a78-80d4-04806b9f6a18"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("58da7e44-df6d-49f0-a0a5-1bb4400fac3c"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("5908735c-1dac-4ac4-874f-0182647486c0"), new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("595fdbb8-3aa9-410b-8e4e-2f8cba92d1e7"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("598649f1-3f24-4b3b-a0f5-256c7050ee22"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("59ab2e70-7c77-42c2-bae4-c3abe82d7c88"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("59cb19c3-270f-4caa-b85e-411bf3934bb8"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("59e5fce7-6a45-4e0e-b505-6542c223b7d2"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("5a052b3c-6038-41f5-8569-3014822aa37a"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("5a0e27d1-a2ac-46c6-b36c-fb7fa483acef"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("5a406a32-e65f-4789-8104-c6ae72d5958e"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("5b4444fc-ce30-46e7-9053-cc79ffb925ef"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("5b9a9aa6-7015-4332-898d-5072d9e0d4ce"), new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("5befea0f-a4ff-4ae8-a0a7-1d3c862a8f84"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("5c7afc3b-1fa5-4484-aefa-642087cd4f79"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("5cb5da6b-67e0-4064-982e-249d10fa84fd"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("5d0842c3-adf1-4f2b-97df-292b48f96ccd"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("5d387100-72de-4ec3-a5aa-3baa51f32909"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("5d72e95f-c87d-44f5-be68-765985509a4e"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("8126231a-e1ef-420f-b445-2082755bb12a") },
                    { new Guid("5d965186-7007-440e-972e-39351e588cd0"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("5decd6ae-7cbd-4661-9639-f94a7088cf29"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("5e47b8aa-1450-4a75-bda5-db52fa27bf02"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("5e54f1e8-7c62-4a5b-8f97-9720eaa43f03"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("5ec4a5e1-5dfc-4338-bc9f-6c369697a17b"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("5f4871ae-ad02-48cb-a900-86f94d36aa8a"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("5f70ff89-bb6d-44ff-8f86-9a20c567ac04"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("5fc549cc-8204-4d4e-8990-d31069014b0b"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("6000e60c-06eb-40e5-a264-f0d7679381fc"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("604dc7d3-ee44-4386-b352-e55bf76bae16"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("60ca1e7b-f10c-4bc3-b743-0204d7875cfc"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("60f7ce54-8309-4fa0-8392-1f33117ae3b9"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8") },
                    { new Guid("6103ce32-e7fb-4a3f-9a18-8f5cc05c001a"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("61bae3bc-b00e-492b-bcb4-dd6d748b020d"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("61c0cddc-37ba-41a2-be1c-bfdeafefbe32"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("62dd722b-1a61-4ee7-a429-85c57476ff2a"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("632f539a-2207-4ea7-821d-00bf378b1d79"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("63642598-e92c-48c8-8e50-3031a779e9ff"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("637ea79b-f556-4880-9c52-09b3e267fdc8"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("63912d9b-0df8-469c-8368-6ca67f3a44cc"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("63f31f95-f82e-42b2-bf95-671a0cd266c8"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("63fe1d5c-eabc-495d-b3e2-0b043fe5bd6b"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("646df5bf-4532-4a84-ae9b-004df34f5079"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("649dbed3-db41-4b9c-8a75-31a3edfbef38"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("65035b01-4a5a-4688-a453-002a4d329e4c"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("65834264-aa93-4972-9b63-614f4bd9e9c2"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("659c26cc-8bf3-43f4-ba42-419f38f11436"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("65df6cfe-1062-44ff-95c4-05940423b957"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("660f58b9-fd61-4bf3-99a1-09725036eeef"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("66229ca8-00f6-41e4-84d2-be88a6b7faa5"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("66385f2a-9ebe-4c56-9455-1e86138fc83f"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("664f1b77-1278-4eca-b09e-3c98b98314c0"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("6675cfaf-80d3-45fa-be50-9489cdbe5058"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("66c5059b-4ae3-4ed2-988f-be8adc5a2fc9"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("671bd4e1-a538-4ac1-88b2-157b50b21f89"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("6748af0b-a35c-4c36-8167-d6c235fc6b5c"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("686ec387-c890-4d2b-8c03-61493a0f8fd7"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("688d5385-8ce8-4296-81d8-0c7ecaac6d9a"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("6892ad24-fdcb-49b1-a674-505c5ded0431"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("68b3bda1-a02e-4e4b-9e14-ce639bebc0fc"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("5c82d9b7-0dd8-4d2a-b7b4-048257c73bc0") },
                    { new Guid("68db5323-bb3a-4fab-a79e-7eab8e595a5a"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("e9128b8c-0324-4e3b-97e7-8f055ee50c20") },
                    { new Guid("6930c47a-b362-410c-950e-a6aeb564cc90"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("6946fbc4-a0c7-4f76-bb01-8c108b7de225"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("69af19e7-8be1-4e94-9c1a-4a55492345da"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("69f3f2fd-95da-483b-a493-a8188016b1cc"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("6a0df18c-0c3b-4208-8c11-fceacd9f6ce8"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("6a2f91ac-620a-4b93-849b-0a4b18f593b2"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("6a51c2a1-dda5-473d-9f67-ff6b5e42e703"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("6a63027d-9d7b-4135-b750-d8e25691ae77"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf") },
                    { new Guid("6a74fdd4-5b90-49af-8bd6-af42d204ec70"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("6ab68b12-ed69-4b48-bdc8-640cc0e1167c"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("6b05387d-23ea-4096-a0f2-1a8250940b46"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("5c82d9b7-0dd8-4d2a-b7b4-048257c73bc0") },
                    { new Guid("6b100f85-6f3f-4cf1-a869-e6ebe55b6e4d"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("6b874f3b-33d0-4f91-ae2c-bfd899aa9ec7"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("6c33f3a5-4d76-42a5-b892-affb2f936c9f"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("6ccb642c-9461-4253-b4a4-f63e5b353517"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("6d4d2838-35dd-44fe-8024-2034c3ae5822"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("6d6c3c22-eb20-4210-b971-a44290190eaa"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("6d882728-53eb-440f-9c53-4fe878feaed8"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("6db04778-63ff-442d-b59a-5f94d6cc2203"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("6dd9d2ea-d942-4522-998c-3919f107b25f"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("6dee4808-6449-4686-b25a-c265b19c7cb6"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("6eabb805-36a7-4777-b56e-5457f07c06c2"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("6f116130-020b-42ad-a080-0c503b2e4b47"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("6f6a49c2-5f7e-4731-9c7d-ebd3f8e86470"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("6fff49d2-f586-442f-9012-5f0a468ad129"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("701a3360-cc80-4f87-aaa4-10d693dcb5f6"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("705aea9f-8a8b-46c7-96af-512446b338ed"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("70a93842-a933-4337-8938-f30e11098215"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("71234d1c-4765-4fe1-a248-7fc11ef622b0"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("7181a4dd-9ce3-4e38-bc76-9bcf9e9c65ed"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8") },
                    { new Guid("71f4e7db-f340-4a0c-aa05-1902894842b2"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("72020612-ae8c-4c96-a3b4-fb99783e9974"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("45caaee9-f60d-421e-9913-55eb5b41b7f4") },
                    { new Guid("7204bbfc-a258-44b6-89c7-5a1be470baae"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("729d196d-f10f-429d-a10d-3721f0265594"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("72ac47c0-fb1d-4ae3-a0f0-cf6e6fb960ef"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("730a8320-1e93-4e59-9617-280cad2549e4"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("73765d8a-dd71-4044-9fa7-86a25f5dae8d"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("55944788-a67b-4111-ad4c-6979213845e6") },
                    { new Guid("737ebfc5-d25c-4ea2-8c64-4568651bb60c"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("739b4cd3-4032-4883-955b-63756f0cdd3b"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("73af09a3-e9c5-4f6a-a98a-c84f7622792c"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("73b6da19-117a-48f0-8f8f-3ba5d5038d69"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("73ef310b-0915-49dd-ba28-23f0970ab524"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("73fff5e5-96cc-4d8f-a5ef-6571d919ce30"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("7430ca13-319a-4bd5-9eb7-9dde452d8887"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("74edfd97-0323-4b03-b054-52b2c5571874"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0") },
                    { new Guid("74ef1ea2-5446-4b29-897d-45aa5aaf6c95"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("754a33d2-334a-4bf8-a0eb-6da0725c8d84"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("7565dfd1-3b82-4936-a680-e463f4df0837"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("75a5d2aa-b769-4130-bf38-a7da03ca40cb"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("760ce3c3-7c1f-4881-967c-f28720a8e451"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("764bb794-13ab-45b6-b7ee-cbdfabdd58f3"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("7679ceb7-5bbb-4959-aea1-ade1a52d43e8"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("76b3c1c9-456b-474f-b941-2d22e718c91b"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("76cd0a1a-1909-4e87-b85d-4db7be4beba1"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("76d6217b-95e0-4f07-a551-14c3b9058d1a"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("77316592-5ffd-4e10-a2fc-765e9508a577"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("77351f5e-4a93-4d05-9ad4-3141fd75a858"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("7779db80-baeb-4576-acf8-d21a6d6d4a45"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("e9128b8c-0324-4e3b-97e7-8f055ee50c20") },
                    { new Guid("77dd1569-91a7-4071-a0f7-402237a5aad7"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0") },
                    { new Guid("78424acb-c101-4cec-b6b0-391be74711ab"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("7899ca92-cdb3-45ed-91c3-41f491eac291"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("78ade09b-31a8-45eb-aab7-661f4898a265"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("78af2b45-61f7-407f-b142-269caa9c427a"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("71ebfb68-d9fd-455d-9ec8-e3df3900fd17") },
                    { new Guid("797a0352-5166-4972-9a6c-c5e186ef60a2"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("798fb464-e9aa-49b5-9a18-057834afa6c0"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("79b5b5f0-2c5f-4458-90ad-07dd2080b8a3"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("8addb550-241d-43f8-882b-ce328401317b") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("7a1221a3-c4c6-4e18-9907-75d906b34171"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("7a90ce77-2448-4f17-8cff-2c01ef6af72d"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("7aabd614-5413-4236-b662-e37d2b87f152"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("7ae0d3a1-7d97-4f35-885a-d19777322c33"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") },
                    { new Guid("7aef3c1c-457b-4308-8c4b-17a60b4d9eab"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("7b657adb-8882-407f-b1cf-7b7fa12299c4"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("7bb1d7ed-796c-495e-8bdb-6fd1f325edca"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("7bc84971-bc50-488a-82db-8f7b5c2800af"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("7bcc05f8-33c9-488b-a800-105d86c6f349"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("7c6b4b23-047f-46de-824f-08c721c9e780"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("7c8d5f97-428b-4eb9-b5b9-ff066bf6cd49"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("7ce92455-7b33-4475-b669-34b89cb3af53"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("7cfc3e2f-c1ff-4782-9505-acd8fc61371c"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("7d014669-644e-41d3-9141-f1909b32725a"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("7d192e0f-78fa-447a-88ce-ac332e288b74"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("7de82923-c6fd-45b5-9364-24dd810f6c46"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("7dedb4c3-7f22-4617-bb94-a149b3969ecb"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("463454ef-dcec-4e4b-9628-2b8c84a6eb38") },
                    { new Guid("7e084fd0-cc3b-4a5c-af57-1739df278c86"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("7e0e8678-6a0d-46ba-9442-79551837dd19"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("7e361e35-c0d2-4c38-b864-19c328d9a384"), new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0") },
                    { new Guid("7e52c157-5d19-41f2-a838-d959ec40c211"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("7e682e41-103e-4042-966d-0683c70ba10b"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("7e6f160f-13e1-4573-ac4e-989fe47021e1"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("7ec69e7b-46ff-4e4c-a45c-2ff56b4cf9a8"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("7ed55273-93fc-4d0c-9966-8a5a9a79b446"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("7f2c3a4a-a3c1-4bef-b538-239d5d5ec40e"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("7f2e98df-16dc-45e1-9456-aa1ff277b555"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("7f3a931b-cfdb-4ef0-92b3-f8fd3dda36f1"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("7f4547d1-4be8-45a6-8813-7ebcc35218a1"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("7f61eea6-30cc-46f2-bc7d-41f6ffcb9f45"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("7f623d14-dd4b-4984-9607-6549e7addc8f"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("7f69c2d5-9b84-4ab1-a69a-e698fdaf785f"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("7fb5c005-d3c2-477f-94b7-4cbbfbd15070"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("7fdac2e7-e3ce-4979-bf84-78fd93b30535"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("7fe56182-93f0-4495-8d5d-274c33d8ccfb"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("806b1704-31fd-451c-8506-e51ed2b85d4b"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf") },
                    { new Guid("807dbfee-b73e-47d9-935d-03409eb95c38"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("80a62103-3cee-4834-b660-631cf8c1b201"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("80c97ab9-48b9-493d-8b3c-6da6c21e885f"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("80dffa2b-3db8-49e0-b68e-69fee4402f4b"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("81200c3e-8096-46a9-b65c-a23ee35c95f1"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("813a325c-ad33-4e1c-951d-4ce6eaf393e0"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("8148ae80-33f3-4837-809c-7739bcf45c5f"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("8074ae5b-9d87-420b-9556-302280538d40") },
                    { new Guid("81751b89-ed7e-4f5e-978a-2953b62aa9ab"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("817d122b-3a86-46e8-9ae0-f0faa236544e"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("81d5306d-4fcc-4afb-bbfd-fd881c211b00"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("8206d35b-5561-4dd9-9074-463f90f7fd1f"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("82481d67-c729-4076-b37a-03220150b89f"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("824ebbef-e8df-4e09-a9b3-d6410793d87f"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("824f5e3b-3c11-4cf6-8d2f-a67f6e10f852"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("82725261-4e83-4522-87d1-e9ab17381c8d"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("82807577-a4fb-447b-a936-f623c309ba59"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("8282cd2a-1524-416b-a511-11163396f28e"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("82c7c3e8-2e5f-47da-a6b9-1a641d355191"), new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("8315b037-da2d-4e0a-b9b2-7e0bf7291eba"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("83357427-e776-4a1a-8f21-2d78cfcfc234"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("83f235de-c622-43c1-97fe-9c6cb52283c6"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("8411a11d-6009-4a5b-93cc-b1fe3048312c"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("842821ad-94e9-4350-b9f3-e2486f0dcd49"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("845707fc-493f-4cae-8420-6f75b7f85d2b"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("8480a335-9745-4258-9c0b-3f7f3d189cf5"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("84a3b5fe-bdb7-4c74-b782-698a5819571a"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("84f544f4-b9e2-4fbc-a5bf-b2b5dafd45c2"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("85096ab1-0ec6-40a9-91a5-891bbdb0a71d"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("8571feee-65ad-4dca-bc34-9a768cf30a9b"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("85a79223-83bc-466d-a5c8-15cc62a9484e"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("85ae0bb8-f755-4720-88e3-0b279d3ea5c4"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("86bbafc6-f956-4198-8b7a-ddcb512e9cf6"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("86f416d4-65f3-4b86-8f3b-e9dfcf7ab573"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("87240d8d-2ceb-4c3c-9973-f88f237714a6"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("872710e8-5487-48b9-bf26-c2fa4230b610"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("8759825c-a8a3-4361-bc7f-bdaacf274a29"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("87736423-6e02-4312-9004-113a9f3a196c"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("8774ef40-1911-4442-83cd-7334683d42c6"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8") },
                    { new Guid("87af2acd-aefd-4a69-8363-90bc43f95cc3"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("884d9c89-29e5-4789-ba0e-d9b76c3399ac"), new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("886d9a37-a449-4d5d-806b-e750c438432c"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("88d0d87e-e3d4-4627-90b0-8cdfa93b3003"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("71ebfb68-d9fd-455d-9ec8-e3df3900fd17") },
                    { new Guid("89159a36-a300-4774-8699-00db24031a95"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("892d9ee5-dd94-4ee4-afd9-b20daec64d74"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("8930013c-1973-4566-9199-e4f4ac35c91a"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("8941ec67-f474-4a5f-a27d-e38642fd90b0"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0") },
                    { new Guid("89a0abfb-6d26-4506-afb5-5e6c40f8e56e"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("89ce2eb7-22d1-4cd9-93c7-45873a9e5209"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("89d45691-72a3-4069-ac9c-bde02e517954"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("8a264a18-1906-4690-a6ab-f0237ee1232b"), new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("8a4b3bc6-f6ac-4356-81d9-cb38be230e92"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("8a7091bc-eeb5-4161-a58c-d8bb3ba7c024"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("8a7b407a-b868-42ca-bf2b-1e9216851b8e"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("8a8723ec-b62c-467a-a23e-9dbb9464fe31"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("8a99901f-12f4-43f2-a343-8e7d4488dcc9"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b") },
                    { new Guid("8aec8d70-0175-4299-91ce-6989683e8534"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("8af73ebb-58a5-4984-9884-215a6632a295"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("8b7051fd-15cd-4f20-9773-2ec1394decb9"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("8b785394-6750-4a37-be0e-9da001af331b"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("8b9bd46f-0d99-4b11-913f-7012d3aca0c4"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("8c1a08a4-90a0-4219-b79e-a4e558080cbd"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("8c1dcb15-152e-4972-99fa-21b0f6127c72"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("8cbc6f10-08b8-4252-8ffe-ab0eb1357616"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("8d2f5616-e436-4df4-9329-14d6e341f591"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("8d342df8-0a6f-4820-84b5-7e561a5cd525"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("8d3f26a4-e577-4400-aa1d-174da4be3b5f"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("8d438fe3-ee77-4726-b717-3f462bb50116"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("8d511efb-d2e7-400c-803b-5ae5ead6e701"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("8d83b856-2d73-4a6c-b91c-a04dcfe9d0a0"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("8dd9d138-7830-4b52-b705-8a694ee977d0"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("8ddc8b09-bb0b-45f9-a11c-85e945ddae56"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("8e1ce3e5-bdbe-4c1f-a5a9-73a42684a49c"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("8e37b364-c417-444a-91f4-49cd9aba16a4"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("8e4472af-c14c-4cfc-94ea-afc3e58bba2f"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("8e7be33b-444b-49a3-aa1b-9665ff5f6d69"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("8ea74ec9-4835-44ba-be03-b7effc4d51c9"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("8ed48294-dd29-44ce-b399-36a387f773c8"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("8f127b04-5ecd-4d2b-9e5e-6ee48216766f"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("8f93fea6-2c19-43a0-96a7-d83ffafe8a6a"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("8ffd0376-84a1-4f44-b6d1-eeaa34f8d7e4"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("90eb95bb-7766-4170-ad7c-73ec3e38a741"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("91b537e2-2e1e-40c2-8042-90f114d46e31"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("91ca947a-ba11-4466-91ca-64c88d267900"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("4570822f-c52f-469e-8374-7b3c96e6e98c") },
                    { new Guid("920befdb-c4e0-4a0f-8b3d-e35a98d93e6c"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("9245f05f-a7fe-4c9e-8b3d-d3abb00e9474"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("92542201-79ed-4ac6-8ad1-7f5008d8966a"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("92d651af-4e4a-495e-adb9-4288e480406b"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("9343a0c2-1469-4aa2-9693-aed5e914e2b1"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("463454ef-dcec-4e4b-9628-2b8c84a6eb38") },
                    { new Guid("93dcd595-78eb-4175-94af-d01ce6218206"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("94112729-7f10-4dda-b51d-64d5738d6110"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("2195b083-3622-4e68-beca-6666738371bc") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("945c4f47-5b53-478b-bde5-bc3992aa9996"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("94bf90c4-5d3f-4a31-942c-85ae810c335c"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("954b9518-46d2-4e06-9d08-c3f0d0d6d9de"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("955f0484-5912-431a-ab11-53b9cf604282"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("95b99cc9-e49b-451d-bbf5-ad50492ca288"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("95bafff6-b6f0-46a4-b1a2-a590f02b64d8"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("95d72039-eb70-464b-b33d-b7c65228b867") },
                    { new Guid("962c017b-8c23-4312-9719-ca49577331b9"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("964c9780-079b-4665-ab4e-5760baf090f4"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("965bcd5e-3b49-47c9-8b19-ee730be14365"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("968bc665-eb7a-4394-b894-9d3082e45fd4"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("96bb5eac-11c7-4507-a074-8e485546e31a"), new Guid("5bca1f5c-6a9c-4c3d-8b00-1ece00d99a4e"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("97103cb3-3f2c-498d-83d2-152d8b50b664"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("972ae099-42e6-4d22-988d-6fc8815f8d05"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("97582a14-80e7-4259-b560-dab6cbd9fa13"), new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("97648e8b-93fb-4fd6-97b9-0de74d64a53e"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("977725ac-c097-44e2-9d48-c567310dce9d"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("97a22938-769a-492e-98c0-57ba97e8daae"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("97cb4583-bf89-4e4f-a7a2-8a9aee9aee46"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("97ef438b-0e81-4bcc-b605-69e8b25cf7b2"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("9858fcd1-c09b-41ce-960c-c1f17dcc712b"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("988dc3d6-061b-470a-8b9e-3707ae34b933"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("98ab39c5-5663-4496-bb0c-1de65df955a2"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("98e5962d-064a-41bb-8d3c-b985331f5353"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("9973a2bc-072c-454e-9e13-94e8f2261030"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("9975f858-b2ad-489d-91a7-b1617f59ca73"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("9a4adf7e-9bfe-4449-bd29-3efaa8f989f2"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("9a58019c-86f1-4db2-9c63-08128197792b"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("9ab62012-cd71-47b7-97c3-80103fd21ac7"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("9b299d4b-8ebf-457d-a85b-c68876530ffc"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("9b52bc38-5493-47f4-979f-7279561960be"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("9ba818c7-6c1c-4297-8a9c-58fbad799ef6"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("9bc83f51-5676-4e05-990e-267060e97c54"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("9bf3c538-6720-4031-9640-d31dedbb1bdc"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("9c4ca698-3e6c-4114-8081-82419f02d269"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("9c64b0a4-6ea9-4af3-8fe3-8ea757550284"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("4570822f-c52f-469e-8374-7b3c96e6e98c") },
                    { new Guid("9c8a6b0e-8aca-4dca-9bf5-fb36ead0b9e5"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("9cb26220-9a15-4dc3-8464-a630e51a405a"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("9dfc349e-c144-4759-b392-9b039521b5df"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("9e5baf74-8788-4816-b694-b74729aad044"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("9e88647e-c3df-462a-b9c9-22b75b61bd6e"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("9eb664b4-686b-45c8-9a31-18dbaf0d6093"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("a0eeb12b-0a0b-43c4-8ef6-68098c228df0"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("a11772f5-4d36-4beb-a91f-e2414bbefdc0"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("a11c8502-f5c3-4e7f-8ee7-b4c15d3e2bb9"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("a126e025-519f-4a68-a5c9-0390dc064302"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("a131754e-9f38-4f93-87f0-bd38c8815711"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("45caaee9-f60d-421e-9913-55eb5b41b7f4") },
                    { new Guid("a14a38a6-4cce-4035-8af7-e534dac2e8fe"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("a19bcabd-c30d-4c9b-a3e8-ae5b15ab09c9"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("a2602f69-719a-40f5-b73b-100c7f9bebf0"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("a2a19c1e-16a5-4d6e-b5fc-6ab96476e20e"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("a2a5adb7-f13d-4002-bcf4-88b5e113db81"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("a2d1de07-a704-42ee-9142-b61de58e978d"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("a31b4603-e6fb-4a55-8cac-145015fe9419"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("a36fd2a1-f182-4422-815e-49e680935f95"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("a3a3f3f2-d9d5-4290-b8e2-7d92cc0cdbaa"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("a3cff0f0-1597-43eb-8936-530ff2bd207c"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("a3e9752a-92d0-4501-9285-8b8fe5b6d837"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("a409339e-cd47-4189-8ae8-b4acaf68b419"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("6931ffbe-b2a1-4e28-9a9f-de09e1d66e21") },
                    { new Guid("a44fbe54-7c04-4a99-ade4-89935e07b1c9"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("a478e7d6-fd07-417a-ba87-16580102246b"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("a4b61ca3-c063-4541-9147-0c6149c0c637"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("a521b9b0-99de-41bc-8fb3-c6a24988ac35"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("a52869ae-6ded-419b-a5b3-d98044b565d6"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("a588df94-a8ec-4dff-a536-bf031190b2cc"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("a5986772-8250-47eb-ba1b-90f3b8d8f52b"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("a5b70584-5828-49b0-97a1-4feea73ce518"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("a5bde445-2abd-4e3c-884f-ac1bef3bc941"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("a5c4b0a6-64df-483b-8150-899b29f0faf6"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("a5f8a28d-8ec2-4b84-a1ba-2872249135b1"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("cab0192b-1b83-4e6b-a8d4-7b57b3fda22d") },
                    { new Guid("a602800c-9b9a-43fd-9270-ef1ab955da91"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("a624734c-9a5f-4c1f-9265-a5611852bb6a"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("a6a286e6-36b1-465b-a309-835418c75eeb"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("a6aa8daf-de95-40a3-bfaf-b59a686127da"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0") },
                    { new Guid("a6e1abc9-18bd-48d1-b596-526852347fdd"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("a709fb7a-6df6-423e-975a-3fd784fd65db"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("a71b6c0b-37ce-43c2-8dba-f93eba59c542"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("a80f40b1-a79a-4deb-b5c5-6e54d7f36947"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("a82994ac-0cd5-44bc-a544-764ea5b31a3d"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("a8b657d5-a8c9-4bcd-8722-0100a5a8a4df"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("a8bb43d8-ccf9-4b44-a37d-a00af0c061ce"), new Guid("9a726541-3470-4956-903e-aa3731482e4e"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("a91d80dc-17fd-4a81-87d9-e8640814a9e9"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("a9518107-2fa6-4cde-8ed4-34d0b948ab72"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("a9860c07-5b96-45ce-8b6a-1fdecc9209c3"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("a9ec32da-8e93-4dde-b8d5-fd49a056783c"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("aa35a7ae-70ee-446c-a29c-ddf1058c88e2"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("aa806b87-25bc-4f8e-8f49-e569e8a274b3"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("aa9e928e-c916-43e3-afe6-f52aea7ed976"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("aac44682-fb8c-4c6f-b029-1d23a796ec30"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("aac9d1ca-04b3-4a6e-bb13-10d1abac66e0"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("aae94ecd-d844-4fdd-9e9e-1f21f0bf66cb"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("ab8ba6e1-3a3f-4415-bddd-86c10821d0b2"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("aba27775-3f36-4e07-b10a-9e7ed39b6c10"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0") },
                    { new Guid("abad02a8-2f70-43a9-bbb3-a8ecdf2b6ec5"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("abdcaae5-3d23-4c82-a3e2-254aa37b6a0a"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") },
                    { new Guid("abf4ef54-9168-4070-8dd6-43ac4a61a003"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("68a5ab67-e774-48a4-8dae-3dd97b3c0dd5") },
                    { new Guid("abfe616e-db07-4219-985a-94a43078294a"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("ac684178-8ad9-468b-8f9d-7d57ce5bcad2"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("acc4f039-bce6-4206-a6f7-af35842d5209"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("acfd9e99-9a34-471a-a3cb-a5f0ffe85ecb"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b") },
                    { new Guid("ad98b091-20a5-4297-9dd3-5c60ac015535"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("a71ca591-3d3e-4848-95d7-450c6d5b3c66") },
                    { new Guid("ada49e3f-da01-4ef5-825a-259ff27813c5"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("adedf902-af7c-425d-ae6c-98272e8d425f"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("42d5eca0-6cd1-42ab-b185-133f908507eb") },
                    { new Guid("ae0009ce-7ba5-49a3-a1fa-c0f01afbf0fc"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("ae02ee5e-80fd-43e5-af3a-bda0e4c3ddc0"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("ae4a4ddd-c88e-4977-9c45-ff5d837897f3"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("ae5d7ca0-76ac-4192-bb64-329cad735e36"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("af61dab9-c821-48a5-9679-100bf7ed3406"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("af8028cb-3a9c-41f6-a17a-004dde15d5fd"), new Guid("d0deb7e1-e3b4-42b5-8ff3-2ddfbba844e4"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("b0238bf6-763b-4110-8bf8-b627e373ff10"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("68a5ab67-e774-48a4-8dae-3dd97b3c0dd5") },
                    { new Guid("b05a17d2-cb23-4934-ac78-f7fd534aa26d"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("b0908462-202f-40cf-9c11-3f9c1f08129c"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("b0aef1a9-165f-4601-bc70-b2b0a3a3d35c"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("b0fa3920-b9f8-4799-8362-68e5841b34d6"), new Guid("9a726541-3470-4956-903e-aa3731482e4e"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("b104a541-a96a-4e0c-8576-7cca299a6546"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("b11e3a2d-6016-4a14-80ab-951a7bfa9a4f"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("e12e9b12-b1b8-47f2-b503-9fea9eb73703") },
                    { new Guid("b14d2d57-598c-495e-a68a-99b83c0603f5"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("b16c725f-a935-4613-866e-dc0a6656e7cd"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("b2aa0894-1d48-4b82-a762-2a1ca92724b3"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("95d72039-eb70-464b-b33d-b7c65228b867") },
                    { new Guid("b2b09af4-3dfe-4a64-ac40-3607c933fef2"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("b2e97804-c61f-4edd-9e29-2e2378a233da"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("b3892a1e-775f-44d6-8e62-29307792315b"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("b3aafaef-e042-41b6-884e-a0d7bc11089d"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("b3ecf78b-da01-4e3b-8c8a-5437d1042b57"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("b4080871-81f4-41c0-b46d-bec67389a1c6"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("b40c0818-65f3-4702-b594-d078b220624a"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("b4122f7b-82e7-47e6-9f20-f06551563393"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("b41861b1-9c70-4d6d-8665-5fa9fc70749f"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("b429aee9-2340-48f1-b660-9f7912519e22"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("bfe94f71-5d84-4d22-8533-f68576f82805") },
                    { new Guid("b43f5fda-75f9-4dff-a3cd-9f8b781cc210"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("b441c36b-11e3-4628-8cec-9654bada6cdd"), new Guid("de0a167b-be16-4f0b-b1ef-bc53d708df1b"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("b46b9e4a-4792-4d2e-9b41-b35cf1a41837"), new Guid("55972629-e0e9-4577-aff7-107e36898ed6"), new Guid("aad696f7-a0f9-4cfb-b1ad-e92419b2de8d") },
                    { new Guid("b483e5b6-7343-4c76-b494-a2b43bbaecef"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("b4904876-6090-4b64-b72b-c2415444e2f1"), new Guid("b29ab598-326c-4873-88de-358f94db58c2"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("b4ec5584-aafd-4dc1-b568-dd69a8c5b005"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("b5311b8d-a4b4-4616-9203-a85bdbfcf9ca"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("b5437e04-edae-41b7-bc9d-0400901e0cfa"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("b548651b-1bb1-4dba-ab99-32d6526af5d4"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("b54ef151-f3a2-4066-8902-959b6be3992f"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("b5820304-d47b-40d8-92a1-b143986fc8fe"), new Guid("7bd71801-5eb0-486c-a8d1-d4ebbbd08bb4"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("b58a6e6c-7068-4952-96e3-58fc0bf6b87f"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("b5dc8148-3cb0-4cbc-a820-e8dedff6e12b"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("b5f05995-74d3-4534-9e0b-5a719d8a29cf"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("b636a9ff-f673-4539-90bc-3d70b5bf1bfb"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("b77829cd-6d93-47c5-afe5-b4a8fc9451ac"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("b7bd7f4b-1e53-43f4-9a94-b9c2dd71928f"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("b7d29252-5b6f-4a17-b98a-3d9407d25e1c"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("b81026e2-6602-43f7-97a3-faf8bcabbd59"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("b850bcf7-245b-4877-b1df-23372ccff8b7"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("b89445d0-0c84-40a5-9c9d-3e2f4b40bbef"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("b987677f-125e-4969-af56-b4e0a7e9f605"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("ba449472-1afe-40fb-9cb9-8ef77602b3da"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("bb9531aa-56d8-42ce-befd-1f533355d0f8"), new Guid("ad6e7ee4-24c6-4bbd-9ed7-9440904b2193"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("bb98975b-5af7-485d-81e8-2220632f0751"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("bbfee5ec-b5a7-4d18-9904-bc66e33b5936"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("bc54a49f-7b8c-4e0c-bf89-75d15e89b9fd"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("bcf06b95-8e65-49bb-ba2b-c036411f1e66"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("bd5fdeeb-1cf5-45a3-8d39-7bb6bc82df15"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("bd76d232-fbc8-4670-af59-c7792a40e21a"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("bdbe917b-aeee-42cc-98ef-8aa188c61f8b"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("be1e8fc2-25b2-465c-87f0-0325ace5dfec"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("be287c1a-6345-4996-b397-d15b9484152d"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("be573e8c-ed99-436a-bc6e-b55041bcb2c5"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("beb9d58b-add2-4c43-866c-a7a6a987e73b"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("bebe31d6-2832-4ce7-a633-71003c9ef332"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("beca98ac-3660-483e-b516-a1640a30b4e4"), new Guid("1c5b4882-dbb3-4a8c-8834-d942a8965c8c"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("bf10293f-e06a-4c8f-98ec-cb04c1768f0a"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("bf1a1784-a898-46e3-afb2-00b708d21d94"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("bf362bb3-b11f-4d79-8b79-f0c33da09067"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("bfcb8ecd-e700-4708-a98c-7096dcf5df7d"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("a9beebf0-dfc9-4eb8-8825-54d3ae44c6d4") },
                    { new Guid("bff7e3a7-536b-4a1e-8987-a840335afecf"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("c0033083-f6e4-4726-a4a4-8a95fba273a3"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("c00af776-caf2-46f2-8100-f3a2111eb6f0"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("c04f8253-97d5-4a08-9f5e-0480d045b494"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("c0c19102-d2a5-4f96-8f28-3bff9577e5c1"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("c0dec629-5742-4499-8f42-fabe528acb79"), new Guid("def60b37-9224-4a3a-a022-fb0a20e64bb0"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("c1209b82-cdfd-466f-ad5a-14fb505321a7"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("c120bb13-ee23-4375-9148-05bdeba8fce5"), new Guid("8ccf5b8c-7049-4751-9e3f-3ccbdd2795d8"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("c188b348-c194-4d3b-981d-893b0b95db1b"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("c18cf292-ff89-46e2-bfa6-d6375eb39aff"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("c1d67115-d9c1-4164-b685-e8a188d2d42c"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("8074ae5b-9d87-420b-9556-302280538d40") },
                    { new Guid("c1dd77a8-9b91-4596-804a-11765b4dcd82"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("c20d1b05-9a15-43ca-a72a-647e70bfe5d3"), new Guid("9a726541-3470-4956-903e-aa3731482e4e"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("c2479b94-72b3-455e-b959-1e88ba174c1a"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("c35bf2e9-23d1-45ee-9b8d-c075ad867af5"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("c3d9db80-7276-44dc-af31-9471178ca6ab"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("c3e411be-bdf8-4136-ae73-23a2e342137a"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("c45ecd79-9e9f-4dd2-b203-4a581c28590b"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("c4769ab2-fdbf-479e-a2e2-3b240bf40b3d"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("c57a32e0-a7a0-40c6-9816-6cbe2d6e87d3"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("c694681f-9736-4a9d-ab9c-d2b20369da62"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("c6b8ebee-ee02-4f60-aa3c-b8517a05a05d"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("c6dd5d0b-4515-4d34-ba5f-a1cf6a46e22a"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("c79f2093-48aa-4534-8803-cc62dd7f5bcf"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("c84333bb-f07a-4b26-8784-c3fc0d62f113"), new Guid("ac0c477e-e094-4a14-b12e-51a1e88fc1ae"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("c84430c1-aade-431a-a5ba-7e8ddedf9bf3"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("c8b5623d-7db0-4e0d-b590-c683938bf62c"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("c8d8b82c-3b56-41bf-b120-b53656e7f7a1"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("f533775e-eb2f-404f-9713-fdf23a59b349") },
                    { new Guid("c8ead920-16ac-4aa6-941f-bdfe68074650"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("c8f799ca-a7d7-4778-9234-833b9e5141df"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("c98c8bff-66fe-4b3e-8a89-70a29af3da27"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("ca042337-7386-4125-9a21-a1bec0a8fb0b"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("ca48dedd-16f4-484a-8ecc-3fc873ecb581"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("ca799fe2-550b-4971-b86a-06875a40a73f"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("04e1bde7-830c-4acd-b66a-729c5d5310b8") },
                    { new Guid("ca93b65f-2093-4a56-b931-eb224c6bd628"), new Guid("df5d57e0-76eb-47df-9538-a24fd7949368"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("cab06b64-e8fb-4f07-b341-8acfb5b3751c"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("cb427267-a424-450a-b1ee-daf5bc304c8b"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("cb5a7f3e-2817-4132-9150-9fab3f10cdc6"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("603545c5-dce2-40a7-bc77-9cf38c71fdc0") },
                    { new Guid("cb6d04f4-4657-4f5a-a9a6-e6f9f8dc4924"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("cc02d3de-c912-48d7-a114-3f18be6c00b0"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("cc7526dd-6731-43cf-837d-a7f951ea99bc"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("1230ec95-f42d-4361-ae91-824194359bff") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("cd0f92f6-4cf1-49e2-ae33-df991b807c2f"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("cd153c50-6382-4e98-9f53-f4df6c2b74ff"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("cd2296a6-64ea-416d-b236-083e48cb9c7b"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("cd25e60c-0e4f-4326-9a0d-92af94277c64"), new Guid("37f1eecd-9fa2-4431-b32d-1c6add72fd92"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("cd31a684-2c63-48e0-a0db-0e674d8733d7"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("c8cb971b-2c8b-4ab2-a572-e15e92b681c0") },
                    { new Guid("cd3570ce-68d6-45ce-a5d8-46acb383979b"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("3ab4b0d9-262e-42d7-bbf5-1a6530f41980") },
                    { new Guid("cd3c655a-0762-4181-8e61-ef68d97d022a"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("cd7f0ef6-a5aa-495b-9818-7206a40ffe9d"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("cd914dfe-ac42-4248-b725-ea31afc24229"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("cded67d1-ec51-48bd-b69a-03b672538991"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("ce21cd91-3342-44a7-8255-914c91edc668"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("cec02022-e0da-4372-b13d-01c92ec38856"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("f533775e-eb2f-404f-9713-fdf23a59b349") },
                    { new Guid("cec7e364-9e4a-415c-a3d3-46689c1404ec"), new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("ceee39e1-ed3d-4163-82c9-083ca79fb841"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("cef7f4c7-f3c9-456a-8dc5-ee0c686f2cc4"), new Guid("fb4a7e77-482a-45dc-a43f-d4f69fa6d707"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("cf596c9a-5ff5-4d79-91e0-d28585731bc4"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("cf63e9a0-ee0b-4113-8db2-0c0eee5cb570"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("cffd76e3-4d37-428b-9f1d-ee4e3e2fd3f8"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("15ad3208-28fa-4c1d-8b4a-2ec3c2074efa") },
                    { new Guid("d0806c40-b753-4522-be63-b7b4f1298a90"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("91eba14a-53c3-48ad-85c2-4e6ddbaf83b0") },
                    { new Guid("d08ca8a7-0561-4efe-afb1-ecef88beba65"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("d08d866d-2451-4a4d-9087-bf27d884d465"), new Guid("0a86f7c5-eca5-4734-8cd8-bfe47d2ea214"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("d0958400-7424-46c2-8647-c02086deece4"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("d0cc4d5f-1570-462c-9286-b95ded95814a"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("d0d23269-6f8a-4d17-b503-73671fdcd70f"), new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("d1114774-1f6c-452f-b730-b6f00c5854cf"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("d15a48de-b42b-4b79-a6c5-1fb9749caf59"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("d1a295fe-763f-47c6-80fe-b45a0264b90a"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("d1f36a9f-adc2-47c0-b4ff-f1878242e4b3"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("d2d1a663-609c-4fba-862a-f247d8bb648b"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("d3096369-987f-42b5-8241-0cfbbd7aea8c"), new Guid("b7f09a2a-6899-439a-a0cc-8ed5766da739"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("d403e774-ce86-4b80-af4d-0ddd42550106"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("d179bef0-4363-40a2-8f07-d1671b4d21a8") },
                    { new Guid("d4394d3a-2a16-41e8-8322-4195627eb61a"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("d4559ce1-53c8-4151-a929-d92cbd04c507"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("d466e5ea-bca8-44cd-965f-896884605c19"), new Guid("33cb4da4-a17e-46de-acc6-42c1d16d9fbe"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("d49bd95d-c71a-404b-a70a-0694a36ca57b"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("d53eb890-fe89-4e01-8381-653067c3d088"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("f533775e-eb2f-404f-9713-fdf23a59b349") },
                    { new Guid("d5526429-f00a-49bc-8fec-0af967362c45"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("d576a21c-af59-4693-886e-9692b9f290ba"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("d57e1a65-c93f-4844-8de1-5582c5c763ae"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("d5a8178f-facf-47d7-8de6-51a547857928"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("8addb550-241d-43f8-882b-ce328401317b") },
                    { new Guid("d5c09664-5bd6-4c5a-bd3b-97399d80182b"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("d6198f6e-fd31-4346-a48b-08b0f037b0db"), new Guid("2d4d5580-89cc-4a54-9c3a-f3cb54115667"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("d65a28db-9049-4e64-aa79-e6a87907bc6a"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("5c764ded-80d3-498c-a87d-3783174cca8a") },
                    { new Guid("d70ddb74-3ebc-4498-8e65-17f1074e846f"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("d7654976-72a6-455c-b343-34071aac37d7"), new Guid("19c3ddcd-5680-437a-bef0-5e971dbbcd11"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("d7971745-8c74-4383-8709-160e7b649147"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("d7c018be-524e-4624-b198-f8acc8915ff7"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("d7fcf1dd-800a-4889-b8f0-2fb9976950df"), new Guid("57c58762-baf3-4079-819e-d2d5b9d330e0"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("d81f5aed-cfb3-458c-9084-0202e6a43cb1"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("d83b9195-5624-4dad-8fa8-26d2a21554db"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("368d58e4-48a9-41d8-9f93-cd782a5246cf") },
                    { new Guid("d87f3684-8411-4e8d-8db6-25cc96467241"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("d94ca279-f48b-4e70-99d8-146f0f1823d2"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("d96fca36-dbbb-4f5a-b4bf-7040aae85867"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("da1d137a-ee28-46f5-9fd1-d39dfafd53e0"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("4c4f06aa-2b84-4a7c-b58c-fb7dcd2e8037") },
                    { new Guid("dab48ccc-2737-4ad9-ac08-76b04fb5efb8"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("dace30d6-e5c5-46e5-a9f5-e97a3de4dbd4"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("daf023ca-f3c2-4c52-a6df-996ff7c057c3"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("daf241b0-51d9-42e8-943d-5c9e04febbd2"), new Guid("aeb92b4c-19f1-4031-8c59-3e5f10a948a1"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("db96955d-c7f9-4064-baea-0a3d8fc96407"), new Guid("bc64e0d9-222b-4941-994c-3dcb68c8dc01"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("db98c42f-e82d-492e-914d-e55ac8cf50a3"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("dbabbd11-4609-4eca-bbb6-91b34e24b30e"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("dbba0629-7a94-4cdd-bbb8-3ef72914e9cf"), new Guid("2b525350-c2fa-4238-bfbe-d0a099301f0a"), new Guid("00d21ab9-f4f9-45a4-97e6-39c6140be55b") },
                    { new Guid("dc8e22bb-a84a-451e-af8c-dce00d3923c0"), new Guid("79c7e7ab-b96b-460f-80c4-5eba3b48d9a2"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("dcca0f30-d358-4d03-8a10-f4c2aa949d35"), new Guid("6359fda7-1a9d-4ede-b741-2efb8e5253da"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("dceb42a3-af73-4ea3-8c75-797a9642cb3f"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("dd283456-9e97-46be-989c-62c4c4f22e70"), new Guid("8a3d16e9-e092-4901-82b8-07cab0e50bd0"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("dd42f91b-813b-49c6-9243-13e710fbaeb0"), new Guid("b469cbcc-17b9-42d8-9a19-58c10c99765a"), new Guid("923b5245-5cb9-4a34-880f-6c4f97634d61") },
                    { new Guid("dd5f557d-79c9-4759-a5ba-037e6ca675fc"), new Guid("fc2539c0-618e-4a25-8e79-64f29c3326e3"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("de1e63b4-36c1-428b-b566-437b96ad0e86"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("de4c172b-92a6-499f-b4c6-9e82f50e321e"), new Guid("2f2d3052-2fa9-4a73-9f61-b244d2c51255"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("decaf029-bcec-41b7-aea6-c4b7aae67397"), new Guid("36714e82-3838-4ecb-92ec-167bd0dc5056"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("df48bdfc-a83c-4a26-8f55-5b012c611b75"), new Guid("7de2fbab-961a-46af-b57b-87ddc7f3b963"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("df50c309-d4af-4669-8531-36f93724afe6"), new Guid("3adb70a8-c395-4f31-93b3-12e2aac869dc"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("dfaaffe7-be75-4925-8469-e7aa4aec0e2b"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("dfb3e945-c6a3-4735-8110-675642629663"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("dfb624f8-8be8-4989-977e-fa314b904d07"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("dfbf7412-644e-4713-9372-4f2891615979"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("dfeb064e-ee62-479b-a891-459226bb0ff5"), new Guid("52c66c0f-4736-4059-996e-9aab04f1fe36"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("dfefd8d9-412b-4f7a-a3c3-0412281a6b77"), new Guid("8e8d25af-9da6-4ece-b1a2-ef0b9d960d21"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("e006a914-9ba4-4f12-9dc5-64984d176201"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("e03c50b6-4fb8-43b6-a6a1-2cdce7573192"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("e0658752-d009-4b38-af89-523d044c4680"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("e0972735-01a9-4f05-8012-170782fab1d7"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("e09ac42d-4bf3-45d1-a924-c183d860c92e"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("e132b4c7-9ecb-42c1-8ec9-c24769f6881b"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("7cb37c86-6afa-4103-b198-d9bf787e540a") },
                    { new Guid("e1ebd8ac-7f86-4fcd-a9b6-ad0bf587d113"), new Guid("d10a4272-f49c-4c98-9a4d-5fc30408fa26"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("e1fdfe84-7f0e-4124-bc82-8f885ee66fbe"), new Guid("04bcc9a0-3b97-4044-b3b4-842b9c493d88"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("e286e77e-a16c-4ca0-b813-47e7630cac4a"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("e2b1f507-b1a6-47f8-99c9-76fcc466702a"), new Guid("1581ae3f-ae8b-4b54-9039-f7f8e25752ee"), new Guid("f7dfafb3-1dac-4b96-827b-bdd61380e352") },
                    { new Guid("e3e61fc8-9d22-41d8-97b5-a830d1d88b63"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5e91f0fc-1591-410c-9f6c-e8fc4744c7f1") },
                    { new Guid("e41689ae-8860-49b4-b13c-962566f4f5a3"), new Guid("8a8e903a-9275-471a-bb80-686a0fe89acb"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("e460fa80-a71f-4ae1-baaa-af80acb801e6"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b") },
                    { new Guid("e49c0328-92f9-462d-aaee-dabc1aec6fc1"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("e4df24c6-b80e-4908-b9cb-e861798e020a"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("e50d5a57-5f51-462d-ade5-1a94f12cc404"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("e5b49059-ac2b-45ff-a11b-0258efe9d426"), new Guid("a12e2902-0bae-4724-bde7-726cd2f77fa4"), new Guid("0245e56c-bf89-4811-ad3c-127f46543d8c") },
                    { new Guid("e5bf2673-cb79-4313-b9a3-347d8d65879e"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("77f264c2-2b61-410d-affc-5ea36c232896") },
                    { new Guid("e5e6ce56-8682-47c5-b68a-5ca829cbc719"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("3e2d2671-be78-4abf-8db9-c3c7cbe312e3") },
                    { new Guid("e602cb5d-f8ce-498d-81e2-0142bedafa31"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("e6246660-74f9-4614-88a6-b24da24f3011"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("e62f1043-2e21-41c1-89bb-79ddbd2c728b"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("e6334cad-5375-41b0-88e1-2913d1b8eb17"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("e67c64d0-f625-4a06-b684-4b221e639efe"), new Guid("b8c46d97-6fa7-4a04-b9dd-05577151fafc"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("e6963e7f-cdcc-4e8b-b9c2-5e2bf9132d62"), new Guid("82f3cddf-fcdb-4947-b271-78e789c4af7c"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("e78ffd6c-4cc1-441c-b48b-c0df981da1b8"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("e7c44f3e-f89d-4440-a033-6d94942a01ab"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("75ab4068-2d71-4b0d-920a-d11d0998ba32") },
                    { new Guid("e84fa31a-073d-42d6-98f6-62109b9e892c"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("4afca418-af0d-46df-8567-8b280e0821ba") },
                    { new Guid("e8559e7a-e5b3-4e06-9ad4-9d5cf100f1e4"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("e856e497-c785-41b9-a957-41b0ad1d0652"), new Guid("0c17955d-c671-4b3c-9723-02374685dc25"), new Guid("725ed7bb-21d7-4015-9222-4a15c4a7c4b5") },
                    { new Guid("e8ac1387-be0a-45d6-8cc2-ea9306b17862"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("e90250b0-ef6d-4a86-abda-010c186bc291"), new Guid("0456ddc2-e0be-4127-a901-050d6bb8adfd"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("e91e9ac9-2313-4da6-a149-16118add4506"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("e9300a83-3ccd-4300-ab8e-276a00c8e3ad"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("e94a0bc9-b64f-42db-b958-88ef696b5eb3"), new Guid("733c86a1-358e-491a-bdc1-51cad6da4baa"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("e994f704-aa78-4c16-aa8c-35f5e08d2b34"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("e9ac34fc-fe30-4a37-bc12-e62729a07e7d"), new Guid("daf6bc78-2d79-4dfb-9f26-50199b554750"), new Guid("06c0ff41-0ec6-4c6a-8154-b93795b3740b") },
                    { new Guid("eac8a620-9bde-4da4-a6cb-29abf956315e"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("eb4f95b1-40e7-4d5c-b11b-ada55c2a0b1c"), new Guid("3baaf643-4573-4e56-8148-8941af31294f"), new Guid("3bb530da-ae2d-46db-bb9f-a4145a9a1b7c") },
                    { new Guid("eb62cbfc-06b2-45b3-a4d9-9c382a317787"), new Guid("ac1ac2e1-d523-4103-8146-34d3e8540b1b"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("eb69f057-786d-4647-a646-521dabd176e9"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("988bb559-2546-4273-888a-b2caa60d9a11") },
                    { new Guid("eb86f6f8-e316-41a5-9b21-a3cce16395c5"), new Guid("e2e62a4e-e617-41e8-a98a-f4844982c4a8"), new Guid("e4f353e0-7620-4c5f-9068-70af67c258b8") },
                    { new Guid("ebf3ccfa-0e3b-41a4-b6e0-8e9e2078e5b2"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("c576b24a-ea1e-413b-aac0-54e5618f605a") },
                    { new Guid("ec2b3487-0579-4392-abbf-fbc1805ecf47"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("0fca7b18-e8a6-47f2-949d-58103c4329e2") },
                    { new Guid("ec7ff5ea-5878-4a57-a512-42882a4f58ef"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("ed05fb61-102b-44af-a8d0-d37add519b3e"), new Guid("054187c7-7891-4a02-9821-0bcfe7a554de"), new Guid("5338d3ae-d333-4fc6-a82e-b7252ee730d9") },
                    { new Guid("ed2a845a-b584-4556-9bf2-41eda4614eac"), new Guid("f8454b22-fd5e-4b22-92f9-781b5bb5edab"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("eda66641-412a-4ee1-8366-577fa5307dac"), new Guid("276758bf-7195-4c9e-9c68-11e60feb851a"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("edc93032-146f-47ca-82f1-c0683aecb6ff"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("a8c86a0a-f16e-4041-b851-6a02798ae2c2") },
                    { new Guid("edfeb8d4-4996-459b-82ba-e753a58954ac"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("e4950192-5467-4c28-b6f5-874473e83550") },
                    { new Guid("ee1ee58d-ef90-4b38-8ec2-ad1330453021"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("ee536f3f-ed46-47ac-8c18-77142125f01f"), new Guid("6061c632-7495-4704-8ff8-853101e6dae9"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("ee615c7d-e18b-4284-b5dd-28adf32bac98"), new Guid("db109801-5938-4f0f-89d2-94faa87c95eb"), new Guid("940f63d4-0055-4203-b9c4-cec63c5520ba") },
                    { new Guid("ee6a6076-d2d1-4013-8d67-20c27b809d9a"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("13bf2bb6-11a4-4024-b47f-90660b5006f3") },
                    { new Guid("ee934c63-b882-49fd-b43c-25e90f96e6cb"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("5e256890-c2a0-4113-b021-f0ce56a1776b") },
                    { new Guid("eeed504b-257d-429b-9e7f-bd922d6e9ad8"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("0ff86592-5099-476f-8166-389c897ef2f5") },
                    { new Guid("ef79b4b1-805c-4fda-b3f3-3d935f26061b"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("ef9a0a90-6a13-487c-b8d5-17c2bf441f11"), new Guid("b56601c7-0b5a-46ba-8fb7-8ba7a3ff76fc"), new Guid("44962a59-6e5a-4ff5-aeb6-bbfb585cfe79") },
                    { new Guid("efbff433-0fc8-4c56-802d-41dd52b03641"), new Guid("bf1b585a-2441-4f24-b996-0ff9f039df69"), new Guid("92065fb3-5cb8-4a1e-959c-db0c78aa5122") },
                    { new Guid("f0417fac-002a-4d18-9657-b64af9aacb81"), new Guid("53c959b2-3201-4c9d-8280-8dc408b08753"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("f091a287-69e1-4cf3-ae42-7cf84880431b"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("f0bd4a87-91db-4db6-8b91-311ba43a34c3"), new Guid("79d276cd-00a2-4511-a2db-d0214f4bac51"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("f174aceb-eabd-4923-b848-ab2c2b16ab17"), new Guid("f1551a92-3178-49aa-9fa0-8e94c1dc1dbb"), new Guid("2eda78f1-f945-47a3-9177-50f97cbbc200") },
                    { new Guid("f1b25f81-de15-40a9-9eaa-0cb0f4e6ef18"), new Guid("b512b0c7-d132-47a8-8685-10d75edb748b"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("f1e0ac6d-d245-4adf-b7d3-c25daac6ddfb"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("ba52c6c8-ec22-4a79-9b83-532f4c19afe0") },
                    { new Guid("f2149c36-76b0-4cb8-b0f5-f63e4343ab54"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("dd478672-cd66-49a0-9ae6-f4946acb152d") },
                    { new Guid("f22bdca2-1918-4acb-bdb5-0c0d33d82c50"), new Guid("562fc457-3daa-4efb-94dd-0b5d2ec1950e"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("f2d34c4a-de2d-4fb2-a2ea-f780fe7124ad"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("f2f9fbdd-946d-40fa-acdc-67d85a450aae"), new Guid("aae1dcf0-444a-45f8-b6ca-14bcdc9ab58f"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("f2fedaf0-2412-4f2d-b173-aa5ccef38b67"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("61647f7d-a28d-4959-9176-6ac539cc0099") },
                    { new Guid("f30761c1-f185-4d34-8e7e-8798aa74dcf4"), new Guid("fa7af651-acf6-4fdf-9caa-b295e68a6295"), new Guid("ba85d345-670b-4cff-9505-8a18d1210664") },
                    { new Guid("f317d8c6-bb90-41ba-bc60-8215eae80767"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("e9128b8c-0324-4e3b-97e7-8f055ee50c20") },
                    { new Guid("f3331d64-b176-4e11-8f4a-96e5034cf07c"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("bda12c67-08d6-4fbe-9ac9-7119dce13dbd") },
                    { new Guid("f34f1b4a-353b-4f88-a846-ba846178d261"), new Guid("f9f5d55d-2c2c-4bbf-af98-5432fa17d62a"), new Guid("bdaf5e7d-cf3d-4eb6-97e9-9c57091d523b") },
                    { new Guid("f369361a-88bb-45f4-af31-cf141967487b"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("b5abf390-93a7-4c0a-8b77-dd7e225954ee") },
                    { new Guid("f37a93ef-d962-430b-acf5-209abd6ce963"), new Guid("209d6dcb-f3a5-4365-ae87-4421c6663d21"), new Guid("d402cc37-258f-4f7d-80d8-97f6a70e38a8") },
                    { new Guid("f3d77ecb-92ea-49cd-a9bd-789beb325cf5"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("f4050017-0754-4c68-a463-cef7a562c97a"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("f7d78b97-4aa2-4745-aa8b-bd76539d8aee") },
                    { new Guid("f4426ca4-c5c8-4a50-922e-f2dbc5de7928"), new Guid("51b06331-2a30-4306-bfcf-9dfbda290adc"), new Guid("04e1bde7-830c-4acd-b66a-729c5d5310b8") },
                    { new Guid("f4496d0a-40f9-40f2-b358-057839582837"), new Guid("11c3e69a-481e-4a4d-ad9b-2c75ff1b7bd5"), new Guid("2da12171-7e3e-478e-81b9-bbf84eaa7970") },
                    { new Guid("f4554078-d2e5-4952-902f-b3a2649fe5e1"), new Guid("85dc0075-04a7-4576-97e2-3e5d5ada6ce6"), new Guid("8126231a-e1ef-420f-b445-2082755bb12a") },
                    { new Guid("f4f0a6dc-1c35-42d7-831b-6470c1132f03"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("f5033a02-3b97-4205-beff-77f6e2e7a761"), new Guid("a6866d0a-7abc-4cc0-9db7-9aa3465649de"), new Guid("7eba38b3-7db3-4d73-8fa1-f20337d4fae0") },
                    { new Guid("f50f73a3-8870-425c-ae77-2ccc334753d7"), new Guid("b17f11ed-c02c-4fae-8aad-0d0c94d53e4e"), new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf") },
                    { new Guid("f51297cb-0fc2-4271-9179-a6f385ae47ed"), new Guid("83e08f27-17e6-4946-9d59-f00dfea582c2"), new Guid("238443ad-a8d2-4a73-a350-41e9b6ebe586") },
                    { new Guid("f5341017-c624-49a9-b7e7-af8d27b6d523"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("d3c57364-77dc-4a71-a2aa-2c11e7ee68d4") },
                    { new Guid("f53699be-8e0a-4585-8feb-6c9ab53840d4"), new Guid("5885e933-342b-4620-b118-c8576750264f"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("f5c089d1-c8cb-409f-b261-389aeddbc6ce"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("f66a7c47-bf82-499b-82e7-270a1bfbff20"), new Guid("98aa063f-5c4a-4323-a942-212fd1bbf199"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") }
                });

            migrationBuilder.InsertData(
                table: "UsedSpareParts",
                columns: new[] { "Id", "FaultId", "SparePartId" },
                values: new object[,]
                {
                    { new Guid("f6e74c85-22ba-42d4-85cb-bd7ec62ab5d7"), new Guid("1a979813-963d-442e-98c4-753473ffb7dd"), new Guid("1197f9ad-973e-4704-bf8e-a001f1e2b4f0") },
                    { new Guid("f6f470c1-79e5-450a-9ba8-7af8e3417d5b"), new Guid("bf769727-de51-4cca-968d-c3e122733b8a"), new Guid("b55acc74-2a6b-437b-ba65-ee67bf4ac28e") },
                    { new Guid("f7146fca-224a-4cfb-82b3-d9b54f4db2d8"), new Guid("0872a3f8-c442-423c-925b-e58cdf2cdff5"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("f75b344c-4fb7-4d6c-b061-2521c45ae11f"), new Guid("89d4cef1-70b3-4d73-a7f8-24c67160c666"), new Guid("e192f8a8-2c9b-4831-b3fa-0bacb7dc037c") },
                    { new Guid("f7d415a3-62e7-49e0-bd95-d2acaa6db482"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("05816cc7-7e07-4992-be72-a89b39980cb2") },
                    { new Guid("f80ca780-6cb0-43c6-9ac6-09da5cefb016"), new Guid("e6e9cde1-af93-4e57-b15d-fde3d50b11d7"), new Guid("26376905-3136-45fa-b917-a36133aa63fa") },
                    { new Guid("f8c3cdab-b833-4b39-a422-d38ed6e18cfc"), new Guid("81a7c05e-3496-4807-87b5-f172613a50ec"), new Guid("bd79295b-1388-480a-b19b-860d9996cc4e") },
                    { new Guid("f913dffe-1741-4198-914f-fcccec8b5937"), new Guid("41cdd094-6a8d-4bfe-b947-09757303de46"), new Guid("18e6d30a-0b2a-4ab9-8b96-d7d02c08fc22") },
                    { new Guid("f919c2eb-654e-40b2-a411-a729ed151c8d"), new Guid("695775d0-e87f-493b-b079-5c0f685938e8"), new Guid("208d3aec-de1a-4832-a980-88ee4b11a763") },
                    { new Guid("f9386286-2c2f-4eb7-9846-505eeca15e5a"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("e5ff4e8b-be85-4a9d-a732-7c3ffe28cedf") },
                    { new Guid("f9890e60-a631-49b5-a613-13ee67fcdf28"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("03bf51e4-453f-4e23-b204-55dd5e5369e3") },
                    { new Guid("f9a18ad2-64b7-4587-865a-f3cc0713573d"), new Guid("0509a016-7e0c-4a0a-8d45-3fe90615094c"), new Guid("3a833c0f-a6c3-4062-9af9-ad14515d589c") },
                    { new Guid("f9dc4ebe-58a7-47f7-b6f3-fd6a06ac6d85"), new Guid("20211330-7cf5-44bd-8941-00cd323dc942"), new Guid("5c7a8199-a18f-4afc-87f1-ec9c56f36920") },
                    { new Guid("f9e1e2da-1c3f-4968-8379-88e8b3f0841e"), new Guid("a53147e3-7b8d-4a93-b362-933f4956fd87"), new Guid("865091a3-4aac-43cd-a7ad-7b54477cb975") },
                    { new Guid("f9f572e0-7357-4919-b41c-10e135b6aee8"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("a71ca591-3d3e-4848-95d7-450c6d5b3c66") },
                    { new Guid("fa9f2be0-0504-4f9f-9f45-2b668bfc5c4f"), new Guid("d0deb7e1-e3b4-42b5-8ff3-2ddfbba844e4"), new Guid("2195b083-3622-4e68-beca-6666738371bc") },
                    { new Guid("fab8b829-c9ad-459f-8501-f049a216c42d"), new Guid("22b78584-0f8d-437f-827e-2d15b7b5fa7d"), new Guid("d9a5d62b-a655-4bb7-9f77-753a22fd4c00") },
                    { new Guid("faf80838-37a0-4b26-a6ee-5ec9fb828708"), new Guid("33f96b8e-a55b-4856-8fff-d6e4a9f87e01"), new Guid("8fe914af-84cd-4f01-9f4d-1b82c2a1fb00") },
                    { new Guid("fc27853b-b22c-4cb7-8482-a0484d466ba7"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("293e9df9-77df-4658-91e0-ecba0150b2df") },
                    { new Guid("fc3ced01-a043-4b8d-b1e3-81d99c3a1ba0"), new Guid("29f638da-987d-4d0d-b9c3-c5c2e5a348a3"), new Guid("6484162f-3848-449c-91bb-4b8487eb306f") },
                    { new Guid("fcaef60f-0e69-432b-a6b2-680113081a0a"), new Guid("57c22a05-ab34-4e63-a0f3-a323251f7d26"), new Guid("45629291-f3d7-41cf-a119-7d2c21472669") },
                    { new Guid("fd287942-54d7-4e62-aa79-f8db9f2fb032"), new Guid("cfd146ac-adb3-4ebb-866c-5ca8591f5835"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("fdaf8c5b-2b9a-46bf-8dff-c1cb061b6b0e"), new Guid("837f5655-4596-4124-ab4b-d404f311de50"), new Guid("c176aaf6-de9c-4689-83a1-107dbc76a35c") },
                    { new Guid("fdb49709-7f98-44c3-97b1-445fb0d712fc"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("89e61a6a-c9cc-451e-80fe-f42022eda41a") },
                    { new Guid("fdcbfd29-d24e-4189-9a46-1e7d98577561"), new Guid("2dc72594-653d-4323-8e59-653dbc161032"), new Guid("5e842733-1290-438f-88cc-22121bb1ef22") },
                    { new Guid("fdda1b20-dec0-451c-aad2-72a70ecc7e91"), new Guid("8fa4d352-459c-4c84-aa48-d1137c0d1635"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("fe08ad59-e5de-45cf-984c-1b2157caffcf"), new Guid("544e7597-7e1e-49e7-8057-1ab6175bcb49"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") },
                    { new Guid("fe08ff25-3f29-4c53-982b-ab406322c6e5"), new Guid("d9090b42-b79c-47d9-8dd5-8942d559aa52"), new Guid("477bdda5-8aa5-46d9-b710-386078c20056") },
                    { new Guid("fed329cb-891a-4c48-b73a-7c9442afe4bb"), new Guid("04aaf15a-feb1-4543-950c-626a2da56636"), new Guid("55944788-a67b-4111-ad4c-6979213845e6") },
                    { new Guid("fedcc054-8d58-450d-bbfd-96e4d061ad9d"), new Guid("f5bdc125-0b4d-4dd2-92ff-1734588a3dff"), new Guid("60937a23-0e2e-4dea-863f-9be149fdeab7") },
                    { new Guid("ff3ddfab-2654-472f-886e-fead38795600"), new Guid("a6bb0980-07f5-452d-9655-2b27b877ac70"), new Guid("d7192cdb-351c-4a4e-938a-aae623e790e5") },
                    { new Guid("ff5ab865-fb34-4e66-99d5-a7bf28c39618"), new Guid("03414f74-50fe-4bdc-bba6-5a0aa1415510"), new Guid("c4e4c1e1-b3c0-4a73-bbef-9d7abc98b158") },
                    { new Guid("ff658e3f-dcfc-4cf5-946e-032d34ade6a9"), new Guid("091c20d1-c9b4-470e-9e75-a3da93fd1e51"), new Guid("a4a4854e-08aa-4c21-913c-23ec5b76a4e7") },
                    { new Guid("ff807d41-0255-44d5-b875-4838f9a6ccae"), new Guid("b47a68fc-db94-4c51-8086-cc112348633d"), new Guid("bd6e773d-dadf-437a-b7a2-dcb5c3811580") }
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
                name: "IX_People_ServicedStoreId",
                table: "People",
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
                name: "Faults");

            migrationBuilder.DropTable(
                name: "SpareParts");

            migrationBuilder.DropTable(
                name: "ServicedStores");

            migrationBuilder.DropTable(
                name: "RepairingModels");
        }
    }
}
