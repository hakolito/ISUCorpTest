using AutoMapper;
using ISUCorp.Reservation.Business.DTO;
using ISUCorp.Reservation.Business.Interfaces;
using ISUCorp.Reservation.Data.Interfaces.Framework;
using ISUCorp.Reservation.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ISUCorp.Reservation.Business.Implementations
{
    public class ReservationService : GenericService<Data.Models.Reservation, ReservationDTO>, IReservationService
    {
        IGenericRepository<Data.Models.Reservation> _repository;
        IMapper _mapper;
        public ReservationService(IGenericRepository<Data.Models.Reservation> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Method to get all the reservations with their contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ReservationDTO> GetAllList()
        {
            var reservations = _repository.Where(null, x => x.Include(c => c.Contact));

            return _mapper.Map<IEnumerable<ReservationDTO>>(reservations);
        }
    }
}
