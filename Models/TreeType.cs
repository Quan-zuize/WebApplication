using System.Collections.Generic;

namespace WebApplication2.Models
{
    public class TreeType
    {
        public int TreeTypeId { get; set; }
        public string TreeName { get; set; }
        public virtual ICollection<Tree> tree { get; set; }
    }
}