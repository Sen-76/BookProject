using BookProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookProject.Logics
{
    public class UserManager
    {
        BookContext context;
        public UserManager()
        {
            context = new BookContext();
        }
        public User Loged(string Account, string Password)
        {
            return context.Users.Where(x => x.Account == Account && x.Password == Password).FirstOrDefault();
        }
        public User Profile(int UserId)
        {
            return context.Users.Where(x => x.UserId == UserId).FirstOrDefault();
        }
        public List<User> ExistAccount()
        {
            return context.Users.ToList();
        }
        public void AddAccount(string Account, string Password, string RePassword, string Email)
        {
            User a = new User();
            a.Account = Account;
            a.Password = Password;
            a.UserName = Account;
            a.Email = Email;
            a.Status = 1;
            context.Users.Add(a);
            context.SaveChanges();
        }
        public void UpdateAccount(User NewUser)
        {
            //User a = context.Users.FirstOrDefault(x => x.UserId == NewUser.UserId);
            //a.UserName = NewUser.UserName;
            //a.Email = NewUser.Email;
            //a.Avatar = NewUser.Avatar;
            //a.Gender = NewUser.Gender;
            //a.FaceBook = NewUser.FaceBook;
            //a.Address = NewUser.Address;
            //a.DoB = NewUser.DoB;
            context.Users.Update(NewUser);
            context.SaveChanges();
        }
    }
}
