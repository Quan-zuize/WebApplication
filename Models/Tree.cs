using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class Tree
    {
        public int TreeId { get; set; }
        public string TreeType { get; set; }
        public int TreeQuantity { get; set; }
        public virtual TreeType LoaiCays { get; set; }
    }
}