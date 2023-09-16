using System.Drawing;

using CheckInManager.QRGenerator.Enums;
using CheckInManager.QRGenerator.Services.Interfaces;

using Newtonsoft.Json;

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
    public byte[] Generate<T>(ImageType imageType, T content, Size? size = null, int? margin = null)
    {
        var serialised = JsonConvert.SerializeObject(content, formatting: Formatting.Indented);

        return this.Generate(imageType, serialised, size, margin);
    }

    /// <inheritdoc //>
    public byte[] Generate(ImageType imageType, string content, Size? size = null, int? margin = null)
    {
        using var skBitmap = this.Create<SKBitmapRenderer, SKBitmap>(content, size ?? defaultQRSize, margin ?? DefaultMargin);
        var format = this.ConvertToSkia(imageType);

        return skBitmap.Encode(format, 100).AsSpan().ToArray();
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

        qrWriter.Options.Hints[EncodeHintType.CHARACTER_SET] = System.Text.Encoding.UTF8.WebName.ToUpper();

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
