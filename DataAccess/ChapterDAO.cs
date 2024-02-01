using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class ChapterDAO
    {
        private readonly ProjectPRN231Context _context;

        public ChapterDAO()
        {
            _context = new ProjectPRN231Context();
        }

        public List<Chapter> GetAllChapters()
        {
            var chapters = _context.Chapters.ToList();
            return chapters;
        }

        public Chapter GetChapterById(int chapterId)
        {
            var chapter = _context.Chapters.Find(chapterId);
            return chapter;
        }

        public void AddChapter(Chapter chapter)
        {
            _context.Chapters.Add(chapter);
            _context.SaveChanges();
        }

        public void UpdateChapter(Chapter chapter)
        {
            var existingChapter = _context.Chapters.Find(chapter.ChapterId);

            if (existingChapter != null)
            {
                existingChapter.Title = chapter.Title;
                existingChapter.Content = chapter.Content;

                _context.SaveChanges();
            }
        }

        public bool DeleteChapter(int chapterId)
        {
            var chapterToDelete = _context.Chapters.Find(chapterId);

            if (chapterToDelete != null)
            {
                _context.Chapters.Remove(chapterToDelete);
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
