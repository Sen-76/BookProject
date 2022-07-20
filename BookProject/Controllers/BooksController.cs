using BookProject.Logics;
using BookProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace BookProject.Controllers
{
    public class BooksController : Controller
    {
        public IActionResult Books(string BookName, int Page, string Author, string Category)
        {
            int Index = 0;
            if (BookName == null)
            {
                BookName = "";
            }
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            else
            {
                Index = (Page - 1) * 20;
            }
            BookManager book = new BookManager();
            int MaxPage = 1;
            if (book.CountBooks(BookName, Author) / 20 == 0)
            {
                MaxPage = book.CountBooks(BookName, Author) / 20 + 1;
            }
            if (book.CountBooks(BookName, Author) / 20 != 0)
            {
                MaxPage = book.CountBooks(BookName, Author) / 20 + 1;
            }
            List<Book> topBook = book.GetTop10Books();
            ViewBag.Top = topBook;
            ViewBag.Search = BookName;
            ViewBag.MaxPage = MaxPage;
            ViewBag.Author = Author;
            ViewBag.Page = Page;
            List<Book> lbook = book.GetBooks(BookName, Index, Author, Category);
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.Status = u.Status;
            ViewBag.UserAvatar = u.Avatar;
            string active = HttpContext.Session.GetString("active");
            ViewBag.LeftActive = active; 
            return View(lbook);
        }
        public IActionResult AddBook()
        {
            CategoryManager category = new CategoryManager();
            List<Category> lcate = category.GetCategories();
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.Status = u.Status;
            ViewBag.UserAvatar = u.Avatar;
            List<string> lista = new List<string>();
            ViewBag.Onecate = lista;
            string active = HttpContext.Session.GetString("active");
            ViewBag.LeftActive = active;
            return View(lcate);
        }
        public IActionResult UpdateBook(int BookId)
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            int Id = u.UserId;
            BookManager book = new BookManager();
            Book lbook = book.OneBook(BookId);
            ViewBag.UserId = u.UserId;
            ViewBag.Status = u.Status;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            CategoryManager category = new CategoryManager();
            List<Category> lcate = category.GetCategories();
            List<BookCategory> onecate = category.BookCategories(BookId);
            ViewBag.BookId = lbook.BookId;
            ViewBag.BookName = lbook.BookName;
            ViewBag.OtherName = lbook.OtherName;
            ViewBag.Author = lbook.Author;
            ViewBag.Description = lbook.Description;
            ViewBag.Status = lbook.Status;
            ViewBag.TimeProvide = lbook.TimeProvide;
            ViewBag.Provider = lbook.Provider;
            ViewBag.Id = Id;
            ViewBag.Onecate = onecate;
            ViewBag.Lcate = lcate;
            ViewBag.Checked = "checked";
            string active = HttpContext.Session.GetString("active");
            ViewBag.LeftActive = active;
            return View(lcate);
        }
        public IActionResult DeleteBook(int BookId)
        {
            BookManager book = new BookManager();
            List<Book> lbook = book.GetBooks();
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            ViewBag.UserId = u.UserId;
            ViewBag.Status = u.Status;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            book.DeleteBooks(BookId);
            return RedirectToAction("ProviderBook");
        }
        public IActionResult DoAddBook(string BookName, string OtherName, string Author,
            string Description, string BookCover)
        {
            BookManager book = new BookManager();
            List<Book> lbook = book.GetBooks();
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            int Id = u.UserId;
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.Status = u.Status;
            ViewBag.UserAvatar = u.Avatar;
            foreach (Book b in lbook)
            {
                if (b.BookName.Equals(BookName))
                {
                    CategoryManager category = new CategoryManager();
                    List<Category> lcate = category.GetCategories();
                    ViewBag.BookName = BookName;
                    ViewBag.OtherName = OtherName;
                    ViewBag.Author = Author;
                    ViewBag.Description = Description;
                    ViewBag.BookCover = BookCover;
                    ViewBag.Message = "Tên truyện đã tồn tại.";
                    ViewBag.Theme = "Warning";
                    ViewBag.Title = "Add truyện thất bại";
                    string aa = Request.Form["Categories"];
                    List<string> lista = new List<string>();
                    if (!string.IsNullOrEmpty(aa))
                    {
                        string[] words = aa.Split(',');
                        foreach (string w in words)
                        {
                            lista.Add(w.Trim());
                        }
                    }
                    ViewBag.Onecate = lista;
                    //return RedirectToAction("AddBook");
                    return View("/Views/Books/AddBook.cshtml", lcate);
                }
            }
            book.AddBook(BookName, OtherName, Author, Description, BookCover, Id);
            string a = Request.Form["Categories"];
            CategoryManager cate = new CategoryManager();
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(a))
            {
                string[] words = a.Split(',');
                foreach (string w in words)
                {
                    list.Add(w.Trim());
                }
                cate.AddCategories4NewBook(list);
            }

            return RedirectToAction("ProviderBook");
        }
        public IActionResult AddComment(int BookId, string CommentContent)
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            CommentManager cmt = new CommentManager();
            cmt.AddComment(CommentContent, u.UserId, BookId);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult EditComment(int BookId, int CmtId, string CommentContent)
        {
            CommentManager cmt = new CommentManager();
            cmt.EditComment(CommentContent, CmtId);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public string TestAjax(string BookName, int Page, string Author, string Category)
        {
            int Index = 0;
            if (BookName == null)
            {
                BookName = "";
            }
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            else
            {
                Index = (Page - 1) * 20;
            }
            BookManager book = new BookManager();
            int MaxPage = 1;
            if (book.CountBooks(BookName, Author) / 20 == 0)
            {
                MaxPage = book.CountBooks(BookName, Author) / 20 + 1;
            }
            if (book.CountBooks(BookName, Author) / 20 != 0)
            {
                MaxPage = book.CountBooks(BookName, Author) / 20 + 1;
            }
            List<Book> lbook = book.GetBooks(BookName, Index, Author, Category);
            string a = "";
            a += "<ul>";
            foreach (Book o in lbook)
            {
                a += "<li class=\"slide\">\n"
                       + " <a href =\"/Books/DetailBook?BookId=" + o.BookId + "\" ><img src =\"/image/Enmusubi-full-body.png\" ></a>\n"
                       + " <a href =\"/ Books/DetailBook?BookId=" + o.BookId + "\" >\n"
                       + "     <p> " + o.BookName + " </p>\n"
                       + " </a>\n"
                       + " <a class=\"newestchap\" href=\"#\">Chap</a>\n"
                       + " <ul class=\"ff\">\n"
                       + "     <li class=\"date\">" + o.TimeProvide?.ToString("dd MM yyyy") + " </li> \n"
                       + "     <li class=\"hot\">Hot</li>\n"
                       + " </ul>\n"
                       + " </li>";
            }
            a += "</ul>";
            a += "<div class=\"pagediv\">";
            if (Page > 1)
            {
                a += "<a onclick=\"searchManga(" + (Page - 1) + ")\" class=\"page\" ><ion-icon name=\"skip-backward\" ></ion-icon></a>";
            }
            for (int i = 1; i <= MaxPage; i++)
            {
                a += "<a onclick=\"searchManga(" + i + ")\" class=\"page Page " + (Page == i ? "active" : "") + "\">" + i + "</a>";
            }
            if (Page < MaxPage)
            {
                a += "<a onclick=\"searchManga(" + (Page + 1) + ")\" class=\"page\"><ion-icon name=\"skip-forward\" ></a>";
            }
            a += "</div>";
            return a;
        }
        public IActionResult DeleteComment(int BookId, int CmtId)
        {
            CommentManager cmt = new CommentManager();
            cmt.DeleteComment(CmtId);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult AddChapter(int BookId, string ChapterName)
        {
            ChapterManager chap = new ChapterManager();
            Chapter maxChap = chap.MaxChapter(BookId);
            int maxChaps = 0;
            if (maxChap == null)
            {
                maxChaps = 0;
            }
            else
            {
                maxChaps = maxChap.ChapterNumber;
            }
            if (ChapterName.Length > 100)
            {
                ViewBag.Message = "Tên chapter không được quá 100 ký tự.";
                ViewBag.Theme = "Warning";
                ViewBag.Title = "Add chapter thất bại";
                ViewBag.Text = ChapterName;
                return RedirectToAction("DetailBook", new { BookId = BookId });
            }
            chap.AddChapter(ChapterName, BookId, maxChaps);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult DeleteChapter(int BookId, int ChapterId)
        {
            ChapterManager chap = new ChapterManager();
            chap.DeleteChapter(ChapterId);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult EditChapter(int BookId, int ChapterId, string ChapterName)
        {
            ChapterManager chap = new ChapterManager();
            chap.EditChapter(ChapterId, ChapterName);
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult DoUpdateBook(int BookId, string BookName, string OtherName,
            string Author, string Description, int Status, string BookCover)
        {
            BookManager book = new BookManager();
            List<Book> lbook = book.GetBooks();
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            int Id = u.UserId;
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            book.UpdateBooks(BookId, Id, BookName, OtherName, Author, Description, BookCover, Status);
            string a = Request.Form["Categories"];
            CategoryManager cate = new CategoryManager();
            List<string> list = new List<string>();
            if (!string.IsNullOrEmpty(a))
            {
                string[] words = a.Split(',');
                foreach (string w in words)
                {
                    list.Add(w.Trim());
                }
                cate.AddBookCategories(BookId, list);
            }
            else
            {
                cate.DeleteBookCategories(BookId);
            }
            return RedirectToAction("DetailBook", new { BookId = BookId });
        }
        public IActionResult ProviderBook(string BookName)
        {
            if (BookName == null)
            {
                BookName = "";
            }
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            if(jsonStr != null)
            {
                int Id = u.UserId;
                ViewBag.UserId = u.UserId;
                ViewBag.UserName = u.UserName;
                ViewBag.UserAvatar = u.Avatar;
                BookManager book = new BookManager();
                List<Book> lbook = book.ProviderBooks(Id, BookName);
                string active = HttpContext.Session.GetString("active");
                ViewBag.LeftActive = active;
                return View(lbook);
            }
            else
            {
                return View("/views/home/index.cshtml");
            }
        }
        public IActionResult DetailBook(int BookId, int Page)
        {
            string jsonStr = HttpContext.Session.GetString("user");
            User u;
            if (jsonStr is null) u = new User();
            else u = JsonConvert.DeserializeObject<User>(jsonStr);
            int Id = u.UserId;
            ViewBag.UserId = u.UserId;
            ViewBag.UserName = u.UserName;
            ViewBag.UserAvatar = u.Avatar;
            BookManager book = new BookManager();
            Book lbook = book.OneBook(BookId);
            CategoryManager cate = new CategoryManager();
            List<BookCategory> lcate = cate.BookCategories(BookId);
            ChapterManager chap = new ChapterManager();
            List<Chapter> lchap = chap.BookChapter(BookId);
            CommentManager cmt = new CommentManager();
            UserManager user = new UserManager();
            int Index = 0;
            if (Page == null || Page == 0)
            {
                Page = 1;
            }
            else
            {
                Index = (Page - 1) * 20;
            }
            int MaxPage = 1;
            if (cmt.CountComment(BookId) / 20 == 0)
            {
                MaxPage = cmt.CountComment(BookId) / 20 + 1;
            }
            if (cmt.CountComment(BookId) / 20 != 0)
            {
                MaxPage = cmt.CountComment(BookId) / 20;
            }
            ViewBag.MaxPage = MaxPage;
            ViewBag.Page = Page;
            List<Comment> lcmt = cmt.BookComment(BookId, Index);
            ViewBag.Chap = lchap;
            ViewBag.Comment = lcmt;
            ViewBag.CountChap = lchap.Count;
            User uu = user.Profile(Convert.ToInt32(lbook.Provider));
            ViewBag.Usera = uu;
            ViewBag.BookId = lbook.BookId;
            ViewBag.BookName = lbook.BookName;
            ViewBag.Provider = lbook.Provider;
            ViewBag.OtherName = lbook.OtherName;
            ViewBag.Author = lbook.Author;
            ViewBag.Description = lbook.Description;
            ViewBag.Status = lbook.Status;
            ViewBag.TimeProvide = lbook.TimeProvide;
            string active = HttpContext.Session.GetString("active");
            ViewBag.LeftActive = active;
            return View(lcate);
        }
    }
}
