namespace FinalProjectWP.Models
{
    public partial class Supply
    {
        public int Id { get; set; }
        public int? ExpId { get; set; }
        public int? EqmId { get; set; }
        public int? Quantity { get; set; }

        public virtual Equipment Eqm { get; set; }
        public virtual Experiment Exp { get; set; }
    }
}
