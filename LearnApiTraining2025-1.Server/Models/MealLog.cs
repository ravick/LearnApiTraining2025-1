using System.ComponentModel.DataAnnotations;

namespace LearnApiTraining2025_1.Server.Models;

public class MealLog
{
    public int Id { get; set; }

    [Required]
    public DateTime MealTime { get; set; }

    [Required]
    [MaxLength(20)]
    public string MealType { get; set; } = string.Empty;
    // Breakfast | Lunch | Dinner | Snack

    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Range(0, 5000)]
    public int Calories { get; set; }
}
