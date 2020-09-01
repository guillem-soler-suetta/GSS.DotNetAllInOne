using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GSS.DotNetAllInOne.WebAPI.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected IMediator Mediator { get; set; }
        protected IMapper Mapper { get; set; }
        public ApiController(IMediator mediator, IMapper mapper)
        {
            Mediator = mediator;
            Mapper = mapper;
        }
    }
}
