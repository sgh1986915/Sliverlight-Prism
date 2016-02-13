using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Procbel.Apps.Model.CRM.Dashboard
{
    public class DashboardStats
    {
        public IEnumerable<Opportunity> Opportunities { get; set; }
        public IEnumerable<Activity> Activities { get; set; }

        private int[] closedOpportunities;
        public int[] ClosedOpportunities
        {
            get
            {
                if (closedOpportunities == null)
                {
                    var data = from o in Opportunities
                               orderby o.EstimationCloseDate
                               where o.EstimationCloseDate <= DateTime.Now && (o.StatusType == OpportunityStatusType.ClosedLost || o.StatusType == OpportunityStatusType.ClosedWon)
                               select o;
                    var projectedData = from o in data
                                        group data by o.EstimationCloseDate.Value.Month into g
                                        select new { Month = g.Key, Count = g.Count() };
                    var values = from o in projectedData
                                 select o.Count;
                    this.closedOpportunities = values.ToArray();
                }
                return this.closedOpportunities;
            }
        }

        private int[] leads;
        public int[] Leads
        {
            get
            {
                if (this.leads == null)
                {

                    var data = from o in Opportunities
                               orderby o.DateCreated
                               where o.DateCreated <= DateTime.Now
                               && (o.StatusType == OpportunityStatusType.Open)
                               select o;
                    var projectedData = from o in data
                                        group data by o.DateCreated.Value.Month into g
                                        select new { Month = g.Key, Count = g.Count() };
                    var values = from o in projectedData
                                 select o.Count;
                    this.leads = values.ToArray();
                }
                return this.leads;
            }
        }

        public double ClosedOpportunitiesPercentage
        {
            get
            {
                if (this.ClosedOpportunities == null || this.ClosedOpportunities.Count() == 0)
                {
                    return 0;
                }
                var averageValue = this.ClosedOpportunities.Average();
                var last = this.ClosedOpportunities.Last();
                var percentage = CalculateAboveAveragePercentage(last, averageValue);
                return percentage;
            }
        }

        public double LeadsPercentage
        {
            get
            {
                if (this.Leads == null || this.Leads.Count() == 0)
                {
                    return 0;
                }
                var lastLead = this.Leads.Last();
                var averageLeadValue = this.Leads.Average();
                var percentage = CalculateAboveAveragePercentage(lastLead, averageLeadValue);
                return percentage;
            }
        }
        public int ClosedWinOpportunitiesPercentage
        {
            get
            {
                if (this.ClosedOpportunitiesCount == 0)
                {
                    return 0;
                }

                var closedWinOpportunitiesCount = this.ClosedWinOpportunitiesCount * 100 / this.ClosedOpportunitiesCount;
                return closedWinOpportunitiesCount;
            }
        }
        public int ClosedLossOpportunitiesPercentage
        {
            get
            {
                if (this.ClosedOpportunitiesCount == 0)
                {
                    return 0;
                }

                var closedLossOpportunitiesCount = this.ClosedLossOpportunitiesCount * 100 / this.ClosedOpportunitiesCount;
                return closedLossOpportunitiesCount;
            }
        }


        public int ActivitiesCount
        {
            get
            {
                var count = this.Activities.Count();
                return count;
            }
        }
        public int OpenTasksCount
        {
            get
            {
                var activityStatusOpen = ActivityStatusType.InProgress;
                return this.Activities.Count(a => a.StatusType == activityStatusOpen);
            }
        }
        public int OpportunitiesCount
        {
            get
            {
                var count = this.Opportunities.Count();
                return count;
            }
        }

        public int OpenOpportunitiesCount
        {
            get
            {
                var count = this.Opportunities.Count(o => o.StatusType == OpportunityStatusType.Open);
                return count;
            }
        }

        public int ClosedWinOpportunitiesCount
        {
            get
            {
                return this.Opportunities.Count(o => o.StatusType == OpportunityStatusType.ClosedWon);
            }
        }
        public int ClosedOpportunitiesCount
        {
            get
            {
                var closedOpportunitiesCount = this.Opportunities.Count(o => o.StatusType == OpportunityStatusType.ClosedWon || o.StatusType == OpportunityStatusType.ClosedLost);
                return closedOpportunitiesCount;
            }
        }
        public decimal TotalOpenOpportunitiesPrice
        {
            get
            {
                var totalPrice = this.Opportunities.Where(o => o.StatusType == OpportunityStatusType.Open).Sum(o => o.TotalPrice);
                return totalPrice;
            }
        }

        private int ClosedLossOpportunitiesCount
        {
            get
            {
                return this.Opportunities.Count(o => o.StatusType == OpportunityStatusType.ClosedLost);
            }
        }

        private double CalculateAboveAveragePercentage(double last, double averageValue)
        {
            var percentage = (last - averageValue) * 100 / averageValue;
            return percentage;
        }
    }
}
