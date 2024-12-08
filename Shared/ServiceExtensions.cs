using Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Shared.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class ServiceExtensions
    {
        public static void AddSharedLayer(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {


            services
            .AddTransient<IMediator, Mediator>()
            .AddTransient<IImagenService, ImagenService>();



        }
    }
}
