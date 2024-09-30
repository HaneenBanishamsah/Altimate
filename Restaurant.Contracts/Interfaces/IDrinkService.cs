using Restaurant.Domain.Entities;

namespace Restaurant.Contracts.Interfaces
{
    public interface IDrinkService
    {
        Drink GetDrinkById(int id);
        IEnumerable<Drink> GetAllDrinks();
        void AddDrink(Drink drink);
        void UpdateDrink(Drink drink);
        void DeleteDrink(int id);
    }
}
