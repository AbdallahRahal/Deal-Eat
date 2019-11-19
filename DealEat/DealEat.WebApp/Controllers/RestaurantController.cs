using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DealEat.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using DealEat.WebApp.Authentication;
using DealEat.DAL;

namespace DealEat.WebApp.Controllers
{
    [Route("api/[controller]")]
    public class RestaurantController : Controller
    {
        readonly RestaurantGateway _restaurantGateway;

        public RestaurantController(RestaurantGateway restaurantGateway)
        {
            _restaurantGateway = restaurantGateway;

        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurantList()
        {
           IEnumerable<RestaurantData> result = await _restaurantGateway.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            Result<RestaurantData> result = await _restaurantGateway.FindById(id);
            return this.CreateResult(result);
        }

        /*
        [HttpPost]
        public async Task<IActionResult> CreateRestaurant([FromBody] RestaurantViewModel model)
        {
            Result<int> result = await _restaurantGateway.Create( model.RestaurantId, model.Name, model.Adresse, model.PhotoLink, model.Telephone, model.UserId );
            return this.CreateResult(result, o =>
            {
                o.RouteName = "GetRestaurant";
                o.RouteValues = id => new { id };
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            Result result = await _restaurantGateway.Delete(id);
            return this.CreateResult(result);
        }
        */
    }
}