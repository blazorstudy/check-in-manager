using System.Drawing;

using CheckInManager.QRGenerator.Enums;
using CheckInManager.QRGenerator.Services;

namespace CheckInManager.QRGenerator.Tests.Services;

[TestClass]
public class QRGeneratorServiceTests
{
    [DataTestMethod]
    [DataRow(ImageType.Png, "content", -1, -1)]
    [DataRow(ImageType.Png, "content", 0, 0)]
    [DataRow(ImageType.Png, "content", 0, 1)]
    [DataRow(ImageType.Png, "content", 1, 0)]
    public void Given_Parameters_When_Generate_Then_ThrowArgumentException(
        ImageType imageType, string content, int? width = null, int? height = null, int? margin = null)
    {
        var size = (Size?)(width != null && height != null ? new Size(width.Value, height.Value) : null);
        var service = new QRGeneratorService();

        Assert.ThrowsException<ArgumentException>(() => service.Generate(imageType, content, size, margin));
    }

    [DataTestMethod]
    [DataRow(ImageType.Png, null)]
    [DataRow(ImageType.Png, "")]
    public void Given_Parameters_When_Generate_Then_ThrowArgumentNullException(
        ImageType imageType, string content, int? width = null, int? height = null, int? margin = null)
    {
        var size = (Size?)(width != null && height != null ? new Size(width.Value, height.Value) : null);
        var service = new QRGeneratorService();

        Assert.ThrowsException<ArgumentNullException>(() => service.Generate(imageType, content, size, margin));
    }
}
