using Restaurant.Domain.Entities;

namespace Restaurant.Contracts.Interfaces
{
    public interface IFoodService
    {
        Food GetFoodById(int id);
        IEnumerable<Food> GetAllFoods();
        void AddFood(Food food);
        void UpdateFood(Food food);
        void DeleteFood(int id);
    }
}
