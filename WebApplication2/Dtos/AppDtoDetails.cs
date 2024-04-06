using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos;

public record class AppDtoDetails(
    int Id,
    [Required][StringLength(50)]string Name,
    int GenreId,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
    );
