﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RB.Core.Application.DTOModel;
using RB.Core.Application.Interface;

namespace RB.Presentation.User.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRegistration _vehicleRegistration;
       
        public  VehicleController(IVehicleRegistration vehicleRegistration )

        {
            _vehicleRegistration = vehicleRegistration;
           
        }
        [HttpPost]
        [Route("register")]
        public IActionResult Register([FromForm] VehicleDTO vehicleDTO , IFormFile ImageFile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("not a valid request");
            }
           var response= _vehicleRegistration.RegisterVehicle(vehicleDTO, ImageFile);
            return Ok(response);
        }
    }
}
