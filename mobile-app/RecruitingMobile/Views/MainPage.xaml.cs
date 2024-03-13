using CommunityToolkit.Mvvm.Input;
using RecruitingMobile.Models;
using RecruitingMobile.ViewModels;
using System.Diagnostics;

namespace RecruitingMobile
{
    public partial class MainPage : ContentPage
    {

        public MainPage(JobListViewModel jobListViewModel)
        {
            InitializeComponent();
            BindingContext = jobListViewModel;

        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await ((JobListViewModel)BindingContext).GetJobsAsync();
        }


    }

}
