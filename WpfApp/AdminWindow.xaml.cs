using BussinessObject;  // Ensure you have the correct namespace for your Business Objects
using Repository;       // Ensure this namespace contains your repositories
using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp
{
    public partial class AdminWindow : Window
    {
        private readonly string connectionString;
        private readonly ICustomerRepository customerRepository;
        private readonly IRoomInformationRepository roomInformationRepository;
        private readonly IBookingReservationRepository bookingReservationRepository;
        private readonly IBookingDetailRepository bookingDetailRepository;

        private RoomInformation selectedRoom;

        public AdminWindow()
        {
            InitializeComponent();
            customerRepository = new CustomerRepository();
            roomInformationRepository = new RoomInformationRepository();
            bookingReservationRepository = new BookingReservationRepository();
            bookingDetailRepository = new BookingDetailRepository();
            LoadData();
            LoadReservations();
        }

        private void LoadData()
        {
         
            List<Customer> customers = customerRepository.GetAllCustomers();
            dataGridCustomers.ItemsSource = customers;

         
            List<RoomInformation> rooms = roomInformationRepository.GetAllRoomInformation(); 
            dataGridRooms.ItemsSource = rooms; 
        }

        private void LoadReservations()
        {
            List<BookingReservation> reservations = bookingReservationRepository.GetAllBookingReservations();
            dataGridReservations.ItemsSource = reservations; 
        }
        private void dataGridRooms_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
           
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

            roomInformationRepository.AddRoomInformation(newRoom);
            LoadData();
        }

        private void UpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRoom != null)
            {

                roomInformationRepository.UpdateRoomInformation(selectedRoom);
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
                roomInformationRepository.DeleteRoomInformation(selectedRoom.RoomID);
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
                bookingReservationRepository.UpdateBookingReservation(selectedReservation);

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
                bookingReservationRepository.UpdateBookingReservation(selectedReservation);

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
                // Call the existing bookingReservationRepository to get bookings by period
                var reportData = bookingReservationRepository.GetBookingsByPeriod(startDate.Value, endDate.Value);

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
