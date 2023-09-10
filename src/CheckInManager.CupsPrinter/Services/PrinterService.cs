using System.Diagnostics;

using CheckInManager.CupsPrinter.Core;
using CheckInManager.CupsPrinter.Models;
using CheckInManager.CupsPrinter.Services.Interfaces;
using CheckInManager.CupsPrinter.Structures;

using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CheckInManager.CupsPrinter.Services;

/// <summary>
/// Printer Service.
/// </summary>
public sealed class PrinterService : IPrinterService
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PrinterService()
    {
        // We're used only community level.
        QuestPDF.Settings.License = LicenseType.Community;
    }

    /// <inheritdoc />
    public void SamplePrint()
    {
        var pdfPath = "sample.pdf";
        var paperType = PaperType.W80H56;
        var model = new MeetUpNameTagModel
        {
            Name = "User Name",
            Company = "Cloud Bandwagon"
        };
        var document = new MeetUpNameTagDocument(model, paperType);
        document.GeneratePdf(pdfPath);

        var command = CupsArgumentBuilder.CreateCommand(paperType, pdfPath);

        Process.Start(command);
    }
}
