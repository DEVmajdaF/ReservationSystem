using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Reservations
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public string id { get; set; }
        [Required(ErrorMessage = "Enter Your Booking Day")]
        public DateTime  date { get; set; }
        public DateTime dateres { get; set; }
        public bool? status{ get; set; }
        [Required(ErrorMessage = "Enter Your Cause")]
        public string  cause { get; set; }
        public string studentId { get; set; }
        public Students student { get; set; }
        public string ReservationTypeId  { get; set; }
        public ReservationType ReservationType { get; set; }

      
    }
}
