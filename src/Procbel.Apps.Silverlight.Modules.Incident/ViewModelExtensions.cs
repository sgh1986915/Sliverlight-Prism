using Procbel.Apps.Model.Main;
using Procbel.Apps.Silverlight.Modules.Incidencias.Models;
using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.Modules.Incidencias
{
    public static class ViewModelExtensions
    {
        public static TicketComment ConvertToEntity(this TicketCommentObject obj)
        {
            return new TicketComment
            {
                TicketId = obj.TicketId,
                CommentId = obj.CommentId,
                Comment = obj.Comment,
                CommentEvent = obj.CommentEvent,
                CommentedBy = obj.CommentedBy,
                CommentedDate = obj.CommentedDate,
                IsHtml = obj.IsHtml,
                Version = obj.Version
            };
        }

        public static Ticket ConvertToEntity(this TicketObject obj)
        {
            return new Ticket
            {
                TicketId = obj.TicketId,
                Title = obj.Title,
                Details = obj.Details,
                IsHtml = obj.IsHtml,
                TagList = obj.TagList,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                Owner = obj.Owner,
                AssignedTo = obj.AssignedTo,
                CurrentStatusDate = obj.CurrentStatusDate,
                CurrentStatusSetBy = obj.CurrentStatusSetBy,
                LastUpdateBy = obj.LastUpdateBy,
                LastUpdateDate = obj.LastUpdateDate,
                Priority = obj.Priority,
                AffectsCustomer = obj.AffectsCustomer,
                PublishedToKb = obj.PublishedToKb,
                Version = obj.Version,
                DimCreatedDateId = obj.DimCreatedDateId,
                DimCreatedTimeId = obj.DimCreatedTimeId,
                DimCurrentStatusDateId = obj.DimCurrentStatusDateId,
                DimCurrentStatusTimeId  = obj.DimCurrentStatusTimeId,
                SiteId = obj.SiteId,
                TicketCategoryTicketCategoryId = obj.TicketCategoryTicketCategoryId,
                TicketTypeTicketTypeId = obj.TicketTypeTicketTypeId,
                TicketStatusTicketStatusId = obj.TicketStatusTicketStatusId,
                //Navigation Properties
                TicketType = obj.TicketType,
                TicketCategory = obj.TicketCategory
            };
        }

        public static TicketObject ConvertToEntity(this Ticket obj)
        {
            return new TicketObject
            {
                TicketId = obj.TicketId,
                Title = obj.Title,
                TagList = obj.TagList,
                Details = obj.Details,
                IsHtml = obj.IsHtml,
                CreatedBy = obj.CreatedBy,
                CreatedDate = obj.CreatedDate,
                Owner = obj.Owner,
                AssignedTo = obj.AssignedTo,
                CurrentStatusDate = obj.CurrentStatusDate,
                CurrentStatusSetBy = obj.CurrentStatusSetBy,
                LastUpdateBy = obj.LastUpdateBy,
                LastUpdateDate = obj.LastUpdateDate,
                Priority = obj.Priority,
                AffectsCustomer = obj.AffectsCustomer,
                PublishedToKb = obj.PublishedToKb,
                Version = obj.Version,
                DimCreatedDateId = obj.DimCreatedDateId,
                DimCreatedTimeId = obj.DimCreatedTimeId,
                DimCurrentStatusDateId = obj.DimCurrentStatusDateId,
                DimCurrentStatusTimeId = obj.DimCurrentStatusTimeId,
                SiteId = obj.SiteId,
                TicketCategoryTicketCategoryId = obj.TicketCategoryTicketCategoryId,
                TicketTypeTicketTypeId = obj.TicketTypeTicketTypeId,
                TicketStatusTicketStatusId = obj.TicketStatusTicketStatusId,
                Importance = obj.ImportanceBrush,
                //Navigation Properties
                TicketType = obj.TicketType,
                TicketCategory = obj.TicketCategory
            };
        }
    }
}
