using DataCenter;
using Restaurant.Contracts.Interfaces;
using Restaurant.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Restaurant.Application.Services
{
    public class DrinkService : IDrinkService
    {
        private readonly ApplicationDbContext _context;

        public DrinkService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Drink>> GetAllDrinksAsync()
        {
            return await _context.Drinks.ToListAsync();
        }

        public async Task<Drink> GetDrinkByIdAsync(int id)
        {
            return await _context.Drinks.FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task AddDrinkAsync(Drink drink)
        {
            await _context.Drinks.AddAsync(drink);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateDrinkAsync(Drink drink)
        {
            _context.Drinks.Update(drink);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteDrinkAsync(int id)
        {
            var drink = await GetDrinkByIdAsync(id);
            if (drink != null)
            {
                _context.Drinks.Remove(drink);
                await _context.SaveChangesAsync();
            }
        }
    }
}
