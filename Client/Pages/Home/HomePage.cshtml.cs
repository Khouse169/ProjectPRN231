using BusinessObject.Models;
using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Home
{
    public class HomePageModel : PageModel
    {
        private readonly StoryDAO _storyDAO;
        private readonly GenreDAO _genreDAO;

        public List<Story> Stories { get; set; }
        public List<Genre> Genres { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int SelectedGenreId { get; set; }

        public string SearchTerm { get; set; }

        public HomePageModel(StoryDAO storyDAO, GenreDAO genreDAO)
        {
            _storyDAO = storyDAO;
            _genreDAO = genreDAO;
        }



        //    public void OnGet(int page1, int genreId)
        //    {
        //        const int ItemsPerPage = 12;

        //        if (page1 < 1)
        //        {
        //            page1 = 1;
        //        }

        //        Genres = _genreDAO.GetAllGenres();

        //        if (genreId != 0)
        //        {
        //            Stories = _storyDAO.GetStoriesByGenrePaged(genreId, page1, ItemsPerPage);
        //            TotalPages = _storyDAO.GetTotalPagesByGenre(genreId, ItemsPerPage);
        //        }
        //        else
        //        {
        //            Stories = _storyDAO.GetAllStoriesPaged(page1, ItemsPerPage);
        //            TotalPages = _storyDAO.GetTotalPages(ItemsPerPage);
        //        }

        //        CurrentPage = page1;
        //        SelectedGenreId = genreId;
        //    }

        //}

        public void OnGet(int page1, int genreId, string searchTerm)
        {
            const int ItemsPerPage = 12;

            if (page1 < 1)
            {
                page1 = 1;
            }

            Genres = _genreDAO.GetAllGenres();

            if (!string.IsNullOrEmpty(searchTerm))
            {
                Stories = _storyDAO.SearchStories(searchTerm, page1, ItemsPerPage);
                TotalPages = _storyDAO.GetTotalPagesForSearch(searchTerm, ItemsPerPage);
            }
            else if (genreId != 0)
            {
                Stories = _storyDAO.GetStoriesByGenrePaged(genreId, page1, ItemsPerPage);
                TotalPages = _storyDAO.GetTotalPagesByGenre(genreId, ItemsPerPage);
            }
            else
            {
                Stories = _storyDAO.GetAllStoriesPaged(page1, ItemsPerPage);
                TotalPages = _storyDAO.GetTotalPages(ItemsPerPage);
            }

            CurrentPage = page1;
            SelectedGenreId = genreId;
            SearchTerm = searchTerm;
        }
    }

}
