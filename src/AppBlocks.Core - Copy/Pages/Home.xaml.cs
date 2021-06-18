using AppBlocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Animation;

namespace AppBlocks.Core.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Home : Page
	{
		public Home()
		{
			InitializeComponent();

			Loading += Page_Loading;
		}

		private async void Page_Loading(object sender, object args)
		{
			if (App.Group == null) App.Group = new Item().FromServiceAsync<Item>(null).Result;

			if (App.Group == null)
			{
				//MainListView.ItemsSource = await dataSource.GetDataAsync<Item>(new Dictionary<string, string> { { "source", typeof(Index).Namespace } });
			}
			else
            {
				MainListView.ItemsSource = App.Group.Children;
            }

		}

		private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (e.ClickedItem == null) return;
			var item = (Item)e.ClickedItem;

			if (item.Children.Any())
            {
				MainListView.ItemsSource = item.Children;
				//App.LastDataSource = $"Item:{item.Id}";


				//Index.HomeButton.Tag = $"Item:{item.Id}";
				//Index.HomeButton.Icon = "Back";
				return;
            }
			var itemType = Type.GetType($"{item.Name}.Index");
			if (itemType == null) return;

			//var itemPage = Activator.CreateInstance(itemType);
			//await Navigation.PushModalAsync(itemPage);
			Frame.Navigate(itemType, null, new SuppressNavigationTransitionInfo());

			//Frame.Navigate(itemType);

			//         NavigationTransitionInfo navigationTransitionInfo = null;
			//         var backItem = new PageStackEntry(typeof(Index), this, navigationTransitionInfo);
			//Frame.BackStack.Add(backItem);

			//await Navigation.PushModalAsync(detailPage);
		}
	}
}