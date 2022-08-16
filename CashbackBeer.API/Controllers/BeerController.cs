using CashbackBeer.Application.Interfaces;
using CashbackBeer.Domain.Pagination;
using Microsoft.AspNetCore.Mvc;

namespace CashbackBeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerService _beerService;
        public BeerController(IBeerService beerService)
        {
            _beerService = beerService;
        }

        [HttpGet("SearchAll")]
        public IActionResult GetAll([FromQuery()] PaginationParams pagination, [FromQuery()] string? name)
        {
            if (pagination.Limit <= 0 || pagination.Page <= 0)
            {
                return BadRequest();
            }           
            var getAll = _beerService.GetBeersByName(pagination, name);
            return Ok(getAll);
        }

        [HttpGet("SearchId/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var get = await _beerService.GetBeerById(id);
            if (get == null)
            {
                return BadRequest("Invalid id");
            }
            return Ok(get);
        }
    }
}
