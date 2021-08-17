using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class User
    {
        public int ID { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 4)]
        [RegularExpression(@"([A-Za-z])\w+")]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string pass { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("pass")]
        public string Repass { get; set; }
        [Required]

        public string Address { get; set; }
    }
}