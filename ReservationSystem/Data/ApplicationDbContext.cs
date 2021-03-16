using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReservationSystem.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Students> Students { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ReservationType> ReservationTypes { get; set; }
        //public DbSet<ReservationSystem.Models.ReservationViewModel> ReservationViewModel { get; set; }
       

    }
}
