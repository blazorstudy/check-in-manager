using System.ComponentModel;

using CheckInManager.CupsPrinter.Attributes;

namespace CheckInManager.CupsPrinter.Structures;

/// <summary>
/// Paper Supported Types.
/// </summary>
/// <remarks>
/// CUPS, <c>lpoptions -p "nemonic_MIP_001" -l</c>
/// </remarks>
/// <example>
/// <![CDATA[
/// 80x28mm.Transverse
/// 80x56mm.Transverse
/// 80x80mm.Fullbleed
/// 80x104mm.Fullbleed
/// 80x136mm.Fullbleed
/// Custom.WIDTHxHEIGH
/// ]]>
/// </example>
[DefaultValue(PaperType.W80H80)]
public enum PaperType
{
    /// <summary>
    /// 3x1
    /// </summary>
    [MediaName("80x28mm.Transverse")]
    W80H28,

    /// <summary>
    /// 3x2
    /// </summary>
    [MediaName("80x56mm.Transverse")]
    W80H56,

    /// <summary>
    /// 3x3
    /// </summary>
    [MediaName("80x280m.Fullbleed")]
    W80H80,

    /// <summary>
    /// 3x4
    /// </summary>
    [MediaName("80x104mm.Fullbleed")]
    W80H104,

    /// <summary>
    /// 3x5
    /// </summary>
    [MediaName("80x136mm.Fullbleed")]
    W80H136,

    /// <summary>
    /// Custom
    /// </summary>
    [MediaName("Custom.WIDTHxHEIGH")]
    Custom
}
