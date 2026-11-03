using Photo_Sharing_Website.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Photo_Sharing_Website.Controllers
{
    public class FollowController : Controller
    {
        private readonly PhotoShareContext db = new PhotoShareContext();

        // POST: Follow/FollowUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult FollowUser(string followerUserName, string followingUserName)
        {
            if (string.IsNullOrWhiteSpace(followerUserName) ||
                string.IsNullOrWhiteSpace(followingUserName))
            {
                return new HttpStatusCodeResult(400, "Thieu username.");
            }

            if (followerUserName == followingUserName)
            {
                TempData["Message"] = "Ban khong the tu theo doi chinh minh.";
                return RedirectToAction("Index", "Profile",
                    new { username = followingUserName });
            }

            bool alreadyFollowing = db.Follows.Any(f =>
                f.FollowerUserName == followerUserName &&
                f.FollowingUserName == followingUserName);

            if (!alreadyFollowing)
            {
                db.Follows.Add(new Follow
                {
                    FollowerUserName = followerUserName,
                    FollowingUserName = followingUserName,
                    CreatedAt = DateTime.Now
                });

                db.SaveChanges();
            }

            return RedirectToAction("Index", "Profile",
                new { username = followingUserName });
        }

        // POST: Follow/UnfollowUser
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UnfollowUser(string followerUserName, string followingUserName)
        {
            if (string.IsNullOrWhiteSpace(followerUserName) ||
                string.IsNullOrWhiteSpace(followingUserName))
            {
                return new HttpStatusCodeResult(400, "Thieu username.");
            }

            var follow = db.Follows.FirstOrDefault(f =>
                f.FollowerUserName == followerUserName &&
                f.FollowingUserName == followingUserName);

            if (follow != null)
            {
                db.Follows.Remove(follow);
                db.SaveChanges();
            }

            return RedirectToAction("Index", "Profile",
                new { username = followingUserName });
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