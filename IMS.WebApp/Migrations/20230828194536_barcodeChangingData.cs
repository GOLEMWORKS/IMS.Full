﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IMS.WebApp.Migrations
{
    public partial class barcodeChangingData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    InventoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Barcode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.InventoryId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductQuantity = table.Column<int>(type: "int", nullable: false),
                    ProductPrice = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                });

            migrationBuilder.CreateTable(
                name: "InventoryTransactions",
                columns: table => new
                {
                    InventoryTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    QuantityBefore = table.Column<int>(type: "int", nullable: false),
                    InventoryType = table.Column<int>(type: "int", nullable: false),
                    QuantityAfter = table.Column<int>(type: "int", nullable: false),
                    POnumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cost = table.Column<double>(type: "float", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryTransactions", x => x.InventoryTransactionId);
                    table.ForeignKey(
                        name: "FK_InventoryTransactions_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductInventory",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    InventoryId = table.Column<int>(type: "int", nullable: false),
                    InventoryQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductInventory", x => new { x.ProductId, x.InventoryId });
                    table.ForeignKey(
                        name: "FK_ProductInventory_Inventories_InventoryId",
                        column: x => x.InventoryId,
                        principalTable: "Inventories",
                        principalColumn: "InventoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductInventory_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTransactions",
                columns: table => new
                {
                    ProductTransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    QuantityBefore = table.Column<int>(type: "int", nullable: false),
                    ActivityType = table.Column<int>(type: "int", nullable: false),
                    QuantityAfter = table.Column<int>(type: "int", nullable: false),
                    ProductionNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SalesOrderNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UnitPrice = table.Column<double>(type: "float", nullable: true),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DoneBy = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTransactions", x => x.ProductTransactionId);
                    table.ForeignKey(
                        name: "FK_ProductTransactions_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Inventories",
                columns: new[] { "InventoryId", "Barcode", "InventoryName", "Price", "Quantity" },
                values: new object[,]
                {
                    { 1, "", "Двигатель (Бензиновый)", 26000.0, 1 },
                    { 2, "", "Двигатель (Дизельный)", 20000.0, 1 },
                    { 3, "", "Электродвигатель", 40000.0, 1 },
                    { 4, "", "Трансмиссия", 28700.0, 1 },
                    { 5, "", "Колёса", 4000.0, 4 },
                    { 6, "", "Шины", 4000.0, 5 },
                    { 7, "", "Кузов", 74000.0, 1 },
                    { 8, "", "Блок батареи", 70000.0, 1 },
                    { 9, "", "Одиночное кресло", 9000.0, 1 },
                    { 10, "", "Кресло 2 + 1", 18500.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "ProductName", "ProductPrice", "ProductQuantity" },
                values: new object[,]
                {
                    { 1, "Автомобиль (Дизельное топливо)", 2000000.0, 1 },
                    { 2, "Автомобиль (Бензин)", 2020000.0, 1 },
                    { 3, "Электромобиль", 4120000.0, 1 }
                });

            migrationBuilder.InsertData(
                table: "ProductInventory",
                columns: new[] { "InventoryId", "ProductId", "InventoryQuantity" },
                values: new object[,]
                {
                    { 2, 1, 1 },
                    { 5, 1, 4 },
                    { 6, 1, 4 },
                    { 7, 1, 1 },
                    { 9, 1, 2 },
                    { 10, 1, 1 },
                    { 1, 2, 1 },
                    { 5, 2, 4 },
                    { 6, 2, 4 },
                    { 7, 2, 1 },
                    { 9, 2, 2 },
                    { 10, 2, 1 },
                    { 3, 3, 4 },
                    { 5, 3, 4 },
                    { 6, 3, 4 },
                    { 7, 3, 1 },
                    { 8, 3, 2 },
                    { 9, 3, 2 },
                    { 10, 3, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryTransactions_InventoryId",
                table: "InventoryTransactions",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductInventory_InventoryId",
                table: "ProductInventory",
                column: "InventoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTransactions_ProductId",
                table: "ProductTransactions",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryTransactions");

            migrationBuilder.DropTable(
                name: "ProductInventory");

            migrationBuilder.DropTable(
                name: "ProductTransactions");

            migrationBuilder.DropTable(
                name: "Inventories");

            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
