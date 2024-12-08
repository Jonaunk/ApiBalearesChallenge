using Domain.Entities.Users;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Context
{
    public class IdentityContext : IdentityDbContext<Usuario>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
           
        }
    }

}
