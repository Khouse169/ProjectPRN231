using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CommentDAO
    {
        private readonly ProjectPRN231Context _context;

        public CommentDAO()
        {
            _context = new ProjectPRN231Context();
        }

        public List<Comment> GetAllComments()
        {
            var comments = _context.Comments.ToList();
            return comments;
        }

        public Comment GetCommentById(int commentId)
        {
            var comment = _context.Comments.Find(commentId);
            return comment;
        }

        public void AddComment(Comment comment)
        {
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void UpdateComment(string comment, int commentId)
        {
            var existingComment = _context.Comments.Where(c => c.CommentId == commentId).FirstOrDefault();

            if (existingComment != null)
            {
                existingComment.CommentText = comment;

                _context.SaveChanges();
            }
        }

        public bool DeleteComment(int commentId)
        {
            var commentToDelete = _context.Comments.Find(commentId);

            if (commentToDelete != null)
            {
                _context.Comments.Remove(commentToDelete);
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
