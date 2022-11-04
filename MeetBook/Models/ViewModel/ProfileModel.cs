namespace MeetBook.Models.ViewModel
{
    public class ProfileModel
    {
        public string LogInID { get; set; }
        public List<UserAccount> Followers { get; set; }
        public List<UserAccount> following { get; set; }
        public string UserName { get; set; }
        public string ProfilePic { get; set; }
        public string Status { get; set; }
        public List<Post> posts { get; set; }
        public bool isLoggedIn { get; set; }
    }
}
