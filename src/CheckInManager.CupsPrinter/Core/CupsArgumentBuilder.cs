﻿using System.Diagnostics;

using CheckInManager.CupsPrinter.Extensions;
using CheckInManager.CupsPrinter.Structures;

namespace CheckInManager.CupsPrinter.Core;

/// <summary>
/// CUPS arguments builder.
/// </summary>
public sealed class CupsArgumentBuilder
{
    /// <summary>
    /// Create cups printing command.
    /// </summary>
    /// <param name="paperType">paper type.</param>
    /// <param name="pdfPath">pdf file path.</param>
    /// <returns>cups command.</returns>
    public static ProcessStartInfo CreateCommand(PaperType paperType, string pdfPath)
    {
        if (paperType is PaperType.Custom)
        {
            throw new NotSupportedException("Custom type not supported currently.");
        }

        if (!File.Exists(pdfPath))
        {
            throw new FileNotFoundException("PDF file not found", pdfPath);
        }

        return new ProcessStartInfo
        {
            FileName = "lp",
            Arguments = $"-o {paperType.GetMediaName()} {pdfPath}",
            CreateNoWindow = true
        };
    }
}
