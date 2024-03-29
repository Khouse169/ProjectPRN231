﻿using System.Collections.Generic;
using System.Linq;
using BusinessObject.Models;
using BusinessObject.DTO;
using Microsoft.EntityFrameworkCore;

namespace BusinessObject.DataAccess
{
    public class LibraryDAO
    {
        private readonly ProjectPRN231Context _context;

        public LibraryDAO()
        {
            _context = new ProjectPRN231Context();
        }

        public List<Library> GetAllLibraries()
        {
            var libraries = _context.Libraries.ToList();
            return libraries;
        }

        public Library GetLibraryById(int libraryId)
        {
            var library = _context.Libraries.FirstOrDefault(l => l.LibraryId == libraryId);
            return library;
        }

        public List<Library> GetLibrariesByUserId(int userId)
        {
            var libraries = _context.Libraries.Where(l => l.UserId == userId).ToList();
            return libraries;
        }

        public List<Library> GetLibrariesByStoryId(int storyId)
        {
            var libraries = _context.Libraries.Where(l => l.StoryId == storyId).ToList();
            return libraries;
        }

        public bool AddLibrary(LibraryDTO library)
        {
            var check = _context.Libraries.Where(x => x.UserId == library.UserId && x.StoryId == library.StoryId).ToList();
            if (check == null)
            {
                _context.Libraries.Add(new Library
                {
                    UserId = library.UserId,
                    StoryId = library.StoryId,
                });
                _context.SaveChanges();
                return true;
            }
            else return false;
        }

        public void RemoveLibrary(int libraryId)
        {
            var libraryToRemove = _context.Libraries.Find(libraryId);
            if (libraryToRemove != null)
            {
                _context.Libraries.Remove(libraryToRemove);
                _context.SaveChanges();
            }
        }

        public void RemoveLibrariesByUserId(int userId)
        {
            var librariesToRemove = _context.Libraries.Where(l => l.UserId == userId).ToList();
            if (librariesToRemove.Any())
            {
                _context.Libraries.RemoveRange(librariesToRemove);
                _context.SaveChanges();
            }
        }

        public void RemoveLibrariesByStoryId(int storyId)
        {
            var librariesToRemove = _context.Libraries.Where(l => l.StoryId == storyId).ToList();
            if (librariesToRemove.Any())
            {
                _context.Libraries.RemoveRange(librariesToRemove);
                _context.SaveChanges();
            }
        }
    }
}
