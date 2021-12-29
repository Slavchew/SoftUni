using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ratings.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DrawRating(int rating)
        {
            ViewBag.Rating = rating;
            //Rating [0...100]

            var allStars = 10;
            var fullStars = rating * allStars / 100;
            var emptyStars = (100 - rating) * allStars /100;
            var halfStars = allStars - fullStars - emptyStars;

            var stars = "";
            for (int i = 0; i < fullStars; i++)
            {
                stars += "<img src='/images/full-star.png'/>";
            }
            for (int i = 0; i < halfStars; i++)
            {
                stars += "<img src='/images/half-star.png'/>";
            }
            for (int i = 0; i < emptyStars; i++)
            {
                stars += "<img src='/images/empty-star.png'/>";
            }
            ViewBag.Stars = stars;

            return View("Index");
        }
    }
}