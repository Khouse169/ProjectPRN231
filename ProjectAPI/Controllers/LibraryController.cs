using BusinessObject.DataAccess;
using BusinessObject.Models;
using BusinessObject.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly LibraryDAO _libraryDAO;

        public LibraryController()
        {
            _libraryDAO = new LibraryDAO();
        }

        [HttpGet]
        public IActionResult GetAllLibraries()
        {
            var libraries = _libraryDAO.GetAllLibraries();
            return Ok(libraries);
        }

        [HttpGet("{libraryId}")]
        public IActionResult GetLibraryById(int libraryId)
        {
            var library = _libraryDAO.GetLibraryById(libraryId);
            if (library == null)
            {
                return NotFound();
            }
            return Ok(library);
        }

        [HttpGet("user/{userId}")]
        public IActionResult GetLibrariesByUserId(int userId)
        {
            var libraries = _libraryDAO.GetLibrariesByUserId(userId);
            return Ok(libraries);
        }

        [HttpGet("story/{storyId}")]
        public IActionResult GetLibrariesByStoryId(int storyId)
        {
            var libraries = _libraryDAO.GetLibrariesByStoryId(storyId);
            return Ok(libraries);
        }

        [HttpPost("AddLibrary")]
        public IActionResult AddLibrary([FromBody] LibraryDTO library)
        {
            bool check = _libraryDAO.AddLibrary(library);
            return Ok(check ? "Success" : "Fail");
        }

        [HttpDelete("{libraryId}")]
        public IActionResult RemoveLibrary(int libraryId)
        {
            var existingLibrary = _libraryDAO.GetLibraryById(libraryId);
            if (existingLibrary == null)
            {
                return NotFound();
            }
            _libraryDAO.RemoveLibrary(libraryId);
            return Ok();
        }

        [HttpDelete("user/{userId}")]
        public IActionResult RemoveLibrariesByUserId(int userId)
        {
            _libraryDAO.RemoveLibrariesByUserId(userId);
            return Ok();
        }

        [HttpDelete("story/{storyId}")]
        public IActionResult RemoveLibrariesByStoryId(int storyId)
        {
            _libraryDAO.RemoveLibrariesByStoryId(storyId);
            return Ok();
        }
    }
}
