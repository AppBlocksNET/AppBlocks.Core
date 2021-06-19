using AppBlocks.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBlocks.Core.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Index : Page
	{
		Type currentPage;
		public Index()
		{
			InitializeComponent();

            if (Context.CurrentUser == null)
            {
                LoginButton.Opacity = 1;
                ProfileButton.Opacity = 0;
                LogoutButton.Opacity = 0;
            }
            else
            {
                LoginButton.Opacity = 0;
                ProfileButton.Opacity = 1;
                LogoutButton.Opacity = 1;
            }

			//BackButton.Visibility = Visibility.Collapsed;

            //Loading += Page_Loading;
            currentPage = typeof(Home);
			if (currentPage != null) contentFrame.Navigate(currentPage);

			if (Context.Group != null) CommandBarTitle.Text = GetAppTitle();
		}

        private string GetAppTitle()
        {
			return !string.IsNullOrEmpty(Context.Group?.Title) ? Context.Group?.Title : "UnoTestApp";
		}
		
        private void OnAppBarButtonTapped(object sender, RoutedEventArgs args)
		{
			if (sender is FrameworkElement element)
			{
				var tag = element.Tag.ToString();
				Type page = null;
				switch (tag)
				{
					//case "Blocks":
					//	page = typeof(Blocks);
					//	break;
					//case "Browse":
					//	page = typeof(Browse);
					//	break;
					case "Home":
						if (currentPage != typeof(Home))
						{
							page = typeof(Home);
                        }
                        else
                        {
							//App.Navigate(typeof(Index), true);
                        }
						break;
					case "Info":
						//page = typeof(Info);
						break;
					case "About":
						//page = typeof(Admin.Env.Index);
						break;
					case "Login":
						//page = typeof(Account.Login);
						break;
					case "Logout":
						Context.CurrentUser = null;
						//page = typeof(Account.Login);
						break;
					case "Profile":
						//page = typeof(Account.Profile);
						break;
				}

				if (page == null) return;

				if (currentPage != page)
				{
					currentPage = page;
					//contentFrame.Navigate(page);
				}

				var title = tag;
				if (title == "Home") title = GetAppTitle();
				CommandBarTitle.Text = title;
			}
		}
	}
}