namespace TheMealApp.Models;

public class CategoryRoot
{
    public List<Category> categories { get; set; }
}

public class Category
{
    public string idCategory { get; set; }
    public string strCategory { get; set; }
    public string strCategoryThumb { get; set; }
    public string strCategoryDescription { get; set; }
}
