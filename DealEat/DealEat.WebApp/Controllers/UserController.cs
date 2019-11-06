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
    public class UserController : Controller
    {
        readonly UserGateway userGateway;

        public UserController(UserGateway userGateway)
        {
            _userGateway = userGateway;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserList()
        {
            IEnumerable<UserData> result = await _userGateway.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetUser")]
        public async Task<IActionResult> GetUserById(int id)
        {
            Result<UserData> result = await _userGateway.FindById(id);
            return this.CreateResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserViewModel model)
        {
            Result<int> result = await _userGateway.Create(/* METTRE LES MODELS ex : model.Name*/);
            return this.CreateResult(result, o =>
            {
                o.RouteName = "GetUser";
                o.RouteValues = id => new { id };
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            Result result = await _userGateway.Delete(id);
            return this.CreateResult(result);
        }
    }
}
