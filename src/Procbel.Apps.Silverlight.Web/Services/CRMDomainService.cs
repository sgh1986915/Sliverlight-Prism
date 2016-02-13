
namespace Procbel.Apps.Silverlight.Web
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Data;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.ServiceModel.DomainServices.EntityFramework;

    using System.ServiceModel.DomainServices.Hosting;
    using System.ServiceModel.DomainServices.Server;
    using Procbel.Apps.Model.CRM;
    using System.Data.Entity;
    using Procbel.Apps.Model.CRM.Dashboard;


    // Implements application logic using the CRMEntities context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    [CLSCompliant(false)]
    public class CRMDomainService : DbDomainService<CRMEntities>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Activity' query.
        public IQueryable<Activity> GetActivity()
        {
            return this.DbContext.Activity;
        }

        public void InsertActivity(Activity activity)
        {
            DbEntityEntry<Activity> entityEntry = this.DbContext.Entry(activity);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Activity.Add(activity);
            }
        }

        public void UpdateActivity(Activity currentActivity)
        {
            this.DbContext.Activity.AttachAsModified(currentActivity, this.ChangeSet.GetOriginal(currentActivity), this.DbContext);
        }

        public void DeleteActivity(Activity activity)
        {
            DbEntityEntry<Activity> entityEntry = this.DbContext.Entry(activity);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Activity.Attach(activity);
                this.DbContext.Activity.Remove(activity);
            }
        }

        public IQueryable<Activity> GetActivitiesByCompanyID(int companyID)
        {
            var activities = this.DbContext.Activity.ToList().Where(a => a.Opportunity != null).Where(a => a.Opportunity.Contact.CompanyID == companyID);
            //original (as it should be) :
            //var activities = this.DataContext.Activities.ToList().Where(a => a.Opportunity.Company.CompanyID == companyID && a.IsCreationDateValid);
            return activities.AsQueryable();
        }

        public IQueryable<Activity> GetActivitiesByContactID(int contactID)
        {
            var activities = this.DbContext.Activity.ToList().Where(a => a.Opportunity != null && a.Opportunity.Contact != null && a.Opportunity.Contact.ContactID == contactID);
            return activities.AsQueryable();
        }

        public IQueryable<Opportunity> GetOpportunitiesByContactID(int contactID)
        {
            var data = this.DbContext.Opportunity.ToList().Where(o => o.ContactID == contactID);
            var dataAsQueryable = data.AsQueryable();
            return dataAsQueryable;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Company' query.
        public IQueryable<Company> GetCompany()
        {
            //return this.DbContext.Company.Include(o => o.SalesTrend).OrderBy(o => o.CompanyID);
            return this.DbContext.Company.Include(o => o.SalesTrend).OrderBy(o => o.CompanyID);
        }

        public void InsertCompany(Company company)
        {
            DbEntityEntry<Company> entityEntry = this.DbContext.Entry(company);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Company.Add(company);
            }
        }

        public void UpdateCompany(Company currentCompany)
        {
            this.DbContext.Company.AttachAsModified(currentCompany, this.ChangeSet.GetOriginal(currentCompany), this.DbContext);
        }

        public void DeleteCompany(Company company)
        {
            DbEntityEntry<Company> entityEntry = this.DbContext.Entry(company);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Company.Attach(company);
                this.DbContext.Company.Remove(company);
            }
        }

        public IQueryable<Activity> GetCompanyOverviewActivities(int companyID)
        {
            var activities = this.GetActivitiesByCompanyID(companyID).Where(a => a.Status == (int)ActivityStatusType.InProgress);
            return activities;
        }

        public IQueryable<SalesTrend> GetTrendsByCompanyID(int companyID)
        {
            var company = this.DbContext.Company.FirstOrDefault(c => c.CompanyID == companyID);
            if (company == null)
            {
                return Enumerable.Empty<SalesTrend>().AsQueryable();
            }
            var salesTrends = company.SalesTrend;
            var orderedTrends = salesTrends.OrderBy(t => t.Date.GetValueOrDefault()).AsQueryable();
            return orderedTrends;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Contact' query.
        public IQueryable<Contact> GetContact()
        {
            return this.DbContext.Contact.Include(o => o.Company).OrderBy(o => o.ContactID);
        }

        public void InsertContact(Contact contact)
        {
            DbEntityEntry<Contact> entityEntry = this.DbContext.Entry(contact);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Contact.Add(contact);
            }
        }

        public void UpdateContact(Contact currentContact)
        {
            this.DbContext.Contact.AttachAsModified(currentContact, this.ChangeSet.GetOriginal(currentContact), this.DbContext);
        }

        public void DeleteContact(Contact contact)
        {
            DbEntityEntry<Contact> entityEntry = this.DbContext.Entry(contact);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Contact.Attach(contact);
                this.DbContext.Contact.Remove(contact);
            }
        }

        /// <summary>
        /// Additional methods from Tererik
        /// </summary>
        /// <param name="companyID"></param>
        /// <returns></returns>
        public ContactsMetadata GetContactsMetadata(int companyID)
        {
            var metadata = new ContactsMetadata { Contacts = this.DbContext.Contact.Where(c => c.CompanyID == companyID).ToList() };
            return metadata;
        }

        public IQueryable<Contact> GetContactsByCompanyID(int companyID)
        {
            var contacts = this.DbContext.Contact.Where(c => c.CompanyID == companyID).OrderBy(c => c.Name);
            return contacts;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Employee' query.
        public IQueryable<Employee> GetEmployee()
        {
            return this.DbContext.Employee;
        }

        public void InsertEmployee(Employee employee)
        {
            DbEntityEntry<Employee> entityEntry = this.DbContext.Entry(employee);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Employee.Add(employee);
            }
        }

        public void UpdateEmployee(Employee currentEmployee)
        {
            this.DbContext.Employee.AttachAsModified(currentEmployee, this.ChangeSet.GetOriginal(currentEmployee), this.DbContext);
        }

        public void DeleteEmployee(Employee employee)
        {
            DbEntityEntry<Employee> entityEntry = this.DbContext.Entry(employee);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Employee.Attach(employee);
                this.DbContext.Employee.Remove(employee);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Image' query.
        public IQueryable<Image> GetImage()
        {
            return this.DbContext.Image;
        }

        public void InsertImage(Image image)
        {
            DbEntityEntry<Image> entityEntry = this.DbContext.Entry(image);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Image.Add(image);
            }
        }

        public void UpdateImage(Image currentImage)
        {
            this.DbContext.Image.AttachAsModified(currentImage, this.ChangeSet.GetOriginal(currentImage), this.DbContext);
        }

        public void DeleteImage(Image image)
        {
            DbEntityEntry<Image> entityEntry = this.DbContext.Entry(image);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Image.Attach(image);
                this.DbContext.Image.Remove(image);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Opportunity' query.
        public IQueryable<Opportunity> GetOpportunity()
        {
            return this.DbContext.Opportunity;
        }

        public void InsertOpportunity(Opportunity opportunity)
        {
            DbEntityEntry<Opportunity> entityEntry = this.DbContext.Entry(opportunity);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Opportunity.Add(opportunity);
            }
        }

        public void UpdateOpportunity(Opportunity currentOpportunity)
        {
            this.DbContext.Opportunity.AttachAsModified(currentOpportunity, this.ChangeSet.GetOriginal(currentOpportunity), this.DbContext);
        }

        public void DeleteOpportunity(Opportunity opportunity)
        {
            DbEntityEntry<Opportunity> entityEntry = this.DbContext.Entry(opportunity);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Opportunity.Attach(opportunity);
                this.DbContext.Opportunity.Remove(opportunity);
            }
        }

        /// <summary>
        /// Extension methods from Tererik
        /// </summary>
        /// <param name="opportunityID"></param>
        /// <returns></returns>
        public IQueryable<Activity> GetActivitiesByOpportunityID(int opportunityID)
        {
            return this.DbContext.Activity.Where(a => a.OpportunityID == opportunityID);
        }

        public IQueryable<Opportunity> GetOpportunitiesByCompanyID(int companyID)
        {
            var data = this.DbContext.Opportunity.ToList().Where(o => o.Contact != null && o.Contact.CompanyID == companyID);
            var dataAsQueryable = data.AsQueryable();
            return dataAsQueryable;
        }

        public IQueryable<Opportunity> GetCompanyOverviewOpportunities(int companyID)
        {
            var opportunities = this.GetOpportunitiesByCompanyID(companyID).Where(o => o.Status == (int)OpportunityStatusType.Open);
            return opportunities;
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Product' query.
        public IQueryable<Product> GetProduct()
        {
            return this.DbContext.Product;
        }

        public void InsertProduct(Product product)
        {
            DbEntityEntry<Product> entityEntry = this.DbContext.Entry(product);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Product.Add(product);
            }
        }

        public void UpdateProduct(Product currentProduct)
        {
            this.DbContext.Product.AttachAsModified(currentProduct, this.ChangeSet.GetOriginal(currentProduct), this.DbContext);
        }

        public void DeleteProduct(Product product)
        {
            DbEntityEntry<Product> entityEntry = this.DbContext.Entry(product);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Product.Attach(product);
                this.DbContext.Product.Remove(product);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'SalesTrend' query.
        public IQueryable<SalesTrend> GetSalesTrend()
        {
            return this.DbContext.SalesTrend;
        }

        public void InsertSalesTrend(SalesTrend salesTrend)
        {
            DbEntityEntry<SalesTrend> entityEntry = this.DbContext.Entry(salesTrend);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.SalesTrend.Add(salesTrend);
            }
        }

        public void UpdateSalesTrend(SalesTrend currentSalesTrend)
        {
            this.DbContext.SalesTrend.AttachAsModified(currentSalesTrend, this.ChangeSet.GetOriginal(currentSalesTrend), this.DbContext);
        }

        public void DeleteSalesTrend(SalesTrend salesTrend)
        {
            DbEntityEntry<SalesTrend> entityEntry = this.DbContext.Entry(salesTrend);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.SalesTrend.Attach(salesTrend);
                this.DbContext.SalesTrend.Remove(salesTrend);
            }
        }

        public DashboardStats GetDashboardStats()
        {
            var stats = new DashboardStats() { Activities = this.DbContext.Activity.ToList(), Opportunities = this.DbContext.Opportunity.ToList() };
            return stats;
        }
    }
}


