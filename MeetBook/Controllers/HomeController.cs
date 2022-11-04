using MeetBook.Models;
using MeetBook.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MeetBook.Models.Interfaces;

namespace MeetBook.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUser userRepo;
        private readonly IAccount accRepo;
        private readonly IPosts postRepo;
        private readonly IFriends friendRepo;
        private readonly IWebHostEnvironment Environment;

        public HomeController(ILogger<HomeController> logger, IUser userRepo, IAccount accRepo, IPosts postRepo, IFriends friendRepo, IWebHostEnvironment environment)
        {
            _logger = logger;
            this.userRepo = userRepo;
            this.accRepo = accRepo;
            this.postRepo = postRepo;
            this.friendRepo = friendRepo;
            Environment = environment;
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Index()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string email = HttpContext.Session.GetString("email");
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                PostFriend p = home();
                ViewBag.image = acc1.ProfilePic;
                return View("HomePage", p);
            }
            string s = null;
            return View(s);
        }
        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                return RedirectToAction("HomePage");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult Login(string email, string pwd) //login status update krna ha abhi
        {
            if (userRepo.userExist(email))
            {
                User u = userRepo.getUser(email);
                HttpContext.Session.SetInt32("UserId", u.UserId);
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("Phone", u.PhoneNo);
                if (userRepo.validateUser(email, pwd))
                {
                    Account acc = accRepo.getAccountByUserID(u.UserId);
                    ViewBag.image = acc.ProfilePic;
                    accRepo.updateLogIn(u.UserId, 1);
                    HttpContext.Session.SetString("profilePic", acc.ProfilePic);
                    PostFriend p = home();
                    ViewBag.image = acc.ProfilePic;
                    return View("HomePage", p);
                }
                else
                    return RedirectToAction("FailedLogIn");
            }
            else
                return View("Index", "User doesn't exist");
        }
        [HttpGet]
        public IActionResult SignUp()
        {
            string s = null;
            return View(s);
        }
        [HttpPost]
        public IActionResult SignUp(User u, string pwd, string LoginId)
        {
            if (userRepo.userExist(u.Email))  //agar user already ha tw wahin rhy ga
            {
                return View("SignUp", "Email already exists!");
            }
            else //if user already doesn't exist 
            {
                u.Dob = DateOnly.Parse(u.Dob).ToString("MM/dd/yyyy");
                userRepo.insertUser(u);
                int userID = userRepo.getUser(u.Email).UserId;
                HttpContext.Session.SetInt32("UserId", userID);
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("Phone", u.PhoneNo);
                if (userID >= 1)
                {
                    Account acc = new Account
                    {
                        UserId = userID,
                        Password = pwd,
                        //DateCreated = System.DateTime.Now.ToString("MM/dd/yyyy"),
                        AccountStatus = "active",
                        LogIn = 1,
                        ProfilePic = "/Profiles/empty.png",
                        LoginId = LoginId
                    };
                    accRepo.insertAccount(acc);
                    ViewBag.image = acc.ProfilePic;
                    HttpContext.Session.SetString("profilePic", acc.ProfilePic);
                    return RedirectToAction("Profile");

                }
                return View("SignUp", "Error in signing up try later...");

            }
        }
        [HttpGet]
        public IActionResult Profile()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                User u = userRepo.getUser(email);
                ProfileModel p = profileFunc(u, acc);
                ViewBag.image = acc.ProfilePic;
                return View("Profile", p);
            }
            return View("Index");
        }
        private ProfileModel profileFunc(User u, Account acc)
        {
            ProfileModel p = new ProfileModel();
            p.LogInID = acc.LoginId;
            p.UserName = u.Fname + " " + u.Lname;
            p.Status = acc.Status;
            p.posts = postRepo.getPosts(acc.AccountId);
            p.Followers = friendRepo.getFollowers(acc.AccountId);
            p.following = friendRepo.getFollowings(acc.AccountId);
            p.ProfilePic = acc.ProfilePic;
            if (HttpContext.Session.GetString("email") == u.Email)
                p.isLoggedIn = true;
            else
                p.isLoggedIn = false;
            return p;
        }
        [HttpPost]
        public ViewResult ShowProfile(string UserID)
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                Account acc = accRepo.getAccountByUserID(int.Parse(UserID));
                User u = userRepo.getUserById(acc.UserId);
                ProfileModel p = profileFunc(u, acc);
                ViewBag.image = acc1.ProfilePic;
                return View("Profile", p);
            }
            return View("Index");
        }      
        [HttpGet]
        public IActionResult EditProfile()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                User u = userRepo.getUserById((int)userID);
                UserAccount au = new UserAccount();                
                au.account = acc;
                au.user = u;
                ViewBag.image = acc.ProfilePic;
                return View(au);
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult EditProfile(UpdateProfile up)
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                User u = userRepo.getUserById((int)userID);
                u.Gender = up.Gender;
                u.Email = up.Email;
                u.PhoneNo = up.PhoneNo;
                acc.Status = up.Status;
                acc.LoginId = up.LoginId;
                //update function call
                accRepo.updateAccount((int)userID, acc);
                userRepo.updateUser((int)userID, u);
                //update cookies
                HttpContext.Session.SetString("email", u.Email);
                HttpContext.Session.SetString("Phone", u.PhoneNo);
                UserAccount au = new UserAccount();
                au.account = acc;
                au.user = u;
                ViewBag.image = acc.ProfilePic;
                return View(au);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult EditPassword()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                User u = userRepo.getUserById((int)userID);
                UserAccount au = new UserAccount();
                au.account = acc;
                au.user = u;
                ViewBag.image = acc.ProfilePic;
                return View(au);
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult EditPassword(string NewPassword)
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                User u = userRepo.getUserById((int)userID);
                accRepo.updatePassword((int)userID, NewPassword);
                UserAccount au = new UserAccount();
                au.account = acc;
                au.user = u;
                ViewBag.image = acc.ProfilePic;
                return View(au);
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult UploadProfilePicture(IFormFile postedFiles)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Profiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (postedFiles != null)
                {
                    acc.LoginId = acc.LoginId.Trim();
                    var fileName = acc.LoginId + ".png";
                    var pathWithFileName = Path.Combine(path, fileName); 
                    if (System.IO.File.Exists(pathWithFileName))
                        System.IO.File.Delete(pathWithFileName);
                    using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                    {
                        postedFiles.CopyTo(stream);
                        ViewBag.Message = "file uploaded successfully";
                    }
                    acc.ProfilePic = $"/Profiles/{fileName}";
                    accRepo.UploadProfilePic(acc, acc.AccountId);
                }
                return RedirectToAction("EditProfile");
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Followings()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string email = HttpContext.Session.GetString("email");
                int accId = accRepo.getAccountByUserID((int)userID).AccountId;
                List<UserAccount> friends = friendRepo.getFollowings(accId);
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc1.ProfilePic;
                return View(friends);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Followers()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string email = HttpContext.Session.GetString("email");
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                List<UserAccount> friends = friendRepo.getFollowers(acc1.AccountId);
                ViewBag.image = acc1.ProfilePic;
                return View(friends);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult Suggestions()
        {
            if (HttpContext.Session.Keys.Contains("UserId"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                int accId = accRepo.getAccountByUserID((int)userID).AccountId;
                List<FriendList> friends = friendRepo.getfriends(accId);
                List<int> friendsID = new List<int>();
                List<Account> allAcc = accRepo.getAllOtherAccounts(accId);
                List<Account> nonfriendsAcc = new List<Account>();
                foreach (var i in friends)
                {
                    friendsID.Add(i.FriendId);
                }
                foreach (var i in allAcc)
                {
                    if (!friendsID.Contains(i.AccountId))
                        nonfriendsAcc.Add(i);
                }
                User u = new User();
                Account acc = new Account();
                List<UserAccount> nonfriends = new List<UserAccount>();
                for (int i = 0; i < nonfriendsAcc.Count; i++)
                {
                    UserAccount au = new UserAccount();
                    acc = nonfriendsAcc[i];
                    u = userRepo.getUserById(acc.UserId);
                    au.user = u;
                    au.account = acc;
                    nonfriends.Add(au);
                }
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc1.ProfilePic;
                return View("Suggestions", nonfriends);
            }
            return View("Index");
        }
        [HttpGet]
        public IActionResult FailedLogIn()
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                return View("FailedLogIn");
            }
            return View("Index");
        }
        public IActionResult HomePage()
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string email = HttpContext.Session.GetString("email");
                Account acc1 = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc1.ProfilePic;
                PostFriend p = home();
                return View(p);
            }
            return View("Index");
        }
        private PostFriend home()
        {
            int? userID = HttpContext.Session.GetInt32("UserId");
            string email = HttpContext.Session.GetString("email");
            Account acc1 = accRepo.getAccountByUserID((int)userID);
            int accId = acc1.AccountId;
            List<UserAccount> friend = friendRepo.getFollowings(accId);   
            List<PostsModel> postsOfFriends = new List<PostsModel>();
            List<int> friendsID = new List<int>();
            friendsID.Add(accId);
            for (int k = 0; k < friend.Count; k++)
            {
                friendsID.Add(friend[k].account.AccountId);
            }
            List<Post> p = postRepo.getFriendsPosts(friendsID);
            for (int i = 0; i < p.Count; i++)
            {
                Account a = accRepo.getAccountByAccountID(p[i].AccountId);
                User u = userRepo.getUserById(a.UserId);
                UserAccount ac = new UserAccount
                {
                    account = a,
                    user = u
                };
                PostsModel pa = new PostsModel
                {
                    useraccount = ac,
                    post = p[i],
                    isLiked = postRepo.IsLiked(p[i].PostId, accId)
                };
                postsOfFriends.Add(pa);
            }
            PostFriend postfrnd = new PostFriend
            {
                friends = friend,
                posts = postsOfFriends
            };
            return postfrnd;
        }
        [HttpPost]
        public IActionResult UploadNewPost(IFormFile postedFiles)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                List<Post> posts = postRepo.getPosts(acc.AccountId);
                string wwwPath = this.Environment.WebRootPath;
                string path = Path.Combine(wwwPath, "Posts");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                if (postedFiles != null)
                {
                    acc.LoginId = acc.LoginId.Trim();
                    var fileName = "";
                    int n = posts.Count;
                    if (n != 0) 
                        fileName = acc.LoginId + (posts[n - 1].PostId) + 1 + ".png";
                    else
                        fileName = acc.LoginId + "1.png";
                    var pathWithFileName = Path.Combine(path, fileName);
                    if (System.IO.File.Exists(pathWithFileName))
                        System.IO.File.Delete(pathWithFileName);
                    using (FileStream stream = new FileStream(pathWithFileName, FileMode.Create))
                    {
                        postedFiles.CopyTo(stream);
                        ViewBag.Message = "file uploaded successfully";
                    }
                    pathWithFileName = $"/Posts/{fileName}";
                    Post p = new Post
                    {
                        AccountId = acc.AccountId,
                        PostImage = pathWithFileName,
                        PostDate = System.DateTime.Now.ToString("dd/MM/yyyy"),
                        NumberOfLikes = 0
                    };
                    postRepo.UploadPost(p);
                }
                return RedirectToAction("HomePage");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult FailedLogIn(string pwd)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                Account acc = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc.ProfilePic;
                string? EmailPhoneNo = HttpContext.Session.GetString("email");
                if (userRepo.validateUser(EmailPhoneNo, pwd))
                {
                    PostFriend p = home();
                    ViewBag.image = acc.ProfilePic;
                    return View("HomePage", p);
                }
                else
                    return RedirectToAction("FailedLogIn");
            }
            return View("Index");
        }
        public JsonResult emailExist(string email)
        {
            if (userRepo.userEmailExist(email))  //agar user already ha tw wahin rhy ga
            {
                return Json("Email already exists!");
            }
            return Json("");
        }
        public JsonResult PasswordValidate(string password)
        {
            string? email = HttpContext.Session.GetString("email");
            if (!userRepo.validateUser(email ,password))  //agar user already ha tw wahin rhy ga
            {
                return Json("Incorrect Password!");
            }
            return Json("");
        }
        public JsonResult phoneExist(string phone)
        {
            if (userRepo.userPhoneExist(phone))  //agar user already ha tw wahin rhy ga
            {
                return Json("Phone number already exists!");
            }
            return Json("");
        }
        public PartialViewResult SearchpartialView(string searching)
        {
            List<UserAccount> l = userRepo.getUserNames(searching);
            return PartialView("SearchpartialView", l);
        }
        public JsonResult LikePost(int postId)
        {
            int? userID = HttpContext.Session.GetInt32("UserId");
            Account acc = accRepo.getAccountByUserID((int)userID);
            bool flag = postRepo.IsLiked(postId, acc.AccountId);
            int like = 0;
            List<int> data = new List<int>();
            if (flag == false)
            {
                like = postRepo.AddLike(postId, acc.AccountId);
                data.Add(like);
                data.Add(1);
            }
            else
            {
                like = postRepo.RemoveLike(postId, acc.AccountId);
                data.Add(like);
                data.Add(0);
            }
            return Json(data);
        }
        [HttpPost]
        public IActionResult Follow(string ID)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                string? email = HttpContext.Session.GetString("email");
                Account acc = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc.ProfilePic;
                if (ID != null)
                {
                    FriendList f = new FriendList();
                    f.FriendId = int.Parse(ID);
                    f.AccountId = accRepo.getAccountByUserID((int)userID).AccountId;
                    friendRepo.Follow(f);
                }
                return RedirectToAction("Suggestions");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult RemoveFollowing(string ID)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                Account acc = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc.ProfilePic;
                if (ID != null)
                {
                    FriendList f = new FriendList();
                    f.FriendId = int.Parse(ID);
                    f.AccountId = accRepo.getAccountByUserID((int)userID).AccountId;
                    friendRepo.RemoveFollowing(f);
                }
                return RedirectToAction("Followings");
            }
            return View("Index");
        }
        [HttpPost]
        public IActionResult RemoveFollower(string ID)
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                Account acc = accRepo.getAccountByUserID((int)userID);
                ViewBag.image = acc.ProfilePic;
                if (ID != null)
                {
                    FriendList f = new FriendList();
                    f.FriendId = int.Parse(ID);
                    f.AccountId = accRepo.getAccountByUserID((int)userID).AccountId;
                    friendRepo.RemoveFollower(f);
                }
                return RedirectToAction("Followings");
            }
            return View("Index");
        }
        public IActionResult Logout()
        {
            if (HttpContext.Session.Keys.Contains("email"))
            {
                int? userID = HttpContext.Session.GetInt32("UserId");
                accRepo.updateLogIn((int)userID, 0);
                HttpContext.Session.Remove("UserId");
                HttpContext.Session.Remove("email");
                HttpContext.Session.Remove("Phone");
            }
            return View("Index");
        }
    }
}