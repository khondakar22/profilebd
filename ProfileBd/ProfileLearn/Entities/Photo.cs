using System.ComponentModel.DataAnnotations.Schema;

namespace ProfileLearn.Entities
{
    [Table("Photos")]
    public class Photo : CoreCombineEntity
    {
        public string Url { get; set; }
        public bool IsMain { get; set; }
        public string PublicId{ get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
    }
}
