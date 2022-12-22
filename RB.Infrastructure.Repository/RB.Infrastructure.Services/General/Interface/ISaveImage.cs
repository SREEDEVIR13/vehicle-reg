using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RB.Infrastructure.RB.Infrastructure.Services.General.Interface
{
    public interface ISaveImage
    {
        string UploadImage(IFormFile logo, string name);

    }
}
