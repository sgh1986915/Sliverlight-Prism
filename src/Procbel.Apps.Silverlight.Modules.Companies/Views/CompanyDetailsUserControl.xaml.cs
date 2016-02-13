using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Infrastructure.Behaviors;
using Procbel.Apps.Silverlight.Modules.Companies.ViewModels;
using System;
using System.ComponentModel.Composition;
using System.Linq;
using System.Windows.Controls;
using Telerik.Windows.Controls;

namespace Procbel.Apps.Silverlight.Modules.Companies.Views
{
    [ViewExport(RegionName = "CompanyDetailsRegion")]
    public partial class CompanyDetailsUserControl : UserControl
    {
        public CompanyDetailsUserControl()
        {
            InitializeComponent();
            
        }

        [Import]
        public CompanyDetailsViewModel ViewModel
        {
            get
            {
                return this.DataContext as CompanyDetailsViewModel;
            }
            set
            {
                this.DataContext = value;
            }
        }


        private void OnDataFormEditEnded(object sender, Telerik.Windows.Controls.Data.DataForm.EditEndedEventArgs e)
        {
            switch (e.EditAction)
            {
                case Telerik.Windows.Controls.Data.DataForm.EditAction.Cancel:
                    ViewModel.CompanyRepository.Context.RejectChanges();
                    (sender as RadDataForm).ValidationSummary.Errors.Clear();
                    break;
                case Telerik.Windows.Controls.Data.DataForm.EditAction.Commit:
                    var company = (sender as RadDataForm).CurrentItem as Company;
                    var modelContainsEntity = ViewModel.CompanyRepository.Context.Companies.Contains(company);
                    if (!modelContainsEntity)
                    {
                        if (!string.IsNullOrEmpty(company.Image.ImagePath))
                            company.Image.Content = null;
                        ViewModel.CompanyRepository.Context.Companies.Add(company);
                    }
                    ViewModel.CompanyRepository.SaveOrUpdateEntities();
                    break;
                default:
                    throw new InvalidOperationException("Edit action should be Cancel or Commit only.");
            }
        }

        private void OnDataFormCurrentItemChanged(object sender, EventArgs e)
        {
            (sender as RadDataForm).CancelEdit();
            (sender as RadDataForm).ValidationSummary.Errors.Clear();
            ViewModel.CompanyRepository.Context.RejectChanges();
        }

        private void dataForm_AddedNewItem(object sender, Telerik.Windows.Controls.Data.DataForm.AddedNewItemEventArgs e)
        {
            var company = (sender as RadDataForm).CurrentItem as Company;
            Model.Main.Image newImage = new Model.Main.Image();
            company.Image = newImage;
            company.SiteId = 1;
            ViewModel.SelectedCompany = company;

        }

        private void TextBox_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            TextBox companyBox = sender as TextBox;
            System.Windows.Browser.HtmlPage.Plugin.Focus();

            Dispatcher.BeginInvoke(() => { companyBox.SelectionStart = companyBox.Text.Length; companyBox.UpdateLayout(); companyBox.Focus(); });
        }



    }
}
