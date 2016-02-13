using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Net;
using Telerik.Windows.Controls.Map;
using System.Linq;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class MapViewModel : NotificationObject
    {
        private string apiKey;
        private MapProviderBase provider;
        private BingSearchProvider searchProvider;
        private ObservableCollection<GeocodeResult> pinPoints;
        private LocationRect bestView;
        private bool isApiKeyBeingLoaded = false;

        public ObservableCollection<GeocodeResult> PinPoints
        {
            get
            {
                if (this.pinPoints == null)
                {
                    this.pinPoints = new ObservableCollection<GeocodeResult>();
                }
                return this.pinPoints;
            }
        }

        public LocationRect BestView
        {
            get
            {
                return this.bestView;
            }
            set
            {
                this.bestView = value;
                this.RaisePropertyChanged(() => this.BestView);
            }
        }

        public string ApiKey
        {
            get
            {
                if (string.IsNullOrEmpty(this.apiKey) && !isApiKeyBeingLoaded)
                {
                    isApiKeyBeingLoaded = true;
                    this.GetApiKeyFromServerAsync(key =>
                    {
                        isApiKeyBeingLoaded = false;
                        this.apiKey = key;
                        this.RaisePropertyChanged(() => this.ApiKey);
                        this.RaisePropertyChanged(() => this.Provider);
                        this.RaisePropertyChanged(() => this.SearchProvider);
                    });
                }

                return this.apiKey;
            }
        }

        public MapProviderBase Provider
        {
            get
            {
                if (this.ApiKey == null)
                {
                    return null;
                }
                else
                {
                    if (this.provider == null)
                    {
                        this.provider = new BingMapProvider(MapMode.Road, true, this.ApiKey);
                    }
                }

                return this.provider;
            }
        }

        public BingSearchProvider SearchProvider
        {
            get
            {
                if (this.ApiKey != null)
                {
                    if (this.searchProvider == null)
                    {
                        this.searchProvider = new BingSearchProvider(this.ApiKey);
                    }
                }
                return this.searchProvider;
            }
        }

        public void LocateOnMap(Company company)
        {
            if (company == null || (string.IsNullOrEmpty(company.Address) && string.IsNullOrEmpty(company.City) && string.IsNullOrEmpty(company.Country)) || this.SearchProvider == null)
            {
                this.BestView = new LocationRect(new Location(0,0),new Location(0,0));
                this.PinPoints.Clear();
                return;
            }

            string address = this.ComposeAddress(company);

            SearchRequest searchRequest = new SearchRequest();
            searchRequest.Culture = System.Globalization.CultureInfo.CurrentCulture;
            searchRequest.Query = address;
            System.Diagnostics.Debug.WriteLine("Address : {0}", address);
            System.Diagnostics.Debug.WriteLine("Address in Company : {0} {1} {2} {3} {4}", company.Address, company.City, company.State, company.Postcode, company.Country);
            this.SearchProvider.SearchCompleted += new EventHandler<SearchCompletedEventArgs>(this.SearchProvider_SearchCompleted);
            this.SearchProvider.SearchAsync(searchRequest);
        }

        private void GetApiKeyFromServerAsync(Action<string> callback)
        {
            WebClient client = new WebClient();
            Uri baseUri = System.Windows.Browser.HtmlPage.Document.DocumentUri;
            Uri fullUri = new Uri(baseUri, "BMApiKey.txt");

            DownloadStringCompletedEventHandler handler = null;
            handler = (s, e) =>
            {
                client.DownloadStringCompleted -= handler;
                var key = e.Result;
                callback(key);
            };

            client.DownloadStringCompleted += handler;
            client.DownloadStringAsync(fullUri);
        }

        private void SearchProvider_SearchCompleted(object sender, SearchCompletedEventArgs e)
        {
            this.SearchProvider.SearchCompleted -= this.SearchProvider_SearchCompleted;
            if (e.Response.Error != null)
            {
                this.BestView = new LocationRect(new Location(0, 0), new Location(0, 0));
                this.PinPoints.Clear();
                throw new Exception("There was a problem with Bing Maps API search. Please view InnerException details.", e.Response.Error);
            }

            if (e.Response.ResultSets == null || e.Response.ResultSets.Count == 0)
            {
                return;
            }

            var resultSet = e.Response.ResultSets.First();
            GeocodeResult geocodeLocation = null;
            if (resultSet.SearchRegion != null)
            {
                // just one result
                geocodeLocation = resultSet.SearchRegion.GeocodeLocation;
            }
            else
            {
                // wrong address, suggestions go in AlternateSearchRegions
                if (resultSet.AlternateSearchRegions.Count != 0)
                {
                    geocodeLocation = resultSet.AlternateSearchRegions[0].GeocodeLocation;
                }
                else
                {
                    // no real results 
                    return;
                }
            }

            this.BestView = geocodeLocation.BestView;
            this.PinPoints.Clear();
            this.PinPoints.Add(geocodeLocation);
        }

        private string ComposeAddress(Company company)
        {
            string address = this.ParseTextToCorrectSendingFormat(company.Address);
            string city = this.ParseTextToCorrectSendingFormat(company.City);
            string state = this.ParseTextToCorrectSendingFormat(company.State);
            string postcode = this.ParseTextToCorrectSendingFormat(company.Postcode);
            string country = this.ParseTextToCorrectSendingFormat(company.Country, false);
            string result = string.Format("{0}{1}{2}{3}{4}", address, city, postcode, state, country);
            return result;
        }

        private string ParseTextToCorrectSendingFormat(string text, bool shouldHaveEndingComma = true)
        {
            return !string.IsNullOrEmpty(text) ? text.Replace('\n', ' ').Trim() + (shouldHaveEndingComma ? ", " : string.Empty) : string.Empty;
        }
    }
}
