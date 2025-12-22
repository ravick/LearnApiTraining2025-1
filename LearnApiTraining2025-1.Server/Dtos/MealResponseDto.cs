using LearnApiTraining2025_1.Server.Domain;

namespace LearnApiTraining2025_1.Server.Dtos;

public class MealResponseDto
{
    public int Id { get; set; }
    public DateTime MealTime { get; set; }
    public MealType MealType { get; set; }
    public string Description { get; set; } = string.Empty;
    public int Calories { get; set; }
}
