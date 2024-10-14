using System.Net.Http.Json;

namespace TheMealApp.Utilities;

public class CategoryService : ICategoryService
{
    public async Task<List<Category>?> GetCategories()
    {
        var categories = await Client.Generate.GetFromJsonAsync<CategoryRoot>("categories.php");

        return categories?.categories;
    }
}
