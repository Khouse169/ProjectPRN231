using BusinessObject.DataAccess;
using IdentityAPI.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        AuthenticationDAO authenticationDAO = new AuthenticationDAO();
        [HttpPost("Login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var check = authenticationDAO.Login(loginDTO);
            return check.Equals("false") ? BadRequest("Wrong email & password") : Ok(check);
        }

        [Authorize]
        [HttpPatch("ChangePassword")]
        public IActionResult ChangePassword(ChangePasswordDTO req)
        {
            string token = HttpContext.Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token)) return BadRequest("Invalid token");
            if (token.StartsWith("Bearer "))
            {
                token = token.Substring("Bearer ".Length).Trim();
            }
            var empId = UserDAO.GetEmployeeIdFromToken(token);
            var check = authenticationDAO.ChangePassword(empId, req);
            return check ? Ok(check) : BadRequest("Confirm password not march password");
        }

        [Authorize]
        [HttpGet("Profile")]
        public IActionResult GetProfile()
        {
            string token = Request.Headers["Authorization"];
            if (string.IsNullOrEmpty(token))
                return BadRequest("Invalid token");
            if (token.StartsWith("Bearer "))
                token = token.Substring("Bearer ".Length).Trim();
            var employeeLogged = authenticationDAO.GetProfile(token);
            return Ok(employeeLogged);
        }
    }
}
