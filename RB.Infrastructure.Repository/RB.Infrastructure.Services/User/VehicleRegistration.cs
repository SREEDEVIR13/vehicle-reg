using Microsoft.AspNetCore.Http;
using RB.Core.Application.DTOModel;
using RB.Core.Application.Interface;
using RB.Core.Domain.Models;
using RB.Infrastructure.RB.Infrastructure.Repository;
using RB.Infrastructure.RB.Infrastructure.Services.General.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.RB.Infrastructure.Services.User
{
    public class VehicleRegistration : IVehicleRegistration
    {
        private readonly UserDbContext _userDbContext;
        private readonly ISaveImage _saveImage;
        public VehicleRegistration(UserDbContext userDbContext, ISaveImage saveImage)
        {
            _userDbContext = userDbContext;
            _saveImage = saveImage;
        }
        public UserResponseDTO RegisterVehicle(VehicleDTO vehicleDTO, IFormFile ImageFile)
        {
            var response = new UserResponseDTO();
            try { 
                string imagepath = _saveImage.UploadImage(ImageFile, vehicleDTO.VehicleName);

                
                var vehicle = new Vehicle()
                {
                    VehicleName = vehicleDTO.VehicleName,
                    VehicleNumber = vehicleDTO.VehicleNumber,
                    VehicleType = vehicleDTO.VehicleType,
                    NumberOfSeats = vehicleDTO.NumberOfSeats,
                    VehicleImage = imagepath


                };
                _userDbContext.Vehicles.Add(vehicle);
                _userDbContext.SaveChanges();

            } 
            
            catch (Exception ex)
            {
                response.Status = false;
                response.Output = ex.Message;
                return response;
            }
            response.Status = true;
            response.Output = "user added successfully";
            return response;

        }
    }
}
