using Application.Features.Contactos.Commands.CreateContacto;
using AutoMapper;
using Domain.Entities.Contactos;
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
        }
    }
}
