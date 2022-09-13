namespace ProfileLearn.Entities
{
    public interface IBaseEntity
    {
        public int Id { get; set; }
        public byte[] Secret { get; set; }
    }
}
