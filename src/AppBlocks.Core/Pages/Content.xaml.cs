using System.ComponentModel;
using Windows.UI.Xaml.Controls;

namespace AppBlocks.Core.Pages
{
    [DesignTimeVisible(false)]
    public partial class Content : Page
    {
        //public User User = User.CurrentUser();
        public string Source { get; set; }

        public Content()
        {
            InitializeComponent();
            Source = "Hello World! Lorum ipsum dolar!";
        }

        //protected async override void OnAppearing()
        //{
        //    await DependencyService.Get<IUserInformation>().GetUserName().ContinueWith(t =>
        //    {
        //        Device.BeginInvokeOnMainThread(() => UserNameLabel.Text = t.Result);
        //    });
        //    base.OnAppearing();
        //}

    }
}