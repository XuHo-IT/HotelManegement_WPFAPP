using System;
using System.Collections.Generic;
using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccessLayer;

public partial class HotelManagementContext : DbContext
{
    public HotelManagementContext()
    {
    }

    public HotelManagementContext(DbContextOptions<HotelManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingDetail> BookingDetails { get; set; }

    public virtual DbSet<BookingReservation> BookingReservations { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }
    public virtual DbSet<RoomInformation> RoomInformation{ get; set; }

    public virtual DbSet<RoomType> RoomType { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("HotelManagement"));
        }
    }

    string GetConnectionString()
    {
        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json").Build();
        return config["ConnectionStrings:HotelManagement"];
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookingDetail>().HasData(
     new BookingDetail { BookingReservationID = 1, RoomID = 3, StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-02"), ActualPrice = 199.0000m },
     new BookingDetail { BookingReservationID = 1, RoomID = 7, StartDate = DateTime.Parse("2024-01-01"), EndDate = DateTime.Parse("2024-01-02"), ActualPrice = 179.0000m },
     new BookingDetail { BookingReservationID = 2, RoomID = 3, StartDate = DateTime.Parse("2024-01-05"), EndDate = DateTime.Parse("2024-01-06"), ActualPrice = 199.0000m },
     new BookingDetail { BookingReservationID = 2, RoomID = 5, StartDate = DateTime.Parse("2024-01-05"), EndDate = DateTime.Parse("2024-01-09"), ActualPrice = 219.0000m }
 );


        modelBuilder.Entity<BookingReservation>().HasData(
            new BookingReservation { BookingReservationID = 1, BookingDate = DateTime.Parse("2023-12-20"), TotalPrice = 378.0000m, CustomerID = 3, BookingStatus = 1 },
            new BookingReservation { BookingReservationID = 2, BookingDate = DateTime.Parse("2023-12-21"), TotalPrice = 1493.0000m, CustomerID = 3, BookingStatus = 1 }
        );

        modelBuilder.Entity<Customer>().HasData(
            new Customer { CustomerID = 3, CustomerFullName = "William Shakespeare", Telephone = "0903939393", EmailAddress = "WilliamShakespeare@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1990-02-02"), CustomerStatus = 1, Password = "123@" },
            new Customer { CustomerID = 5, CustomerFullName = "Elizabeth Taylor", Telephone = "0903939377", EmailAddress = "ElizabethTaylor@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1991-03-03"), CustomerStatus = 1, Password = "144@" },
            new Customer { CustomerID = 8, CustomerFullName = "James Cameron", Telephone = "0903946582", EmailAddress = "JamesCameron@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1992-11-10"), CustomerStatus = 1, Password = "443@" },
            new Customer { CustomerID = 9, CustomerFullName = "Charles Dickens", Telephone = "0903955633", EmailAddress = "CharlesDickens@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1991-12-05"), CustomerStatus = 1, Password = "563@" },
            new Customer { CustomerID = 10, CustomerFullName = "George Orwell", Telephone = "0913933493", EmailAddress = "GeorgeOrwell@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1993-12-24"), CustomerStatus = 1, Password = "177@" },
            new Customer { CustomerID = 11, CustomerFullName = "Victoria Beckham", Telephone = "0983246773", EmailAddress = "VictoriaBeckham@FUMiniHotel.org", CustomerBirthday = DateTime.Parse("1990-09-09"), CustomerStatus = 1, Password = "654@" }
        );

        modelBuilder.Entity<RoomInformation>().HasData(
            new RoomInformation { RoomID = 1, RoomNumber = "2364", RoomDetailDescription = "A basic room with essential amenities, suitable for individual travelers or couples.", RoomMaxCapacity = 3, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDay = 149.0000m },
            new RoomInformation { RoomID = 2, RoomNumber = "3345", RoomDetailDescription = "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", RoomMaxCapacity = 5, RoomTypeID = 3, RoomStatus = 1, RoomPricePerDay = 299.0000m },
            new RoomInformation { RoomID = 3, RoomNumber = "4432", RoomDetailDescription = "A luxurious and spacious room with separate living and sleeping areas, ideal for guests seeking extra comfort and space.", RoomMaxCapacity = 4, RoomTypeID = 2, RoomStatus = 1, RoomPricePerDay = 199.0000m },
            new RoomInformation { RoomID = 5, RoomNumber = "3342", RoomDetailDescription = "Floor 3, Window in the North West.", RoomMaxCapacity = 5, RoomTypeID = 5, RoomStatus = 1, RoomPricePerDay = 219.0000m },
            new RoomInformation { RoomID = 7, RoomNumber = "4434", RoomDetailDescription = "Floor 4, main window in the South.", RoomMaxCapacity = 4, RoomTypeID = 1, RoomStatus = 1, RoomPricePerDay = 179.0000m }
        );

        modelBuilder.Entity<RoomType>().HasData(
            new RoomType { RoomTypeID = 1, RoomTypeName = "Standard room", TypeDescription = "This is typically the most affordable option and provides basic amenities such as a bed, dresser, and TV.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 2, RoomTypeName = "Suite", TypeDescription = "Suites usually offer more space and amenities than standard rooms, such as a separate living area, kitchenette, and multiple bathrooms.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 3, RoomTypeName = "Deluxe room", TypeDescription = "Deluxe rooms offer additional features such as a balcony or sea view, upgraded bedding, and improved décor.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 4, RoomTypeName = "Executive room", TypeDescription = "Executive rooms are designed for business travelers and offer perks such as free breakfast, evening drink, and high-speed internet.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 5, RoomTypeName = "Family Room", TypeDescription = "A room specifically designed to accommodate families, often with multiple beds and additional space for children.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 6, RoomTypeName = "Connecting Room", TypeDescription = "Two or more rooms with a connecting door, providing flexibility for larger groups or families traveling together.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 7, RoomTypeName = "Penthouse Suite", TypeDescription = "An extravagant, top-floor suite with exceptional views and exclusive amenities, typically chosen for special occasions or VIP guests.", TypeNote = "N/A" },
            new RoomType { RoomTypeID = 8, RoomTypeName = "Bungalow", TypeDescription = "A standalone cottage-style accommodation, providing privacy and a sense of seclusion often within a resort setting.", TypeNote = "N/A" }
        );
        modelBuilder.Entity<BookingDetail>()
      .HasKey(b => new { b.BookingReservationID, b.RoomID });

    }
}
