using ISUCorp.Reservation.Business.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Business.Interfaces
{
    public interface IReservationService : IGenericService<Data.Models.Reservation,ReservationDTO>   
    {
        IEnumerable<ReservationDTO> GetAllList();
    }
}
