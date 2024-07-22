using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data;

public class Car
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Model { get; set; } = default!;

    public int? Price { get; set; }

    // Navigational property
    [NotMapped]
    public virtual Brand Brand { get; set; } = default!;

    [ForeignKey(nameof(Brand))]
    public int BrandId { get; set; }
}
