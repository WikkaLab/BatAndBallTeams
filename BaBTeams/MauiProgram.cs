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

		// View models
		builder.Services.AddSingleton<TeamViewModel>();
		builder.Services.AddTransient<TeamDetailViewModel>();

		// Views
		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddTransient<DetailsPage>();

		return builder.Build();
	}
}
