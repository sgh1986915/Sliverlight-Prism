using System.Collections.Generic;
using Telerik.Windows.Controls.ScheduleView;

namespace Procbel.Apps.Silverlight.Helpers
{
    public class ScheduleViewSingleSelectionBehavior : AppointmentSelectionBehavior
    {
        protected override IEnumerable<IOccurrence> GetSelectedAppointments(AppointmentSelectionState state, IOccurrence target)
        {
            return new List<IOccurrence> { target };
        }
    }
}
