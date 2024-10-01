using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;


namespace Restaurant.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly List<Drink> _drinks;

        public DrinkService()
        {
            // to get it from the list

            _drinks = new List<Drink>
            {
                new Drink { Id = 1, Name = "Chat Cola", Price = 1 },
                new Drink { Id = 2, Name = "Ice cofee", Price = 3.5 },
                new Drink { Id = 3, Name = "Hot chocolate", Price = 5},
                new Drink { Id = 4, Name = "sama cola", Price = 1.5 }
            };



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
