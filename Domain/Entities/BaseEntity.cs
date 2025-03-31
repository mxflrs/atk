using System.ComponentModel.DataAnnotations;
using atk_api.Application.Interfaces;
using atk_api.Domain.Interfaces;

namespace atk_api.Domain.Entities;

public abstract class BaseEntity: IEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    
    [StringLength(200)]
    public required string Title { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? ModifiedAt { get; set; }
}