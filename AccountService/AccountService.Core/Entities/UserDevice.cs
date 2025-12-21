namespace AccountService.Core.Entities
{
    public class UserDevice
    {
        public int Id { get; set; }
        public string Device { get; set; }
        public string Browser { get; set; }
        public string Os { get; set; }
        public string Screen { get; set; }
        public string ClientUniqueKey { get; set; }
        public virtual GuestUser GuestUser { get; set; }
        public int? UserId { get; set; }
        public virtual User User { get; set; }
    }
}
