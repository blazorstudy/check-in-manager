using System.Diagnostics;
using CupsPrinter.Core;
using CupsPrinter.Models;
using CupsPrinter.Services.Interfaces;
using CupsPrinter.Structures;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CupsPrinter.Services;

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
            Personal = "Cloud Bandwagon"
        };
        var document = new MeetUpNameTagDocument(model, paperType);
        document.GeneratePdf(pdfPath);

        var command = CupsArgumentBuilder.CreateCommand(paperType, pdfPath);

        Process.Start(command);
    }
}
