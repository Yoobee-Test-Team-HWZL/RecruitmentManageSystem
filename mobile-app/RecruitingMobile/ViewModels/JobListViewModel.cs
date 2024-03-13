using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecruitingMobile.Models;
using RecruitingMobile.Services;
using RecruitingMobile.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

using PageEntity = RecruitingMobile.Models.PageEntity;

namespace RecruitingMobile.ViewModels
{
    public partial class JobListViewModel : BaseViewModel
    {
        RecruitServices recruitServices;
        IConnectivity connectivity;

        public ObservableCollection<Job> Jobs { get; } = new();



        [ObservableProperty]
        bool isRefreshing;

        [ObservableProperty]
        PageEntity page = new();

        public JobListViewModel(RecruitServices recruitServices, IConnectivity connectivity)
        {
            Title = "Jobs@NZ";
            this.recruitServices = recruitServices;
            this.connectivity = connectivity;

        }

        [RelayCommand]
        public async Task GetJobsAsync()
        {
            if (IsBusy)
                return;

            try
            {
                if (connectivity.NetworkAccess != NetworkAccess.Internet)
                {
                    await Shell.Current.DisplayAlert("No Internet", "Please check your internet connection", "OK");
                    return;
                }

                IsBusy = true;
                var jobs = await recruitServices.GetJobs(page);

                if (jobs!.Count != 0)
                    Jobs.Clear();

                foreach (var job in jobs!)
                {
                    Jobs.Add(job);
                }
                Console.WriteLine($"Jobs: {Jobs.Count}");
            }
            catch (Exception ex)
            {
                // Log the exception
                Debug.WriteLine($"Unable to get jobs: {ex.Message}");
                await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        public Task GetMoreJobsAsync()
        {
            if (Jobs.Count > 10)
            {
                page.PageNumber++;
                _ = GetJobsAsync();
            }
            return Task.CompletedTask;
        }

        [RelayCommand]
        private async Task GoToDetails(Job job)
        {
            Debug.WriteLine($"GoToDeailCommand: {job}");
            //Navigate to the details page
            if (job == null)
                return;

            await Shell.Current.GoToAsync(nameof(DetailPage), true, new Dictionary<string, object>
            {
                {"Job", job }
            });
            return;
        }
    }

}
