using MeetBook.Models.Interfaces;
namespace MeetBook.Models.Repositories
{
    public class AccountRepository : IAccount
    {
        public void insertAccount(Account acc)
        {
            MeetBookContext c = new MeetBookContext();
            c.Accounts.Add(acc);
            c.SaveChanges();
        }
        public Account getAccountByAccountID(int accid)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(acc => acc.AccountId == accid);
            return acc;
        }
        public Account getAccountByUserID(int userid)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(acc => acc.UserId == userid);
            return acc;
        }
        public List<Account> getAllOtherAccounts(int id)
        {
            MeetBookContext c = new MeetBookContext();
            List<Account> fl = c.Accounts.Where(acc => acc.AccountId != id).ToList();
            return fl;
        }
        public void updateLogIn(int userID, int status)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(acc => acc.UserId == userID);
            acc.LogIn = status;
            c.SaveChanges();
        }
        public int getAccountId(string fName, string LName)
        {
            MeetBookContext c = new MeetBookContext();
            int u = c.Users.First(u => u.Fname == fName && u.Lname == LName).UserId;
            return c.Accounts.First(a => a.UserId == u).AccountId;
        }
        public void UploadProfilePic(Account a, int AccID)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(a => a.AccountId == AccID);
            acc.ProfilePic = a.ProfilePic;
            c.SaveChanges();
        }
        public void updateAccount(int userID, Account up)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(a => a.UserId == userID);
            acc.Status = up.Status;
            acc.LoginId = up.LoginId;
            c.SaveChanges();
        }
        public void updatePassword(int userID, string NewPassword)
        {
            MeetBookContext c = new MeetBookContext();
            Account acc = c.Accounts.First(a => a.UserId == userID);
            acc.Password = NewPassword;
            c.SaveChanges();
        }
        public List<Account> getAllAccounts(string datecreated)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Accounts.Where(a => a.CreatedDate == datecreated).ToList();            
        }
        public List<Account> getAllAccountsOfDuration(string date2)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Accounts.Where(a => String.Compare(a.CreatedDate, date2) < 0).ToList();            
        }
    }
}
