using Runway.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Runway.Core;

public class PacingCalculator
{
    public WorkspacePacingResult Calculate(WorkspaceSnapshot snapshot, DateTime now)
    {
        if (snapshot.ResetAt <= now)
        {
            return new WorkspacePacingResult
            {
                Workspace = snapshot.Workspace,
                Status = RunwayStatus.Unknown,
                HoursUntilReset = 0,
                SafeUsagePerHour = 0,
                SummaryMessage = "리셋 시각이 현재보다 이전입니다."
            };
        }

        var hoursUntilReset = (snapshot.ResetAt - now).TotalHours;
        var safeUsagePerHour = hoursUntilReset > 0
            ? snapshot.RemainingPercent / hoursUntilReset
            : 0;

        var status = snapshot.RemainingPercent switch
        {
            <= 10 => RunwayStatus.Critical,
            <= 30 => RunwayStatus.Warning,
            _ => RunwayStatus.Safe
        };

        return new WorkspacePacingResult
        {
            Workspace = snapshot.Workspace,
            Status = status,
            HoursUntilReset = hoursUntilReset,
            SafeUsagePerHour = safeUsagePerHour,
            SummaryMessage = $"리셋까지 {hoursUntilReset:F1}시간, 시간당 {safeUsagePerHour:F2}% 사용 가능"
        };
    }
}
