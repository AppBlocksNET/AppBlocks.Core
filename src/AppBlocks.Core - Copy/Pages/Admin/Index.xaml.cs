using AppBlocks.Models;
using System;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBlocks.Core.Pages.Admin
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Index : Page
    {
        //private ReflectionDataSource dataSource = new ReflectionDataSource();

        public Index()
        {
            InitializeComponent();

            Loading += Page_Loading;
        }

        private async void Page_Loading(object sender, object args)
        {
            //MainListView.ItemsSource = await dataSource.GetDataAsync<Item>(new Dictionary<string, string> { { "source", typeof(Index).Namespace } });
        }

        private void MainListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.ClickedItem == null) return;
            var item = (Item)e.ClickedItem;

            var itemType = Type.GetType($"{item.Id}.Index");
            if (itemType == null) return;

            Frame.Navigate(itemType);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}