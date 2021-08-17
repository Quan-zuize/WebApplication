using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Upload
    {
        //image 
        [DataType(DataType.Upload)]
        [Display(Name = "Upload File Image")]
        [Required(ErrorMessage = "Please choose image to upload.")]
        [RegularExpression(@"([a-zA-Z0-9\s\.-:])+(.png|.jpg|.gif)$", ErrorMessage = "yêu cầu đúng định dạng .png|.jpg|.gif")]
        public String Img { get; set; }

        //doc
        [DataType(DataType.Upload)]
        [Required(ErrorMessage = "Please choose file to upload.")]
        [Display(Name = "Upload File")]
        [RegularExpression(@"([a-zA-Z0-9\s\.-:])+(.txt|.doc|.docx|.pdf)$", ErrorMessage = "yêu cầu đúng định dạng .txt|.docx|.pdf|.doc")]
        public String Doc { get; set; }

    }
}