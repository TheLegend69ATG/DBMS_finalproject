using System.Collections.Generic;

namespace FinalProjectWP.Models
{
    public partial class MemberInfo
    {
        public MemberInfo()
        {
            Experiment = new HashSet<Experiment>();
            Participation = new HashSet<Participation>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public int? PosId { get; set; }
        public string DepId { get; set; }
        public int? Birthyear { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Gender { get; set; }
        public double? Salary { get; set; }
        public byte[] ProfilePic { get; set; }

        public virtual Department Dep { get; set; }
        public virtual Position Pos { get; set; }
        public virtual LoginInfo LoginInfo { get; set; }
        public virtual ICollection<Experiment> Experiment { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
    }
}
