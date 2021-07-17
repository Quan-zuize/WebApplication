using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [MinLength(2), MaxLength(150)]
        [Required]
        public string StudentName { get; set; }
        [DataType(DataType.Date)]
        [Required]
        public DateTime StudentDOB { get; set; }
        public virtual ICollection<Exam> Exams { get; set; }
    }
}