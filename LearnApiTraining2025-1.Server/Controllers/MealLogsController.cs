using Microsoft.AspNetCore.Mvc;
using LearnApiTraining2025_1.Server.Models;

namespace LearnApiTraining2025_1.Server.Controllers;

[ApiController]
[Route("api/meals")]
public class MealLogsController : ControllerBase
{

    // Temporary in-memory storage (we will replace with DB)
    private static readonly List<MealLog> _meals = new();
    [HttpGet]
    public IActionResult GetAllMeals()
    {
        //var meals = new List<MealLog>
        //{
        //    new MealLog
        //    {
        //        Id = 1,
        //        MealTime = DateTime.Now.AddHours(-4),
        //        MealType = "Breakfast",
        //        Description = "Oats with banana and almonds",
        //        Calories = 380
        //    },
        //    new MealLog
        //    {
        //        Id = 2,
        //        MealTime = DateTime.Now.AddHours(-1),
        //        MealType = "Lunch",
        //        Description = "Rice, dal, vegetables",
        //        Calories = 650
        //    }
        //};

        return Ok(_meals);
    }

    // POST /api/meals
    [HttpPost]
    public IActionResult CreateMeal(MealLog meal)
    {
        // Simulate auto-increment ID
        meal.Id = _meals.Count + 1;

        _meals.Add(meal);

        // 201 Created is the correct REST response
        return CreatedAtAction(
            nameof(GetAllMeals),
            new { id = meal.Id },
            meal
        );
    }
}
