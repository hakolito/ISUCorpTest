using AutoMapper;
using ISUCorp.Reservation.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ISUCorp.Reservation.Business.DTO
{
    [AutoMap(typeof(Contact))]
    public class ContactDTO
    {
        public int Id { get; set; }
        public int ContactTypeId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public DateTime DBO { get; set; }
    }
}
