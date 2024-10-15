using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Drink>>> GetAllDrinks()
        {
            var drinks = await _drinkService.GetAllDrinksAsync();
            return Ok(drinks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Drink>> GetDrinkById(int id)
        {
            var drink = await _drinkService.GetDrinkByIdAsync(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        [HttpPost]
        public IActionResult AddDrink([FromBody] Drink drink)
        {
            _drinkService.AddDrinkAsync(drink);
            return CreatedAtAction(nameof(GetDrinkById), new { id = drink.Id }, drink);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateDrink(int id, [FromBody] Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }
            _drinkService.UpdateDrinkAsync(drink);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDrink(int id)
        {
            _drinkService.DeleteDrinkAsync(id);
            return NoContent();
        }
    }
}
