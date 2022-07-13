using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookProject.Logics
{
    public class CategoryManager
    {
        BookContext context;
        public CategoryManager()
        {
            context = new BookContext();
        }
        public List<Category> GetCategories()
        {
            return context.Categories.ToList();
        }
        public List<BookCategory> BookCategories(int BookId)
        {
            context.Categories.ToList();
            return context.BookCategories.Where(x => x.BookId == BookId).ToList();
        }
        public void DeleteBookCategories(int BookId)
        {
            List<BookCategory> a = context.BookCategories.Where(x => x.BookId == BookId).ToList();
            foreach (var c in a)
            {
                context.Remove(c);
            }
            context.SaveChanges();
        }
        public void AddBookCategories(int BookId, List<string>Category)
        {
            List<BookCategory> a = context.BookCategories.Where(x => x.BookId == BookId).ToList();
            foreach (var c in a)
            {
                context.Remove(c);
            }
            context.SaveChanges();
            foreach (string s in Category)
            {
                BookCategory b = new BookCategory();
                b.BookId = BookId;
                b.CategoryId = Convert.ToInt32(s);
                context.BookCategories.Add(b);
            }
            context.SaveChanges();
        }
        public void AddCategories4NewBook(List<string> Category)
        {
            var Book = context.Books.OrderByDescending(x => x.BookId).FirstOrDefault();
            foreach (string s in Category)
            {
                BookCategory b = new BookCategory();
                b.BookId = Book.BookId;
                b.CategoryId = Convert.ToInt32(s);
                context.BookCategories.Add(b);
            }
            context.SaveChanges();
        }
    }
}
