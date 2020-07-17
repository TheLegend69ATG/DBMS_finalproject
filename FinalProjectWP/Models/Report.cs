using System;

namespace FinalProjectWP.Models
{
    public partial class Report
    {
        public int Id { get; set; }
        public int? ExpId { get; set; }
        public DateTime? ReportTime { get; set; }
        public string Comment { get; set; }

        public virtual Experiment Exp { get; set; }
    }
}
