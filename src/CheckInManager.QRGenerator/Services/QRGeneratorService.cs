using System.Drawing;

using CheckInManager.Core.Models;
using CheckInManager.QRGenerator.Enums;
using CheckInManager.QRGenerator.Services.Interfaces;

using SkiaSharp;

using ZXing;
using ZXing.QrCode;
using ZXing.Rendering;
using ZXing.SkiaSharp.Rendering;

using static ZXing.Rendering.SvgRenderer;

namespace CheckInManager.QRGenerator.Services;

/// <summary>
/// <see cref="IQRGeneratorService"/> implement.
/// </summary>
public sealed class QRGeneratorService : IQRGeneratorService
{
    private readonly Size DefaultQRSize = new(800, 800);

    /// <inheritdoc //>
    public string CreateVector(string content, Size size, int margin = IQRGeneratorService.DefaultMargin)
    {
        return Create<SvgRenderer, SvgImage>(content, size, margin).Content;
    }

    /// <inheritdoc //>
    public ReadOnlySpan<byte> CreateImage(ImageType imageType, string content, Size size, int margin = IQRGeneratorService.DefaultMargin)
    {
        using var skBitmap = Create<SKBitmapRenderer, SKBitmap>(content, size, margin);
        var format = ConvertToSkia(imageType);

        return skBitmap.Encode(format, 100).AsSpan();
    }

    /// <inheritdoc //>
    public ReadOnlySpan<byte> CreateFrom(MeetUpNameTagModel model)
    {
        // todo: 데이터 셋팅.
        var content = $"{model.Name},{model.Company}";

        return CreateImage(ImageType.Png, content, DefaultQRSize);
    }

    private TOutput Create<TRenderer, TOutput>(string content, Size size, int margin = 0)
        where TRenderer : IBarcodeRenderer<TOutput>, new()
        where TOutput : class
    {
        if (size.IsEmpty)
        {
            throw new ArgumentException("Size couldn't empty.");
        }

        if (string.IsNullOrWhiteSpace(content))
        {
            throw new ArgumentNullException(nameof(content));
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
