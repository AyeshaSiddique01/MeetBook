using MeetBook.Models.Interfaces;
using MeetBook.Models.ViewModel;

namespace MeetBook.Models.Repositories
{
    public class FriendsRepository : IFriends
    {
        private readonly IUser userRepo;
        private readonly IAccount accRepo;

        public FriendsRepository(IUser userRepo, IAccount accRepo)
        {
            this.userRepo = userRepo;
            this.accRepo = accRepo;
        }
        public List<FriendList> getfriends(int Accid)
        {
            MeetBookContext c = new MeetBookContext();
            List<FriendList> fl = c.FriendLists.Where(fl => fl.AccountId == Accid).ToList();
            return fl;
        }
        public void Follow(FriendList f)
        {
            MeetBookContext c = new MeetBookContext();
            c.FriendLists.Add(f);
            c.SaveChanges();
        }
        public void RemoveFollowing(FriendList f)
        {
            MeetBookContext c = new MeetBookContext();
            FriendList delF = new FriendList();
            List<FriendList> l = c.FriendLists.Where(fl => (fl.AccountId == f.AccountId && fl.FriendId == f.FriendId)).ToList();
            c.FriendLists.Remove(l[0]);
            c.SaveChanges();
        }
        public void RemoveFollower(FriendList f)
        {
            MeetBookContext c = new MeetBookContext();
            FriendList delF = new FriendList();
            List<FriendList> l = c.FriendLists.Where(fl => (fl.FriendId == f.AccountId && fl.AccountId == f.FriendId)).ToList();
            c.FriendLists.Remove(l[0]);
            c.SaveChanges();
        }
        public List<UserAccount> getFollowings(int AccountId) //friends 
        {
            MeetBookContext c = new MeetBookContext();
            List<FriendList> f = c.FriendLists.Where(fl => fl.AccountId == AccountId).ToList();
            List<UserAccount> friendsAccounts = new List<UserAccount>();
            foreach (var i in f)
            {
                UserAccount au = new UserAccount();                
                au.account = accRepo.getAccountByAccountID(i.FriendId);
                au.user = userRepo.getUserById(au.account.UserId);
                friendsAccounts.Add(au);
            }
            return friendsAccounts;
        }
        public List<UserAccount> getFollowers(int AccountId)
        {
            MeetBookContext c = new MeetBookContext();
            List<FriendList> f = c.FriendLists.Where(fl => fl.FriendId == AccountId).ToList();
            List<UserAccount> friendsAccounts = new List<UserAccount>();
            foreach (var i in f)
            {
                UserAccount au = new UserAccount();
                au.account = accRepo.getAccountByAccountID(i.AccountId);
                au.user = userRepo.getUserById(au.account.UserId);
                friendsAccounts.Add(au);
            }
            return friendsAccounts;
        }
    }
}
