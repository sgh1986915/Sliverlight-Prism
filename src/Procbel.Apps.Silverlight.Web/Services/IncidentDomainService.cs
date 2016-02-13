
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
    using Procbel.Apps.Model.Main;
    using System.Data.Entity;


    // Implements application logic using the AppsMainContainer context.
    // TODO: Add your application logic to these methods or in additional methods.
    // TODO: Wire up authentication (Windows/ASP.NET Forms) and uncomment the following to disable anonymous access
    // Also consider adding roles to restrict access as appropriate.
    // [RequiresAuthentication]
    [EnableClientAccess()]
    [CLSCompliant(false)]
    public class IncidentDomainService : DbDomainService<AppsMainContainer>
    {

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Tickets' query.
        public IQueryable<Ticket> GetTickets()
        {
            return this.DbContext.Tickets
                .Include(o => o.TicketType)
                .Include(o => o.TicketCategory)
                .Include(o => o.TicketAttachments)
                .Include(o => o.TicketStatus)
                .Include(o => o.TicketComments)
                .OrderBy(o => o.TicketId);
        }

        public void InsertTicket(Ticket ticket)
        {
            DbEntityEntry<Ticket> entityEntry = this.DbContext.Entry(ticket);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.Tickets.Add(ticket);
            }
        }

        public void UpdateTicket(Ticket currentTicket)
        {
            this.DbContext.Tickets.AttachAsModified(currentTicket, this.ChangeSet.GetOriginal(currentTicket), this.DbContext);
        }

        public void DeleteTicket(Ticket ticket)
        {
            DbEntityEntry<Ticket> entityEntry = this.DbContext.Entry(ticket);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.Tickets.Attach(ticket);
                this.DbContext.Tickets.Remove(ticket);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketAttachments' query.
        public IQueryable<TicketAttachment> GetTicketAttachments()
        {
            return this.DbContext.TicketAttachments.OrderByDescending(o => o.UploadedDate);
        }

        public void InsertTicketAttachment(TicketAttachment ticketAttachment)
        {
            DbEntityEntry<TicketAttachment> entityEntry = this.DbContext.Entry(ticketAttachment);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketAttachments.Add(ticketAttachment);
            }
        }

        public void UpdateTicketAttachment(TicketAttachment currentTicketAttachment)
        {
            this.DbContext.TicketAttachments.AttachAsModified(currentTicketAttachment, this.ChangeSet.GetOriginal(currentTicketAttachment), this.DbContext);
        }

        public void DeleteTicketAttachment(TicketAttachment ticketAttachment)
        {
            DbEntityEntry<TicketAttachment> entityEntry = this.DbContext.Entry(ticketAttachment);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketAttachments.Attach(ticketAttachment);
                this.DbContext.TicketAttachments.Remove(ticketAttachment);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketCategorySet' query.
        public IQueryable<TicketCategory> GetTicketCategorySet()
        {
            return this.DbContext.TicketCategorySet;
        }

        public void InsertTicketCategory(TicketCategory ticketCategory)
        {
            DbEntityEntry<TicketCategory> entityEntry = this.DbContext.Entry(ticketCategory);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketCategorySet.Add(ticketCategory);
            }
        }

        public void UpdateTicketCategory(TicketCategory currentTicketCategory)
        {
            this.DbContext.TicketCategorySet.AttachAsModified(currentTicketCategory, this.ChangeSet.GetOriginal(currentTicketCategory), this.DbContext);
        }

        public void DeleteTicketCategory(TicketCategory ticketCategory)
        {
            DbEntityEntry<TicketCategory> entityEntry = this.DbContext.Entry(ticketCategory);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketCategorySet.Attach(ticketCategory);
                this.DbContext.TicketCategorySet.Remove(ticketCategory);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketComments' query.
        public IQueryable<TicketComment> GetTicketComments()
        {
            return this.DbContext.TicketComments.OrderByDescending(o => o.CommentedDate);
        }

        public void InsertTicketComment(TicketComment ticketComment)
        {
            DbEntityEntry<TicketComment> entityEntry = this.DbContext.Entry(ticketComment);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketComments.Add(ticketComment);
            }
        }

        public void UpdateTicketComment(TicketComment currentTicketComment)
        {
            this.DbContext.TicketComments.AttachAsModified(currentTicketComment, this.ChangeSet.GetOriginal(currentTicketComment), this.DbContext);
        }

        public void DeleteTicketComment(TicketComment ticketComment)
        {
            DbEntityEntry<TicketComment> entityEntry = this.DbContext.Entry(ticketComment);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketComments.Attach(ticketComment);
                this.DbContext.TicketComments.Remove(ticketComment);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketEventNotifications' query.
        public IQueryable<TicketEventNotification> GetTicketEventNotifications()
        {
            return this.DbContext.TicketEventNotifications;
        }

        public void InsertTicketEventNotification(TicketEventNotification ticketEventNotification)
        {
            DbEntityEntry<TicketEventNotification> entityEntry = this.DbContext.Entry(ticketEventNotification);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketEventNotifications.Add(ticketEventNotification);
            }
        }

        public void UpdateTicketEventNotification(TicketEventNotification currentTicketEventNotification)
        {
            this.DbContext.TicketEventNotifications.AttachAsModified(currentTicketEventNotification, this.ChangeSet.GetOriginal(currentTicketEventNotification), this.DbContext);
        }

        public void DeleteTicketEventNotification(TicketEventNotification ticketEventNotification)
        {
            DbEntityEntry<TicketEventNotification> entityEntry = this.DbContext.Entry(ticketEventNotification);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketEventNotifications.Attach(ticketEventNotification);
                this.DbContext.TicketEventNotifications.Remove(ticketEventNotification);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketStatusSet' query.
        public IQueryable<TicketStatus> GetTicketStatusSet()
        {
            return this.DbContext.TicketStatusSet;
        }

        public void InsertTicketStatus(TicketStatus ticketStatus)
        {
            DbEntityEntry<TicketStatus> entityEntry = this.DbContext.Entry(ticketStatus);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketStatusSet.Add(ticketStatus);
            }
        }

        public void UpdateTicketStatus(TicketStatus currentTicketStatus)
        {
            this.DbContext.TicketStatusSet.AttachAsModified(currentTicketStatus, this.ChangeSet.GetOriginal(currentTicketStatus), this.DbContext);
        }

        public void DeleteTicketStatus(TicketStatus ticketStatus)
        {
            DbEntityEntry<TicketStatus> entityEntry = this.DbContext.Entry(ticketStatus);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketStatusSet.Attach(ticketStatus);
                this.DbContext.TicketStatusSet.Remove(ticketStatus);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketTags' query.
        public IQueryable<TicketTag> GetTicketTags()
        {
            return this.DbContext.TicketTags.OrderBy(o => o.TicketTagId);
        }

        public void InsertTicketTag(TicketTag ticketTag)
        {
            DbEntityEntry<TicketTag> entityEntry = this.DbContext.Entry(ticketTag);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketTags.Add(ticketTag);
            }
        }

        public void UpdateTicketTag(TicketTag currentTicketTag)
        {
            this.DbContext.TicketTags.AttachAsModified(currentTicketTag, this.ChangeSet.GetOriginal(currentTicketTag), this.DbContext);
        }

        public void DeleteTicketTag(TicketTag ticketTag)
        {
            DbEntityEntry<TicketTag> entityEntry = this.DbContext.Entry(ticketTag);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketTags.Attach(ticketTag);
                this.DbContext.TicketTags.Remove(ticketTag);
            }
        }

        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'TicketTypeSet' query.
        public IQueryable<TicketType> GetTicketTypeSet()
        {
            return this.DbContext.TicketTypeSet;
        }

        public void InsertTicketType(TicketType ticketType)
        {
            DbEntityEntry<TicketType> entityEntry = this.DbContext.Entry(ticketType);
            if ((entityEntry.State != EntityState.Detached))
            {
                entityEntry.State = EntityState.Added;
            }
            else
            {
                this.DbContext.TicketTypeSet.Add(ticketType);
            }
        }

        public void UpdateTicketType(TicketType currentTicketType)
        {
            this.DbContext.TicketTypeSet.AttachAsModified(currentTicketType, this.ChangeSet.GetOriginal(currentTicketType), this.DbContext);
        }

        public void DeleteTicketType(TicketType ticketType)
        {
            DbEntityEntry<TicketType> entityEntry = this.DbContext.Entry(ticketType);
            if ((entityEntry.State != EntityState.Deleted))
            {
                entityEntry.State = EntityState.Deleted;
            }
            else
            {
                this.DbContext.TicketTypeSet.Attach(ticketType);
                this.DbContext.TicketTypeSet.Remove(ticketType);
            }
        }


        // TODO:
        // Consider constraining the results of your query method.  If you need additional input you can
        // add parameters to this method or create additional query methods with different names.
        // To support paging you will need to add ordering to the 'Code' query.
        public IEnumerable<Code> GetCodes()
        {
            return this.DbContext.Code.Where(o => o.CodeType == "Priority").ToList();
        }
    }
}


