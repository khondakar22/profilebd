namespace ProfileLearn.Entities
{
    public class CoreCombineEntity : IBaseEntity, IExternalId
    {
        public int Id { get; set; }
        public byte[] Secret { get; set; }
        public string ExternalId { get; set; }
    }
}
