namespace FinalProjectWP.Models
{
    public partial class LoginInfo
    {
        public string MemId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual MemberInfo Mem { get; set; }
    }
}
