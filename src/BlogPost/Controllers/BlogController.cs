using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPost.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using Microsoft.AspNetCore.Http;



namespace BlogPost.Controllers
{
    public class BlogController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View();
        }

        public IActionResult Create(string blogText)
        {

            string userCode = HttpContext.Session.GetString("userCode");
            if (userCode.Length < 5)
            {

            }

            BlogManage blogManage = new BlogManage();
            blogManage.blogText = blogText;
            blogManage.userCode = userCode;
            blogManage.Flag = "insertBlogs";
            DataSet dss = blogManage.blogGetSet(blogManage);

            return RedirectToAction("Index", "Blog");
        }
        public IActionResult CreateComment(string commentText, string blogCode)
        {

            string userCode = HttpContext.Session.GetString("userCode");
            if (userCode.Length < 5)
            {

            }

            BlogManage blogManage = new BlogManage();
            blogManage.commentText = commentText;

            blogManage.blogCode = blogCode;
            blogManage.userCode = userCode;

            blogManage.Flag = "insertComments";
            DataSet dss = blogManage.blogGetSet(blogManage);

            return View();
        }

        public IActionResult LikeDeslike(string commentCode, string  likeDeslike)
        {

            string userCode = HttpContext.Session.GetString("userCode");
            if (userCode==null)
            {
                return Content("userNot");
            }

            BlogManage blogManage = new BlogManage();
            blogManage.commentCode = commentCode;
            blogManage.userCode = userCode;
            blogManage.likeDeslike = likeDeslike;

            blogManage.Flag = "likeDeslike";
            DataSet dss = blogManage.blogGetSet(blogManage);

            return new JsonResult(Utils.getJsonOfDatasetFull(dss));
        }



        //blog view


        public ActionResult BlogView()
        {

            return View();
        }
        public IActionResult AllBlogs()
        {
            BlogManage blogManage = new BlogManage();


            blogManage.Flag = "AllBlogs";
            DataSet dss = blogManage.blogGetSet(blogManage);
            return new JsonResult(Utils.getJsonOfDatasetFull(dss));

        }

        public IActionResult BlogWiseComment(string blogCode)
        {
            BlogManage blogManage = new BlogManage();

            blogManage.blogCode = blogCode;
            blogManage.Flag = "BlogWiseComment";
            DataSet dss = blogManage.blogGetSet(blogManage);
            return new JsonResult(Utils.getJsonOfDatasetFull(dss));

        }

        public Dictionary<string, Report> dataManupulate(DataSet ds)
        {
            Dictionary<string, List<Comments>> myReport = new Dictionary<string, List<Comments>>();
            Dictionary<string, Report> fReport = new Dictionary<string, Report>();
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                DataRow dataTable = ds.Tables[0].Rows[i];

                string key = dataTable[0].ToString();
               

                if (myReport.ContainsKey(key))
                {
                    List<Comments> tempComments = myReport[key];
                    Comments comments = new Comments();
                    comments.blogCode = dataTable[0].ToString();
                    comments.commentCode = dataTable[4].ToString();
                    comments.commentText = dataTable[5].ToString();
                    comments.commenterCode = dataTable[6].ToString();
                    comments.commenterName = dataTable[7].ToString();
                    comments.like = dataTable[8].ToString();
                    comments.dislike = dataTable[9].ToString();

                    tempComments.Add(comments);
                    myReport[key] = tempComments;
                    Report rep = fReport[key];
                    rep.comments = tempComments;
                    fReport[key] = rep;
                }
                else
                {
                    Report rep = new Report();
                    rep.blogCode = dataTable[0].ToString();
                    rep.blogText = dataTable[1].ToString();
                    rep.bloggerCode = dataTable[2].ToString();
                    rep.blogger = dataTable[3].ToString();
                    rep.blogTime = DateTime.Parse(dataTable[10].ToString());
                    List<Comments> tempComments = new List<Comments>();
                    Comments comments = new Comments();
                    comments.blogCode = dataTable[0].ToString();
                    comments.commentCode = dataTable[4].ToString();
                    comments.commentText = dataTable[5].ToString();
                    comments.commenterCode = dataTable[6].ToString();
                    comments.commenterName = dataTable[7].ToString();
                    comments.like = dataTable[8].ToString();
                    comments.dislike = dataTable[9].ToString();
                    comments.commentTime = DateTime.Parse(dataTable[11].ToString());
                    comments.myStatus = dataTable[11].ToString();

                    tempComments.Add(comments);
                    rep.comments = tempComments;
                    fReport[key] = rep;
                    myReport[key] = tempComments;
                }
            }
            return fReport;
        }


        public ActionResult ReportView(string id)
        {
            BlogManage blogManage = new BlogManage();
            blogManage.Flag = "Report";
            blogManage.userCode = id;

            DataSet dss = blogManage.blogGetSet(blogManage);
            Dictionary<string, Report> rep = dataManupulate(dss);
            var val = rep.Keys.ToList();

            List<Report> myReport = new List<Report>();
            foreach (var key in val)
            {
                myReport.Add(rep[key]);
            }

            return View(myReport);
        }

    }
}
