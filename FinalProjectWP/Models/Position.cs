using System.Collections.Generic;

namespace FinalProjectWP.Models
{
    public partial class Position
    {
        public Position()
        {
            MemberInfo = new HashSet<MemberInfo>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<MemberInfo> MemberInfo { get; set; }
    }
}
