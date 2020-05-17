using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using MyStackOverFlow.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyStackOverFlow.Controllers
{
    public class MemberHelperController : Controller
    {
        // GET: MemberHelper
        public ActionResult GetAllRoles()
        {
            var Result = MemberHelper.GetAllRoles().ToList();
            return View(Result);
        }

        //Get
        public ActionResult AddRole()
        {
            var listOfRoles = MemberHelper.GetAllRoles();
            return View(listOfRoles);
        }

        [HttpPost]
        public ActionResult AddRole(string roleName)
        {
            MemberHelper.CreateRole(roleName);
            var listOfRoles = MemberHelper.GetAllRoles();
            return View(listOfRoles);

        }


        public ActionResult AssignRole()
        {
            ViewBag.RoleView = new SelectList(MemberHelper.GetAllRoles().ToList());
            ViewBag.UsersView = new SelectList(MemberHelper.GetAllUsers().ToList());
            return View();

        }

        [HttpPost]
        [Authorize(Roles = "administrator")]
        public ActionResult AssignRole(string UsersView, string RoleView)
        {

            MemberHelper.AddUserToRole(UsersView, RoleView);


            ViewBag.ResultMessage = "Username added to role successfully !";

            ViewBag.UsersView = new SelectList(MemberHelper.GetAllUsers().ToList());
            ViewBag.RoleView = new SelectList(MemberHelper.GetAllRoles().ToList());
            return View();


        }

        public ActionResult CreateQUpVote(int id)
        {
           
            MemberHelper.CreateQUpVote(id);
            return RedirectToAction("Index/", "Questions", new { id = id.ToString(), viewtype = "extended" });
        }


        public ActionResult CreateQDownVote(int id)
        {
            MemberHelper.CreateQDownVote(id);
            return RedirectToAction("Index/", "Questions", new { id = id.ToString(), viewtype = "extended" });
        }

        public ActionResult CreateAnsUpVote(int qid, int? ansid)
        {
            MemberHelper.CreateAnsUpVote((int)ansid);
            return RedirectToAction("Details/", "Questions", new {Id = qid });
        }


        public ActionResult CreateAnsDownVote(int qid, int ansid)
        {
            MemberHelper.CreateAnsDownVote(qid, ansid);
            return RedirectToAction("Details/", "Questions", new { Id = qid });
        }






    }
}