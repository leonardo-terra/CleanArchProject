namespace Domain.Entities
{
    public abstract class EntityBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime UpdatedDate { get;protected set; }
    }
}
