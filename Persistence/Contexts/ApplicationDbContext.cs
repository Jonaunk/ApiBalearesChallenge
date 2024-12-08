using Application.Common.Interfaces;
using Domain.Common;
using Domain.Entities.Contactos;
using Microsoft.EntityFrameworkCore;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        private readonly CurrentUser _user;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUserService currentUserService) : base(options)
        {
            _user = currentUserService.User;
        }

        public DbSet<Contacto> Contactos { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            //Cada vez que guardamos o modificamos le decimos que guarde la fecha
            foreach (var entry in ChangeTracker.Entries<AuditableBaseEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.UsuarioAlta = _user.Id;
                        entry.Entity.FechaAlta = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UsuarioModificacion = _user.Id;
                        entry.Entity.FechaModificacion = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified;
                        entry.Entity.UsuarioBaja = _user.Id;
                        entry.Entity.FechaBaja = DateTime.Now;
                        break;
                }
            }
            //return base.SaveChangesAsync();

            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            return result;
        }

    }
}
