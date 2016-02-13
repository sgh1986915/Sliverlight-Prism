using System;
using System.Net;
using System.ServiceModel.DomainServices.Client;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Procbel.Apps.Model.Main
{
    public partial class Ticket : Entity
    {
        public int Importance
        {
            get 
            {
                return CalculateImportance();
            }
        }

        public int ImportanceBrush
        {
            get
            {
                return CalculateImportance();
            }
        }

        private int CalculateImportance()
        {
            int c2, c3, c4, c5, c6;
            c2 = this.AffectsCustomer ? 1 : 0;
            c4 = (this.TicketStatus == null) ? 0 : (int)this.TicketStatus.ImportanceSize;
            c5 = GetDaysBetweenDates(this.CreatedDate);
            c6 = GetDaysBetweenDates(this.LastUpdateDate);
            switch (this.Priority)
            {
                case "High":
                    c3 = 3;
                    break;
                case "Midium":
                    c3 = 2;
                    break;
                default:
                    c3 = 1;
                    break;
            }
            return (c2 * 40 + (c3 / 3) * 20 + (c5 / 90) * 20 + (c6 / 30) * 20) * c4 / 100;
        }

        partial void OnAffectsCustomerChanged()
        {
            this.RaisePropertyChanged("Importance");
            this.RaisePropertyChanged("ImportanceBrush");
        }

        partial void OnLastUpdateDateChanged()
        {
            this.RaisePropertyChanged("Importance");
            this.RaisePropertyChanged("ImportanceBrush");
        }

        partial void OnPriorityChanged()
        {
            this.RaisePropertyChanged("Importance");
            this.RaisePropertyChanged("ImportanceBrush");
        } 

        private int GetDaysBetweenDates(DateTime firstDate)
        {
            var secondDate = DateTime.Today;

            return secondDate.Subtract(firstDate).Days;
        }
    }
}
