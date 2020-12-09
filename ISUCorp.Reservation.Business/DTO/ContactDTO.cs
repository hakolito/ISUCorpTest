using AutoMapper;
using ISUCorp.Reservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Business.DTO
{
    [AutoMap(typeof(Contact))]
    public class ContactDTO
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime DBO { get; set; }
    }
}
