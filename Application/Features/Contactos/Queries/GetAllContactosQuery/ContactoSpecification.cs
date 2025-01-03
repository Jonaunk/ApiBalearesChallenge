﻿using Ardalis.Specification;
using Domain.Entities.Contactos;

namespace Application.Features.Contactos.Queries.GetAllContactosQuery
{
    public class ContactoSpecification : Specification<Contacto>
    {
        public ContactoSpecification(PaginationContactosParameters parameters)
        {
            Query.Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            if (parameters.Id != null && parameters.Id != 0)
                Query.Where(x => x.Id == parameters.Id);

            if (!string.IsNullOrEmpty(parameters.Nombre))
                Query.Where(x => x.Nombre.Contains(parameters.Nombre));

            if (!string.IsNullOrEmpty(parameters.Email))
                Query.Where(x => x.Email.Contains(parameters.Email));

            if (!string.IsNullOrEmpty(parameters.Telefono))
                Query.Where(x => x.Telefono.Contains(parameters.Telefono));

            if (parameters.CiudadId != null && parameters.CiudadId != 0)
                Query.Where(x => x.CiudadId == parameters.CiudadId);

            if (parameters.ProvinciaId != null && parameters.ProvinciaId != 0)
                Query.Where(x => x.ProvinciaId == parameters.ProvinciaId);

            if (parameters.OrdenarPorMail != null && parameters.OrdenarPorMail is true) // Verifica si se debe ordenar por email
                Query.OrderBy(x => x.Email);

            Query.Where(x => x.FechaBaja == null)
              .Include(x => x.Provincia)
              .Include(x => x.Ciudad)
              .Include(x => x.Transporte);
        }
    }

}
