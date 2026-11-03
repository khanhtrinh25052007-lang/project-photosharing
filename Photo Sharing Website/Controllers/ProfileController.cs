using Photo_Sharing_Website.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Photo_Sharing_Website.Controllers
{
    public class ProfileController : Controller
    {
        private readonly PhotoShareContext db = new PhotoShareContext();

        // GET: Profile/Index
        public ActionResult Index(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new HttpStatusCodeResult(400, "Thieu username.");
            }

            var profile = db.UserProfiles
                .FirstOrDefault(p => p.UserName == username);

            if (profile == null)
            {
                profile = new UserProfile
                {
                    UserName = username,
                    DisplayName = username,
                    Bio = ""
                };
            }

            // Tai khoan thu nghiem, chua co dang nhap
            string currentUser = "alice";

            ViewBag.CurrentUser = currentUser;

            ViewBag.PhotoCount = db.Photos.Count(
                p => p.UserName == username
            );

            ViewBag.FollowerCount = db.Follows.Count(
                f => f.FollowingUserName == username
            );

            ViewBag.FollowingCount = db.Follows.Count(
                f => f.FollowerUserName == username
            );

            ViewBag.Photos = db.Photos
                .Where(p => p.UserName == username)
                .OrderByDescending(p => p.PhotoId)
                .ToList();

            ViewBag.IsFollowing = db.Follows.Any(f =>
                f.FollowerUserName == currentUser &&
                f.FollowingUserName == username
            );

            ViewBag.Message = TempData["Message"];

            return View(profile);
        }

        // GET: Profile/Following
        public ActionResult Following(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new HttpStatusCodeResult(400, "Thieu username.");
            }

            var users = db.Follows
                .Where(f => f.FollowerUserName == username)
                .Select(f => f.FollowingUserName)
                .ToList();

            ViewBag.Username = username;

            return View(users);
        }

        // GET: Profile/Followers
        public ActionResult Followers(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return new HttpStatusCodeResult(400, "Thieu username.");
            }

            var users = db.Follows
                .Where(f => f.FollowingUserName == username)
                .Select(f => f.FollowerUserName)
                .ToList();

            ViewBag.Username = username;

            return View(users);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}