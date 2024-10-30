using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessObject
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        [Required]
        [MaxLength(80)]
        public string CustomerFullName { get; set; }
        [Required]
        [MaxLength(10)]
        public string Telephone { get; set; }
        [EmailAddress]
        [Required]
        [MaxLength(100)]
        public string EmailAddress { get; set; }

        public DateTime? CustomerBirthday { get; set; }

        [Range(0, 1, ErrorMessage = "Customer status must be either 0 (inactive) or 1 (active).")]
        public byte? CustomerStatus { get; set; }

        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
