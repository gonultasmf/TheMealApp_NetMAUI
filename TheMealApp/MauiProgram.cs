namespace TheMealApp;

[MauiMarkup(typeof(StatusBarBehavior))]
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("IndieFlower-Regular.ttf", "IndieFlower");
            });

        builder.Services
            .AddSingleton<App>()
            .AddSingleton<AppShell>()
            .AddScoped<IMealService, MealService>()
            .AddScoped<ICategoryService, CategoryService>()
            .AddScopedWithShellRoute<CategoryPage, CategoryPageViewModel>(nameof(CategoryPage))
            .AddScopedWithShellRoute<HomePage, HomePageViewModel>(nameof(HomePage))
            .AddScopedWithShellRoute<MealsPage, MealsPageViewModel>(nameof(MealsPage))
            .AddScopedWithShellRoute<MealDetailsPage, MealDetailsPageViewModel>(nameof(MealDetailsPage));

        return builder.Build();
    }
}
