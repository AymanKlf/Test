using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.Filters;
using MediatR;
using System.Collections.Generic;

namespace Web.Controllers
{
    [ApplicationExceptionFilter]
    [ApiController]
    [Route("api/[controller]")]
    public class APIBaseController : ControllerBase
    {
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }

    public class ApplicationExceptionFilterAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case Application.Common.Exceptions.ValidationException e:
                    List<string> errors = new List<string>();
                    
                    foreach(var item in e.Failures)
                    {
                        errors.Add(item.Value[0]);
                    }

                    context.Result = new BadRequestObjectResult(errors);
                    return;

                case Application.Common.Exceptions.EntityNotFoundException e:
                    context.Result = new NotFoundObjectResult(e.Message);
                    return;

                case Domain.Exceptions.InvalidCoordinatePointException e:
                    {
                        context.Result = new BadRequestObjectResult(e.Message);
                        return;
                    }

                default:
                    {
                        context.Result = new BadRequestObjectResult(context.Exception.Message);
                        return;
                    }

                    //case BadRequestException e:
                    //    context.Result = new BadRequestObjectResult(e.Message);
                    //    return;

                    //case ConflictException e:
                    //    context.Result = new ConflictObjectResult(e.Message);
                    //    return;

                    //case ForbiddenException e:
                    //    context.Result = new ForbidResult();
                    //    return;

                    //case UnauthorizedException e:
                    //    context.Result = new UnauthorizedResult();
                    //    return;
            }
        }
    }

}
