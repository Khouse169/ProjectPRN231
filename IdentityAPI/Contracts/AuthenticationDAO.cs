using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DataAccess;
using BusinessObject.Models;
using BusinessObject.DataAccess;

namespace IdentityAPI.Contracts
{
    public class AuthenticationDAO
    {
        UserDAO userDAO = new UserDAO();
        public string Login(LoginDTO login)
        {
            var user = userDAO.Login(login.Email, login.Password);
            if (user == null) return "false";
            if (user.IsActive != true) return "false";
            string token = CreateToken(user);
            return token;
        }

        public static string CreateToken(User e)
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            var configuration = builder.Build();
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Role,e.Role),
                new Claim("UserId",e.UserId.ToString()),
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JWT:Token").Value!));
            var cread = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: cread
                );
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public bool ChangePassword(int empId, ChangePasswordDTO req)
        {
            var user = userDAO.GetUserById(empId);
            if (!req.Password.Equals(req.ConfirmPassword))
                return false;
            userDAO.UpdateUser(user);
            return true;
        }

        public User GetProfile(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            var idEmployee = claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
            var employeeLogged = userDAO.GetUserById(int.Parse(idEmployee));
            User p = new User
            {
                UserId = employeeLogged.UserId,
                Username = employeeLogged.Username,
                Email = employeeLogged.Email,
                Role = employeeLogged.Role,
            };
            return p;
        }
    }
}
