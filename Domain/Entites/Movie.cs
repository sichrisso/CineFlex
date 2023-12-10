using System.ComponentModel.DataAnnotations;

namespace Domain.Entites;

public class Movie
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Title is required")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Genre is required")]
    public string Genre { get; set; } = string.Empty;

    [Range(1900, 2100, ErrorMessage = "Release year must be between 1900 and 2100")]
    public int ReleaseYear { get; set; }
}