﻿//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Procbel.Apps.Model.AdventureWorks2008R2
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Objects;
    using System.Data.Objects.DataClasses;
    using System.Linq;
    
    public partial class AdventureWorks2008R2Entities : DbContext
    {
        public AdventureWorks2008R2Entities()
            : base("name=AdventureWorks2008R2Entities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<AWBuildVersion> AWBuildVersion { get; set; }
        public DbSet<DatabaseLog> DatabaseLog { get; set; }
        public DbSet<ErrorLog> ErrorLog { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<EmployeeDepartmentHistory> EmployeeDepartmentHistory { get; set; }
        public DbSet<EmployeePayHistory> EmployeePayHistory { get; set; }
        public DbSet<JobCandidate> JobCandidate { get; set; }
        public DbSet<Shift> Shift { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<AddressType> AddressType { get; set; }
        public DbSet<BusinessEntity> BusinessEntity { get; set; }
        public DbSet<BusinessEntityAddress> BusinessEntityAddress { get; set; }
        public DbSet<BusinessEntityContact> BusinessEntityContact { get; set; }
        public DbSet<ContactType> ContactType { get; set; }
        public DbSet<CountryRegion> CountryRegion { get; set; }
        public DbSet<EmailAddress> EmailAddress { get; set; }
        public DbSet<Password> Password { get; set; }
        public DbSet<Person> Person { get; set; }
        public DbSet<PersonPhone> PersonPhone { get; set; }
        public DbSet<PhoneNumberType> PhoneNumberType { get; set; }
        public DbSet<StateProvince> StateProvince { get; set; }
        public DbSet<BillOfMaterials> BillOfMaterials { get; set; }
        public DbSet<Culture> Culture { get; set; }
        public DbSet<Illustration> Illustration { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<ProductCostHistory> ProductCostHistory { get; set; }
        public DbSet<ProductDescription> ProductDescription { get; set; }
        public DbSet<ProductDocument> ProductDocument { get; set; }
        public DbSet<ProductInventory> ProductInventory { get; set; }
        public DbSet<ProductListPriceHistory> ProductListPriceHistory { get; set; }
        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<ProductModelIllustration> ProductModelIllustration { get; set; }
        public DbSet<ProductModelProductDescriptionCulture> ProductModelProductDescriptionCulture { get; set; }
        public DbSet<ProductPhoto> ProductPhoto { get; set; }
        public DbSet<ProductProductPhoto> ProductProductPhoto { get; set; }
        public DbSet<ProductReview> ProductReview { get; set; }
        public DbSet<ProductSubcategory> ProductSubcategory { get; set; }
        public DbSet<ScrapReason> ScrapReason { get; set; }
        public DbSet<TransactionHistory> TransactionHistory { get; set; }
        public DbSet<TransactionHistoryArchive> TransactionHistoryArchive { get; set; }
        public DbSet<UnitMeasure> UnitMeasure { get; set; }
        public DbSet<WorkOrder> WorkOrder { get; set; }
        public DbSet<WorkOrderRouting> WorkOrderRouting { get; set; }
        public DbSet<ProductVendor> ProductVendor { get; set; }
        public DbSet<PurchaseOrderDetail> PurchaseOrderDetail { get; set; }
        public DbSet<PurchaseOrderHeader> PurchaseOrderHeader { get; set; }
        public DbSet<ShipMethod> ShipMethod { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        public DbSet<CountryRegionCurrency> CountryRegionCurrency { get; set; }
        public DbSet<CreditCard> CreditCard { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<CurrencyRate> CurrencyRate { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<PersonCreditCard> PersonCreditCard { get; set; }
        public DbSet<SalesOrderDetail> SalesOrderDetail { get; set; }
        public DbSet<SalesOrderHeader> SalesOrderHeader { get; set; }
        public DbSet<SalesOrderHeaderSalesReason> SalesOrderHeaderSalesReason { get; set; }
        public DbSet<SalesPerson> SalesPerson { get; set; }
        public DbSet<SalesPersonQuotaHistory> SalesPersonQuotaHistory { get; set; }
        public DbSet<SalesReason> SalesReason { get; set; }
        public DbSet<SalesTaxRate> SalesTaxRate { get; set; }
        public DbSet<SalesTerritory> SalesTerritory { get; set; }
        public DbSet<SalesTerritoryHistory> SalesTerritoryHistory { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }
        public DbSet<SpecialOffer> SpecialOffer { get; set; }
        public DbSet<SpecialOfferProduct> SpecialOfferProduct { get; set; }
        public DbSet<Store> Store { get; set; }
        public DbSet<vEmployee> vEmployee { get; set; }
        public DbSet<vEmployeeDepartment> vEmployeeDepartment { get; set; }
        public DbSet<vEmployeeDepartmentHistory> vEmployeeDepartmentHistory { get; set; }
        public DbSet<vJobCandidate> vJobCandidate { get; set; }
        public DbSet<vJobCandidateEducation> vJobCandidateEducation { get; set; }
        public DbSet<vJobCandidateEmployment> vJobCandidateEmployment { get; set; }
        public DbSet<vAdditionalContactInfo> vAdditionalContactInfo { get; set; }
        public DbSet<vStateProvinceCountryRegion> vStateProvinceCountryRegion { get; set; }
        public DbSet<vProductAndDescription> vProductAndDescription { get; set; }
        public DbSet<vProductModelCatalogDescription> vProductModelCatalogDescription { get; set; }
        public DbSet<vProductModelInstructions> vProductModelInstructions { get; set; }
        public DbSet<vVendorWithAddresses> vVendorWithAddresses { get; set; }
        public DbSet<vVendorWithContacts> vVendorWithContacts { get; set; }
        public DbSet<vIndividualCustomer> vIndividualCustomer { get; set; }
        public DbSet<vPersonDemographics> vPersonDemographics { get; set; }
        public DbSet<vSalesPerson> vSalesPerson { get; set; }
        public DbSet<vSalesPersonSalesByFiscalYears> vSalesPersonSalesByFiscalYears { get; set; }
        public DbSet<vStoreWithAddresses> vStoreWithAddresses { get; set; }
        public DbSet<vStoreWithContacts> vStoreWithContacts { get; set; }
        public DbSet<vStoreWithDemographics> vStoreWithDemographics { get; set; }
    
        [EdmFunction("AdventureWorks2008R2Entities", "ufnGetContactInformation")]
        public virtual IQueryable<ufnGetContactInformation_Result> ufnGetContactInformation(Nullable<int> personID)
        {
            var personIDParameter = personID.HasValue ?
                new ObjectParameter("PersonID", personID) :
                new ObjectParameter("PersonID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.CreateQuery<ufnGetContactInformation_Result>("[AdventureWorks2008R2Entities].[ufnGetContactInformation](@PersonID)", personIDParameter);
        }
    
        public virtual ObjectResult<uspGetBillOfMaterials_Result> uspGetBillOfMaterials(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
        {
            var startProductIDParameter = startProductID.HasValue ?
                new ObjectParameter("StartProductID", startProductID) :
                new ObjectParameter("StartProductID", typeof(int));
    
            var checkDateParameter = checkDate.HasValue ?
                new ObjectParameter("CheckDate", checkDate) :
                new ObjectParameter("CheckDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetBillOfMaterials_Result>("uspGetBillOfMaterials", startProductIDParameter, checkDateParameter);
        }
    
        public virtual ObjectResult<uspGetEmployeeManagers_Result> uspGetEmployeeManagers(Nullable<int> businessEntityID)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetEmployeeManagers_Result>("uspGetEmployeeManagers", businessEntityIDParameter);
        }
    
        public virtual ObjectResult<uspGetManagerEmployees_Result> uspGetManagerEmployees(Nullable<int> businessEntityID)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetManagerEmployees_Result>("uspGetManagerEmployees", businessEntityIDParameter);
        }
    
        public virtual ObjectResult<uspGetWhereUsedProductID_Result> uspGetWhereUsedProductID(Nullable<int> startProductID, Nullable<System.DateTime> checkDate)
        {
            var startProductIDParameter = startProductID.HasValue ?
                new ObjectParameter("StartProductID", startProductID) :
                new ObjectParameter("StartProductID", typeof(int));
    
            var checkDateParameter = checkDate.HasValue ?
                new ObjectParameter("CheckDate", checkDate) :
                new ObjectParameter("CheckDate", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<uspGetWhereUsedProductID_Result>("uspGetWhereUsedProductID", startProductIDParameter, checkDateParameter);
        }
    
        public virtual int uspLogError(ObjectParameter errorLogID)
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspLogError", errorLogID);
        }
    
        public virtual int uspPrintError()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspPrintError");
        }
    
        public virtual int uspSearchCandidateResumes(string searchString, Nullable<bool> useInflectional, Nullable<bool> useThesaurus, Nullable<int> language)
        {
            var searchStringParameter = searchString != null ?
                new ObjectParameter("searchString", searchString) :
                new ObjectParameter("searchString", typeof(string));
    
            var useInflectionalParameter = useInflectional.HasValue ?
                new ObjectParameter("useInflectional", useInflectional) :
                new ObjectParameter("useInflectional", typeof(bool));
    
            var useThesaurusParameter = useThesaurus.HasValue ?
                new ObjectParameter("useThesaurus", useThesaurus) :
                new ObjectParameter("useThesaurus", typeof(bool));
    
            var languageParameter = language.HasValue ?
                new ObjectParameter("language", language) :
                new ObjectParameter("language", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspSearchCandidateResumes", searchStringParameter, useInflectionalParameter, useThesaurusParameter, languageParameter);
        }
    
        public virtual int uspUpdateEmployeeHireInfo(Nullable<int> businessEntityID, string jobTitle, Nullable<System.DateTime> hireDate, Nullable<System.DateTime> rateChangeDate, Nullable<decimal> rate, Nullable<byte> payFrequency, Nullable<bool> currentFlag)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            var jobTitleParameter = jobTitle != null ?
                new ObjectParameter("JobTitle", jobTitle) :
                new ObjectParameter("JobTitle", typeof(string));
    
            var hireDateParameter = hireDate.HasValue ?
                new ObjectParameter("HireDate", hireDate) :
                new ObjectParameter("HireDate", typeof(System.DateTime));
    
            var rateChangeDateParameter = rateChangeDate.HasValue ?
                new ObjectParameter("RateChangeDate", rateChangeDate) :
                new ObjectParameter("RateChangeDate", typeof(System.DateTime));
    
            var rateParameter = rate.HasValue ?
                new ObjectParameter("Rate", rate) :
                new ObjectParameter("Rate", typeof(decimal));
    
            var payFrequencyParameter = payFrequency.HasValue ?
                new ObjectParameter("PayFrequency", payFrequency) :
                new ObjectParameter("PayFrequency", typeof(byte));
    
            var currentFlagParameter = currentFlag.HasValue ?
                new ObjectParameter("CurrentFlag", currentFlag) :
                new ObjectParameter("CurrentFlag", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateEmployeeHireInfo", businessEntityIDParameter, jobTitleParameter, hireDateParameter, rateChangeDateParameter, rateParameter, payFrequencyParameter, currentFlagParameter);
        }
    
        public virtual int uspUpdateEmployeePersonalInfo(Nullable<int> businessEntityID, string nationalIDNumber, Nullable<System.DateTime> birthDate, string maritalStatus, string gender)
        {
            var businessEntityIDParameter = businessEntityID.HasValue ?
                new ObjectParameter("BusinessEntityID", businessEntityID) :
                new ObjectParameter("BusinessEntityID", typeof(int));
    
            var nationalIDNumberParameter = nationalIDNumber != null ?
                new ObjectParameter("NationalIDNumber", nationalIDNumber) :
                new ObjectParameter("NationalIDNumber", typeof(string));
    
            var birthDateParameter = birthDate.HasValue ?
                new ObjectParameter("BirthDate", birthDate) :
                new ObjectParameter("BirthDate", typeof(System.DateTime));
    
            var maritalStatusParameter = maritalStatus != null ?
                new ObjectParameter("MaritalStatus", maritalStatus) :
                new ObjectParameter("MaritalStatus", typeof(string));
    
            var genderParameter = gender != null ?
                new ObjectParameter("Gender", gender) :
                new ObjectParameter("Gender", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("uspUpdateEmployeePersonalInfo", businessEntityIDParameter, nationalIDNumberParameter, birthDateParameter, maritalStatusParameter, genderParameter);
        }
    }
}
