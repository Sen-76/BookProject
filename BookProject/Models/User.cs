using System;
using System.Collections.Generic;

#nullable disable

namespace BookProject.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            Comments = new HashSet<Comment>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public int Status { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FaceBook { get; set; }
        public int? Gender { get; set; }
        public string Address { get; set; }
        public DateTime? DoB { get; set; }
        public string Avatar { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
