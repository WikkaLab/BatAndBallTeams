using BaBTeams.Data;
using BaBTeams.Helpers;
using BaBTeams.Services;
using BaBTeams.View;
using BaBTeams.ViewModel;

namespace BaBTeams;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Services
        builder.Services.AddSingleton<TeamsService>();
        string dbPath = FileAccessHelper.GetLocalFilePath("teams.db3");
        builder.Services.AddSingleton(s => ActivatorUtilities.CreateInstance<TeamsRepository>(s, dbPath));

        // View models
        builder.Services.AddSingleton<TeamViewModel>();
        builder.Services.AddTransient<TeamDetailViewModel>();

        // Views
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddTransient<DetailsPage>();

        return builder.Build();
    }
}
