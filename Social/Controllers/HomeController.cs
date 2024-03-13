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

                // { PostId: 52, Count: 20 }
                var MostCommentedPostObj = 
                    db.Comments
                        .GroupBy(c => c.PostId)
                        .Select(c => new {PostId = c.Key, Count = c.Count()})
                        .OrderByDescending(c => c.Count)
                        .FirstOrDefault();
                /*
                 * SELECT PostId, COUNT(*) as Count
                 * FROM Comments
                 * GROUP BY PostId
                 * ORDER BY DESC Count
                 * LIMIT 1
                 * */

                ViewBag.PostMostCommentedComments= MostCommentedPostObj.Count;
                ViewBag.PostMostCommented = db.Posts.Find(MostCommentedPostObj.PostId);

                // { PostId: 52, Count: 20 }
                var MostLikedPostObj =
                    db.Likes
                        .GroupBy(l => l.PostId)
                        .Select(l => new {PostId = l.Key, Count = l.Count()})
                        .OrderByDescending (l => l.Count)
                        .FirstOrDefault();

                ViewBag.PostMostLikedLikes = MostLikedPostObj.Count;
                ViewBag.PostMostLiked = db.Posts.Find(MostLikedPostObj.PostId);

                return View("IndexAdmin");
            }

            var posts = db.Posts.ToList();
            return View(posts);
        }
    }
}
