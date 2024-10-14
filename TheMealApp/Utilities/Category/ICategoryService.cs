namespace TheMealApp.Utilities;

public interface ICategoryService
{
    Task<List<Category>?> GetCategories();
}
