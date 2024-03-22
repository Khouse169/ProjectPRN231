using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChapterController : ControllerBase
    {
        private readonly ChapterDAO _chapterDAO;

        public ChapterController()
        {
            _chapterDAO = new ChapterDAO();
        }

        [HttpGet]
        public ActionResult<IEnumerable<Chapter>> GetAllChapters()
        {
            try
            {
                var chapters = _chapterDAO.GetAllChapters();
                return Ok(chapters);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetChapterById/{chapterId}&{storyId}")]
        public ActionResult<Chapter> GetChapterById(int chapterId, int storyId)
        {
            try
            {
                var chapter = _chapterDAO.GetChapterById(chapterId, storyId);
                if (chapter != null)
                    return Ok(chapter);
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public IActionResult AddChapter([FromBody] Chapter chapter)
        {
            try
            {
                _chapterDAO.AddChapter(chapter);
                return CreatedAtAction(nameof(GetChapterById), new { id = chapter.ChapterId }, chapter);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateChapter(int id, [FromBody] Chapter chapter)
        {
            try
            {
                if (id != chapter.ChapterId)
                    return BadRequest("Chapter ID mismatch");

                _chapterDAO.UpdateChapter(chapter);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteChapter(int id)
        {
            try
            {
                var result = _chapterDAO.DeleteChapter(id);
                if (result)
                    return NoContent();
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
