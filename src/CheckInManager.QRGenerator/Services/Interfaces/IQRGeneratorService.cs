using System.Drawing;

using CheckInManager.Core.Models;
using CheckInManager.QRGenerator.Enums;

namespace CheckInManager.QRGenerator.Services.Interfaces;

/// <summary>
/// QR generator service.
/// </summary>
public interface IQRGeneratorService
{
    /// <summary>
    /// Default border margin.
    /// </summary>
    protected const int DefaultMargin = 1;

    /// <summary>
    /// Create qr code to vector image.
    /// </summary>
    /// <param name="content">content.</param>
    /// <param name="size">size.</param>
    /// <param name="margin">margin.</param>
    /// <returns>
    /// Vector image script.
    /// </returns>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// // Create new qr service.
    /// var qrService = new QRGeneratorService();
    ///
    /// // Create qr size, w:800, h:800
    /// var qrSize = new Size(800, 800);
    ///
    /// // Define qr content.
    /// var qrContent = "http://localhost:7071/api/someting";
    ///
    /// // Method 1: Create qr vector image with default margin(value: 1).
    /// qrService.CreateSvg(qrContent, qrSize);
    ///
    /// // Method 2: Create qr vector image with margin.
    /// qrService.CreateSvg(qrContent, qrSize, 3);
    /// ]]>
    /// <code/>
    /// </example>
    string CreateVector(string content, Size size, int margin = DefaultMargin);

    /// <summary>
    /// Create qr code to binary image.
    /// </summary>
    /// <param name="imageType">save image type.</param>
    /// <param name="content">content.</param>
    /// <param name="size">size.</param>
    /// <param name="margin">margin.</param>
    /// <returns>
    /// Image data.
    /// </returns>
    /// <example>
    /// <code>
    /// <![CDATA[
    /// // Create new qr service.
    /// var qrService = new QRGeneratorService();
    ///
    /// // Create qr size, w:800, h:800
    /// var qrSize = new Size(800, 800);
    ///
    /// // Define qr content.
    /// var qrContent = "http://localhost:7071/api/someting";
    ///
    /// // Method 1: Create qr vector image with default margin(value: 1).
    /// qrService.CreateImage(ImageType.Png, qrContent, qrSize);
    ///
    /// // Method 2: Create qr vector image with margin.
    /// qrService.CreateImage(ImageType.Png, qrContent, qrSize, 3);
    /// ]]>
    /// <code/>
    /// </example>
    ReadOnlySpan<byte> CreateImage(ImageType imageType, string content, Size size, int margin = DefaultMargin);

    /// <summary>
    /// Create qr code image from <see cref="MeetUpNameTagModel" />.
    /// </summary>
    /// <param name="model">model.</param>
    /// <returns>
    /// Image data.
    /// </returns>
    ReadOnlySpan<byte> CreateFrom(MeetUpNameTagModel model);
}