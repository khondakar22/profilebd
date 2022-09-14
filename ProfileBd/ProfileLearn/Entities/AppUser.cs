namespace ProfileLearn.Entities
{
    public class AppUser : CoreCombineEntity
    {
        public string UserName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public HistoryEntity HistoryEntity { get; set; }
        public int HistoryEntityId { get; set; }
    }
}
