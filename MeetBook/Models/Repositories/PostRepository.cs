using MeetBook.Models.Interfaces;

namespace MeetBook.Models.Repositories
{
    public class PostRepository : IPosts
    {
        public List<Post> getPosts(int AccountId)
        {
            MeetBookContext c = new MeetBookContext();
            List<Post> posts = c.Posts.Where(p => p.AccountId == AccountId).ToList();
            return posts;
        }
        public void UploadPost(Post p)
        {
            MeetBookContext c = new MeetBookContext();
            c.Posts.Add(p);
            c.SaveChanges();
        }
        public List<Post> getFriendsPosts(List<int> friendsID)
        {
            MeetBookContext c = new MeetBookContext();
            List<Post> posts = c.Posts.Where(p => friendsID.Contains(p.AccountId)).ToList();
            return posts;
        }
        public int AddLike(int postId, int AccountId)
        {
            MeetBookContext c = new MeetBookContext();
            List<Post> p = c.Posts.Where(p => p.PostId == postId).ToList();
            p[0].NumberOfLikes++;
            c.SaveChanges();
            PostLike Plike = new PostLike()
            {
                PostId = postId,
                ReactedBy = AccountId
            };
            c.PostLikes.Add(Plike);
            c.SaveChanges();
            return p[0].NumberOfLikes;
        }
        public int RemoveLike(int postId, int AccountId)
        {
            MeetBookContext c = new MeetBookContext();
            List<Post> p = c.Posts.Where(p => p.PostId == postId).ToList();
            p[0].NumberOfLikes--;
            c.SaveChanges();
            PostLike pl = c.PostLikes.First(p => p.PostId == postId && p.ReactedBy == AccountId);
            c.PostLikes.Remove(pl);
            c.SaveChanges();
            return p[0].NumberOfLikes;
        }
        public bool IsLiked(int postId, int AccountId)
        {
            MeetBookContext c = new MeetBookContext();
            return c.PostLikes.Any(p => p.PostId == postId && p.ReactedBy == AccountId);
        }
        public List<Post> getAllPostsOfDuration(string date2)
        {
            MeetBookContext c = new MeetBookContext();
            return c.Posts.Where(a => String.Compare(a.CreatedDate, date2) < 0).ToList();
        }
        public List<PostLike> getRecentActivitiesOfDuration(string date2)
        {
            MeetBookContext c = new MeetBookContext();
            return c.PostLikes.Where(a => String.Compare(a.CreatedDate, date2) < 0).ToList();
        }
    }
}
