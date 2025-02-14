using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Name must be between 1 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "Email must be between 1 and 50 characters.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Location must be between 1 and 100 characters.")]
        public string Location { get; set; }

        [Required(ErrorMessage = "Profile Picture is required.")]
        public string PictureProfile { get; set; }

        public ICollection<Crop> Crops { get; set; }
    }
}
