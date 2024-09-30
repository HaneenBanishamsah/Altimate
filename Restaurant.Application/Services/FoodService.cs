using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;

namespace Restaurant.Application.Services
{
    public class FoodService : IFoodService
    {
        private readonly List<Food> _foods;

        public FoodService()
        {
            _foods = new List<Food>();
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
