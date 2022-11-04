using Microsoft.AspNetCore.Mvc;
using MeetBook.Models.Interfaces;
using MeetBook.Models;
using MeetBook.Models.ViewModel;
using Newtonsoft.Json;

namespace MeetBook.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUser userRepo;
        private readonly IAccount accRepo;
        private readonly IPosts postRepo;
        private readonly IFriends friendRepo;
        private readonly IWebHostEnvironment Environment;

        public AdminController(ILogger<HomeController> logger, IUser userRepo, IAccount accRepo, IPosts postRepo, IFriends friendRepo, IWebHostEnvironment environment)
        {
            this.userRepo = userRepo;
            this.accRepo = accRepo;
            this.postRepo = postRepo;
            this.friendRepo = friendRepo;
            Environment = environment;
        }
        public IActionResult Index()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime();
            date2 = date1.AddMonths(-1);
            List<Account> l = accRepo.getAllAccountsOfDuration(date2.ToString("dd/MM/yyyy"));
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Password = l[i].Password.Trim(' ');
                l[i].AccountStatus = l[i].AccountStatus.Trim(' ');
                l[i].ProfilePic = l[i].ProfilePic.Trim(' ');
                if (l[i].Status != null) l[i].Status = l[i].Status.Trim(' ');
                l[i].LoginId = l[i].LoginId.Trim(' ');
            }
            return View("Accounts", l);
        }
        public IActionResult Accounts()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime();
            date2 = date1.AddMonths(-1);            
            List<Account> l = accRepo.getAllAccountsOfDuration(date2.ToString("dd/MM/yyyy"));            
            for (int i = 0; i < l.Count; i++)
            {
                l[i].Password = l[i].Password.Trim(' ');
                l[i].AccountStatus = l[i].AccountStatus.Trim(' ');
                l[i].ProfilePic = l[i].ProfilePic.Trim(' ');
                if (l[i].Status != null) l[i].Status = l[i].Status.Trim(' ');
                l[i].LoginId = l[i].LoginId.Trim(' ');
            }
            return View("Accounts", l);
        }
        public IActionResult RecentPosts()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime();
            date2 = date1.AddMonths(-1);
            List<Post> l = postRepo.getAllPostsOfDuration(date2.ToString("dd/MM/yyyy"));
            for (int i = 0; i < l.Count; i++)
            {
                l[i].PostImage = l[i].PostImage.Trim(' ');
                l[i].CreatedByUserId = l[i].CreatedByUserId.Trim(' ');
                l[i].CreatedDate = l[i].CreatedDate.Trim(' ');
                l[i].LastModifiedUserId = l[i].LastModifiedUserId.Trim(' ');
                l[i].LastModifiedDate = l[i].LastModifiedDate.Trim(' ');
            }
            return View(l);
        }
        public IActionResult RecentActivities()
        {
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime();
            date2 = date1.AddMonths(-1);
            List<PostLike> l = postRepo.getRecentActivitiesOfDuration(date2.ToString("dd/MM/yyyy"));
            for (int i = 0; i < l.Count; i++)
            {
                l[i].CreatedByUserId = l[i].CreatedByUserId.Trim(' ');
                l[i].CreatedDate = l[i].CreatedDate.Trim(' ');
                l[i].LastModifiedUserId = l[i].LastModifiedUserId.Trim(' ');
                l[i].LastModifiedDate = l[i].LastModifiedDate.Trim(' ');
            }
            return View(l);
        }
    }
}