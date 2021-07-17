using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TinhToan
    {
        [Required]
        [RegularExpression(@"^\d$")]
        public int a { get; set; }
        [Required]
        [RegularExpression(@"^\d$")]
        public int b { get; set; }
        public string operation { get; set; }
    }
}