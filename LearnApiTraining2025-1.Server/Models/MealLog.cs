using LearnApiTraining2025_1.Server.Domain;
using System.ComponentModel.DataAnnotations;

namespace LearnApiTraining2025_1.Server.Models;

public class MealLog
{
    [Key]
    public int Id { get; set; }

    [Required]
    public DateTime MealTime { get; set; }

    [Required]
    public MealType MealType { get; set; }

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 5000)]
    public int Calories { get; set; }
}
