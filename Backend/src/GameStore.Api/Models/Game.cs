using System;
using System.ComponentModel.DataAnnotations;

namespace GameStore.Api.Models;

public class Game
{
    // Guid for unique identifier
    // Pro: Security
    // Con: Require more space than Integer
    public Guid id { get; set; }

    // ? after string or initialise with string.Empty
    [Required]
    [StringLength(50)]
    public required string name { get; set; }

    [Required]
    [StringLength(20)]
    public required string genre { get; set; }

    // Using float or double might have some accuracys problem
    // Decimal number represented in binary format as a fixed point type (more optimised + precise)
    [Range(1, 500)]
    public decimal price { get; set; }

    // Only interest in date of time
    public DateOnly releaseDate { get; set; }

}
