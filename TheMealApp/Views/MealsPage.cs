namespace TheMealApp.Views;

public class MealsPage : ContentPage, IFmgLibHotReload
{
    private readonly MealsPageViewModel viewModel;

    public MealsPage(MealsPageViewModel viewModel)
    {
        this.viewModel = viewModel;
        this.InitializeHotReload();
    }

    public void Build()
    {
        this
        .BindingContext(viewModel)
        .Content(
            new Grid()
            .RowDefinitions(e => e.Auto().Star())
            .Margin(-1, -5)
            .Children(
                new Border()
                .BackgroundColor(AppColors.Primary)
                .Stroke(AppColors.Primary)
                .StrokeShape(new RoundRectangle().CornerRadius(0, 0, 16, 16))
                .StrokeThickness(1)
                .Content(
                    new Grid()
                    .ColumnDefinitions(e => e.Auto().Star())
                    .Children(
                        new ImageButton()
                        .Source("back.png")
                        .SizeRequest(30)
                        .AlignCenterLeft()
                        .Command(viewModel.BackCommand),

                        new Label()
                        .Column(1)
                        .Text(e => e.Path("CategoryName"))
                        .TextColor(White)
                        .FontAttributes(Bold)
                        .FontSize(35)
                        .Margin(10, 5, 0, 0)
                        .AlignCenterLeft()
                    )
                ),

                new CollectionView()
                .Row(1)
                .ItemsLayout(new LinearItemsLayout(ItemsLayoutOrientation.Vertical).ItemSpacing(5))
                .ItemsSource(e => e.Path("Meals"))
                .ItemTemplate(new DataTemplate(() =>
                    new Border()
                    .Background(Transparent)
                    .Stroke(Transparent)
                    .StrokeThickness(1)
                    .StrokeShape(new RoundRectangle().CornerRadius(20))
                    .HeightRequest(250)
                    .Content(
                        new Grid()
                        .RowDefinitions(e => e.Star(8).Star(2))
                        .Background(White)
                        .FillHorizontal()
                        .GestureRecognizers(
                            new TapGestureRecognizer().Command(viewModel.TapCommand).CommandParameter(e => e.Path("idMeal"))
                        )
                        .Children(
                            new Image()
                            .Row(0)
                            .RowSpan(2)
                            .Source(e => e.Path("strMealThumb"))
                            .Aspect(Aspect.AspectFill),

                            new Border()
                            .Row(1)
                            .BackgroundColor(AppColors.Primary)
                            .Stroke(AppColors.Primary)
                            .Padding(10, 0)
                            .Content(
                                new Label()
                                .MaxLines(1)
                                .LineBreakMode(LineBreakMode.TailTruncation)
                                .FontSize(20)
                                .AlignCenterLeft()
                                .TextColor(White)
                                .FontAttributes(Bold)
                                .Text(e => e.Path("strMeal"))
                            )
                        )
                    )
                ))
            )
        );
    }
}