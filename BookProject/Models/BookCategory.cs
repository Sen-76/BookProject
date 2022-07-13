using System;
using System.Collections.Generic;

#nullable disable

namespace BookProject.Models
{
    public partial class BookCategory
    {
        public int BookCateId { get; set; }
        public int BookId { get; set; }
        public int CategoryId { get; set; }

        public virtual Book Book { get; set; }
        public virtual Category Category { get; set; }
    }
}
