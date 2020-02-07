using Application.CQRS.Maps.Command;
using Domain.Enumerations;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Maps.Validator
{
    public class MapCreaterCommandValidator : AbstractValidator<MapCreaterCommand>
    {
        public MapCreaterCommandValidator()
        {
            RuleFor(v => v.EntityDTO.Zoom).NotNull().WithMessage("Map zoom field is required");
            RuleFor(v => v.EntityDTO.Type).NotNull().WithMessage("Map type field is required");
            RuleFor(x => x.EntityDTO.Type).IsEnumName(typeof(MapType), caseSensitive: false).WithMessage("Map type should be [Roadmap|Satellite|Hybrid|Terrain]");
            RuleFor(v => v.EntityDTO.Center.Latitude).NotNull().WithMessage("Map center latitude field is required");
            RuleFor(v => v.EntityDTO.Center.Longitude).NotNull().WithMessage("Map center longitude field is required");            
        }
    }
}