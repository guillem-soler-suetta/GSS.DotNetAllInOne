using AutoMapper;
using GSS.DotNetAllInOne.Application.Features.Examples.Queries;
using GSS.DotNetAllInOne.Application.Wrappers;
using GSS.DotNetAllInOne.WebAPI.DTOs;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace GSS.DotNetAllInOne.WebAPI.Controllers
{
    public class ExamplesController : ApiController
    {
        public ExamplesController(IMediator mediator, IMapper mapper) : base(mediator, mapper)
        {

        }


        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] ListExamplesParameter filter)
        {
            var result = await Mediator.Send(new ListExamplesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber });
            var response = Mapper.Map<Response<IEnumerable<ExampleDTO>>>(result);
            return Ok(response);
        }

        //[HttpPost]
        //[Consumes("application/json")]
        //[ProducesResponseType(StatusCodes.Status201Created)]
        //public async Task<IActionResult> Post([FromBody] RecipeModel model)
        //{
        //    var recipe = Mapper.Map<Recipe>(model);
        //    return Created($"/api/recipes/{model.Id}", await Mediator.Send(new CreateRecipeCommand { Recipe = recipe }));
        //}

        //[HttpGet("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> Get(Guid id)
        //{
        //    var response = await Mediator.Send(new GetRecipeByIdQuery() { Id = id });
        //    if (response.Data is null) return NotFound(id);
        //    return Ok(response);
        //}

        //[HttpPut("{id}")]
        //[Consumes("application/json")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //public async Task<IActionResult> Put(Guid id, [FromBody] Recipe recipe)
        //{
        //    if (id != recipe.Id) return BadRequest(id);
        //    var response = await Mediator.Send(new UpdateRecipeCommand() { Recipe = recipe });
        //    if (response.Succeeded == false) return NotFound(id);
        //    return Ok(response);
        //}

        //[HttpDelete("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public async Task<ActionResult> Delete(Guid id)
        //{
        //    var response = await Mediator.Send(new DeleteRecipeByIdCommand { Id = id });
        //    if (response.Succeeded == false) return NotFound(id);
        //    return Ok(response);
        //}

    }
}
