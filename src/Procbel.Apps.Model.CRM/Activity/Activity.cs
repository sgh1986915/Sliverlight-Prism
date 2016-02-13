using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ServiceModel.DomainServices.Server;

namespace Procbel.Apps.Model.CRM
{
    public partial class Activity
    {
        public ActivityType TypeAsEnum
        {
            get
            {
                if (this.Type.HasValue)
                {
                    return (ActivityType)this.Type.Value;
                }
                return ActivityType.Call;
            }
            set
            {
                //intentionally empty            	
            }
        }

        public PriorityType PriorityType
        {
            get
            {
                if (this.Priority.HasValue)
                {
                    return (PriorityType)this.Priority.Value;
                }
                return PriorityType.Low;
            }
            set
            {
                //intentionally empty
            }
        }

        public ActivityStatusType StatusType
        {
            get
            {
                if (this.Status.HasValue)
                {
                    return (ActivityStatusType)this.Status.Value;
                }
                return ActivityStatusType.NotStarted;
            }
            set
            {
                //intentionally empty
            }
        }

        public bool IsOverdue
        {
            get
            {
                return this.DueDate <= DateTime.Now;
            }
            set
            {
                //intentionally empty            	
            }
        }

        /// <summary>
        /// A valid creation date is before DateTime.Now
        /// </summary>
        //public bool IsCreationDateValid
        //{
        //    get
        //    {
        //        return this.DateCreated <= DateTime.Now;
        //    }
        //    private set
        //    {
        //        //intentionally empty
        //    }
        //}

    }

    [System.ComponentModel.DataAnnotations.MetadataTypeAttribute(typeof(Activity.ActivityMetadata))]
    public partial class Activity
    {
        internal sealed class ActivityMetadata
        {
            public ActivityMetadata()
            {
            }

            [Include]
            [System.ComponentModel.DataAnnotations.Association("Activities-opportunity-association", "OpportunityID", "OpportunityID")]
            public Company Opportunity { get; set; }
        }
    }
}
