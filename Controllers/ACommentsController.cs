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
    public class ACommentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: AComments
        public ActionResult Index(int? id)
        {
            //var aComments = db.AComments.Include(a => a.Answer).Include(a => a.User);
            var aComments = db.AComments.Where(Ac => Ac.AnswerId == id);
              return View(aComments.ToList());
          
        }

        // GET: AComments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AComment aComment = db.AComments.Find(id);
            if (aComment == null)
            {
                return HttpNotFound();
            }
            return View(aComment);
        }

        // GET: AComments/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: AComments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Description")] AComment aComment, int? id)
        {
            aComment.UserId = this.User.Identity.GetUserId();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            aComment.AnswerId= id;
            aComment.Comdate = DateTime.Now;
            db.AComments.Add(aComment);
            db.SaveChanges();
           
            return RedirectToAction("Details/" , "Questions", new { id = id.ToString(), viewtype = "extended" });
           
        }

        // GET: AComments/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AComment aComment = db.AComments.Find(id);
            if (aComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.AnswerId = new SelectList(db.Answers, "Id", "Description", aComment.AnswerId);
       
            return View(aComment);
        }

        // POST: AComments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Description,Comdate,AnswerId,UserId")] AComment aComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AnswerId = new SelectList(db.Answers, "Id", "Description", aComment.AnswerId);
            ViewBag.UserId = new SelectList(db.ApplicationUsers, "Id", "Email", aComment.UserId);
            return View(aComment);
        }

        // GET: AComments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AComment aComment = db.AComments.Find(id);
            if (aComment == null)
            {
                return HttpNotFound();
            }
            return View(aComment);
        }

        // POST: AComments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AComment aComment = db.AComments.Find(id);
            db.AComments.Remove(aComment);
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
