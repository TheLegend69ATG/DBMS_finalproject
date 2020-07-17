using System.Collections.Generic;

namespace FinalProjectWP.Models
{
    public partial class Equipment
    {
        public Equipment()
        {
            Supply = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Quantity { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Supply> Supply { get; set; }
    }
}
