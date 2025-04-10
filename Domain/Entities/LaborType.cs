namespace atk_api.Domain.Entities;

public class LaborType: BaseEntity
{
    public string? Description { get; set; }
    public decimal RateMultiplier { get; set; }
    public bool Active { get; set; }
    public ICollection<Labor> Labors { get; set; }
}