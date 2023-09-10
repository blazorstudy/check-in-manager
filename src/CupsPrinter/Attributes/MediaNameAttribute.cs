using System;

namespace CupsPrinter.Attributes;

/// <summary>
/// MediaName attribute.
/// </summary>
[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
public sealed class MediaNameAttribute : Attribute
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="mediaName">Media name.</param>
    public MediaNameAttribute(string mediaName)
    {
        if (string.IsNullOrWhiteSpace(mediaName))
        {
            throw new ArgumentNullException(nameof(mediaName));
        }

        MediaName = mediaName;
    }

    /// <summary>
    /// Media Name.
    /// </summary>
    public string MediaName { get; }
}
