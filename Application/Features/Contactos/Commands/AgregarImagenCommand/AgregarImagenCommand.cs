﻿using Application.Common.Wrappers;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Commands.AgregarImagenCommand
{
    public class AgregarImagenCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public IFormFile? Imagen { get; set; }
    }
}
