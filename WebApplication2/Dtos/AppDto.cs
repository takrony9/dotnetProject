using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Dtos;

public record class AppDto(
    int Id,
    [Required][StringLength(50)]string Name,
    [Required][StringLength(20)]string Genre,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate
    );
