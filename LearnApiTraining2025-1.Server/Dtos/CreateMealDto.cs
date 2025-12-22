using System.ComponentModel.DataAnnotations;
using LearnApiTraining2025_1.Server.Domain;

namespace LearnApiTraining2025_1.Server.Dtos;

public class CreateMealDto
{
    [Required]
    public DateTime MealTime { get; set; }

    [Required]
    [MaxLength(20)]
    public MealType MealType { get; set; }


    [Required]
    [MaxLength(200)]
    public string Description { get; set; } = string.Empty;

    [Range(1, 5000)]
    public int Calories { get; set; }
}
