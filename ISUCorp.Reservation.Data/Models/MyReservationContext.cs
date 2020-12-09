using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Data.Models
{
    public class MyReservationContext : DbContext
    {
        
        public MyReservationContext(DbContextOptions<MyReservationContext> options)
            : base(options)
        {

        }

        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
