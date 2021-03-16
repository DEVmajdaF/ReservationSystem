using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Models
{
    public class ReservationViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime date { get; set; }
        public bool?  status { get; set; }
        public string cause { get; set; }
        public string ReservationTypeId { get; set;}
        public string SearchString { get; set; }
        public string reservationName { get; set; }

    }
}
