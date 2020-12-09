using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Data.Models
{
   public class Contact
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }

        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DBO { get; set; }

        public virtual ContactType ContactType { get; set; }
    }
}
