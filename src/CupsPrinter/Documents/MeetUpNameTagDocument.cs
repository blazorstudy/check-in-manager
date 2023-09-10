using System;
using CupsPrinter.Extensions;
using CupsPrinter.Models;
using CupsPrinter.Structures;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;

namespace CupsPrinter;

/// <summary>
/// <see cref="MeetUpNameTagModel"/> Document.
/// </summary>
public sealed class MeetUpNameTagDocument : IDocument
{
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="model">model.</param>
    /// <param name="paperType">paperType.</param>
    public MeetUpNameTagDocument(MeetUpNameTagModel model, PaperType paperType)
    {
        Model = model ?? throw new ArgumentNullException(nameof(model));
        PaperType = paperType;
    }

    /// <summary>
    /// Model.
    /// </summary>
    public MeetUpNameTagModel Model { get; }

    /// <summary>
    /// Paper type.
    /// </summary>
    public PaperType PaperType { get; }

    /// <inheritdoc `/>
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PaperType.GetWidth(), PaperType.GetHeight(), Unit.Millimetre);
            page.DefaultTextStyle(style => style.FontFamily("NanumGothic"));

            page.Content()
                .AlignCenter()
                .AlignMiddle()
                .Column(column =>{
                    column.Spacing(20);

                    column.Item().Text(text => WriteUserName(text, Model.Name));
                    column.Item().Text(text => WriteCompany(text, Model.Company));
                });
        });
    }

    private void WriteUserName(TextDescriptor descriptor, string? userName)
    {
        descriptor.AlignCenter();

        descriptor.Span(userName).FontSize(20).Bold();
    }

    private void WriteCompany(TextDescriptor descriptor, string? company)
    {
        descriptor.AlignCenter();

        descriptor.Span(company).FontSize(14).SemiBold();
    }
}
