using System.ComponentModel.DataAnnotations;
using LearnApiTraining2025_1.Server.Domain;

namespace LearnApiTraining2025_1.Server.Models;

public class MealLog
{
    public int Id { get; set; }

    [Required]
    public DateTime MealTime { get; set; }

    [Required]
    [MaxLength(20)]
    public MealType MealType { get; set; }
    // Breakfast | Lunch | Dinner | Snack

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 5000)]
    public int Calories { get; set; }
}
