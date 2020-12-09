using AutoMapper;
using ISUCorp.Reservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Business.DTO
{
    [AutoMap(typeof(ContactType))]
    public class ContactTypeDTO
    {   
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
