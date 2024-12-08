﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Usuarios.Queries.GetUsuariosOrdenadosQuery
{
    public class GetUsuariosOrdenadosQueryResponse
    {
        public Guid? Id { get; set; }
        public string? UserName { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Email { get; set; }
    }
}
