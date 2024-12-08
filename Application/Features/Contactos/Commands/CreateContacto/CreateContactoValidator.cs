using Application.Features.Authenticate.Commands.RegisterCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Contactos.Commands.CreateContacto
{
    public class CreateContactoValidator : AbstractValidator<CreateContactoCommand>
    {
        public CreateContactoValidator()
        {
            RuleFor(p => p.Nombre)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Apellido)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .MaximumLength(100).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .EmailAddress().WithMessage("{PropertyName} debe ser una dirección válida.")
                .MaximumLength(250).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.FechaNacimiento)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .LessThan(DateTime.Now).WithMessage("{PropertyName} debe ser una fecha pasada.");

            RuleFor(p => p.Telefono)
                .NotEmpty().WithMessage("{PropertyName} no puede ser vacío.")
                .Matches(@"^\+?[1-9]\d{1,14}$").WithMessage("{PropertyName} debe ser un número de teléfono válido.");

            RuleFor(p => p.Direccion)
                .MaximumLength(250).WithMessage("{PropertyName} no debe exceder de {MaxLength} caracteres.");

            RuleFor(p => p.CiudadId)
                .NotEmpty().WithMessage("{PropertyName} debe ser un valor válido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser un número mayor que cero.");

            RuleFor(p => p.ProvinciaId)
                .NotEmpty().WithMessage("{PropertyName} debe ser un valor válido.")
                .GreaterThan(0).WithMessage("{PropertyName} debe ser un número mayor que cero.");
        }
    }



}
