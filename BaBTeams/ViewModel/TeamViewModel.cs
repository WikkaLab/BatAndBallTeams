using BaBTeams.Model;
using BaBTeams.Services;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace BaBTeams.ViewModel
{
    public partial class TeamViewModel : BaseViewModel
    {
        TeamsService service;

        public ObservableCollection<Team> Teams { get; } = new();

        public TeamViewModel(TeamsService teamsService)
        {
            this.service = teamsService;

            Title = "All teams in Spain";
        }

        [RelayCommand]
        async Task GetTeamsAsync()
        {
            if (IsBusy) return;

            try
            {
                IsBusy = true;
                var teams = await service.GetAllTeams();

                if (Teams.Count != 0)
                {
                    Teams.Clear();
                }

                foreach (var team in teams)
                {
                    Teams.Add(team);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error",
                    "Something wrong happened on getting teams!",
                    "OK :(");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
