using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        [MinLength(1), MaxLength(30)]
        [Required]
        public string SubjectName { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}