using Microsoft.Practices.Prism.Events;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.ViewModels;
using Procbel.Apps.Silverlight.Modules.Companies.Helpers;
using Procbel.Apps.Silverlight.MainRepository;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Telerik.Windows.Controls;
using Telerik.Windows.Data;
using System.Linq;
using Microsoft.Practices.Prism.Commands;
using Procbel.Apps.Silverlight.Modules.Companies.Views;
using Telerik.Windows.Media.Imaging;
using Telerik.Windows.Media.Imaging.FormatProviders;
using System.IO;
using Procbel.Apps.Silverlight.Infrastructure.Extensions;

namespace Procbel.Apps.Silverlight.Modules.Companies.ViewModels
{
    [Export]
    public class CompanyDetailsViewModel : NavigationAwareDataViewModel
    {
        public CompanyDetailsViewModel()
        {
            UpLoadImageCommand = new DelegateCommand<object>(UploadImage);
            SaveImageCommand = new DelegateCommand<object>(SaveImage);
        }
        public CultureInfo CurrentCulture
        {
            get
            {
                return LocalizationManager.DefaultCulture;
            }
        }

        [Import]
        public MapViewModel MapViewModel { get; set; }

        [Import]
        public IEventAggregator EventAggregator { get; set; }

        [Import]
        public CompanyRepository CompanyRepository { get; set; }

        private Company selectedCompany;
        public Company SelectedCompany
        {
            get
            {
                return this.selectedCompany;
            }

            set
            {
                if (this.selectedCompany == value)
                {
                    return;
                }
                this.selectedCompany = value;
                if (value.CompanyID == 0)
                {
                    value.Image.ImagePath = "/Images/CompanyLogos/defaultCompany.jpg";
                    value.Image.Extension = "jpg";
                    value.Image.Name = "defaultCompany";
                }
                if (!string.IsNullOrEmpty(value.Image.ImagePath))
                {
                    Stream strm = ExtensionUtilities.GetStream(new Uri(value.Image.ImagePath.StartsWith("/Assets") == true ? value.Image.ImagePath : "/Assets" + value.Image.ImagePath, UriKind.Relative), "Procbel.Apps.Silverlight");
                    using (MemoryStream ms = new MemoryStream())
                    {
                        strm.CopyTo(ms);
                        value.Image.Content = ms.ToArray();
                    }
                }

                BitmapImage = new RadBitmap(new MemoryStream(value.Image.Content));
                this.RaisePropertyChanged("SelectedCompany");
                this.RaisePropertyChanged("SelectedCompanySalesTrends");
            }
        }

        private QueryableCollectionView companies;

        public QueryableCollectionView Companies
        {
            get
            {
                return companies;
            }
            set
            {
                companies = value;
                this.RaisePropertyChanged("Companies");
                this.RaisePropertyChanged("SelectedCompany");
            }
        }

        public override void OnImportsSatisfied()
        {
            this.EventAggregator.GetEvent<SelectedCompanyChangedEvent>().Subscribe(this.OnSelectedCompanyChanged);
            this.EventAggregator.GetEvent<CompaniesLoadedEvent>().Subscribe(this.OnCompaniesLoadedEvent);
        }

        public void OnCompaniesLoadedEvent(QueryableCollectionView companies)
        {
            this.Companies = companies;
            this.Companies.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Companies_CollectionChanged);
        }

        void Companies_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case System.Collections.Specialized.NotifyCollectionChangedAction.Add:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Remove:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Replace:
                    break;
                case System.Collections.Specialized.NotifyCollectionChangedAction.Reset:
                    break;
                default:
                    throw new InvalidOperationException("Invalid enum value.");
            }

        }

        public void OnSelectedCompanyChanged(Company company)
        {
            //order is important
            if (company != null && company.CompanyID != 0)
            {
                this.DataHasPendingUpdates = true;
                this.SelectedCompany = company;
                this.MapViewModel.LocateOnMap(company);
            }
        }

        private IEnumerable<SalesTrend> selectedCompanySalesTrends;
        public IEnumerable<SalesTrend> SelectedCompanySalesTrends
        {
            get
            {
                if (this.DataHasPendingUpdates)
                {
                    this.CompanyRepository.GetSalesTrendDataByCompany(this.SelectedCompany,
                        items =>
                        {
                            this.DataHasPendingUpdates = false;
                            this.selectedCompanySalesTrends = items;
                            this.RaisePropertyChanged("SelectedCompanySalesTrends");
                            this.RaisePropertyChanged("Percentage");
                            this.RaisePropertyChanged("PercentageToZeroCompared");
                        });
                }
                return this.selectedCompanySalesTrends;
            }
        }

        public double Percentage
        {
            get
            {
                var percentage = this.CalculatePercentage(this.SelectedCompanySalesTrends);
                return percentage;
            }
        }

        /// <summary>
        /// Returns -1 if percentage is <0 , 0 if percentage is equal to 0, and 1 if percentage is >0
        /// </summary>
        public int PercentageToZeroCompared
        {
            get
            {
                int comparison = Percentage.CompareTo(0);
                if (comparison < 0)
                {
                    return -1;
                }
                if (comparison == 0)
                {
                    return 0;
                }

                return 1;
            }
        }

        private double CalculatePercentage(IEnumerable<SalesTrend> salesTrends)
        {
            const double defaultReturnValue = 0L;

            if (salesTrends == null || salesTrends.AsQueryable().Count() == 0)
            {
                return defaultReturnValue;
            }

            var average = salesTrends.Average(x => x.Amount);
            var lastItem = salesTrends.LastOrDefault() ?? new SalesTrend { Amount = 0 };
            var percentage = (lastItem.Amount - average) * 100 / average;

            return Convert.ToDouble(percentage);
        }

        protected override void OnDataUpdateTriggered()
        {
            this.RaisePropertyChanged("SelectedCompanySalesTrends");
        }



        #region Image Edit Related

        #region Properties

        private RadBitmap bitmapImage;
        public RadBitmap BitmapImage
        {
            get { return bitmapImage; }
            set { bitmapImage = value; RaisePropertyChanged("BitmapImage"); }
        }

        public CompanyImageEditView ImageEditView { get; set; }

        public RadWindow ModelWindow { get; set; }
        #endregion

        #region Event Handlers
        private void ModelWindow_PreviewClosed(object sender, WindowPreviewClosedEventArgs e)
        {
            if (ModelWindow != null)
                ModelWindow.Content = null;
            ModelWindow = null;
        }
        #endregion

        #endregion

        #region Command Implementation

        public void SaveImage(object prm)
        {
            if (prm != null && prm is RadBitmap)
            {
                RadBitmap image = prm as RadBitmap;
                PngFormatProvider provider = new PngFormatProvider();
                byte[] array = null;
                using (MemoryStream stream = new MemoryStream())
                {
                    provider.Export(image, stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    array = stream.ToArray();
                }
                if (SelectedCompany.Image != null)
                {
                    SelectedCompany.Image.Content = array;
                    SelectedCompany.Image.ImagePath = string.Empty;
                }
            }
            ModelWindow.Content = null;
            ModelWindow.Close();
            ModelWindow = null;
        }

        public void UploadImage(object prm)
        {
            ModelWindow = new RadWindow();
            ImageEditView = new CompanyImageEditView();
            ModelWindow.Header = "Update Image";
            ModelWindow.HideMaximizeButton = true;
            ModelWindow.HideMinimizeButton = true;
            ModelWindow.PreviewClosed += ModelWindow_PreviewClosed;
            ModelWindow.WindowStartupLocation = Telerik.Windows.Controls.WindowStartupLocation.CenterOwner;
            ImageEditView.DataContext = this;
            ModelWindow.Content = ImageEditView;

            ModelWindow.ShowDialog();

        }

        #endregion

        #region Commands
        public DelegateCommand<object> UpLoadImageCommand { get; set; }
        public DelegateCommand<object> SaveImageCommand { get; set; }
        #endregion
    }
}
