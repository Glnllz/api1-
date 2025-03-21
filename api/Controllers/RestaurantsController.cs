using api1.Interfaces;
using api1.Model;
using api1.Service;
using Microsoft.AspNetCore.Mvc;

namespace api1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RestaurantsController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;

        public RestaurantsController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurants()
        {
            return await _restaurantService.GetAllRestaurantsAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            return await _restaurantService.GetRestaurantByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRestaurant(Restaurant restaurant)
        {
            return await _restaurantService.CreateRestaurantAsync(restaurant);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRestaurant(int id, Restaurant restaurant)
        {
            return await _restaurantService.UpdateRestaurantAsync(id, restaurant);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            return await _restaurantService.DeleteRestaurantAsync(id);
        }
    }
}