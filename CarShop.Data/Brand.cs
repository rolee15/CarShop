using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShop.Data;

public class Brand
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = default!;

    // Navigational property
    public ICollection<Car> Cars { get; set; }

    public Brand()
    {
        Cars = new HashSet<Car>();
    }
}
