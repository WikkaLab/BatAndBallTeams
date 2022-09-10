using BaBTeams.ViewModel;

namespace BaBTeams.View;

public partial class DetailsPage : ContentPage
{
    public DetailsPage(TeamDetailViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}