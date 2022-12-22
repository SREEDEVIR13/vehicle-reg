//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using RB.Core.Application.DTOModel;
//using RB.Core.Application.Interface;

//namespace RB.Presentation.User.API.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class RegistrationController : ControllerBase
//    {
//        private readonly IUserRegistration _userRegistration;
//        public RegistrationController(IUserRegistration userRegistration)
//        {
//            _userRegistration = userRegistration;
//        }
//        [HttpPost]
//        [Route("Register")]
//        public IActionResult Register([FromForm] UserRegisterDTO userRegisterDTO)
//        {
//            if(!ModelState.IsValid)
//            {
//                return BadRequest("not a valid request");
//            }
//            var response= _userRegistration.Register(userRegisterDTO);
//            return Ok(response);
           
//        }
//    }
//}
