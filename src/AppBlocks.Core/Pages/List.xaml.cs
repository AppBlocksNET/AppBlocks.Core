using AppBlocks.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Media.Animation;

namespace AppBlocks.Core.Pages
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class List : Page
	{
		public List(string id)
		{
			InitializeComponent();

			Loading += Page_Loading;
		}

		private async void Page_Loading(object sender, object args)
		{
			//MainListView.ItemsSource = await dataSource.GetDataAsync<DataGridDataItem>(new Dictionary<string, string> { { "source", typeof(Index).Namespace } });
			var source = await new Item().FromServiceAsync<Item>(null);
			MainListView.ItemsSource = source?.Children;
		}

		private async void MainListView_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (e.ClickedItem == null) return;
			var item = (Item)e.ClickedItem;

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