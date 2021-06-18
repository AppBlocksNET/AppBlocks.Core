using System;
using System.IO;
using System.Net;
using AppBlocks.Models;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace AppBlocks.Core.Pages.Account
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Profile : Page
	{
		public Profile()
		{
			InitializeComponent();

            //Loading += Page_Loading;
            //currentPage = typeof(_Home);
            if (App.CurrentUser == null)
            {
                //App.Navigate(typeof(Login));
                return;
            }
            EmailTextBox.Text = App.CurrentUser.Name;
            //App.CurrentUser.
		}

		private void CancelButton_Click(object sender, RoutedEventArgs e)
		{
			if (Frame.CanGoBack) Frame.GoBack();
			Frame.Navigate(typeof(Home));
		}

		private void SaveButton_Click(object sender, RoutedEventArgs e)
		{
            return;

			if (string.IsNullOrEmpty($"{EmailTextBox.Text}{PasswordPasswordBox.Password}")) return;

            var results = Authenticate(EmailTextBox.Text, PasswordPasswordBox.Password);
            if (results != null)
            {
                App.CurrentUser = results;
                //Frame.Navigate(typeof(_Home));
                //var rootFrame = _window.Content as Frame;
                //rootFrame.Navigate(typeof(Shared.Pages.Index), e.Arguments);
                //App.Navigate(typeof(Index), true);
            }
            else
            {
                //EmailTextBox.Focus();
            }
        }

		private Item Authenticate(string username, string password)
        {
			//var broker =  WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.UseHttpPost,
			//new Uri("https://mysite.com/mobileauth/Microsoft"),
			//new Uri("myapp://"));
			//var results = broker.GetResults();

			//return !string.IsNullOrEmpty(results.ResponseData);
            //return User.Authenticate(username, password);
            //return username == "dave@grouplings.com" && password != "Gonecrazy!1";
            //var user = new Item().FromServiceAsync<User> (null).Result;
            return From($"?username={username}&password={password}");
		}


        /// <summary>
        /// FromUri
        /// </summary>
        /// <param name="uri"></param>
        /// <returns></returns>
        public Item From(string source = null)
        {
            if (source == null || source.ToString().StartsWith("?"))
            {
                source = Settings.AppBlocksServiceUrl + $"account/authenticate" + source?.ToString();
            }

            var uri = new Uri(source);
            //_logger?.LogInformation($"{typeof(Item).Name}.FromUri({uri}) started:{DateTime.Now.ToShortTimeString()}");
            var content = string.Empty;
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(uri);
                request.ServerCertificateValidationCallback = (message, cert, chain, errors) => { return true; };
                // response.GetResponseStream();
                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    //_logger?.LogInformation($"HttpStatusCode:{response.StatusCode}");
                    var responseValue = string.Empty;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        var message = $"{typeof(Item).FullName} ERROR: Request failedd. Received HTTP {response.StatusCode}";
                        throw new ApplicationException(message);
                    }

                    // grab the response
                    using (var responseStream = response.GetResponseStream())
                    {
                        if (responseStream != null)
                            using (var reader = new StreamReader(responseStream))
                            {
                                responseValue = reader.ReadToEnd();
                            }
                    }

                    content = responseValue;

                    return new Item(content);
                }
            }
            catch (Exception exception)
            {
                //_logger?.LogInformation($"{nameof(Item)}.FromUri({uri}) ERROR:{exception.Message} {exception}");
                return null;
            }
            //_logger?.LogInformation($"content:{content}");

            //return FromJson<T>(content);
            return null;
        }
    }
}