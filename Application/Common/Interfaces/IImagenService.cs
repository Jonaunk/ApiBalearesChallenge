﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IImagenService
    {
        Task<string> ConvertirImagenABase64(IFormFile imagen);
    }
}
