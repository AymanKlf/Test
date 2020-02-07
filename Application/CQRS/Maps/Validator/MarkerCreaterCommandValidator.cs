using Application.CQRS.Maps.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Maps.Validator
{
    public class MarkerCreaterCommandValidator : AbstractValidator<MarkerCreaterCommand>
    {
        public MarkerCreaterCommandValidator()
        {
            RuleFor(v => v.EntityDTO.MapId).NotNull().WithMessage("Marker map field is required");
            RuleFor(v => v.EntityDTO.Name).NotNull().WithMessage("Marker name field is required");
            RuleFor(v => v.EntityDTO.Address).NotNull().WithMessage("Marker address field is required");
            RuleFor(v => v.EntityDTO.Position.Latitude).NotNull().WithMessage("Marker position latitude field is required");
            RuleFor(v => v.EntityDTO.Position.Longitude).NotNull().WithMessage("Marker position longitude field is required");
        }
    }
}
