using Application.Common.Wrappers;
using Application.Features.Contactos.Commands.CreateContacto;
using Application.Features.Contactos.Queries.GetAllContactosQuery;
using BalearesChallengeApi.Controllers.V1;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BalearesChallengeAPI.Tests.Controllers
{
    public class ContactosControllerTests
    {
        private readonly ContactosController _controller;
        private readonly Mock<IMediator> _mediatorMock;
        private readonly IServiceProvider _serviceProvider;

        public ContactosControllerTests()
        {
            // Inicializar el mock de IMediator
            _mediatorMock = new Mock<IMediator>();

            // Configurar el contenedor de servicios en memoria
            var services = new ServiceCollection();
            services.AddSingleton<IMediator>(_ => _mediatorMock.Object);

            // Agrega otros servicios necesarios como IHttpContextAccessor si es necesario
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Crea un ServiceProvider para resolver las dependencias
            _serviceProvider = services.BuildServiceProvider();

            // Configura el HttpContext en el controlador
            var httpContext = new DefaultHttpContext
            {
                RequestServices = _serviceProvider
            };

            // Inicializa el controlador
            _controller = new ContactosController
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = httpContext
                }
            };
        }

        [Fact]
        public async Task CreateContactoAsync_ReturnsOkResult()
        {
            // Crea un comando de prueba.
            var command = new CreateContactoCommand
            {
                Nombre = "Checo",
                Apellido = "Pérez",
                Empresa="Red Bull",
                Email = "checo.perez@example.com",
                FechaNacimiento = DateTime.Now.AddYears(-30),
                Telefono = "123456789",
                Direccion = "Calle Falsa 123",
                CiudadId = 1,
                ProvinciaId = 1
            };



            // Act
            var result = await _controller.CreateContactoAsync(command);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, okResult.StatusCode);
        }
    }
}
