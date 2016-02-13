
namespace Procbel.Apps.Silverlight.Web.Services
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
    using System.Data.Entity;
    using Procbel.Apps.Model.Main;


    // Implements application logic using the AppsMainContainer context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    [CLSCompliant(false)]
    public class AppsmainDomainService : DbDomainService<AppsMainContainer>
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

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Company' query.
        public IQueryable<Company> GetCompany()
        {
            return this.DbContext.Company.Include(o => o.SalesTrend).Include(o=>o.Image).OrderBy(o => o.CompanyID);
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

        public void UpdateCompany(Company company)
        {
            this.DbContext.Company.AttachAsModified(company, this.ChangeSet.GetOriginal(company), this.DbContext);
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

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Customers' query.
        public IQueryable<Customer> GetCustomers()
        {
            return this.DbContext.Customers;
        }

        public void InsertCustomer(Customer customer)
        {
            DbEntityEntry<Customer> entityEntry = this.DbContext.Entry(customer);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Customers.Add(customer);
            }
        }

        public void UpdateCustomer(Customer currentCustomer)
        {
            this.DbContext.Customers.AttachAsModified(currentCustomer, this.ChangeSet.GetOriginal(currentCustomer), this.DbContext);
        }

        public void DeleteCustomer(Customer customer)
        {
            DbEntityEntry<Customer> entityEntry = this.DbContext.Entry(customer);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Customers.Attach(customer);
                this.DbContext.Customers.Remove(customer);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Images' query.
        public IQueryable<Image> GetImages()
        {
            return this.DbContext.Images;
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
                this.DbContext.Images.Add(image);
            }
        }

        public void UpdateImage(Image currentImage)
        {
            this.DbContext.Images.AttachAsModified(currentImage, this.ChangeSet.GetOriginal(currentImage), this.DbContext);
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
                this.DbContext.Images.Attach(image);
                this.DbContext.Images.Remove(image);
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

        public void UpdateSalesTrend(SalesTrend salesTrend)
        {
            this.DbContext.SalesTrend.AttachAsModified(salesTrend, this.ChangeSet.GetOriginal(salesTrend), this.DbContext);
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


        public IQueryable<Contact> GetContact()
        {
            return this.DbContext.Contact;
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

        public void UpdateContact(Contact contact)
        {
            this.DbContext.Contact.AttachAsModified(contact, this.ChangeSet.GetOriginal(contact), this.DbContext);
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


        public IQueryable<Product> GetProduct()
        {
            return this.DbContext.Products;
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
                this.DbContext.Products.Add(product);
            }
        }

        public void UpdateProduct(Product product)
        {
            this.DbContext.Products.AttachAsModified(product, this.ChangeSet.GetOriginal(product), this.DbContext);
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
                this.DbContext.Products.Attach(product);
                this.DbContext.Products.Remove(product);
            }
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
        public IQueryable<Contact> GetContactsByCompanyID(int companyID)
        {
            var contacts = this.DbContext.Contact.Where(c => c.CompanyID == companyID).OrderBy(c => c.Name);
            return contacts;
        }

         [CLSCompliant(false)]
        public ContactsMetadata GetContactsMetadata(int companyID)
        {
            var metadata = new ContactsMetadata { Contacts = this.DbContext.Contact.Where(c => c.CompanyID == companyID).ToList() };
            return metadata;
        }
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
        public IQueryable<Opportunity> GetOpportunitiesByContactID(int contactID)
        {
            var data = this.DbContext.Opportunity.ToList().Where(o => o.ContactID == contactID);
            var dataAsQueryable = data.AsQueryable();
            return dataAsQueryable;
        }
        public IQueryable<Opportunity> GetCompanyOverviewOpportunities(int companyID)
        {
            var opportunities = this.GetOpportunitiesByCompanyID(companyID).Where(o => o.Status == (int)OpportunityStatusType.Open);
            return opportunities;
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

        public IQueryable<Activity> GetCompanyOverviewActivities(int companyID)
        {
            var activities = this.GetActivitiesByCompanyID(companyID).Where(a => a.Status == (int)ActivityStatusType.InProgress);
            return activities;
        }

       

    }
}


