using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public partial class Exam
    {
        [Key]
        public int ExamId { get; set; }
        [Required]
        public int SubjectId { get; set; }
        [Required]
        public int StudentId { get; set; }
        [Range(1, 100)]
        [Required]
        public int Mark { get; set; }
        public virtual Student Students { get; set; }
        public virtual Subject Subjects { get; set; }
    }
}