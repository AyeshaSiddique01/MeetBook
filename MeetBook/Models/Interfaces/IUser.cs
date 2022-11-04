using MeetBook.Models.ViewModel;
namespace MeetBook.Models.Interfaces
{
    public interface IUser
    {
        public void insertUser(User u);
        public User getUser(string EmailPhoneNo);
        public bool userEmailExist(string Email);
        public bool userPhoneExist(string PhoneNo);
        public bool userExist(string EmailPhoneNo);
        public bool validateUser(string EmailPhoneNo, string pwd);
        public User getUserById(int userid);
        public List<UserAccount> getUserNames(string searching);
        public List<User> getSearchedUserNames(string searching);
        public void updateUser(int userID, User u);
        public List<User> getAllUsers();

    }
}
