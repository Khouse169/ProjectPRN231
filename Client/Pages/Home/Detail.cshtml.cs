using BusinessObject.DataAccess;
using Clients.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Pages.Home
{
    public class DetailModel : PageModel
    {
        LibraryDAO libraryDAO = new LibraryDAO();
        public void OnGet()
        {
        }

        

    }
}
