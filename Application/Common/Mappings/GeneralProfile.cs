using Application.DTOs;
using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Commands.UpdateContacto;
using Application.Features.Contactos.Queries;
using Application.Features.Usuarios.Queries.GetUsuariosOrdenadosQuery;
using AutoMapper;
using Domain.Entities.Contactos;
using Domain.Entities.Domain;
using Domain.Entities.Users;
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
            CreateMap<UpdateContactoCommand, Contacto>().ReverseMap();

            CreateMap<Ciudad, CiudadDTO>().ReverseMap();
            CreateMap<Provincia, ProvinciaDTO>().ReverseMap();
            CreateMap<Usuario, GetUsuariosOrdenadosQueryResponse>().ReverseMap();
        }
    }
}
