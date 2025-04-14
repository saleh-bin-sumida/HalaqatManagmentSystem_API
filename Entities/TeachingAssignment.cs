namespace HalaqatManagmentSystem_API.Entities;

public class TeachingAssignment
{
    public int Id { get; set; }
    public Guid TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public int HalaqaId { get; set; }
    public Halaqa Halaqa { get; set; }
    public DateTime StartDate { get; set; } = DateTime.Now;
    public DateTime? EndDate { get; set; }
    public bool IsCurrent { get; set; }

}
