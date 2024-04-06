using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos;

public record class CreateDto(
    [Required][StringLength(50)]string Name,
    int GenreId,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
    );
