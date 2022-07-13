using System;
using System.Collections.Generic;

#nullable disable

namespace BookProject.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Status { get; set; }
        public string CmtContent { get; set; }
        public DateTime TimePost { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
