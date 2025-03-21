using api1.Model;
using Microsoft.AspNetCore.Mvc;

namespace api1.Interfaces
{
    public interface IRestaurantService
    {
        Task<IActionResult> GetAllRestaurantsAsync();
        Task<IActionResult> GetRestaurantByIdAsync(int id);
        Task<IActionResult> CreateRestaurantAsync(Restaurant restaurant);
        Task<IActionResult> UpdateRestaurantAsync(int id, Restaurant restaurant);
        Task<IActionResult> DeleteRestaurantAsync(int id);
    }
}