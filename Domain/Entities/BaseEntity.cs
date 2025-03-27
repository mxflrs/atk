using System.ComponentModel.DataAnnotations;
namespace atk_api.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; set; }
    
    [StringLength(200)]
    public required string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}