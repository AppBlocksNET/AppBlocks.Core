using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBlocks.Core.Pages.Admin.AppSettings
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Index : Page
	{public Index()
		{
			InitializeComponent();

			Loading += Page_Loading;
		}

		private async void Page_Loading(object sender, object args)
		{
			//MainDataGrid.ItemsSource = await dataSource.GetDataAsync<DataGridDataItem>(null);
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			if (Frame.CanGoBack)
				Frame.GoBack();
		}
	}
}