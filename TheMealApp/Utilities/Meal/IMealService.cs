namespace TheMealApp.Utilities;

public interface IMealService
{
    Task<Meal?> GetMealDetailsById(string id);
    Task<Meal?> GetMealDetailsByName(string name);
    Task<List<ShortMeal>?> GetMealsByCategory(string categoryName);
    Task<List<ShortMeal>?> GetMealsByIngredient(string ingredientName);
    Task<List<Meal>?> GetLatestMeals();
    Task<List<Meal>?> GetRandomMeals();
}
