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
    public class ContactController : Controller
    {
        private readonly IContactService _service;
        public ContactController(IContactService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<ContactDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]")]
        public ContactDTO Search(string name)
        {
            return _service.Search(name);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] ContactDTO model)
        {
            var result = await _service.Create(model);

            return Json(result);
        }

        [HttpGet("[action]")]
        public async Task<ContactDTO> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] ContactDTO model)
        {
            var result = await _service.Update(model);

            return Json(result);
        }

        [HttpGet("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Json(result);
        }
    }
}
