using Social.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Social.Controllers
{
    public class UsersController : Controller
    {
        DBContext db = new DBContext();

        // GET: Users
        [Authorize(Roles ="admin")]
        public ActionResult Index()
        {
            var user = User;
            var users = db.Users.ToList(); // List<User>
            return View(users);
        }
    }
}