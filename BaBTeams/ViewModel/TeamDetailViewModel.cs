using BaBTeams.Model;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BaBTeams.ViewModel
{
    [QueryProperty("Team", "Team")]
    public partial class TeamDetailViewModel : BaseViewModel
    {
        public TeamDetailViewModel()
        {

        }

        [ObservableProperty]
        Team team;
    }
}
