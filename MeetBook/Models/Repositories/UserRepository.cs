using MeetBook.Models.Interfaces;
using MeetBook.Models.ViewModel;

namespace MeetBook.Models.Repositories
{
    public class UserRepository : IUser
    {
        public void insertUser(User u)
        {
            MeetBookContext c = new MeetBookContext();
            //c.Accounts.Add(u);
            c.Users.Add(u);
            c.SaveChanges();
        }
        public User getUser(string EmailPhoneNo)
        {
            MeetBookContext c = new MeetBookContext();
            User u = c.Users.First(u => u.Email == EmailPhoneNo || u.PhoneNo == EmailPhoneNo);
            return u;
        }
        public bool userEmailExist(string Email)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Users.Any(u => u.Email == Email);
        }
        public bool userPhoneExist(string PhoneNo)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Users.Any(u => u.PhoneNo == PhoneNo);
        }
        public bool userExist(string EmailPhoneNo)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Users.Any(u => u.Email == EmailPhoneNo || u.PhoneNo == EmailPhoneNo);
        }
        public bool validateUser(string EmailPhoneNo, string pwd)
        {
            MeetBookContext c = new MeetBookContext();
            User u = c.Users.First(u => u.Email == EmailPhoneNo || u.PhoneNo == EmailPhoneNo);
            return c.Accounts.Any(acc => acc.UserId == u.UserId && acc.Password == pwd);
        }
        public User getUserById(int userid)
        {
            MeetBookContext c = new MeetBookContext();
            User u = c.Users.First(u => u.UserId == userid);
            return u;
        }
        public List<UserAccount> getUserNames(string searching)
        {
            MeetBookContext c = new MeetBookContext();
            List<User> user = c.Users.Where(u => u.Fname.StartsWith(searching)).ToList();
            List<Account> account = new List<Account>();
            List<UserAccount> au = new List<UserAccount>();
            foreach (var u in user)
            {
                UserAccount ac = new UserAccount();
                Account a = c.Accounts.First(ur => ur.UserId == u.UserId);
                ac.user = u;
                ac.account = a;
                au.Add(ac);
            }
            return au;
        }
        public void updateUser(int userID, User u)
        {
            MeetBookContext c = new MeetBookContext();
            User user = c.Users.First(user => user.UserId == userID);
            user.Gender = u.Gender;
            user.Email = u.Email;
            user.PhoneNo = u.PhoneNo;
            c.SaveChanges();
        }
        public List<User> getAllUsers()
        {
            MeetBookContext c = new MeetBookContext();
            return c.Users.ToList();
        }

        public List<User> getSearchedUserNames(string searching)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Users.Where(u => u.Fname == searching).ToList();
        }
    }
}
