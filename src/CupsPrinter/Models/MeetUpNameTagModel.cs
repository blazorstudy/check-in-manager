namespace CupsPrinter.Models;

/// <summary>
/// Meet-Up name tag model.
/// </summary>
public sealed class MeetUpNameTagModel
{
    /// <summary>
    /// Name.
    /// </summary>
    public string? Name { get; init; }

    /// <summary>
    /// Personal.
    /// </summary>
    public string? Company { get; init; } = "개인";
}
