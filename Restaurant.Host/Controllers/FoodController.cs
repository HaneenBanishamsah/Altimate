using Microsoft.AspNetCore.Mvc;
using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;
using Restaurant.Contracts.DTOs;

namespace Restaurant.Host.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FoodController : ControllerBase
    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }

        [HttpGet("{id}")]
        public IActionResult GetFoodById(int id)
        {
            var food = _foodService.GetFoodById(id);
            if (food == null)
                return NotFound();

            return Ok(food);
        }

        [HttpGet]
        public IActionResult GetAllFoods()
        {
            var foods = _foodService.GetAllFoods();
            return Ok(foods);
        }

        [HttpPost]
        public IActionResult AddFood([FromBody] FoodDTO foodDto)
        {
            var food = new Food { Name = foodDto.Name, Price = foodDto.Price };
            _foodService.AddFood(food);
            return CreatedAtAction(nameof(GetFoodById), new { id = food.Id }, food);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateFood(int id, [FromBody] FoodDTO foodDto)
        {
            var food = _foodService.GetFoodById(id);
            if (food == null)
                return NotFound();

            food.Name = foodDto.Name;
            food.Price = foodDto.Price;
            _foodService.UpdateFood(food);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFood(int id)
        {
            var food = _foodService.GetFoodById(id);
            if (food == null)
                return NotFound();

            _foodService.DeleteFood(id);
            return NoContent();
        }
    }
}
