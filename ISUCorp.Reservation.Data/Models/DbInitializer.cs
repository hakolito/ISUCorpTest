using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISUCorp.Reservation.Data.Models
{
    public static class DbInitializer
    {
        public static void Initialize(MyReservationContext context)
        {
            context.Database.EnsureCreated();

            //Checking if we have any record on the db
            if (context.ContactTypes.Any())
            {
                return;
            }

            //Creating the default contact types
            var contactTypes = new ContactType[]
            {
                new ContactType{Name="Contact Type 1"},
                new ContactType{Name="Contact Type 2"},
                new ContactType{Name="Contact Type 3"}
            };

            foreach (ContactType ct in contactTypes)
            {
                context.ContactTypes.Add(ct);
            }
            context.SaveChanges();


            //Creating the default contacts
            var contacts = new Contact[]
            {
                new Contact{Name="Carlos Vargas",ContactTypeId = 1, DBO =  DateTime.Now.AddMonths(1), Phone = "800-123-4567"},
                new Contact{Name="Cassie Zurbrigg",ContactTypeId = 2, DBO =  DateTime.Now.AddMonths(2), Phone = "900-582-9875"},
                new Contact{Name="David Mansilla",ContactTypeId = 3, DBO =  DateTime.Now.AddMonths(3), Phone = "100-698-8546"}
            };

            foreach (Contact c in contacts)
            {
                context.Contacts.Add(c);
            }
            context.SaveChanges();

            //Creating the default reservations
            var reservations = new Reservation[]
            {
                new Reservation{ContactId=1,Description="This is a description from the Dominican Republic",Date=DateTime.Now, IsFavorite = true, Ranking = 2},
                new Reservation{ContactId=2,Description="This is a description from the Canada",Date=DateTime.Now, IsFavorite = false, Ranking = 5},
                new Reservation{ContactId=3,Description="This is a description from the USA",Date=DateTime.Now, IsFavorite = true, Ranking = 1}
            };

            foreach (Reservation r in reservations)
            {
                context.Reservations.Add(r);
            }
            context.SaveChanges();
        }
    }
}
