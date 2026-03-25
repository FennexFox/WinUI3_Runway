using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runway.Core
{
    public class WorkspacePacingResult
    {
        public WorkspaceKind Workspace { get; set; }
        public RunwayStatus Status { get; set; }
        public double HoursUntilReset { get; set; }
        public double SafeUsagePerHour { get; set; }
        public string SummaryMessage { get; set; } = string.Empty;
    }
}
