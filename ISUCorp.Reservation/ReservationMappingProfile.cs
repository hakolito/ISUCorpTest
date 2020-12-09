using AutoMapper;
using ISUCorp.Reservation.Business.DTO;

namespace ISUCorp.Reservation
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile()
        {
            CreateMap<Data.Models.Reservation, ReservationDTO>().ReverseMap();
            CreateMap<Data.Models.Contact, ContactDTO>().ReverseMap();
            CreateMap<Data.Models.ContactType, ContactTypeDTO>().ReverseMap();
        }
    }
}