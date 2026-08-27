using AzmoonYar.Domain.Entities;
using AzmoonYar.Domain.Enums;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace AzmoonYar.Infrastructure.Reports;

public class ExamDocument(Exam exam) : IDocument
{
    public DocumentMetadata GetMetadata() => DocumentMetadata.Default;
    
    public void Compose(IDocumentContainer container)
    {
        container.Page(page =>
        {
            page.Size(PageSizes.A4);
            page.Margin(1, Unit.Centimetre);
            page.PageColor(Colors.White);
            page.DefaultTextStyle(x => x.FontFamily("Vazirmatn").FontSize(11));
            page.ContentFromRightToLeft();

            page.Content().Element(ComposeTable);
        });
    }

    private void ComposeTable(IContainer container)
    {
        container.Table(table =>
        {
            table.ColumnsDefinition(columns =>
            {
                columns.ConstantColumn(35);
                columns.RelativeColumn();
                columns.ConstantColumn(45);
            });
            
            ComposeHeader(table);
            ComposeQuestions(table);
        });
    }
    private void ComposeHeader(TableDescriptor table)
    {
        var header = exam.ExamHeader; // خواندن از ValueObject
        var examTypeTitle = exam.ExamType.ToString(); // در صورت داشتن Extension Method برای نام فارسی، اینجا استفاده کنید
        var bookTitle = exam.Book?.BookName ?? "بدون نام کتاب";

        table.Cell().ColumnSpan(3).Border(1).BorderColor(Colors.Black).Padding(5).Table(ht =>
        {
            ht.ColumnsDefinition(c => { c.RelativeColumn(); c.RelativeColumn(); c.RelativeColumn(); });

            // اطلاعات سمت راست سربرگ
            ht.Cell().Column(c =>
            {
                c.Item().Text($"نام استاد: {header.TeacherName}");
                c.Item().Text($"تاریخ امتحان: {header.ExamDate}");
            });

            // اطلاعات وسط سربرگ (نام کتاب و نوع امتحان)
            ht.Cell().AlignCenter().AlignMiddle().Column(c =>
            {
                c.Item().Text(bookTitle).Bold().FontSize(14);
                c.Item().Text($"آزمون {examTypeTitle}").FontSize(12);
            });

            // اطلاعات سمت چپ سربرگ
            ht.Cell().AlignLeft().Column(c =>
            {
                c.Item().Text("نام و نام خانوادگی: .........................");
                c.Item().Text("شماره داوطلب: ...............................");
            });
        });

            // تیتر ستون‌ها
        table.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("ردیف").Bold();
        table.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("شرح سوالات").Bold(); 
        table.Cell().Border(1).Background(Colors.Grey.Lighten3).AlignCenter().Text("بارم").Bold();
    }

    private void ComposeQuestions(TableDescriptor table)
    {
        int index = 1;
        foreach (var examQuestion in exam.ExamQuestions)
        {
            var q = examQuestion.Question;
            if (q == null) continue;

            // سلول ردیف
            table.Cell().Border(1).AlignCenter().AlignMiddle().Text(index.ToString());

            // سلول شرح سوال
            table.Cell().Border(1).Padding(8).Column(qCol =>
            {
                // چاپ عنوان اصلی سوال
                qCol.Item().Text(q.QuestionText).Bold().FontSize(11);

                // --- ۱) سوالات چند گزینه‌ای (تستی) ---
                if (q.QuestionType == QuestionType.Optional && q.OptionalItem != null)
                {
                    qCol.Item().PaddingTop(10).Grid(grid =>
                    {
                        grid.Spacing(15);
                        grid.Columns(2); // چیدمان دو ستونه برای گزینه‌ها

                        RenderOption(grid, "الف)", q.OptionalItem.Option1);
                        RenderOption(grid, "ب)", q.OptionalItem.Option2);
                        RenderOption(grid, "ج)", q.OptionalItem.Option3);
                        RenderOption(grid, "د)", q.OptionalItem.Option4);
                    });
                }

                // --- ۲) سوالات صحیح / غلط ---
                else if (q.QuestionType == QuestionType.TrueFalse && q.TrueFalseItems != null && q.TrueFalseItems.Any())
                {
                    qCol.Item().PaddingTop(8).Column(tfCol =>
                    {
                        foreach (var tf in q.TrueFalseItems)
                        {
                            tfCol.Item().PaddingBottom(4).Row(row =>
                            {
                                // استفاده از ItemText بر اساس دامین شما
                                row.RelativeItem().Text("• " + tf.ItemText).FontSize(11);
                                row.ConstantItem(120).AlignLeft().Text("صحیح [   ]   غلط [   ]").FontSize(10);
                            });
                        }
                    });
                }

                // --- ۳) سوالات وصل‌کردنی ---
                else if (q.QuestionType == QuestionType.Matching && q.MatchingItems != null && q.MatchingItems.Any())
                {
                    qCol.Item().PaddingTop(10).Grid(grid =>
                    {
                        grid.Spacing(20);
                        grid.Columns(2);

                        // ستون راست (RightItemText)
                        grid.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("ستون الف").Bold().FontSize(10);
                            foreach (var match in q.MatchingItems)
                            {
                                c.Item().PaddingVertical(4).Text($" ⚪  {match.RightItemText}").FontSize(11);
                            }
                        });

                        // ستون چپ (LeftItemText) همراه با Shuffle کردن تا جواب‌ها روبه‌روی هم نیفتند
                        var shuffledLeftItems = q.MatchingItems.OrderBy(x => Guid.NewGuid()).ToList();

                        grid.Item().Column(c =>
                        {
                            c.Item().PaddingBottom(5).Text("ستون ب").Bold().FontSize(10);
                            foreach (var match in shuffledLeftItems)
                            {
                                c.Item().PaddingVertical(4).Text($" ⚪  {match.LeftItemText}").FontSize(11);
                            }
                        });
                    });
                }

                // --- ۴) سوالات جای‌خالی ---
                else if (q.QuestionType == QuestionType.FillInBlank && q.FillInBlankItems != null &&
                         q.FillInBlankItems.Any())
                {
                    qCol.Item().PaddingTop(8).Column(fbCol =>
                    {
                        foreach (var fb in q.FillInBlankItems)
                        {
                            // استفاده از ItemText بر اساس دامین شما
                            fbCol.Item().PaddingBottom(5).Text("• " + fb.ItemText).FontSize(11);
                        }
                    });
                }

                // --- ۵) سوالات تشریحی (Fallback) ---
                else
                {
                    qCol.Item().PaddingTop(15).Column(descCol =>
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            descCol.Item().PaddingBottom(12)
                                .Text(
                                    "..................................................................................................................................................................")
                                .FontColor(Colors.Grey.Lighten1);
                        }
                    });
                }
            });

            // سلول بارم
            table.Cell().Border(1).AlignCenter().AlignMiddle().Text(examQuestion.Score.ToString("0.##"));
            index++;
        }
    }

    // متد کمکی برای رسم گزینه‌های تستی (جلوگیری از تکرار کد)
    void RenderOption(GridDescriptor grid, string prefix, string text)
    {
        if (string.IsNullOrWhiteSpace(text)) return;
        
        grid.Item().Row(row =>
        {
            row.AutoItem().Text("[   ] ").FontSize(10);
            row.AutoItem().PaddingRight(2).Text(prefix).Bold().FontSize(10);
            row.RelativeItem().PaddingRight(5).Text(text).FontSize(11);
        });
    }
}