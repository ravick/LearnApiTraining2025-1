namespace LearnApiTraining2025_1.Server.Dtos;

public class MealResponseDto
{
    public int Id { get; set; }
    public DateTime MealTime { get; set; }
    public string MealType { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Calories { get; set; }
}
