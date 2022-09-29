using BaBTeams.View;

namespace BaBTeams;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // TODO: Navegación con Shell 🐚
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
    }
}
