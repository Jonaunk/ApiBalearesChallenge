﻿using Application.DTOs;
using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Queries;
using AutoMapper;
using Domain.Entities.Contactos;
using Domain.Entities.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<CreateContactoCommand, Contacto>().ReverseMap();
            CreateMap<Contacto, ContactoResponse>().ReverseMap();

            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
        }
    }
}
