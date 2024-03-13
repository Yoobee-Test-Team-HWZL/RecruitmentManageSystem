using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RecruitingMobile.Models;
using System.Xml.Linq;

namespace RecruitingMobile.ViewModels;

[QueryProperty(nameof(Job), "Job")]
public partial class DetailViewModel : BaseViewModel
{
    public DetailViewModel()
    {
    }

    [ObservableProperty]
    Job job;

    [RelayCommand]
    public async Task Apply()
    {
        if (Email.Default.IsComposeSupported)
        {
            string subject = $"Application for {job.Title}";
            string body = $"Dear Hiring Manager,\r\n\r\nI am writing to apply for the {job.Title} position at {job.EmployerName}, bringing [number of years] years of experience in relevant field and a recent degree in [Your Degree].\r\n\r\nBest regards,\r\n[Your Name]";
            string[] recipients = new[] { job.EmployerEmail };

            var message = new EmailMessage
            {
                Subject = subject,
                Body = body,
                BodyFormat = EmailBodyFormat.PlainText,
                To = new List<string>(recipients)
            };

            await Email.Default.ComposeAsync(message);
        }

        return;
    }
}