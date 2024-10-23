using BussinessObject;  // Ensure you have the correct namespace for your Business Objects
using Repository;       // Ensure this namespace contains your repositories
using Service;         // Ensure this namespace contains your services
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    public partial class AdminWindow : Window
    {
        private readonly string connectionString;
        private readonly ICustomerRepository customerService; 
        private readonly IRoomInformationRepository roomService;
        private readonly IBookingReservationRepository bookingReservationService;
        private readonly IBookingDetailRepository bookingDetailService;

        private RoomInformation selectedRoom;

        public AdminWindow()
        {
            InitializeComponent();

            // Connection string to the database
            var connectionString = "Server=(local); Database=HotelManagement; Uid=sa; Pwd=sa123; TrustServerCertificate=True";

            // Instantiate repositories
            var customerRepository = new CustomerRepository(connectionString);
            customerService = new CustomerService(customerRepository);  

            var roomRepository = new RoomInformationRepository(connectionString); 
            roomService = new RoomInformationService(roomRepository);

            var bookingReservationRepository = new BookingReservationRepository(connectionString);
            bookingReservationService = new BookingReservationService(bookingReservationRepository);

            var bookingDetailRepository = new BookingDetailRepository(connectionString); 
            bookingDetailService = new BookingDetailService(bookingDetailRepository);

            LoadData(); 
            LoadReservations();
        }

        private void LoadData()
        {
            // Load all customers
            List<Customer> customers = customerService.GetAllCustomers();
            dataGridCustomers.ItemsSource = customers; // Bind customer data to DataGrid

            // Load all room information
            List<RoomInformation> rooms = roomService.GetAllRoomInformation(); // Retrieve room information
            dataGridRooms.ItemsSource = rooms; // Bind room data to DataGrid
        }

        private void LoadReservations()
        {
            List<BookingReservation> reservations = bookingReservationService.GetAllBookingReservations();
            dataGridReservations.ItemsSource = reservations; // Bind reservation data to DataGrid
        }
        private void dataGridRooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            // Get the selected room
            selectedRoom = (RoomInformation)dataGridRooms.SelectedItem;
        }

        private void AddRoom_Click(object sender, RoutedEventArgs e)
        {
            // Open dialog for new room input (you can create a dialog window for this)
            RoomInformation newRoom = new RoomInformation
            {
                RoomNumber = "New Room",
                RoomDetailDescription = "Description",
                RoomMaxCapacity = 2,
                RoomTypeID = 1,
                RoomStatus = 1,
                RoomPricePerDay = 100
            };

            roomService.AddRoomInformation(newRoom);
            LoadData(); 
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRoom != null)
            {
              
                roomService.UpdateRoomInformation(selectedRoom);
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Please select a room to update.");
            }
        }

        private void DeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRoom != null)
            {
                roomService.DeleteRoomInformation(selectedRoom.RoomID);
                LoadData(); 
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }


        private void ConfirmReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = (BookingReservation)dataGridReservations.SelectedItem;
            if (selectedReservation != null)
            {
             
                selectedReservation.BookingStatus = 1;
                bookingReservationService.UpdateBookingReservation(selectedReservation);

                LoadReservations();

          
                MessageBox.Show("The reservation has been confirmed.");
            }
            else
            {
                MessageBox.Show("Please select a reservation to confirm.");
            }
        }


        private void RejectReservation_Click(object sender, RoutedEventArgs e)
        {
            var selectedReservation = (BookingReservation)dataGridReservations.SelectedItem;
            if (selectedReservation != null)
            {
                // Update the BookingStatus to rejected (0)
                selectedReservation.BookingStatus = 0;
                bookingReservationService.UpdateBookingReservation(selectedReservation);

                LoadReservations(); // Refresh the data grid
            }
            else
            {
                MessageBox.Show("Please select a reservation to reject.");
            }
        }
        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve selected start and end dates from DatePickers
            DateTime? startDate = startDatePicker.SelectedDate;
            DateTime? endDate = endDatePicker.SelectedDate;

            if (startDate.HasValue && endDate.HasValue)
            {
                // Call the existing bookingReservationService to get bookings by period
                var reportData = bookingReservationService.GetBookingsByPeriod(startDate.Value, endDate.Value);

                // Display the report data in the DataGrid
                dataGridReservations.ItemsSource = reportData;
            }
            else
            {
                MessageBox.Show("Please select both start and end dates.", "Invalid Input", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }



    }
}
