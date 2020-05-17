using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStackOverFlow.Models
{
    public class Answer
    {
        public Answer()
        {
            this.Comments = new HashSet<AComment>();
            this.Votes = new HashSet<Vote>();
        }

        public int Id { get; set; }

        public string Description { get; set; }
        public DateTime Ansdate { get; set; }
        public Nullable<int> AnsVoteCount { get; set; }


        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [ForeignKey("Question")]
        public int? QuestionId { get; set; }
        public virtual Question Question { get; set; }

        public virtual ICollection<AComment> Comments { get; set; }    
        public virtual ICollection<Vote> Votes { get; set; }



    }
}