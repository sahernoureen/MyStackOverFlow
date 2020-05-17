using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyStackOverFlow.Models
{
    public class Tag
    {
        public Tag()
        {
            this.Question = new HashSet<Question>();
        }
        public int TagId { get; set; }
        public string Title { get; set; }

       

        public virtual ICollection<Question> Question { get; set; }
    }
}