using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookProject.Logics
{
    public class BookManager
    {
        BookContext context;
        public BookManager()
        {
            context = new BookContext();
        }
        public List<Book> GetBooks()
        {
            return context.Books.Where(x => x.Status != 5).ToList();
        }
        public List<Book> GetBooks(string BookName, int Index)
        {
            return context.Books.Where(x => x.BookName.Contains(BookName) && x.Status != 5)
                .Skip(Index).Take(20).ToList();
        }
        public int CountBooks(string BookName)
        {
            return context.Books.Where(x => x.BookName.Contains(BookName) && x.Status != 5).Count();
        }
        public List<Book> ProviderBooks(int UserId, string BookName)
        {
            return context.Books.Where(x => x.Provider == UserId && x.Status != 5 
            && x.BookName.Contains(BookName)).ToList();
        }
        public Book OneBook(int BookId)
        {
            return context.Books.Where(x => x.BookId == BookId).FirstOrDefault();
        }
        public void DeleteBooks(int BookId)
        {
            Book a = context.Books.Where(x => x.BookId == BookId).FirstOrDefault();
            a.Status = 5;
            context.SaveChanges();
        }
        public void UpdateBooks(int BookId, int UserId, string BookName, 
            string OtherName, string Author, string Description, string BookCover, int Status)
        {
            Book a = context.Books.Where(x => x.BookId == BookId).FirstOrDefault();
            a.BookName = BookName;
            a.OtherName = OtherName;
            a.Author = Author;
            a.Description = Description;
            a.BookCover = BookCover;
            a.Status = Status;
            context.SaveChanges();
        }
        public void AddBook(string BookName, string OtherName, string Author, string Description, string BookCover, int Provider)
        {
            Book a = new Book();
            a.BookName = BookName;
            a.OtherName = OtherName;
            a.Author = Author;
            a.Description = Description;
            a.BookCover = BookCover;
            a.Status = 1;
            a.Provider = Provider;
            a.TimeProvide = DateTime.Now;
            context.Books.Add(a);
            context.SaveChanges();
        }
    }
    

}
