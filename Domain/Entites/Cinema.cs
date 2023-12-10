using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Cinema
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [MaxLength(255, ErrorMessage = "Name can be at most 255 characters long")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Location is required")]
    [MaxLength(255, ErrorMessage = "Location can be at most 255 characters long")]
    public string Location { get; set; } = string.Empty;

    [Required(ErrorMessage = "Phone number is required")]
    [RegularExpression(@"^[0-9]+$", ErrorMessage = "Phone number must consist of digits only")]
    [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be 10 digits long")]
    public string PhoneNo { get; set; } = string.Empty;
}