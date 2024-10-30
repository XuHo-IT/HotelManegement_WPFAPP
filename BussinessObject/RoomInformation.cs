using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class RoomInformation
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomID { get; set; }
        [Required]
        public string RoomNumber { get; set; }
        [Required]
        [MaxLength(500)]
        public string RoomDetailDescription { get; set; }
        [Required]
        public int? RoomMaxCapacity { get; set; }
        [ForeignKey("RoomType")]
        public int RoomTypeID { get; set; }
        [Required]
        [Range(0, 2, ErrorMessage = "Room status must be within the allowed range.")]
        public byte? RoomStatus { get; set; }
        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Price of room must be a non-negative value.")]
        public decimal? RoomPricePerDay { get; set; }
    }
}
