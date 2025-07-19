using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace MajorExpress.Delivery.Infrastructure.Adapters.Postgres.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: false),
                    Size = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Patronymic = table.Column<string>(type: "text", nullable: true),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Couriers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Couriers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Couriers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ClientId = table.Column<Guid>(type: "uuid", nullable: false),
                    CargoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CourierId = table.Column<Guid>(type: "uuid", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PickupAddress = table.Column<string>(type: "text", nullable: false),
                    DeliveryAddress = table.Column<string>(type: "text", nullable: false),
                    PickupTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CancelComment = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Cargos_CargoId",
                        column: x => x.CargoId,
                        principalTable: "Cargos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Couriers_CourierId",
                        column: x => x.CourierId,
                        principalTable: "Couriers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Cargos",
                columns: new[] { "Id", "Description", "Size", "Weight" },
                values: new object[,]
                {
                    { new Guid("14a3d5b1-fbc6-4300-8d5f-42ad13f5bfb9"), "Кресло", 240m, 25m },
                    { new Guid("72a0b771-9caf-41ca-b1e5-142c3a584cc6"), "Компьютер", 90m, 5m },
                    { new Guid("73b3dcd2-9fd9-427e-9257-29c5f28cea5e"), "Шкаф", 600m, 50m },
                    { new Guid("b8ab0ba0-6067-4b85-abc8-be3236d40a78"), "Стол", 360m, 7m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "LastName", "Patronymic", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("0eaa9e2a-eed0-4619-946c-aa91c320210e"), "Гавриил", "Кушкин", "Николаевич", "+7 (970) 422-97-49" },
                    { new Guid("166a99b2-7ed0-4b41-87fb-affbda39119d"), "Александра", "Дудко", "Егоровна", "+7 (936) 742-93-76" },
                    { new Guid("23244377-d294-46b4-9245-5df4af5d1d9f"), "Вера", "Сияносова", "Прокловна", "+7 (978) 409-31-96" },
                    { new Guid("37fce3f7-3c45-4117-a88d-204c2e931a76"), "Филипп", "Кулатов", "Маркович", "+7 (959) 964-23-76" },
                    { new Guid("5b453a8e-c239-42ed-8b2d-ac04ce43c33b"), "Ева", "Батурина", "Афанасьевна", "+7 (974) 364-82-60" },
                    { new Guid("6124c5dd-155e-453a-90d7-401f08b8f376"), "Савва", "Ярошевский", "Петрович", "+7 (953) 595-58-95" },
                    { new Guid("e1a1daf4-0f83-4358-919d-75c9c34280bf"), "Людмила", "Уттеркло", "Тимофеевна", "+7 (921) 346-18-59" },
                    { new Guid("f23f844b-ffe5-4c13-9be0-78997c289de8"), "Тимофей", "Кинжаев", "Николаевич", "+7 (913) 161-14-77" }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("d5f3f9f7-8d6c-4100-aecf-4af6e4969eb2"), new Guid("23244377-d294-46b4-9245-5df4af5d1d9f") },
                    { new Guid("e6ca25f2-6691-410e-8c1b-7be47b109995"), new Guid("37fce3f7-3c45-4117-a88d-204c2e931a76") },
                    { new Guid("e83ccf84-dc67-45fd-8fb7-6d82b5319ee8"), new Guid("f23f844b-ffe5-4c13-9be0-78997c289de8") },
                    { new Guid("f5cea0f2-1bc8-402f-9e02-7e4512de4fea"), new Guid("0eaa9e2a-eed0-4619-946c-aa91c320210e") }
                });

            migrationBuilder.InsertData(
                table: "Couriers",
                columns: new[] { "Id", "UserId" },
                values: new object[,]
                {
                    { new Guid("68a6a604-2b38-4376-95f9-b06652543e05"), new Guid("166a99b2-7ed0-4b41-87fb-affbda39119d") },
                    { new Guid("83108fb9-1177-4d2e-ae59-6b4c86b014ba"), new Guid("5b453a8e-c239-42ed-8b2d-ac04ce43c33b") },
                    { new Guid("95420664-aa3c-45bc-8170-2f60c4d8f697"), new Guid("e1a1daf4-0f83-4358-919d-75c9c34280bf") },
                    { new Guid("ef391859-a5cc-4b04-aa7e-c43d8d8ef2f5"), new Guid("6124c5dd-155e-453a-90d7-401f08b8f376") }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "CancelComment", "CargoId", "ClientId", "CourierId", "CreatedAt", "DeliveryAddress", "PickupAddress", "PickupTime", "Status" },
                values: new object[,]
                {
                    { new Guid("22a11daa-7534-4d0f-ab6b-766a4ac855f0"), null, new Guid("72a0b771-9caf-41ca-b1e5-142c3a584cc6"), new Guid("d5f3f9f7-8d6c-4100-aecf-4af6e4969eb2"), new Guid("83108fb9-1177-4d2e-ae59-6b4c86b014ba"), new DateTime(2025, 7, 10, 7, 20, 0, 0, DateTimeKind.Utc), "Адрес выгрузки 0", "Адрес погрузки 0", new DateTime(2025, 7, 24, 14, 40, 0, 0, DateTimeKind.Utc), "Новая" },
                    { new Guid("bb3d699a-381c-49db-a97f-a87cc55d7325"), null, new Guid("b8ab0ba0-6067-4b85-abc8-be3236d40a78"), new Guid("f5cea0f2-1bc8-402f-9e02-7e4512de4fea"), new Guid("95420664-aa3c-45bc-8170-2f60c4d8f697"), new DateTime(2025, 7, 11, 8, 21, 0, 0, DateTimeKind.Utc), "Адрес выгрузки 1", "Адрес погрузки 1", new DateTime(2025, 7, 25, 15, 41, 0, 0, DateTimeKind.Utc), "Передано на выполнение" },
                    { new Guid("d51b4b9e-0e70-4e9c-82c1-c96c69c1c769"), "Тест", new Guid("73b3dcd2-9fd9-427e-9257-29c5f28cea5e"), new Guid("e83ccf84-dc67-45fd-8fb7-6d82b5319ee8"), new Guid("ef391859-a5cc-4b04-aa7e-c43d8d8ef2f5"), new DateTime(2025, 7, 13, 10, 23, 0, 0, DateTimeKind.Utc), "Адрес выгрузки 3", "Адрес погрузки 3", new DateTime(2025, 7, 27, 17, 43, 0, 0, DateTimeKind.Utc), "Отменена" },
                    { new Guid("eef68d46-5959-422f-b782-09722c4d483f"), null, new Guid("14a3d5b1-fbc6-4300-8d5f-42ad13f5bfb9"), new Guid("e6ca25f2-6691-410e-8c1b-7be47b109995"), new Guid("68a6a604-2b38-4376-95f9-b06652543e05"), new DateTime(2025, 7, 12, 9, 22, 0, 0, DateTimeKind.Utc), "Адрес выгрузки 2", "Адрес погрузки 2", new DateTime(2025, 7, 26, 16, 42, 0, 0, DateTimeKind.Utc), "Выполнено" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_UserId",
                table: "Clients",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Couriers_UserId",
                table: "Couriers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CargoId",
                table: "Orders",
                column: "CargoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ClientId",
                table: "Orders",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CourierId",
                table: "Orders",
                column: "CourierId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Couriers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
