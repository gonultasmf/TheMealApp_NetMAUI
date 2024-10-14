namespace TheMealApp;

public partial class App : Application
{
    public App(IServiceProvider service)
    {
        this
        .Resources(AppStyles.Default)
        .MainPage(service.GetService<AppShell>());
    }
}
