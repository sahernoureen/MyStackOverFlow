using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStackOverFlow.Models
{
    public class Vote
    {
        public Vote()
        {
            this.UpVote = false;
            this.DownVote = false;
          
        }
        public int Id { get; set; }
        public bool UpVote { get; set; }
        public bool DownVote { get; set; }

        [ForeignKey("Question")]
        public Nullable<int> QuestionId { get; set; }
        public virtual Question Question { get; set; }

        [ForeignKey("Answer")]
        public Nullable<int> AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

       
    }
}