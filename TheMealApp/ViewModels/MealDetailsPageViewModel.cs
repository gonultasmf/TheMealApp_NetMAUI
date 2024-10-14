using System.Web;

namespace TheMealApp.ViewModels;

[QueryProperty(nameof(MealId), nameof(MealId))]
public partial class MealDetailsPageViewModel : ObservableObject, IQueryAttributable
{
    private readonly IMealService _mealService;

    public MealDetailsPageViewModel(IMealService mealService)
    {
        _mealService = mealService;

        LoadData();
    }

    [ObservableProperty]
    private string _mealId;

    [ObservableProperty]
    private Meal _myMeal;

    private async void LoadData()
    {
        MyMeal = await _mealService.GetMealDetailsById(MealId);
    }

    [RelayCommand]
    public async Task Tap(string url)
    {
        try
        {
            if (string.IsNullOrEmpty(url))
            {
                await Shell.Current.DisplayAlert("Info", "Youtube içeriği yoktur.", "OK");
            }

            Uri uri = new Uri(url);
            await Browser.Default.OpenAsync(uri, BrowserLaunchMode.SystemPreferred);
        }
        catch (Exception) { }
    }

    [RelayCommand]
    public async Task ShareTap()
    {
        var text = $@"{MyMeal.strMeal}

{MyMeal.strInstructions}

{(string.IsNullOrEmpty(MyMeal.strYoutube) ? "" : $"Youtube video link: {MyMeal.strYoutube}")}
";
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Text = text,
            Title = MyMeal.strMeal
        });
    }

    [RelayCommand]
    public async Task Back()
    {
        await Shell.Current.GoToAsync("..", true);
    }

    public void ApplyQueryAttributes(IDictionary<string, object> query)
    {
        MealId = HttpUtility.UrlDecode(query[nameof(MealId)].ToString());

        LoadData();
    }
}
