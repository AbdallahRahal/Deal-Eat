using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DealEat.WebApp.Models;
using Microsoft.AspNetCore.Authorization;
using DealEat.WebApp.Authentication;

namespace DealEat.WebApp.Controllers
{
    [Route("api/[controller]")]
    [Authorize( AuthenticationSchemes = JwtBearerAuthentication.AuthenticationScheme)]
    public class CategoryController : Controller
    {
        readonly CategoryGateway categoryGateway;
        readonly RestaurantGateway restaurantGateway;

        public CategoryController(CategoryGateway categoryGateway, RestaurantGateaway restaurantGateaway)
        {
            _categoryGateway = categoryGateway;
            _restaurantGateway = restaurantGateaway;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryList()
        {
            IEnumerable<CategoryData> result = await _categoryGateway.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCategory")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            Result<CategoryData> result = await _categoryGateway.FindById(id);
            return this.CreateResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel model)
        {
            Result<int> result = await _categoryGateway.Create(/* METTRE LES MODELS ex : model.Name*/);
            return this.CreateResult(result, o =>
            {
                o.RouteName = "GetCategory";
                o.RouteValues = id => new { id };
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Result result = await _categoryGateway.Delete(id);
            return this.CreateResult(result);
        }
    }
}
