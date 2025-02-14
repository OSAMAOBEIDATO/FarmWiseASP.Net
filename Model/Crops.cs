using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class Crop
    {
        [Key]
        public Guid CropID { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Crop name is required.")]
        [StringLength(100, ErrorMessage = "Crop name cannot exceed 100 characters.")]
        public string CropName { get; set; }

        [Required(ErrorMessage = "Crop type is required.")]
        public string CropType { get; set; }

        public string Pesticides { get; set; } = string.Empty;  
        public string Fertilizers { get; set; } = string.Empty;

        [Required(ErrorMessage = "Plant date is required.")]
        [DataType(DataType.Date)]
        public DateTime PlantDate { get; set; }

        [Required(ErrorMessage = "Harvest date is required.")]
        [DataType(DataType.Date)]
        public DateTime HarvestDate { get; set; }

        // Foreign Key for User
        [Required]
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public User User { get; set; }

        // Foreign Key for SoilData
        [Required]
        [ForeignKey("SoilData")]
        public Guid SoilDataId { get; set; }
        public SoilData SoilData { get; set; }
    }
}
