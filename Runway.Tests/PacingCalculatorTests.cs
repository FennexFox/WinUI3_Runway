using Runway.Core;

namespace Runway.Tests;

[TestClass]
public class PacingCalculatorTests
{
    [TestMethod]
    public void Calculate_ReturnsSafe_WhenRemainingPercentIsHigh()
    {
        var calculator = new PacingCalculator();
        var now = new DateTime(2026, 1, 1, 12, 0, 0);

        var snapshot = new WorkspaceSnapshot
        {
            Workspace = WorkspaceKind.Personal,
            RemainingPercent = 80,
            CapturedAt = now,
            ResetAt = now.AddHours(8)
        };

        var result = calculator.Calculate(snapshot, now);

        Assert.AreEqual(RunwayStatus.Safe, result.Status);
        Assert.IsGreaterThan(0, result.SafeUsagePerHour);
    }
}