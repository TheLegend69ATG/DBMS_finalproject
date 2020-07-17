using System.Collections.Generic;

namespace FinalProjectWP.Models
{
    public partial class Department
    {
        public Department()
        {
            MemberInfo = new HashSet<MemberInfo>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string LeaderId { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<MemberInfo> MemberInfo { get; set; }
    }
}
