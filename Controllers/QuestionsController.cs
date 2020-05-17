using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyStackOverFlow.Models;
using PagedList;
using PagedList.Mvc;
using System.Data.Entity.Infrastructure;
using System.Security.Claims;
using Microsoft.AspNet.Identity;
using System.Reflection;

namespace MyStackOverFlow.Controllers
{
    public class QuestionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Questions
        public ActionResult Index(int? page)
        {
            var questions = db.Questions.Include(q => q.User);
            return View(questions.ToList().ToPagedList(page ?? 1, 3));
        }

        // GET: Questions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
    ViewBag.UserId = this.User.Identity.GetUserId();
            return View(question);
        }

        // GET: Questions/Create
        [Authorize]
        public ActionResult Create()
        {

            ViewBag.TagId =  new SelectList(db.Tags, "TagId", "Title" );
            ViewBag.TagId2 = new SelectList(db.Tags, "TagId", "Title");

            return View();
        }

        // POST: Questions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tilte,Description")] Question question, int? TagId, int? TagId2)
        {
            if (TagId == null || TagId2 == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tag tag1 = db.Tags.Find(TagId);
            Tag tag2 = db.Tags.Find(TagId2);

            if (tag1 == null || tag2 == null)
            {
                return HttpNotFound();
            }
           

            question.UserId = this.User.Identity.GetUserId();
            question.QVoteCount = 0;
            question.Tag.Add(tag1);
            question.Tag.Add(tag2);
            question.Qdate = DateTime.Now;
            db.Questions.Add(question);

            tag1.Question.Add(question);
            tag2.Question.Add(question);              
            db.SaveChanges();


            ViewBag.TagId = new SelectList(db.Tags, "TagId", "Title");
            ViewBag.TagId2 = new SelectList(db.Tags, "TagId2", "Title");

            ViewBag.Message = "Your Question Is Posted";
            return RedirectToAction("Create/", "Questions");
             //   return View(question);
        }

        // GET: Questions/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
       //     ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", question.UserId);
            return View(question);
        }

        // POST: Questions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tilte,Description,Qdate,QVoteCount,UserId")] Question question)
        {
            if (ModelState.IsValid)
            {
                db.Entry(question).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
      //      ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", question.UserId);
            return View(question);
        }

        // GET: Questions/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Question question = db.Questions.Find(id);
            if (question == null)
            {
                return HttpNotFound();
            }
            return View(question);
        }

        // POST: Questions/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Question question = db.Questions.Find(id);
            db.Questions.Remove(question);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }


        public ActionResult NewestFirst(int? page)
        {
            string cnnString =
            System.Configuration.ConfigurationManager.ConnectionStrings["MyStackOverFlow"].ConnectionString; // Here is your connection string
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "NewestFirst";
            cnn.Open();

            SqlDataReader o = cmd.ExecuteReader();
            List<Question> ResultQuestions = new List<Question>();
            while (o.Read())
            {
                ResultQuestions.Add(new Question()
                {
                    Id = Convert.ToInt32(o[0]),
                    Tilte = Convert.ToString(o[1]),
                    Description = Convert.ToString(o[2]),
                    Qdate = Convert.ToDateTime(o[3]),
                    QVoteCount = Convert.ToInt32(o[4]),
                    UserId = Convert.ToString(o[5])

                });
            }
            cnn.Close();

            return View(ResultQuestions.ToList().ToPagedList(page ?? 1, 5));

        }


        public ActionResult MostAnsweredFirst(int? page)
        {
            string cnnString =
            System.Configuration.ConfigurationManager.ConnectionStrings["MyStackOverFlow"].ConnectionString; // Here is your connection string
            SqlConnection cnn = new SqlConnection(cnnString);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cnn;
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[MostAnswered]";
            cnn.Open();

            SqlDataReader o = cmd.ExecuteReader();
            List<Question> ResultQuestions = new List<Question>();
            while (o.Read())
            {
                ResultQuestions.Add(new Question()
                {
                    Id = Convert.ToInt32(o[0]),
                    Tilte = Convert.ToString(o[1]),
                    Description = Convert.ToString(o[2]),
                    Qdate = Convert.ToDateTime(o[3]),
                    QVoteCount = Convert.ToInt32(o[4]),
                    UserId = Convert.ToString(o[5])

                }); 
            }
            cnn.Close();

          //  var Questions = db.Questions.OrderByDescending(q => q.Answers.Count()).ToList();

            return View(ResultQuestions.ToPagedList(page ?? 1, 5));
           
        }


        }
}
