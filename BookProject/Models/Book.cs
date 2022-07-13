using System;
using System.Collections.Generic;

#nullable disable

namespace BookProject.Models
{
    public partial class Book
    {
        public Book()
        {
            BookCategories = new HashSet<BookCategory>();
            Chapters = new HashSet<Chapter>();
            Comments = new HashSet<Comment>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public int Status { get; set; }
        public string Author { get; set; }
        public string BookCover { get; set; }
        public string OtherName { get; set; }
        public string Description { get; set; }
        public int? Provider { get; set; }
        public DateTime? TimeProvide { get; set; }

        public virtual User ProviderNavigation { get; set; }
        public virtual ICollection<BookCategory> BookCategories { get; set; }
        public virtual ICollection<Chapter> Chapters { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
