using System.Diagnostics;
using System.Reflection;
using CheckInManager.Core.Models;
using CheckInManager.CupsPrinter.Core;
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
    private const string TempFolder = "temp";
    private const PaperType DefaultPaperType = PaperType.W80H56;

    /// <summary>
    /// Constructor.
    /// </summary>
    public PrinterService()
    {
        // We're used only community level.
        QuestPDF.Settings.License = LicenseType.Community;
    }

    /// <inheritdoc />

    public void Print(MeetUpNameTagModel model)
    {
        var pdfPath = CreateUniqueName();
        var document = new MeetUpNameTagDocument(model, DefaultPaperType);


        // Create pdf file.
        document.GeneratePdf(pdfPath);

        // Run 'lp' command
        Process.Start(CupsArgumentBuilder.CreateCommand(DefaultPaperType, pdfPath));
    }

    private static string CreateUniqueName()
    {
        var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!;
        var fileName = $"{DateTime.Now:yyyy-MM-dd__hh_mm_ss}_{Environment.TickCount}.pdf";
        var saveFolder = Path.Combine(basePath, TempFolder);

        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }

        return Path.Combine(saveFolder, fileName);
    }
}
