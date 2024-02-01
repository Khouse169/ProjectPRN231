using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class GenreDAO
    {
        private readonly ProjectPRN231Context _context;

        public GenreDAO()
        {
            _context = new ProjectPRN231Context();
        }

        public List<Genre> GetAllGenres()
        {
            var genres = _context.Genres.ToList();
            return genres;
        }

        public Genre GetGenreById(int genreId)
        {
            var genre = _context.Genres.Find(genreId);
            return genre;
        }

        public void AddGenre(Genre genre)
        {
            _context.Genres.Add(genre);
            _context.SaveChanges();
        }

        public void UpdateGenre(Genre genre)
        {
            var existingGenre = _context.Genres.Find(genre.GenreId);

            if (existingGenre != null)
            {
                existingGenre.Name = genre.Name;

                _context.SaveChanges();
            }
        }

        public bool DeleteGenre(int genreId)
        {
            var genreToDelete = _context.Genres.Find(genreId);

            if (genreToDelete != null)
            {
                _context.Genres.Remove(genreToDelete);
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
