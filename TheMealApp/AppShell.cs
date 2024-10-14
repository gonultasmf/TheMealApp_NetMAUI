namespace TheMealApp;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider service)
    {
        this
        .Behaviors(
            new StatusBarBehavior().StatusBarColor(AppColors.Primary)
        )
        .FlyoutBehavior(FlyoutBehavior.Disabled)
        .ShellNavBarIsVisible(false)
        .Items(
            new TabBar()
            .Items(
                new Tab()
                .Icon("category.png")
                .Route(nameof(CategoryPage))
                .Items(service.GetService<CategoryPage>()),

                new Tab()
                .Icon("diet.png")
                .Route(nameof(HomePage))
                .Items(service.GetService<HomePage>())
            )
        );
    }
}
