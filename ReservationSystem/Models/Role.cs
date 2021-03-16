using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class Role
    {
        [Required]
        public String RoleName { get; set; }
    }
}
