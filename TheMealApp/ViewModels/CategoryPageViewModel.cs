namespace TheMealApp.ViewModels;

public partial class CategoryPageViewModel : ObservableObject
{
    private readonly ICategoryService _categoryService;

    public CategoryPageViewModel(ICategoryService categoryService)
    {
        _categoryService = categoryService;

        LoadData();
    }

    [ObservableProperty]
    private List<Category> _categories;

    private async void LoadData()
    {
        Categories = await _categoryService.GetCategories();
    }

    [RelayCommand]
    public async Task Tap(string name)
    {
        await Shell.Current.GoToAsync($"{nameof(MealsPage)}?CategoryName={name}",true);
    }
}
