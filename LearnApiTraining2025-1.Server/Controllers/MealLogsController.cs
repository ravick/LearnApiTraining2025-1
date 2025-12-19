using LearnApiTraining2025_1.Server.Data;
using LearnApiTraining2025_1.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LearnApiTraining2025_1.Server.Controllers;

[ApiController]
[Route("api/meals")]
public class MealLogsController : ControllerBase
{

    private readonly AppDbContext _db;

    public MealLogsController(AppDbContext db)
    {
        _db = db;
    }

    // GET /api/meals
    [HttpGet]
    public async Task<IActionResult> GetAllMeals()
    {
        var meals = await _db.MealLogs
            .OrderByDescending(m => m.MealTime)
            .ToListAsync();

        return Ok(meals);
    }

    // POST /api/meals
    [HttpPost]
    public async Task<IActionResult> CreateMeal(MealLog meal)
    {
        _db.MealLogs.Add(meal);
        await _db.SaveChangesAsync();

        return CreatedAtAction(nameof(GetAllMeals), new { id = meal.Id }, meal);
    }

    // PUT /api/meals/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMeal(int id, MealLog updatedMeal)
    {
        var existingMeal = await _db.MealLogs.FindAsync(id);

        if (existingMeal == null)
        {
            return NotFound();
        }

        existingMeal.MealTime = updatedMeal.MealTime;
        existingMeal.MealType = updatedMeal.MealType;
        existingMeal.Description = updatedMeal.Description;
        existingMeal.Calories = updatedMeal.Calories;

        await _db.SaveChangesAsync();

        return NoContent(); // 204 is correct for PUT
    }

    // DELETE /api/meals/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMeal(int id)
    {
        var meal = await _db.MealLogs.FindAsync(id);

        if (meal == null)
        {
            return NotFound();
        }

        _db.MealLogs.Remove(meal);
        await _db.SaveChangesAsync();

        return NoContent(); // 204 is correct for DELETE
    }

    //// Temporary in-memory storage (we will replace with DB)
    //private static readonly List<MealLog> _meals = new();
    //[HttpGet]
    //public IActionResult GetAllMeals()
    //{
    //    //var meals = new List<MealLog>
    //    //{
    //    //    new MealLog
    //    //    {
    //    //        Id = 1,
    //    //        MealTime = DateTime.Now.AddHours(-4),
    //    //        MealType = "Breakfast",
    //    //        Description = "Oats with banana and almonds",
    //    //        Calories = 380
    //    //    },
    //    //    new MealLog
    //    //    {
    //    //        Id = 2,
    //    //        MealTime = DateTime.Now.AddHours(-1),
    //    //        MealType = "Lunch",
    //    //        Description = "Rice, dal, vegetables",
    //    //        Calories = 650
    //    //    }
    //    //};

    //    return Ok(_meals);
    //}

    //// POST /api/meals
    //[HttpPost]
    //public IActionResult CreateMeal(MealLog meal)
    //{
    //    // Simulate auto-increment ID
    //    meal.Id = _meals.Count + 1;

    //    _meals.Add(meal);

    //    // 201 Created is the correct REST response
    //    return CreatedAtAction(
    //        nameof(GetAllMeals),
    //        new { id = meal.Id },
    //        meal
    //    );
    //}
}
