using Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class SoilData
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string? SoilType { get; set; }

    [Required]
    public string Location { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]  // Allows values like 6.75
    public decimal PHLevel { get; set; }

    [Required]
    [Column(TypeName = "decimal(5,2)")]  // Allows values like 45.50%
    public decimal SoilMoisture { get; set; }

    [Required]
    public ICollection<Crop> Crops { get; set; } = new List<Crop>();
}
