using Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Services
{
    public class ImagenService : IImagenService
    {
        public async Task<string> ConvertirImagenABase64(IFormFile imagen)
        {
            if (imagen == null || imagen.Length == 0)
            {
                throw new ArgumentException("La imagen no es válida.");
            }

            using (var memoryStream = new MemoryStream())
            {
                await imagen.CopyToAsync(memoryStream);
                var imageBytes = memoryStream.ToArray();
                return Convert.ToBase64String(imageBytes);
            }
        }
    }
}
