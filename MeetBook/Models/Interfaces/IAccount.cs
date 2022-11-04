namespace MeetBook.Models.Interfaces
{
    public interface IAccount
    {
        public void insertAccount(Account acc);
        public Account getAccountByAccountID(int accid);
        public Account getAccountByUserID(int userid);
        public List<Account> getAllOtherAccounts(int id);
        public void updateLogIn(int userID, int status);
        public int getAccountId(string fName, string LName);
        public void UploadProfilePic(Account acc, int AccID);
        public void updateAccount(int userID, Account acc);
        public void updatePassword(int userID, string NewPassword);
        public List<Account> getAllAccounts(string datecreated);
        public List<Account> getAllAccountsOfDuration(string date2);
    }
}
