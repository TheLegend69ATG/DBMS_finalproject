namespace FinalProjectWP.Models
{
    public partial class Finished
    {
        public int ExpId { get; set; }
        public int? Status { get; set; }

        public virtual Experiment Exp { get; set; }
    }
}
