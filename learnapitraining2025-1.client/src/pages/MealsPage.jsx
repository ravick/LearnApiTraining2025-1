import { useEffect, useState } from "react";
import { getMeals } from "../api/mealsApi";
import "../styles/meals.css";


export default function MealsPage() {
  const [meals, setMeals] = useState([]);
  const [page, setPage] = useState(1);
  const [totalCount, setTotalCount] = useState(0);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  const pageSize = 5;
  const totalPages = Math.max(1, Math.ceil(totalCount / pageSize));

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

 return (
  <div className="page">
    <div className="container">
      <h2 className="title">Meal Logs</h2>

      <div className="meal-list">
        {meals.map(meal => (
          <div className="meal-card" key={meal.id}>
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
