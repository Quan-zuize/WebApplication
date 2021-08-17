namespace WebApplication2.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Product")]
    public partial class Product
    {
        [Key]
        [Column(Order = 0)]
        public int productID { get; set; }

        [Column(Order = 1)]
        [Required]
        public string productName { get; set; }

        [Column(Order = 2)]
        [Required]
        public double productPrice { get; set; }

        [Column(Order = 3)]
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        [Display(Name = "Upload File Path")]
        [RegularExpression(@"([a-zA-Z0-9\s_\.-:])+(.png|.jpg|.gif)$", ErrorMessage = "Yêu cầu nhập đúng định dạng ảnh .png|.jpg|.gif")]
        public string productLinkImage { get; set; }

        [StringLength(10)]
        public string productComment { get; set; }
    }
}
