using AutoMapper;
using ISUCorp.Reservation.Business.DTO;
using ISUCorp.Reservation.Business.Interfaces;
using ISUCorp.Reservation.Data.Interfaces.Framework;
using ISUCorp.Reservation.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ISUCorp.Reservation.Business.Implementations
{
    public class ContactService : GenericService<Contact, ContactDTO>, IContactService
    {
        IGenericRepository<Contact> _repository;
        IMapper _mapper;
        public ContactService(IGenericRepository<Contact> repository, IMapper mapper) : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ContactDTO Search(string name)
        {
            var contact = _repository.Where(x => x.Name.Contains(name)).FirstOrDefault(); 

            return _mapper.Map<ContactDTO>(contact);
        }
    }
}
