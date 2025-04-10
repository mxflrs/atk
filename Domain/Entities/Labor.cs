namespace atk_api.Domain.Entities;

public class Labor : BaseEntity
{
    public int Hours { get; set; }
    public int BaseHourRate { get; set; }
    public decimal Rate { get; set; }
    public Guid TypeId { get; set; }
    public LaborType Type { get; set; }
}