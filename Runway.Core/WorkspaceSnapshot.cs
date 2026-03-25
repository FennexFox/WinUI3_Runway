using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runway.Core
{
    public class WorkspaceSnapshot
    {
        public WorkspaceKind Workspace { get; set; }
        public double RemainingPercent { get; set; }
        public DateTime CapturedAt { get; set; }
        public DateTime ResetAt { get; set; }
    }
}
