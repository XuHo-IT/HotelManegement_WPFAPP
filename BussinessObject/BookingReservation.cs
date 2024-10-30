using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class BookingReservation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BookingReservationID { get; set; }
        public DateTime? BookingDate { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Total price must be a non-negative value.")]
        public decimal? TotalPrice { get; set; }
        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        [Range(0, 2, ErrorMessage = "Booking status must be within the allowed range.")]
        public byte? BookingStatus { get; set; }
    }
}
