using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;


namespace Restaurant.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly List<Drink> _drinks;

        public DrinkService()
        {
            _drinks = new List<Drink>();
        }

        public Drink GetDrinkById(int id)
        {
            return _drinks.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Drink> GetAllDrinks()
        {
            return _drinks;
        }

        public void AddDrink(Drink drink)
        {
            _drinks.Add(drink);
        }

        public void UpdateDrink(Drink drink)
        {
            var existingDrink = GetDrinkById(drink.Id);
            if (existingDrink != null)
            {
                existingDrink.Name = drink.Name;
                existingDrink.Price = drink.Price;
            }
        }

        public void DeleteDrink(int id)
        {
            var drink = GetDrinkById(id);
            if (drink != null)
            {
                _drinks.Remove(drink);
            }
        }
    }
}
