namespace RunningApplicationAPI.Models.Base
{
    public class BaseEntity : IEntity
    {
        public virtual int Id { get; set; }

        public BaseEntity() { }
    }
}
