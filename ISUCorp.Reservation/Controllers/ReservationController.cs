﻿using ISUCorp.Reservation.Business.DTO;
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
    public class ReservationController : Controller
    {
        private readonly IReservationService _service;
        public ReservationController(IReservationService service)
        {
            _service = service;
        }

        [HttpGet("[action]")]
        public IEnumerable<ReservationDTO> GetAll()
        {
            return _service.GetAll();
        }

        [HttpGet("[action]")]
        public IEnumerable<ReservationDTO> GetAllList()
        {
           

            return _service.GetAllList();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Create([FromBody] ReservationDTO model)
        {
            // return validation error if required fields aren't filled in
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.Create(model);

            return Json(result);
        }

        [HttpGet("[action]")]
        public async Task<ReservationDTO> GetById(int id)
        {
            return await _service.GetById(id);
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Update([FromBody] ReservationDTO model)
        {
            // return validation error if required fields aren't filled in
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await _service.Update(model);

            return Json(result);
        }

        [HttpGet("[action]")]
        public IActionResult Delete(int id)
        {
            var result = _service.Delete(id);

            return Json(result);
        }

        [HttpGet("[action]")]
        public IActionResult GetCount()
        {
            var result = _service.GetReservationCount();

            return Json(result);
        }
    }
}
