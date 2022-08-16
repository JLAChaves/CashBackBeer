using CashbackBeer.Application.Interfaces;
using CashbackBeer.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using CashbackBeer.Domain.Pagination;

namespace CashbackBeer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinalSaleController : ControllerBase
    {
        private readonly IFinalSaleService _finalSaleService;
        public FinalSaleController(IFinalSaleService finalSaleService)
        {
            _finalSaleService = finalSaleService;
        }

        [HttpPost]
        public async Task<ActionResult> Post(FinalSale finalSale)
        {
            if (finalSale == null) return BadRequest("Invalid Data");
                           
            await _finalSaleService.Add(finalSale);

            return Ok("Registered Sale");
        }

        [HttpGet("SearchId/{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var get = await _finalSaleService.GetById(id);

            if (get == null) return BadRequest("Invalid id");
            
            return Ok(get);
        }

        [HttpGet]
        public IActionResult GetAll([FromQuery()] PaginationParams pagination)
        {
            if (pagination.Limit <= 0 || pagination.Page <= 0) return BadRequest();
           
            var getAll = _finalSaleService.GetAll(pagination);

            return Ok(getAll);
        }

        [HttpGet("SearchDate")]
        public IActionResult GetFinalSaleByDate([FromQuery()] PaginationParams pagination, [FromQuery()] DateTime? minDate, [FromQuery()] DateTime? maxDate)
        {
            if (pagination.Limit <= 0 || pagination.Page <= 0)
            {
                return BadRequest();
            }
            var getAll = _finalSaleService.GetFinalSaleByDate(pagination, minDate, maxDate);
            return Ok(getAll);
        }
    }
}
