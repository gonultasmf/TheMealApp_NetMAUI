using System.Net.Http.Json;

namespace TheMealApp.Utilities;

public class MealService : IMealService
{
    public async Task<Meal?> GetMealDetailsById(string id)
    {
        var result = await Client.Generate.GetFromJsonAsync<MealRoot>($"lookup.php?i={id}");

        return result?.meals?.FirstOrDefault();
    }

    public async Task<Meal?> GetMealDetailsByName(string name)
    {
        var result = await Client.Generate.GetFromJsonAsync<MealRoot>($"search.php?s={name}");

        return result?.meals?.FirstOrDefault();
    }

    public async Task<List<ShortMeal>?> GetMealsByCategory(string categoryName)
    {
        var result = await Client.Generate.GetFromJsonAsync<ShortMealRoot>($"filter.php?c={categoryName}");

        return result?.meals;
    }

    public async Task<List<ShortMeal>?> GetMealsByIngredient(string ingredientName)
    {
        var result = await Client.Generate.GetFromJsonAsync<ShortMealRoot>($"filter.php?i={ingredientName}");

        return result?.meals;
    }

    public async Task<List<Meal>?> GetLatestMeals()
    {
        var result = await Client.Generate.GetFromJsonAsync<MealRoot>("latest.php");

        return result?.meals;
    }

    public async Task<List<Meal>?> GetRandomMeals()
    {
        var result = await Client.Generate.GetFromJsonAsync<MealRoot>("randomselection.php");

        return result?.meals;
    }
}
