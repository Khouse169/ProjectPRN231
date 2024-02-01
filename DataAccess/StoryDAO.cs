using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using BusinessObject;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;

public class StoryDAO
{
    private readonly ProjectPRN231Context _context;

    public StoryDAO()
    {
        _context = new ProjectPRN231Context();
    }

    public List<Story> GetAllStories()
    {
        var stories = _context.Stories.Select(s => new Story
        {
            StoryId = s.StoryId,
            Title = s.Title,
            Author = s.Author,
            Description = s.Description,
            CoverImage = s.CoverImage,
            GenreId = s.GenreId,
            IsApproved = s.IsApproved ?? false
        }).ToList();

        return stories;
    }

    public Story GetStoryById(int storyId)
    {
        var story = (from s in _context.Stories
                     join g in _context.Genres on s.GenreId equals g.GenreId
                     where s.StoryId == storyId
                     select new Story
                     {
                         StoryId = s.StoryId,
                         Title = s.Title,
                         Author = s.Author,
                         Description = s.Description,
                         CoverImage = s.CoverImage,
                         GenreId = s.GenreId,
                         //GenreName = g.name, // Thêm GenreName vào DTO
                         IsApproved = s.IsApproved ?? false
                     })
                .FirstOrDefault();

        return story;
    }

    public void AddStory(Story Story)
    {
        Story newStory = new Story
        {
            Title = Story.Title,
            Author = Story.Author,
            Description = Story.Description,
            CoverImage = Story.CoverImage,
            GenreId = Story.GenreId,
            IsApproved = Story.IsApproved
        };

        _context.Stories.Add(newStory);
        _context.SaveChanges();
    }

    public void UpdateStory(Story Story)
    {
        var existingStory = _context.Stories.Find(Story.StoryId);

        if (existingStory != null)
        {
            existingStory.Title = Story.Title;
            existingStory.Author = Story.Author;
            existingStory.Description = Story.Description;
            existingStory.Chapters = Story.Chapters;
            existingStory.GenreId = Story.GenreId;
            existingStory.IsApproved = Story.IsApproved;

            _context.SaveChanges();
        }
    }

    public bool DeleteStory(int storyId)
    {
        var storyToDelete = _context.Stories.Find(storyId);

        if (storyToDelete != null)
        {
            _context.Stories.Remove(storyToDelete);
            _context.SaveChanges();
            return true;
        }
        else
        {
            return false;
        }
    }

    public List<Story> GetStoriesByGenre(int genreId)
    {
        var stories = _context.Stories
            .Where(s => s.GenreId == genreId)
            .ToList();

        return stories;
    }

    public int GetTotalPagesByGenre(int genreId, int itemsPerPage)
    {
        var totalStories = _context.Stories.Count(s => s.GenreId == genreId);
        var totalPages = (int)Math.Ceiling((double)totalStories / itemsPerPage);
        return totalPages;
    }
    public int GetTotalPages(int itemsPerPage)
    {
        var totalStories = _context.Stories.Count();
        var totalPages = (int)Math.Ceiling((double)totalStories / itemsPerPage);
        return totalPages;
    }

    public List<Story> GetStoriesByGenrePaged(int genreId, int page, int itemsPerPage)
    {
        var stories = _context.Stories
            .Where(s => s.GenreId == genreId)
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        return stories;
    }

    public List<Story> GetAllStoriesPaged(int page, int itemsPerPage)
    {
        var stories = _context.Stories
            .Skip((page - 1) * itemsPerPage)
            .Take(itemsPerPage)
            .ToList();

        return stories;
    }

}
