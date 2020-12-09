using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Business.DTO
{
    [AutoMap(typeof(Data.Models.Reservation))]
    public class ReservationDTO
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public int Ranking { get; set; }
        public bool IsFavorite { get; set; }
        public ContactDTO Contact { get; set; }
    }
}
