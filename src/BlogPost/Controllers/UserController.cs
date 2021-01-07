using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogPost.Controllers
{
    public class UserController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create(string name)
        {
            User user = new User();
            user.name = name;
            user.flag = "insert";
            return RedirectToAction("Index", "User");
        }
        public IActionResult SingIn(string name)
        {
            User user = new User();
            user.name = name;
            user.flag = "isAvailable";
            DataSet dss = user.userGetSet(user);

            DataRow dataTable = dss.Tables[0].Rows[0];

            HttpContext.Session.SetString("userCode", dataTable[1].ToString());
            return RedirectToAction("Index", "Blog");
        }

    }
}
