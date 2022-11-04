namespace MeetBook.Models.Interfaces
{
    public interface IPosts
    {
        public List<Post> getPosts(int AccountId);
        public void UploadPost(Post p);
        public List<Post> getFriendsPosts(List<int> friendsID);
        public int AddLike(int postId, int AccountId);
        public int RemoveLike(int postId, int AccountId);
        public bool IsLiked(int postId, int AccountId);
        public List<Post> getAllPostsOfDuration(string date2);
        public List<PostLike> getRecentActivitiesOfDuration(string date2);
    }
}
