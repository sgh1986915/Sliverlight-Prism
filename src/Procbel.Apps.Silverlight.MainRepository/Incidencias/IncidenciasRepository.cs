using Procbel.Apps.Model.Main;
//using Procbel.Apps.Silverlight.MainRepository.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Silverlight.MainRepository.Incidencias
{
    [Export]
    [PartCreationPolicy(CreationPolicy.Shared)]
    public class IncidenciasRepository : BaseRepository
    {
        public void GetTickets(Action<IEnumerable<Ticket>> callback)
        {
            this.LoadQuery<Ticket>(this.Context.GetTicketsQuery(), callback);
        }

        public void GetTicketTypeSet(Action<IEnumerable<TicketType>> callback)
        {
            this.LoadQuery<TicketType>(this.Context.GetTicketTypeSetQuery(), callback);
        }

        public void GetTicketCategorySet(Action<IEnumerable<TicketCategory>> callback)
        {
            this.LoadQuery<TicketCategory>(this.Context.GetTicketCategorySetQuery(), callback);
        }

        public void GetTicketTags(Action<IEnumerable<TicketTag>> callback)
        {
            this.LoadQuery<TicketTag>(this.Context.GetTicketTagsQuery(), callback);
        }
    }
}
