using BookProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookProject.Logics
{
    public class ChapterManager
    {
        BookContext context;
        public ChapterManager()
        {
            context = new BookContext();
        }
        public List<Chapter> BookChapter(int BookId)
        {
            return context.Chapters.Where(x => x.BookId == BookId).OrderByDescending(x => x.ChapterNumber).ToList();
        }
        public Chapter MaxChapter(int BookId)
        {
            return context.Chapters.Where(x => x.BookId == BookId).OrderByDescending(x => x.ChapterNumber).FirstOrDefault();
        }
        public void AddChapter(string ChapterName, int BookId, int MaxChap)
        {
            Chapter a = new Chapter();
            a.TimeUpdate = DateTime.Now;
            a.BookId = BookId;
            a.ChapterName = ChapterName;
            a.ChapterNumber = MaxChap + 1;
            context.Chapters.Add(a);
            context.SaveChanges();
        }
        public void DeleteChapter(int ChapterId)
        {
            Chapter a = context.Chapters.Where(x => x.ChapterId == ChapterId).FirstOrDefault();
            context.Chapters.Remove(a);
            context.SaveChanges();
        }
        public void EditChapter(int ChapterId, string ChapterName)
        {
            Chapter a = context.Chapters.Where(x => x.ChapterId == ChapterId).FirstOrDefault();
            a.ChapterName = ChapterName;
            context.Chapters.Update(a);
            context.SaveChanges();
        }
    }
}
