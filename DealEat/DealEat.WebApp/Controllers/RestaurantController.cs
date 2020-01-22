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
        readonly UserGateway _userGateway;


        public RestaurantController(RestaurantGateway restaurantGateway, UserGateway userGateway )
        {
            _restaurantGateway = restaurantGateway;
            _userGateway =  userGateway;

        }

        [HttpGet]
        public async Task<IActionResult> GetRestaurantList()
        {
           IEnumerable<RestaurantData> result = await _restaurantGateway.GetAll();
            return Ok(result);
        }



        [HttpGet("GetFeedbackByRestaurant/{id}", Name = "GetFeedbackByRestaurant")]
        public async Task<IActionResult> GetFeedbackByRestaurant(int id)
        {
            IEnumerable<FeedBackData> result = await _restaurantGateway.GetFeedback(id);
            return Ok(result);
        }


        [HttpGet("GetRestaurant/{id}", Name = "GetRestaurant")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            Result<RestaurantData> result = await _restaurantGateway.FindById(id);
            return this.CreateResult(result);
        }


        [HttpGet("GetRestaurantWeb/{id}", Name = "GetRestaurantWeb")]
        public async Task<IActionResult> GetRestaurantByIdWeb(int id)
        {
            Result<RestaurantDataWeb> result = await _restaurantGateway.FindByIdWeb(id);
            return this.CreateResult(result);
        } 
        [HttpPost("UpdateRestaurant/{id}", Name = "UpdateRestaurant")]
        public async Task<IActionResult> UpdateRestaurantById(int id,[FromBody] RestaurantViewModel model)
        {
            Result result = await _restaurantGateway.UpdateRestaurantById( id, model.Name, model.Adresse, model.PhotoLink, model.Telephone);
            return this.CreateResult(result);
        }

        [HttpPost("CreateNewFeedback", Name = "CreateNewFeedback")]
        public async Task<IActionResult> CreateFeedBackRestaurant([FromBody] FeedbackViewModel model)
        {
            Result<int> result = await _restaurantGateway.CreateFeedback(model.Note, model.Feedback, model.CustomerId, model.RestaurantId);
            return this.CreateResult(result, o =>
            {
                o.RouteName = "CreateNewFeedback";
                o.RouteValues = id => new { id };
            });
        }


        [HttpPost("CreateRestaurant/{email}", Name = "CreateRestaurant")]
        public async Task<IActionResult> CreateRestaurant(string email, [FromBody] RestaurantViewModel model)
        {
            UserData user = await _userGateway.FindByEmail(email);
            Result<int> result = await _restaurantGateway.CreateRestaurant( model.Name, model.Adresse, model.PhotoLink, model.Telephone,user.UserId );
            return Ok( this.CreateResult(result, o =>
            {
                o.RouteName = "GetRestaurant";
                o.RouteValues = id => new { id };
            }));
        }
        /*
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            Result result = await _restaurantGateway.Delete(id);
            return this.CreateResult(result);
        }
        */
    }
}