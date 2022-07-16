using BookProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookProject.Logics
{
    public class CommentManager
    {
        BookContext context;
        public CommentManager()
        {
            context = new BookContext();
        }
        public List<Comment> BookComment(int BookId, int Index)
        {
            context.Users.ToList();
            return context.Comments.Where(x => x.BookId == BookId && x.Status == 1)
                .OrderByDescending(x => x.TimePost).Skip(Index).Take(10).ToList();
        }
        public int CountComment(int BookId)
        {
            return context.Comments.Where(x => x.BookId == BookId && x.Status == 1)
                .OrderByDescending(x => x.TimePost).Count();
        }
        public void DeleteComment(int CmtId)
        {
            Comment a = context.Comments.Where(x => x.CommentId == CmtId).FirstOrDefault();
            a.Status = 0;
            context.SaveChanges();
        }
        public void EditComment(string CmtContent, int CmtId)
        {
            Comment a = context.Comments.Where(x => x.CommentId == CmtId).FirstOrDefault();
            a.CmtContent = CmtContent;
            context.Comments.Update(a);
            context.SaveChanges();
        }
        public void AddComment(string CmtContent, int UserId, int BookId)
        {
            Comment a = new Comment();
            a.TimePost = System.DateTime.Now;
            a.Status = 1;
            a.CmtContent = CmtContent;
            a.BookId = BookId;
            a.UserId = UserId;
            context.Comments.Add(a);
            context.SaveChanges();
        }
    }
}
