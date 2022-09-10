using BaBTeams.Data;

namespace BaBTeams;

public partial class App : Application
{
    public static TeamsRepository TeamsRepository { get; private set; }

    public App(TeamsRepository repo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        TeamsRepository = repo;
    }
}
