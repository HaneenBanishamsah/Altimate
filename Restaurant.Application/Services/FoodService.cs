using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly List<Food> _foods;

        public FoodService()
        {
            _foods = new List<Food>
            {
                new Food { Id = 5, Name = "Pizza", Price = 30 },
                new Food { Id = 6, Name = "Burger", Price = 22.5 },
                new Food { Id = 7, Name = "Pasta", Price = 34.99 },
                new Food { Id = 8, Name = "Makloubah", Price = 59.99 }
            };
        }

        public Food GetFoodById(int id)
        {
            return _foods.FirstOrDefault(f => f.Id == id);
        }

        public IEnumerable<Food> GetAllFoods()
        {
            return _foods;
        }

        public void AddFood(Food food)
        {
            _foods.Add(food);
        }

        public void UpdateFood(Food food)
        {
            var existingFood = GetFoodById(food.Id);
            if (existingFood != null)
            {
                existingFood.Name = food.Name;
                existingFood.Price = food.Price;
            }
        }

        public void DeleteFood(int id)
        {
            var food = GetFoodById(id);
            if (food != null)
            {
                _foods.Remove(food);
            }
        }
    }
}
