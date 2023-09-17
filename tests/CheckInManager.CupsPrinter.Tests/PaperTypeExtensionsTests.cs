using CheckInManager.CupsPrinter.Extensions;
using CheckInManager.CupsPrinter.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CheckInManager.CupsPrinter.Tests;

[TestClass]
public class PaperTypeExtensionsTests
{
    [DataTestMethod]
    [DataRow(PaperType.W80H28)]
    [DataRow(PaperType.W80H56)]
    [DataRow(PaperType.W80H80)]
    [DataRow(PaperType.W80H104)]
    [DataRow(PaperType.W80H136)]
    [DataRow(PaperType.Custom)]
    public void Given_PaperType_When_GetMediaName_Then_IsNotNull(PaperType paperType)
    {
        var mediaType = paperType.GetMediaName();

        Assert.IsNotNull(mediaType);
    }

    [DataTestMethod]
    [DataRow(PaperType.W80H28, 80)]
    [DataRow(PaperType.W80H56, 80)]
    [DataRow(PaperType.W80H80, 80)]
    [DataRow(PaperType.W80H104, 80)]
    [DataRow(PaperType.W80H136, 80)]
    public void Given_PaperType_When_GetWidth_Then_AreEqual(PaperType paperType, int expected)
    {
        var width = paperType.GetWidth();

        Assert.AreEqual(expected, width);
    }

    [DataTestMethod]
    [DataRow(PaperType.W80H28, 28)]
    [DataRow(PaperType.W80H56, 56)]
    [DataRow(PaperType.W80H80, 80)]
    [DataRow(PaperType.W80H104, 104)]
    [DataRow(PaperType.W80H136, 136)]
    public void Given_PaperType_When_GetHeight_Then_AreEqual(PaperType paperType, int expected)
    {
        var height = paperType.GetHeight();

        Assert.AreEqual(expected, height);
    }
}