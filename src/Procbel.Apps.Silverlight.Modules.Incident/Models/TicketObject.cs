using Microsoft.Practices.Prism.ViewModel;
using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Incidencias.Models
{
    public class TicketObject : ValidatingObject
    {
        #region Fields

        string title;
        string titleForEdit;
        string details;
        string tagList;
        int ticketTypeTicketTypeId;
        int ticketCategoryTicketCategoryId;
        string imagePath;
        int importance;

        #endregion

        public TicketObject()
        {
            //Need updated when release!
            this.IsHtml = true;
            this.tagList = string.Empty;
            this.Details = string.Empty;
            this.CreatedBy = "Silverlight";
            this.CreatedDate = DateTime.Today;
            // Need fixed
            this.Owner = "Owner";
            this.CurrentStatusDate = DateTime.Now;
            this.CurrentStatusSetBy = "SetBy";
            this.LastUpdateBy = "UpdateBy";
            this.LastUpdateDate = DateTime.Now;
            this.AffectsCustomer = false;
            this.PublishedToKb = true;
            this.Version = Guid.NewGuid();
            this.DimCreatedTimeId = 20;
            this.DimCurrentStatusDateId = 1;
            this.DimCurrentStatusTimeId = 2;
            this.SiteId = 1;
            this.TicketStatusTicketStatusId = 1;
            //Navigation Properties
        }

        #region Properties Getters and Setters

        public int TicketId { get; set; }
        public bool IsHtml { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Owner { get; set; }
        public string AssignedTo { get; set; }
        public DateTime CurrentStatusDate { get; set; }
        public string CurrentStatusSetBy { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Priority { get; set; }
        public bool AffectsCustomer { get; set; }
        public bool PublishedToKb { get; set; }
        public Guid Version { get; set; }
        public int DimCreatedDateId { get; set; }
        public int DimCreatedTimeId { get; set; }
        public int DimCurrentStatusDateId { get; set; }
        public int DimCurrentStatusTimeId { get; set; }
        public int SiteId { get; set; }
        public int TicketStatusTicketStatusId { get; set; }

        //Navigation Properties
        public TicketType TicketType { get; set; }
        public TicketCategory TicketCategory { get; set; }

        #endregion

        [Required(ErrorMessage = "The Title field is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The Title must be at least 1 and at most 20 characters long")]
        public string Title
        {
            get { return this.title; }
            set
            {
                if (value != this.title)
                {
                    this.title = value;
                    this.RaisePropertyChanged(() => this.Title);
                }
            }
        }

        [Required(ErrorMessage = "The Title field is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The Title must be at least 1 and at most 20 characters long")]
        public string TitleForEdit
        {
            get { return this.titleForEdit; }
            set
            {
                if (value != this.titleForEdit)
                {
                    this.titleForEdit = value;
                    this.RaisePropertyChanged(() => this.TitleForEdit);
                }
            }
        }

        [Required(ErrorMessage = "This field is required")]
        public string Details
        {
            get { return this.details; }
            set
            {
                if (value != this.details)
                {
                    this.details = value;
                    this.RaisePropertyChanged(() => this.Details);
                }
            }
        }

        public string TagList
        {
            get { return this.tagList; }
            set
            {
                if (value != this.tagList)
                {
                    this.tagList = value;
                    this.RaisePropertyChanged(() => this.TagList);
                }
            }
        }

        public int TicketTypeTicketTypeId
        {
            get { return this.ticketTypeTicketTypeId; }
            set
            {
                if (value != this.ticketTypeTicketTypeId)
                {
                    this.ticketTypeTicketTypeId = value;
                    this.RaisePropertyChanged(() => this.TicketTypeTicketTypeId);
                }
            }
        }

        public int TicketCategoryTicketCategoryId
        {
            get { return this.ticketCategoryTicketCategoryId; }
            set
            {
                if (value != this.ticketCategoryTicketCategoryId)
                {
                    this.ticketCategoryTicketCategoryId = value;
                    this.RaisePropertyChanged(() => this.TicketCategoryTicketCategoryId);
                }
            }
        }
        
        public string ImagePath
        {
            get { return this.imagePath; }
            set
            {
                if (value != this.imagePath)
                {
                    this.imagePath = value;
                    this.RaisePropertyChanged(() => this.ImagePath);
                }
            }
        }

        public int Importance
        {
            get { return this.importance; }
            set
            {
                if (value != this.importance)
                {
                    this.importance = value;
                    this.RaisePropertyChanged(() => this.Importance);
                }
            }
        }
    }
}
