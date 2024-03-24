using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using BusinessObject.Models;
using BusinessObject.DTO;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.DataAccess
{
    public class UserDAO
    {
        private readonly ProjectPRN231Context _context;

        public UserDAO()
        {
            _context = new ProjectPRN231Context();
        }

        public User Login(string email, string password)
        {
            User emp = _context.Users.Where(e => e.Email == email && e.Password == password).FirstOrDefault();
            if (emp == null) return null;
            return emp;
        }

        public List<User> GetAllUsers()
        {
            var users = _context.Users.ToList();
            return users;
        }

        public User GetUserById(int userId)
        {
            var _context = new ProjectPRN231Context();
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            var _context = new ProjectPRN231Context();
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            return user;
        }

        public void AddUser(UserDTO user)
        {
            var _context = new ProjectPRN231Context();
            _context.Users.Add(new User
            {
                FullName = user.FullName,
                Email = user.Email,
                Password = user.Password,
                Balance = user.Balance,
                IsActive = true,
                Role = "user",
                Username = user.Username,
            });
            _context.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var _context = new ProjectPRN231Context();
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public bool DeleteUser(int userId)
        {
            var _context = new ProjectPRN231Context();
            var userToDelete = _context.Users.Find(userId);

            if (userToDelete != null)
            {
                userToDelete.IsActive = false;
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
        public static int GetEmployeeIdFromToken(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            var jwtToken = handler.ReadJwtToken(token);
            var claims = jwtToken.Claims;
            var idEmployee = claims.FirstOrDefault(c => c.Type == "UserID")?.Value;
            return int.Parse(idEmployee);
        }
    }
}
