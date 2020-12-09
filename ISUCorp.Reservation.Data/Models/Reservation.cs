using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Data.Models
{
    public class Reservation
    {
        public int Id { get; set; }
        public int ContactId { get; set; }

        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Ranking { get; set; }
        public bool IsFavorite { get; set; }
        public virtual Contact Contact { get; set; }
    }
}
