//using Microsoft.AspNetCore.Http;
//using RB.Core.Application.DTOModel;
//using RB.Core.Application.Interface;
//using RB.Core.Domain.Models;
//using RB.Infrastructure.RB.Infrastructure.Repository;
//using RB.Infrastructure.RB.Infrastructure.Services.General.Interface;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace RB.Infrastructure.RB.Infrastructure.Services.User
//{
//    public class UserRegistration : IUserRegistration
//    {
//        private readonly UserDbContext _userDbContext;
//        private readonly IRegisterValidations _registerValidations;
//        private readonly ISaveImage _saveImage;
//        public UserRegistration(UserDbContext userDbContext, IRegisterValidations registerValidations, ISaveImage saveImage)
//        {
//            _userDbContext = userDbContext;
//            _registerValidations = registerValidations;
//            _saveImage = saveImage;
//        }
//        public async Task<UserResponseDTO> Register(UserRegisterDTO userRegisterDTO, IFormFile ImageFile)
//        {
//            var response = new UserResponseDTO(); 
//            try 
//            {
//                _registerValidations.CreatePasswordHash(userRegisterDTO.Password, out byte[] passwordHash, out byte[] passwordSalt);
//                var imgpath = _saveImage.UploadImage(userRegisterDTO.License ,userRegisterDTO.FirstName);
//                var user = new TempUserRegister
//                {
//                    FirstName = userRegisterDTO.FirstName,
//                    LastName = userRegisterDTO.LastName,
//                    PasswordHash = passwordHash,
//                    PasswordSalt = passwordSalt,
//                    Email = userRegisterDTO.Email,
//                    Gender = userRegisterDTO.Gender,
//                    Number = userRegisterDTO.Number,
//                    Department = userRegisterDTO.Department,
//                    EmployeeId = userRegisterDTO.EmployeeId,
//                    Role = userRegisterDTO.Role,
//                    LicenceImageName = await imgpath
//                };
//                _userDbContext.TempUsers.Add(user);
//                _userDbContext.SaveChanges();

//            }
//            catch (Exception ex)
//            {
//                response.Status = false;
//                response.Output = ex.Message;
//                return response;
//            }
//            response.Status = true;
//            response.Output = "user added successfully";
//            return response;



//        }
//    }
//}
