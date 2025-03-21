using api1.DataBaseContext;
using api1.Interfaces;
using api1.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api1.Service
{
    public class RestaurantService : IRestaurantService
    {
        private readonly ContextDb _context;

        public RestaurantService(ContextDb context)
        {
            _context = context;
        }

        public async Task<IActionResult> GetAllRestaurantsAsync()
        {
            var restaurants = await _context.Restaurants.ToListAsync();
            return new OkObjectResult(restaurants);
        }

        public async Task<IActionResult> GetRestaurantByIdAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return new NotFoundResult();
            }
            return new OkObjectResult(restaurant);
        }

        public async Task<IActionResult> CreateRestaurantAsync(Restaurant restaurant)
        {
            _context.Restaurants.Add(restaurant);
            await _context.SaveChangesAsync();
            return new OkObjectResult(restaurant);
        }

        public async Task<IActionResult> UpdateRestaurantAsync(int id, Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return new BadRequestResult();
            }

            _context.Entry(restaurant).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new OkObjectResult(restaurant);
        }

        public async Task<IActionResult> DeleteRestaurantAsync(int id)
        {
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return new NotFoundResult();
            }

            _context.Restaurants.Remove(restaurant);
            await _context.SaveChangesAsync();
            return new OkResult();
        }
    }
}