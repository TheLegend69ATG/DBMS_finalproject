namespace FinalProjectWP.Models
{
    public partial class Participation
    {
        public int Id { get; set; }
        public int? ExpId { get; set; }
        public string MemId { get; set; }

        public virtual Experiment Exp { get; set; }
        public virtual MemberInfo Mem { get; set; }
    }
}
