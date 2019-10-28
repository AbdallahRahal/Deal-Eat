using System;
using System.Threading.Tasks;
using ITI.PrimarySchool.DAL;
using ITI.PrimarySchool.WebApp.Models;
using ITI.PrimarySchool.WebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ITI.PrimarySchool.WebApp.Controllers
{
    public class AuthenticationController : Controller
    {
        readonly AuthenticationGateway _authenticationGateway;
        readonly PasswordHasher _passwordHasher;
        readonly TokenService _tokenService;

        public AuthenticationController(AuthenticationGateway authenticationGateway, PasswordHasher passwordHasher, TokenService tokenService)
        {
            if (authenticationGateway == null) throw new ArgumentNullException(nameof(authenticationGateway));
            if (passwordHasher == null) throw new ArgumentNullException(nameof(passwordHasher));
            if (tokenService == null) throw new ArgumentNullException(nameof(tokenService));

            _authenticationGateway = authenticationGateway;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async  Task<IActionResult> Authenticate(AuthenticationModel model)
        {
            UserData user = await _authenticationGateway.FindUser(model.Email);
            if (user == null) return View("Index", model);

            var result = _passwordHasher.VerifyHashedPassword(user.Password, model.Password);
            if( result == PasswordVerificationResult.Failed ) return View("Index", model);

            Token token = _tokenService.GenerateToken(user.UserId.ToString());
            return View("Authenticate", token.AccessToken);
        }
    }
}
