using System;
using System.Net;
using System.Windows;
using System.Windows.Ink;
using System.Linq;
using System.Windows.Input;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Composition;
using Procbel.Apps.Model.Main;

namespace Procbel.Apps.Silverlight.Repository.Main
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
