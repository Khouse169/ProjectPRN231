using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
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
            var library = _context.Libraries.Find(libraryId);
            return library;
        }

        public void AddLibrary(Library library)
        {
            _context.Libraries.Add(library);
            _context.SaveChanges();
        }

        public void UpdateLibrary(Library library)
        {
            var existingLibrary = _context.Libraries.Find(library.LibraryId);

            if (existingLibrary != null)
            {
                existingLibrary.UserId = library.UserId;
                existingLibrary.StoryId = library.StoryId;

                _context.SaveChanges();
            }
        }

        public bool DeleteLibrary(int libraryId)
        {
            var libraryToDelete = _context.Libraries.Find(libraryId);

            if (libraryToDelete != null)
            {
                _context.Libraries.Remove(libraryToDelete);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
