namespace TheMealApp.Models;

public class ShortMealRoot
{
    public List<ShortMeal> meals { get; set; }
}

public class ShortMeal
{
    public string strMeal { get; set; }
    public string strMealThumb { get; set; }
    public string idMeal { get; set; }
}
