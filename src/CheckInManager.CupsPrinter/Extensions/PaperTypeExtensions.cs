using System.Reflection;

using CheckInManager.CupsPrinter.Attributes;
using CheckInManager.CupsPrinter.Structures;

namespace CheckInManager.CupsPrinter.Extensions;

/// <summary>
/// <see cref="PaperType"/> Extensions.
/// </summary>
public static class PaperTypeExtensions
{
    /// <summary>
    /// Get paper media name.
    /// </summary>
    /// <param name="paperType">paperType.</param>
    /// <returns>media name or null.</returns>
    public static string? GetMediaName(this PaperType paperType)
    {
        var fieldName = Enum.GetName(paperType)!;
        var mediaNameAttr = typeof(PaperType).GetField(fieldName)?.GetCustomAttribute<MediaNameAttribute>();

        return mediaNameAttr?.MediaName;
    }

    /// <summary>
    /// Get paper width.
    /// </summary>
    /// <param name="paperType">paperType.</param>
    /// <returns>width.</returns>
    public static int GetWidth(this PaperType paperType)
    {
        return paperType switch
        {
            PaperType.Custom => throw new NotSupportedException(),
            _ => 80,
        };
    }

    /// <summary>
    /// Get paper height.
    /// </summary>
    /// <param name="paperType">paperType.</param>
    /// <returns>height.</returns>
    public static int GetHeight(this PaperType paperType)
    {
        return paperType switch
        {
            PaperType.W80H28 => 28,
            PaperType.W80H56 => 56,
            PaperType.W80H80 => 80,
            PaperType.W80H104 => 104,
            PaperType.W80H136 => 136,
            _ => throw new NotSupportedException(),
        };
    }
}
