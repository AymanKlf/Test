using Application.CQRS.Maps.Command;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.CQRS.Maps.Validator
{
    public class ShapeCreaterCommandValidator : AbstractValidator<ShapeCreaterCommand>
    {
        public ShapeCreaterCommandValidator()
        {
            RuleFor(v => v.EntityDTO.MapId).NotNull().WithMessage("Shape map field is required");
            RuleFor(v => v.EntityDTO.Type).NotNull().WithMessage("Shape type field is required");
            RuleFor(v => v.EntityDTO.Data).NotNull().WithMessage("Shape data field is required");
        }
    }
}
