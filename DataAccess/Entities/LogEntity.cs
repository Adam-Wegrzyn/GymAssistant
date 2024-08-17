namespace DataAccess.Entities
{
    public class LogEntity: BaseEntity
    {
        bool IsCompleted { get; set; }
        TimeOnly Duration { get; set; }
    }
}