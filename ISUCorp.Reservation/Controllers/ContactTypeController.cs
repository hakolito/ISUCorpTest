using ISUCorp.Reservation.Business.DTO;
using ISUCorp.Reservation.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ISUCorp.Reservation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactTypeController : Controller
    {
        private readonly IContactTypeService _service;
        public ContactTypeController(IContactTypeService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<ContactTypeDTO> GetAll()
        {
            return _service.GetAll();
        }
    }
}
