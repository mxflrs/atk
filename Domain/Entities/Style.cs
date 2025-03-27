using System.ComponentModel.DataAnnotations;

namespace atk_api.Domain.Entities;

public class Style : BaseEntity
{
    [StringLength(200)]
    public string? Icon { get; set; }
}