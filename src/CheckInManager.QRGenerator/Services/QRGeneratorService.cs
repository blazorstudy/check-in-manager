using System.Drawing;

using CheckInManager.QRGenerator.Enums;
using CheckInManager.QRGenerator.Services.Interfaces;

using SkiaSharp;

using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;
using ZXing.SkiaSharp.Rendering;

namespace CheckInManager.QRGenerator.Services;

/// <summary>
/// <see cref="IQRGeneratorService"/> implement.
/// </summary>
public sealed class QRGeneratorService : IQRGeneratorService
{
    private const int DefaultMargin = 1;
    private static Size defaultQRSize = new(800, 800);

    /// <inheritdoc //>
    public ReadOnlySpan<byte> Generate(ImageType imageType, string content, Size? size = null, int? margin = null)
    {
        using var skBitmap = Create<SKBitmapRenderer, SKBitmap>(content, size ?? defaultQRSize, margin ?? DefaultMargin);
        var format = ConvertToSkia(imageType);

        return skBitmap.Encode(format, 100).AsSpan();
    }

    private TOutput Create<TRenderer, TOutput>(string content, Size size, int margin)
        where TRenderer : IBarcodeRenderer<TOutput>, new()
        where TOutput : class
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentNullException(nameof(content));
        }

        if (size.IsEmpty || size.Width < 1 || size.Height < 1)
        {
            throw new ArgumentException("Size couldn't be empty.");
        }

        var qrWriter = new BarcodeWriter<TOutput>
        {
            Format = BarcodeFormat.QR_CODE,
            Renderer = new TRenderer(),
            Options = new QrCodeEncodingOptions
            {
                Height = size.Height,
                Width = size.Width,
                Margin = margin
            },
        };

        return qrWriter.Write(content);
    }

    private SKEncodedImageFormat ConvertToSkia(ImageType imageType)
    {
        return imageType switch
        {
            ImageType.Png => SKEncodedImageFormat.Png,
            ImageType.Jpeg => SKEncodedImageFormat.Jpeg,

            // ex, svg
            // https://github.com/rust-skia/rust-skia/issues/389
            _ => throw new NotSupportedException($"not supported type: {imageType}"),
        };
    }
}
