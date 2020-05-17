using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MyStackOverFlow.Models;

namespace MyStackOverFlow.Controllers
{
    public class QCommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: QComments
        public ActionResult Index()
        {
            var qComments = db.QComments.Include(q => q.Question).Include(q => q.User);
            return View(qComments.ToList());
        }

        // GET: QComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QComment qComment = db.QComments.Find(id);
            if (qComment == null)
            {
                return HttpNotFound();
            }
            return View(qComment);
        }

        // GET: QComments/Create
        [Authorize]
        public ActionResult Create()
        {
           
            return View();
        }

        // POST: QComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] QComment qComment, int id)
        {
            qComment.UserId = this.User.Identity.GetUserId();
            qComment.QuestionId = id;

                qComment.Comdate = DateTime.Now;
                db.QComments.Add(qComment);
                db.SaveChanges();

            return RedirectToAction("Details/", "Questions", new { id = id.ToString(), viewtype = "extended" });

        }

        // GET: QComments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QComment qComment = db.QComments.Find(id);
            if (qComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Tilte", qComment.QuestionId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", qComment.UserId);
            return View(qComment);
        }

        // POST: QComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Comdate,QuestionId,UserId")] QComment qComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "Id", "Tilte", qComment.QuestionId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", qComment.UserId);
            return View(qComment);
        }

        // GET: QComments/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QComment qComment = db.QComments.Find(id);
            if (qComment == null)
            {
                return HttpNotFound();
            }
            return View(qComment);
        }

        // POST: QComments/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QComment qComment = db.QComments.Find(id);
            db.QComments.Remove(qComment);
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
    }
}
