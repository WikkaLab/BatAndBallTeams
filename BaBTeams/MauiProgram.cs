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

		builder.Services.AddSingleton<TeamsService>();
		builder.Services.AddSingleton<TeamViewModel>();
		builder.Services.AddSingleton<MainPage>();

		return builder.Build();
	}
}
