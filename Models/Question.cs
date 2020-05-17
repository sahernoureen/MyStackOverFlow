using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStackOverFlow.Models
{
    public class Question
    {
        public Question()
        {
            this.Answers = new HashSet<Answer>();
            this.Comments = new HashSet<QComment>();
            this.Votes = new HashSet<Vote>(); 
            this.Tag = new HashSet<Tag>();

        }

        public int Id { get; set; }
        public string Tilte { get; set; }
        public string Description { get; set; }
        public DateTime Qdate { get; set; }
        public Nullable<int> QVoteCount { get; set; }

        public virtual ICollection<Answer> Answers { get; set; }
        public virtual ICollection<QComment> Comments { get; set; }
        public virtual ICollection<Vote> Votes { get; set; }
        public virtual ICollection<Tag> Tag { get; set; }


       
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

       

    }
}