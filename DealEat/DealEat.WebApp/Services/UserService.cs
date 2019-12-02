using System.Threading.Tasks;
using DealEat.DAL;
using DealEat.WebApp;

namespace DealEat.WebApp.Services
{
    public class UserService
    {
        readonly UserGateway _userGateway;
        readonly PasswordHasher _passwordHasher;

        public UserService( UserGateway userGateway, PasswordHasher passwordHasher )
        {
            _userGateway = userGateway;
            _passwordHasher = passwordHasher;
        }

        public Task<Result<int>> CreateUser(string email, string name, string lastname, string pseudo, int tel, string password)
        {
            return _userGateway.CreateUser(email, name, lastname,pseudo, tel, _passwordHasher.HashPassword(password));
        }

        public async Task<UserData> FindUser(string email, string password)
        {
            UserData user = await _userGateway.FindByEmail(email);
            if (user != null && _passwordHasher.VerifyHashedPassword(user.Password, password) == PasswordVerificationResult.Success)
            {
                return user;
            }

            return null;
        }
    }
}
