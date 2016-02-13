using Procbel.Apps.Model.CRM;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Repository
{
    [Export]
    public class CompanyRepository : RepositoryBase
    {
        public void GetCompanies(Action<IEnumerable<Company>> callback)
        {
            this.LoadQuery<Company>(this.Context.GetCompanyQuery(), callback);
        }

        public void GetSalesTrendDataByCompany(Company company, Action<IEnumerable<SalesTrend>> callback)
        {
            if (company == null)
            {
                callback(Enumerable.Empty<SalesTrend>());
                return;
            }

            var companyID = company.CompanyID;
            this.LoadQuery<SalesTrend>(this.Context.GetTrendsByCompanyIDQuery(companyID), callback);
        }
    }
}
