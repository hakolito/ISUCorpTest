using AutoMapper;
using ISUCorp.Reservation.Business.DTO;
using ISUCorp.Reservation.Business.Interfaces;
using ISUCorp.Reservation.Data.Interfaces.Framework;
using ISUCorp.Reservation.Data.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ISUCorp.Reservation.Business.Implementations
{
    public class ReservationService : GenericService<Data.Models.Reservation, ReservationDTO>, IReservationService
    {
        IGenericRepository<Data.Models.Reservation> _repository;
        IMapper _mapper;
        MyReservationContext _context;
        public ReservationService(IGenericRepository<Data.Models.Reservation> repository, IMapper mapper, MyReservationContext context) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _context = context;
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

        /// <summary>
        /// Method to execute a stored procedure
        /// </summary>
        /// <returns></returns>
        public int GetReservationCount()
        {
            var countParam = new SqlParameter("Count", SqlDbType.Int) { Direction = ParameterDirection.Output };
            _context.Database.ExecuteSqlRaw("EXEC GetReservationCount  @Count OUTPUT", countParam);

            return Convert.ToInt32(countParam.Value);
        }
    }
}
