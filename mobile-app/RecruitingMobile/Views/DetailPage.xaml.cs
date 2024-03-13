using CommunityToolkit.Mvvm.Input;
using RecruitingMobile.ViewModels;

namespace RecruitingMobile.Views;

public partial class DetailPage : ContentPage
{
	public DetailPage(DetailViewModel detailViewModel)
	{
		InitializeComponent();
		BindingContext = detailViewModel;
	}


	private void OnBackButtonClicked(object sender, EventArgs e)
	{
        Shell.Current.SendBackButtonPressed();
    }
}