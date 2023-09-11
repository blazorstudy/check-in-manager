using CheckInManager.Core.Models;

namespace CheckInManager.CupsPrinter.Services.Interfaces;

/// <summary>
/// Printer service interface.
/// </summary>
public interface IPrinterService
{
    /// <summary>
    /// Print with model.
    /// </summary>
    /// <param name="model">model.</param>
    void Print(MeetUpNameTagModel model);
}
