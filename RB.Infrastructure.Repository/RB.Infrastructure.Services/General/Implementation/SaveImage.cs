using Microsoft.AspNetCore.Http;
using RB.Infrastructure.RB.Infrastructure.Services.General.Interface;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.RB.Infrastructure.Services.General.Implementation
{
    public class SaveImage : ISaveImage
    {
        private readonly IHostingEnvironment _hostEnvironment;
        public SaveImage(IHostingEnvironment hostEnvironment)
        {
            _hostEnvironment = hostEnvironment;
        }

        public string UploadImage(IFormFile logo, string name)
        {

            string imagePath = new String(Path.GetFileNameWithoutExtension(logo.FileName)).Replace(' ', '-');
            imagePath = name + "-" + imagePath + DateTime.Now.ToString("yyyyMMddhhmmfff") + Path.GetExtension(logo.FileName);
            var path = Path.Combine(_hostEnvironment.ContentRootPath, "Images", imagePath);

            using (var filestream = new FileStream(path, FileMode.Create))
            {
                logo.CopyToAsync(filestream);
            }
            return imagePath;
        }
    }
}
