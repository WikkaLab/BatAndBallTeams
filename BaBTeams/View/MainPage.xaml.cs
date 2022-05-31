using BaBTeams.ViewModel;

namespace BaBTeams.View;

public partial class MainPage : ContentPage
{
	public MainPage(TeamViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}

