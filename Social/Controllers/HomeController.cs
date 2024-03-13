using Social.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.Controllers
{
    public class HomeController : Controller
    {
        DBContext db = new DBContext();

        public ActionResult Index()
        {
            if (User.IsInRole("admin"))
            {
                ViewBag.UsersCount = db.Users.Where(u => u.Role != "admin").Count();
                ViewBag.PostsCount = db.Posts.Count();
                ViewBag.CommentsCount = db.Comments.Count();
                ViewBag.LikesCount = db.Likes.Count();
                var MostCommentedPostId = db.Comments.GroupBy(c => c.PostId).Select(c => new {PostId = c.Key, Count = c.Count()}).OrderByDescending(c => c.Count).FirstOrDefault();
                ViewBag.PostMostCommented = db.Posts.Find(MostCommentedPostId.PostId).Contents;
                var MostLikedPostId = db.Likes.GroupBy(l => l.PostId).Select(l => new {PostId = l.Key, Count = l.Count()}).OrderByDescending (l => l.Count).FirstOrDefault();
                ViewBag.PostMostLiked = db.Posts.Find(MostLikedPostId.PostId).Contents;
                //ViewBag.PostMostLiked = 
                return View("IndexAdmin");
            }

            var posts = db.Posts.ToList();
            return View(posts);
        }
    }
}
