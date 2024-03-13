using RecruitingMobile.Models;
using RecruitingMobile.Views;

namespace RecruitingMobile
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(DetailPage), typeof(DetailPage));
        }

    }
}
