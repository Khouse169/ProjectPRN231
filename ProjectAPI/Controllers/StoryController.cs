using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using System.Collections.Generic;
using DataAccess;

[ApiController]
[Route("[controller]")]
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
        var chapters = _chapterDAO.GetAllChapters();
        return Ok(chapters);
    }

    [HttpGet("{id}")]
    public ActionResult<Chapter> GetChapterById(int id)
    {
        var chapter = _chapterDAO.GetChapterById(id);
        if (chapter == null)
        {
            return NotFound();
        }
        return Ok(chapter);
    }

    [HttpPost]
    public IActionResult AddChapter([FromBody] Chapter chapter)
    {
        _chapterDAO.AddChapter(chapter);
        return CreatedAtAction(nameof(GetChapterById), new { id = chapter.ChapterId }, chapter);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateChapter(int id, [FromBody] Chapter chapter)
    {
        if (id != chapter.ChapterId)
        {
            return BadRequest();
        }

        _chapterDAO.UpdateChapter(chapter);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteChapter(int id)
    {
        var deleted = _chapterDAO.DeleteChapter(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }
}
