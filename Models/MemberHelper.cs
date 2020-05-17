using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;


namespace MyStackOverFlow.Models
{
   
    public static class MemberHelper
    {
       
        static ApplicationDbContext db = new ApplicationDbContext();
        static UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>
            (new UserStore<ApplicationUser>(db));

        static RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>
            (new RoleStore<IdentityRole>(db));
        public static List<string> GetAllRoles()
        {
            return db.Roles.Select(r => r.Name).ToList();
        }
        public static bool CheckIfUserIsInRole(string userId, string role)
        {

            var result = userManager.IsInRole(userId, role);
            return result;
            //Do some Logging for example
        }

        public static void CreateRole(string roleName)
        {
            if (!roleManager.RoleExists(roleName))
            {
                roleManager.Create(new IdentityRole { Name = roleName });
            }
        }

        public static bool AddUserToRole(string userId, string role)
        {
            //First, Check if the user is not already in the role
            if (CheckIfUserIsInRole(userId, role))
            {
                return false; // The user can't be added because he is already in the role
            }
            else
            {
                userManager.AddToRole(userId, role);
                return true;
            }
        }
        public static List<string> GetAllRolesForUser(string userId)
        {
            return userManager.GetRoles(userId).ToList();

        }

        public static List<string> GetAllUsers()
        {
            return db.Users.Select(u => u.Id).ToList();
        }


        public static void CreateQUpVote( int id)
        {
           
            Vote vote = new Vote();
            vote.QuestionId = id;
            vote.UpVote = true;
            db.Votes.Add(vote);

            Question q = db.Questions.Find(id);
            q.QVoteCount++;

            var user = db.Users.FirstOrDefault(u => u.Id == q.UserId);
            user.Reputation += 5;

            db.SaveChanges();
        }


        public static void CreateQDownVote(int id)
        {
            Vote vote = new Vote();
            vote.QuestionId = id;
            vote.DownVote = true;
            db.Votes.Add(vote);

            Question q = db.Questions.Find(id);
            q.QVoteCount--;

            var user = db.Users.FirstOrDefault(u => u.Id == q.UserId);
            user.Reputation -= 5;

            db.SaveChanges();
        }

        public static void CreateAnsUpVote(int ansid)
        {
            Vote vote = new Vote();
            vote.AnswerId = ansid;
            vote.UpVote = true;
            db.Votes.Add(vote);

            Answer ans = db.Answers.Find(ansid);
            ans.AnsVoteCount++;
            var user = db.Users.FirstOrDefault(u => u.Id == ans.UserId);
            user.Reputation += 5;
            db.SaveChanges();
        }


        public static void CreateAnsDownVote(int qid, int ansid)
        {

            Vote vote = new Vote();
            vote.AnswerId = ansid;
            vote.DownVote = true;
            db.Votes.Add(vote);

            Answer ans = db.Answers.Find(ansid);
            ans.AnsVoteCount--;

            var user = db.Users.FirstOrDefault(u => u.Id == ans.UserId);
            user.Reputation -= 5;

            db.SaveChanges();
        }


        public static void AssignBadge(ApplicationUser user)
        {
            if(user.Reputation > 100 && user.Reputation < 500)
                 {
          
                user.Badge = "https://img.icons8.com/bubbles/50/000000/prize.png";
                  }
            else if (user.Reputation  >= 500 && user.Reputation < 1000)
            {
             
                user.Badge = "https://img.icons8.com/color/48/000000/diamond.png";
            }
            else if (user.Reputation >= 1000)
             {
              
                user.Badge = "https://img.icons8.com/office/16/000000/ruby-programming-language.png";


            }
        }

    }
}