namespace TheMealApp.ViewModels;

public partial class HomePageViewModel : ObservableObject
{
    private readonly IMealService _mealService;

    public HomePageViewModel(IMealService mealService)
    {
        _mealService = mealService;

        LoadData();
    }

    [ObservableProperty]
    private List<Meal> _meals;

    private async void LoadData()
    {
        Meals = await _mealService.GetLatestMeals();
    }

    [RelayCommand]
    public async Task Tap(string id)
    {
        await Shell.Current.GoToAsync($"{nameof(MealDetailsPage)}?MealId={id}", true);
    }
}
