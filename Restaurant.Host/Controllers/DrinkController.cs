using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Contracts.DTOs;

namespace Restaurant.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DrinkController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        // GET: api/Drink/{id}
        [HttpGet("{id}")]
        public IActionResult GetDrinkById(int id)
        {
            var drink = _drinkService.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }
            return Ok(drink);
        }

        // GET: api/Drink
        [HttpGet]
        public IActionResult GetAllDrinks()
        {
            var drinks = _drinkService.GetAllDrinks();
            return Ok(drinks);
        }

        // POST: api/Drink
        [HttpPost]
        public IActionResult AddDrink([FromBody] DrinkDTO drinkDto)
        {
            if (drinkDto == null)
            {
                return BadRequest("Drink data is null.");
            }

            var drink = new Drink
            {
                Name = drinkDto.Name,
                Price = drinkDto.Price
            };

            _drinkService.AddDrink(drink);

            return CreatedAtAction(nameof(GetDrinkById), new { id = drink.Id }, drink);
        }

        // PUT: api/Drink/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateDrink(int id, [FromBody] DrinkDTO drinkDto)
        {
            if (drinkDto == null || id <= 0)
            {
                return BadRequest("Invalid input.");
            }

            var drink = _drinkService.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound("Drink not found.");
            }

            // Updating the drink information
            drink.Name = drinkDto.Name;
            drink.Price = drinkDto.Price;

            _drinkService.UpdateDrink(drink);

            return NoContent(); // Successful update without any content
        }

        // DELETE: api/Drink/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteDrink(int id)
        {
            var drink = _drinkService.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound("Drink not found.");
            }

            _drinkService.DeleteDrink(id);

            return NoContent(); // Successful deletion without any content
        }
    }
}
