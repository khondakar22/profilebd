using ProfileLearn.Entities;

namespace ProfileLearn.Dto
{
    public class UserResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public HistoryEntity CreationModificationHistory { get; set; }
    }
}
