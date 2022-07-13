using System;
using System.Collections.Generic;

#nullable disable

namespace BookProject.Models
{
    public partial class Chapter
    {
        public int ChapterId { get; set; }
        public int BookId { get; set; }
        public int ChapterNumber { get; set; }
        public string ChapterName { get; set; }
        public DateTime TimeUpdate { get; set; }

        public virtual Book Book { get; set; }
    }
}
