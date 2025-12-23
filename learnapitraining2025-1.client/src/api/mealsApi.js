const BASE_URL = "/api/meals";

export async function deleteMeal(id) {
  const response = await fetch(`/api/meals/${id}`, {
    method: "DELETE"
  });

  if (!response.ok) {
    throw new Error("Failed to delete meal");
  }
}

export async function getMeals({
  page = 1,
  pageSize = 10,
  from,
  to,
  mealType
} = {}) {
  const params = new URLSearchParams();

    params.append("page", String(page));
    params.append("pageSize", String(pageSize));


  if (from) params.append("from", from);
  if (to) params.append("to", to);
  if (mealType) params.append("mealType", mealType);

  const response = await fetch(`${BASE_URL}?${params.toString()}`);

  if (!response.ok) {
    throw new Error("Failed to fetch meals");
  }

  return response.json();
}

export async function createMeal(meal) {
  const response = await fetch(BASE_URL, {
    method: "POST",
    headers: {
      "Content-Type": "application/json"
    },
    body: JSON.stringify(meal)
  });

  if (!response.ok) {
    throw new Error("Failed to create meal");
  }

  return response.json();
}
