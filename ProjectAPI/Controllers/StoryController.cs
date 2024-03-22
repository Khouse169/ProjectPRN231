using Microsoft.AspNetCore.Mvc;
using BusinessObject.Models;
using System.Collections.Generic;
using DataAccess;
using Microsoft.AspNetCore.Authorization;


[ApiController]
[Route("[controller]")]
public class StoryController : ControllerBase
{
    private readonly StoryDAO _storyDAO;

    public StoryController()
    {
        _storyDAO = new StoryDAO();
    }

    [HttpGet]
    public ActionResult<IEnumerable<Chapter>> GetAllChapters()
    {
        var stories = _storyDAO.GetAllStories();
        return Ok(stories);
    }

    [HttpGet("GetStoryById/{id}")]
    public ActionResult<Story> GetStoryById(int id)
    {
        var stories = _storyDAO.GetStoryById(id);
        if (stories == null)
        {
            return NotFound();
        }
        return Ok(stories);
    }

    [HttpPost]
    public IActionResult AddStory([FromBody] Story story)
    {
        _storyDAO.AddStory(story);
        return CreatedAtAction(nameof(GetStoryById), new { id = story.StoryId }, story);
    }

    [HttpPut("UpdateStory/{id}")]
    public IActionResult UpdateStory(int id, [FromBody] Story story)
    {
        if (id != story.StoryId)
        {
            return BadRequest();
        }

        _storyDAO.UpdateStory(story);
        return NoContent();
    }

    [HttpDelete("DeleteStory/{id}")]
    public IActionResult DeleteStory(int id)
    {
        var deleted = _storyDAO.DeleteStory(id);
        if (!deleted)
        {
            return NotFound();
        }
        return NoContent();
    }

    [HttpGet("GetListChapterByStory/{id}")]
    public ActionResult<Chapter> GetListChapterByStory(int id)
    {
        var chapter = _storyDAO.GetListChapterByStory(id);
        if (chapter == null)
        {
            return NotFound();
        }
        return Ok(chapter);
    }
}
