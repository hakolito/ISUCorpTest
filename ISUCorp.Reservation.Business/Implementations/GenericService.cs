using AutoMapper;
using ISUCorp.Reservation.Business.Interfaces;
using ISUCorp.Reservation.Data.Interfaces.Framework;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ISUCorp.Reservation.Business.Implementations
{
    /// <summary>
    /// Generic Service for CRUD Operation
    /// </summary>
    /// <typeparam name="T">Model</typeparam>
    /// <typeparam name="DTO">DTO</typeparam>
    public abstract class GenericService<T, DTO> : IGenericService<T, DTO>
        where T : class
        where DTO : class
    {
        private readonly IGenericRepository<T> _repository;
        private IMapper _mapper;


        public GenericService(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public virtual Task<int> Create(DTO entity)
        {
            var model = _mapper.Map<T>(entity);
            return _repository.Create(model);
        }

        public virtual Task<int> Delete(int id)
        {
            return _repository.Delete(id);
        }

        public virtual IEnumerable<DTO> GetAll()
        {
            return _mapper.Map<IEnumerable<DTO>>(_repository.GetAll());
        }

        public virtual Task<DTO> GetById(int id)
        {
            return _mapper.Map<Task<DTO>>(_repository.GetById(id));
        }


        public virtual Task<int> Update(DTO entity)
        {
            var model = _mapper.Map<T>(entity);
            return _repository.Update(model);
        }
               
    }
}
