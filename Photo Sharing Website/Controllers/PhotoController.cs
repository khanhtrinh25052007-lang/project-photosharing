using Photo_Sharing_Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Photo_Sharing_Website.Controllers
{
    public class PhotoController : Controller
    {
        private PhotoShareContext db = new PhotoShareContext();

        public ActionResult Index()
        {
            var photos = db.Photos
                           .OrderByDescending(p => p.PhotoId)
                           .ToList();

            return View(photos);
        }
    }
}