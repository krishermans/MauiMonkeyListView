using MauiMonkeyListView.ViewModel;

namespace MauiMonkeyListView;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _viewModel;

	public MainPage()
	{
		InitializeComponent();
		_viewModel = new MainPageViewModel();
	}

	protected override void OnAppearing()
	{
		base.OnAppearing();
		_viewModel.OnAppearing();
	}
}

