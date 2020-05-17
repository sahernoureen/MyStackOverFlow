using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStackOverFlow.Models
{
    public class AComment
    {
        public int Id { get; set; }
       // public string Tilte { get; set; }
        public string Description { get; set; }
        public DateTime Comdate { get; set; }

        [ForeignKey("Answer")]
        public Nullable<int> AnswerId { get; set; }
        public virtual Answer Answer { get; set; }

        [Required]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}