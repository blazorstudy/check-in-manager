using System.Drawing;

using CheckInManager.QRGenerator.Enums;

namespace CheckInManager.QRGenerator.Services.Interfaces;

/// <summary>
/// QR generator service.
/// </summary>
public interface IQRGeneratorService
{
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
    /// qrService.Generate(ImageType.Png, qrContent, qrSize);
    ///
    /// // Method 2: Create qr vector image with margin.
    /// qrService.Generate(ImageType.Png, qrContent, qrSize, 3);
    /// ]]>
    /// <code/>
    /// </example>
    byte[] Generate(ImageType imageType, string content, Size? size = null, int? margin = null);

    /// <summary>
    /// Create qr code to binary image.
    /// </summary>
    /// <typeparam name="T">Type of content.</typeparam>
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
    /// qrService.Generate(ImageType.Png, qrContent, qrSize);
    ///
    /// // Method 2: Create qr vector image with margin.
    /// qrService.Generate(ImageType.Png, qrContent, qrSize, 3);
    /// ]]>
    /// <code/>
    /// </example>
    byte[] Generate<T>(ImageType imageType, T content, Size? size = null, int? margin = null);
}
