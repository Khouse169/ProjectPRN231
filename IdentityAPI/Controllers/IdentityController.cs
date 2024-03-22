using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using IdentityAPI.Contracts;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        //private IAuthenticationRepository authenticationRepository = new AuthenticationRepository();
        //private IEmployeeRepository employeeRepository = new EmployeeRepository();

        //[HttpPost("Login")]
        //public IActionResult Login([FromBody] TokenGenerationRequest loginDTO)
        //{
        //    var check = authenticationRepository.Login(loginDTO);
        //    return check.Equals("false") ? BadRequest("Wrong email & password") : Ok(check);
        //}

        //[Authorize]
        //[HttpPatch("ChangePassword")]
        //public IActionResult ChangePassword(ChangePasswordReq req)
        //{
        //    string token = HttpContext.Request.Headers["Authorization"];
        //    if (string.IsNullOrEmpty(token)) return BadRequest("Invalid token");
        //    if (token.StartsWith("Bearer "))
        //    {
        //        token = token.Substring("Bearer ".Length).Trim();
        //    }
        //    var empId = UserHelper.GetEmployeeIdFromToken(token);
        //    var checkEmployeeIsFirstLogin = employeeRepository.GetEmployeeById(empId).IsFirstLogin;
        //    if (checkEmployeeIsFirstLogin)
        //        return BadRequest("You don't use this function");
        //    var check = authenticationRepository.ChangePassword(empId, req);
        //    return check ? Ok(check) : BadRequest("Confirm password not march password");
        //}

        //[Authorize]
        //[HttpGet("Profile")]
        //public IActionResult GetProfile()
        //{
        //    string token = Request.Headers["Authorization"];
        //    if (string.IsNullOrEmpty(token))
        //        return BadRequest("Invalid token");
        //    if (token.StartsWith("Bearer "))
        //        token = token.Substring("Bearer ".Length).Trim();
        //    var employeeLogged = authenticationRepository.GetProfile(token);
        //    return Ok(employeeLogged);
        //}
    }
}

