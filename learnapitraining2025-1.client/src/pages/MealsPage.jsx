import { useEffect, useState } from "react";
import { getMeals, createMeal, deleteMeal } from "../api/mealsApi";
import "../styles/meals.css";


export default function MealsPage() {
    const [meals, setMeals] = useState([]);
    const [page, setPage] = useState(1);
    const [totalCount, setTotalCount] = useState(0);

    const [loading, setLoading] = useState(false);
    const [error, setError] = useState(null);
    const [showForm, setShowForm] = useState(false);
    const [newMeal, setNewMeal] = useState({
        mealType: "Lunch",
        description: "",
        calories: "",
        mealTime: ""
    });

  const pageSize = 5;
  const totalPages = Math.max(1, Math.ceil(totalCount / pageSize));

  async function loadMeals(targetPage = page) {
    const result = await getMeals({ page: targetPage, pageSize });
    setMeals(result.items ?? []);
    setTotalCount(result.totalCount ?? 0);
  }

  useEffect(() => {
    let cancelled = false;

    async function fetchMeals() {
      setLoading(true);
      setError(null);

      try {
        const result = await getMeals({ page, pageSize });

        if (cancelled) return;

        setMeals(result.items ?? []);
        setTotalCount(result.totalCount ?? 0);
      } catch (err) {
        if (!cancelled) {
          setError("Failed to load meals");
          setMeals([]);
        }
      } finally {
        if (!cancelled) setLoading(false);
      }
    }

    fetchMeals();

    return () => {
      cancelled = true;
    };
  }, [page]);

  function goPrevious() {
    setPage(p => Math.max(1, p - 1));
  }

  function goNext() {
    setPage(p => Math.min(totalPages, p + 1));
  }
  async function handleCreateMeal(e) {
  e.preventDefault();

  await createMeal({
    ...newMeal,
    calories: Number(newMeal.calories)
  });

  setShowForm(false);
  setNewMeal({
    mealType: "Lunch",
    description: "",
    calories: "",
    mealTime: ""
  });

  setPage(1); // refresh from first page
}


 return (
  <div className="page">
    <div className="container">
      <h2 className="title">Meal Logs</h2>
      <button onClick={() => setShowForm(s => !s)}>
  {showForm ? "Cancel" : "Add Meal"}
</button>

{showForm && (
  <form onSubmit={handleCreateMeal} style={{ margin: "16px 0" }}>
    <select
      value={newMeal.mealType}
      onChange={e => setNewMeal({ ...newMeal, mealType: e.target.value })}
    >
      <option>Breakfast</option>
      <option>Lunch</option>
      <option>Dinner</option>
      <option>Snack</option>
    </select>

    <input
      placeholder="Description"
      value={newMeal.description}
      onChange={e => setNewMeal({ ...newMeal, description: e.target.value })}
      required
    />

    <input
      type="number"
      placeholder="Calories"
      value={newMeal.calories}
      onChange={e => setNewMeal({ ...newMeal, calories: e.target.value })}
      required
    />

    <input
      type="datetime-local"
      value={newMeal.mealTime}
      onChange={e => setNewMeal({ ...newMeal, mealTime: e.target.value })}
      required
    />

    <button type="submit">Save</button>
  </form>
)}

      <div className="meal-list">
        {meals.map(meal => (
          <div className="meal-card" key={meal.id}>
            <button
              onClick={async () => {
                await deleteMeal(meal.id);
                loadMeals();
              }}
              style={{ marginTop: "6px", color: "#ef4444" }}
            >
              Delete
            </button>

            <div className="meal-left">
              <span className="meal-type">{meal.mealType}</span>
              <span className="meal-desc">{meal.description}</span>
              <span className="meal-time">
                {new Date(meal.mealTime).toLocaleString()}
              </span>
            </div>

            <div className="calories">
              {meal.calories} kcal
            </div>
          </div>
        ))}
      </div>

      <div className="pagination">
        <button disabled={page === 1} onClick={goPrevious}>
          Previous
        </button>

        <span>
          Page {page} of {totalPages}
        </span>

        <button disabled={page >= totalPages} onClick={goNext}>
          Next
        </button>
      </div>
    </div>
  </div>
);

}
