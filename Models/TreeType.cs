using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class TreeType
    {
        public int TreeTypeId { get; set; }
        public string TreeName { get; set; }
        public virtual ICollection<Tree> tree { get; set; }
    }
}