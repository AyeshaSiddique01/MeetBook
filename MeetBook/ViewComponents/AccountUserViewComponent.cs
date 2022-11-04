using Microsoft.AspNetCore.Mvc;
using MeetBook.Models;
using MeetBook.Models.Interfaces;
using MeetBook.Models.ViewModel;
namespace MeetBook.ViewComponents
{
    public class AccountUserViewComponent: ViewComponent
    {
        private readonly IUser userRepo;
        private readonly IAccount accRepo;

        public AccountUserViewComponent(IUser userRepo, IAccount accRepo)
        {
            this.userRepo = userRepo;
            this.accRepo = accRepo;
        }
        public IViewComponentResult Invoke()
        {
            string EmailPhoneNo = HttpContext.Session.GetString("email");
            User u = userRepo.getUser(EmailPhoneNo);
            Account a = accRepo.getAccountByUserID(u.UserId);
            UserAccount au = new UserAccount
            {
                user = u,
                account = a
            };
            return View(au);
        }

    }
}
