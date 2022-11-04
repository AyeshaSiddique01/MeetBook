using MeetBook.Models.ViewModel;

namespace MeetBook.Models.Interfaces
{
    public interface IFriends
    {
        public List<FriendList> getfriends(int Accid);
        public void Follow(FriendList f);
        public void RemoveFollowing(FriendList f);
        public void RemoveFollower(FriendList f);
        public List<UserAccount> getFollowings(int AccountId);
        public List<UserAccount> getFollowers(int AccountId);
    }
}
