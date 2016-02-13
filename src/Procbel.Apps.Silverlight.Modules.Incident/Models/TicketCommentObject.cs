using Procbel.Apps.Silverlight.Modules.Incidencias.Infrastructure;
using System;
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
    public class TicketCommentObject : ValidatingObject
    {
        #region Fields and constructor

        string commentEvent;
        string comment;

        public TicketCommentObject()
        {
            this.IsHtml = false;
            this.commentEvent = string.Empty;
            this.Comment = string.Empty;
            //TODO: 01 - Add a CommentBy to TicketAttachement.
            this.CommentedBy = "Silverlight";
            this.CommentedDate = DateTime.Today;
            this.Version = Guid.NewGuid();
        }

        #endregion

        public int TicketId { get; set; }
        public int CommentId { get; set; }
        public bool IsHtml { get; set; }
        public string CommentedBy { get; set; }
        public DateTime CommentedDate { get; set; }
        public Guid Version { get; set; }

        [Required(ErrorMessage = "The Comment Event field is required")]
        [StringLength(500, MinimumLength = 1, ErrorMessage = "The Title must be at least 1 and at most 20 characters long")]
        public string CommentEvent
        {
            get { return this.commentEvent; }
            set
            {
                if (value != this.commentEvent)
                {
                    this.commentEvent = value;
                    this.RaisePropertyChanged(() => this.CommentEvent);
                }
            }
        }

        [Required(ErrorMessage = "The Comment field is required")]
        public string Comment
        {
            get { return this.comment; }
            set
            {
                if (value != this.comment)
                {
                    this.comment = value;
                    this.RaisePropertyChanged(() => this.Comment);
                }
            }
        }
    }
}
