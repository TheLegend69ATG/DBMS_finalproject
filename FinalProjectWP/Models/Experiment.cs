using System;
using System.Collections.Generic;

namespace FinalProjectWP.Models
{
    public partial class Experiment
    {
        public Experiment()
        {
            Participation = new HashSet<Participation>();
            Report = new HashSet<Report>();
            Supply = new HashSet<Supply>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LeaderId { get; set; }
        public int? Participants { get; set; }

        public virtual MemberInfo Leader { get; set; }
        public virtual Finished Finished { get; set; }
        public virtual ICollection<Participation> Participation { get; set; }
        public virtual ICollection<Report> Report { get; set; }
        public virtual ICollection<Supply> Supply { get; set; }
    }
}
