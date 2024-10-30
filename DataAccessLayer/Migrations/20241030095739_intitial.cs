using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class intitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    BookingDetailID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ActualPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => new { x.BookingReservationID, x.RoomID });
                });

            migrationBuilder.CreateTable(
                name: "BookingReservations",
                columns: table => new
                {
                    BookingReservationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CustomerID = table.Column<int>(type: "int", nullable: false),
                    BookingStatus = table.Column<byte>(type: "tinyint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingReservations", x => x.BookingReservationID);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerFullName = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    EmailAddress = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CustomerBirthday = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CustomerStatus = table.Column<byte>(type: "tinyint", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "RoomInformation",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoomDetailDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    RoomMaxCapacity = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<int>(type: "int", nullable: false),
                    RoomStatus = table.Column<byte>(type: "tinyint", nullable: false),
                    RoomPricePerDay = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomInformation", x => x.RoomID);
                });

            migrationBuilder.CreateTable(
                name: "RoomTypes",
                columns: table => new
                {
                    RoomTypeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomTypeName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TypeDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    TypeNote = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomTypes", x => x.RoomTypeID);
                });

            migrationBuilder.InsertData(
                table: "BookingDetails",
                columns: new[] { "BookingReservationID", "RoomID", "ActualPrice", "EndDate", "StartDate" },
                values: new object[,]
                {
                    { 1, 3, 199.0000m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 7, 179.0000m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, 199.0000m, new DateTime(2024, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 5, 219.0000m, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "BookingReservations",
                columns: new[] { "BookingReservationID", "BookingDate", "BookingStatus", "CustomerID", "TotalPrice" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, 3, 378.0000m },
                    { 2, new DateTime(2023, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), (byte)1, 3, 1493.0000m }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerID", "CustomerBirthday", "CustomerFullName", "CustomerStatus", "EmailAddress", "Password", "Telephone" },
                values: new object[,]
                {
                    { 3, new DateTime(1990, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "William Shakespeare", (byte)1, "WilliamShakespeare@FUMiniHotel.org", "123@", "0903939393" },
                    { 5, new DateTime(1991, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Elizabeth Taylor", (byte)1, "ElizabethTaylor@FUMiniHotel.org", "144@", "0903939377" },
                    { 8, new DateTime(1992, 11, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "James Cameron", (byte)1, "JamesCameron@FUMiniHotel.org", "443@", "0903946582" },
                    { 9, new DateTime(1991, 12, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Charles Dickens", (byte)1, "CharlesDickens@FUMiniHotel.org", "563@", "0903955633" },
                    { 10, new DateTime(1993, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "George Orwell", (byte)1, "GeorgeOrwell@FUMiniHotel.org", "177@", "0913933493" },
                    { 11, new DateTime(1990, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Victoria Beckham", (byte)1, "VictoriaBeckham@FUMiniHotel.org", "654@", "0983246773" }
                });

            migrationBuilder.InsertData(
                table: "RoomInformation",
                columns: new[] { "RoomID", "RoomDetailDescription", "RoomMaxCapacity", "RoomNumber", "RoomPricePerDay", "RoomStatus", "RoomTypeID" },
                values: new object[,]
                {
                    { 1, "A basic room with essential amenities, suitable for individual travelers or couples.", 3, "2364", 149.0000m, (byte)1, 1 },
                    { 2, "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", 5, "3345", 299.0000m, (byte)1, 3 },
                    { 3, "A luxurious and spacious room with separate living and sleeping areas, ideal for guests seeking extra comfort and space.", 4, "4432", 199.0000m, (byte)1, 2 },
                    { 5, "Floor 3, Window in the North West.", 5, "3342", 219.0000m, (byte)1, 5 },
                    { 7, "Floor 4, main window in the South.", 4, "4434", 179.0000m, (byte)1, 1 }
                });

            migrationBuilder.InsertData(
                table: "RoomTypes",
                columns: new[] { "RoomTypeID", "RoomTypeName", "TypeDescription", "TypeNote" },
                values: new object[,]
                {
                    { 1, "Standard room", "This is typically the most affordable option and provides basic amenities such as a bed, dresser, and TV.", "N/A" },
                    { 2, "Suite", "Suites usually offer more space and amenities than standard rooms, such as a separate living area, kitchenette, and multiple bathrooms.", "N/A" },
                    { 3, "Deluxe room", "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", "N/A" },
                    { 4, "Executive room", "Executive rooms are designed for business travelers and offer perks such as free breakfast, evening drink, and high-speed internet.", "N/A" },
                    { 5, "Family Room", "A room specifically designed to accommodate families, often with multiple beds and additional space for children.", "N/A" },
                    { 6, "Connecting Room", "Two or more rooms with a connecting door, providing flexibility for larger groups or families traveling together.", "N/A" },
                    { 7, "Penthouse Suite", "An extravagant, top-floor suite with exceptional views and exclusive amenities, typically chosen for special occasions or VIP guests.", "N/A" },
                    { 8, "Bungalow", "A standalone cottage-style accommodation, providing privacy and a sense of seclusion often within a resort setting.", "N/A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");

            migrationBuilder.DropTable(
                name: "BookingReservations");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "RoomInformation");

            migrationBuilder.DropTable(
                name: "RoomTypes");
        }
    }
}
