using Microsoft.AspNetCore.Hosting;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using QuestPDF.Previewer;
using System.Globalization;
using TravelAgency.DTOs.PdfDTOs;

namespace TravelAgency.Services.Documents
{
    public class PdfService : IPdfService
    {
        private readonly IWebHostEnvironment _environment;
        public PdfService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public async Task GenerateContractPdf(ContractPdf contract)
        {
            await Task.Run(() =>
            {
                int borderSize = 1;
                int cellPadding = 2;
                string headerColor = Colors.LightBlue.Lighten4;
                string dateFormat = "{0:dd/MM/yyyy}";
                string longDateFormat = "{0:dd/MM/yyyy - HH:mm}";

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.PageColor(Colors.White);
                        page.Margin(5, Unit.Millimetre);
                        page.DefaultTextStyle(x => x.FontSize(11).FontFamily(Fonts.Arial));

                        page
                        .Header()
                        .Row(row =>
                        {
                            row.ConstantItem(40, Unit.Millimetre).Image(_environment.WebRootPath + contract.Company.ImagePath);
                            row.RelativeItem(3).AlignCenter().Padding(10, Unit.Millimetre).Text(t =>
                            {
                                t.Span("Договор за патување број:\n");
                                t.Span(contract.Number).FontSize(16).Bold();
                            });
                            row.RelativeItem(4).AlignCenter().Padding(10, Unit.Millimetre).Column(x =>
                            {
                                x.Item().Text(contract.Company.Name).FontSize(14).Bold();
                                x.Item().Text(contract.Company.Address);
                                x.Item().Text(contract.Company.Phone);
                                x.Item().Text(contract.Company.Email);
                                x.Item().Text(contract.Company.Website);
                            });
                        });

                        page.Content()
                        .PaddingVertical(5, Unit.Millimetre)
                        .Column(x =>
                        {
                            x.Item().Background(headerColor).Text("Податоци за патување");
                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                });

                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Земја\n{contract.Country}");
                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Место\n{contract.Location}");
                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Сместивење/Хотел\n{contract.HotelName}");
                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Тип на соба\n{contract.RoomType}");

                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Услуга\n{contract.ServiceType}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Од\n{string.Format(dateFormat, contract.StartDate)}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"До\n{string.Format(dateFormat, contract.EndDate)}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Денови\n{contract.Days}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Ноќи\n{contract.Nights}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Певоз\n{contract.TransportationType}");
                                table.Cell().ColumnSpan(1).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Влез\n{string.Format(dateFormat, contract.StartDate)}");

                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Точен датум на поаѓање\n{string.Format(longDateFormat, contract.DepartureTime)}");
                                table.Cell().ColumnSpan(2).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Осигурување\n{contract.Insurance}");
                                table.Cell().ColumnSpan(4).Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text($"Напомена\n{contract.Note}");
                            });

                            x.Item().PaddingTop(5, Unit.Millimetre).Background(headerColor).Text("Податоци за патници");
                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn(3);
                                    cols.RelativeColumn(2);
                                    cols.RelativeColumn(2);
                                    cols.RelativeColumn(2);
                                    cols.RelativeColumn(3);
                                });

                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Име и Презиме");
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Број на пасош");
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Дата на раѓање");
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Телефон");
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Адреса");

                                foreach(var item in contract.Passengers)
                                {
                                    table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(item.FullName);
                                    table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(item.PassportNumber);
                                    table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(string.Format(dateFormat, item.BirthDate));
                                    table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(item.Phone);
                                    table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(item.Address);
                                }
                            });

                            x.Item().PaddingTop(5, Unit.Millimetre).Background(headerColor).Text("Податоци за уплата");
                            x.Item().Table(table =>
                            {
                                table.ColumnsDefinition(cols =>
                                {
                                    cols.RelativeColumn(1);
                                    cols.RelativeColumn(1);
                                });
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Column(col =>
                                {
                                    col.Item().Row(r =>
                                    {
                                        r.RelativeItem().Text("Начин на плаќање:");
                                        r.RelativeItem().AlignRight().Text(contract.PaymentMethod);
                                    });
                                    col.Item().Row(r =>
                                    {
                                        r.RelativeItem().Text("Вкупно:");
                                        r.RelativeItem().AlignRight().Text(contract.TotalPrice.ToString("C2", CultureInfo.CreateSpecificCulture("mk-MK")));
                                    });
                                    col.Item().Row(r =>
                                    {
                                        r.RelativeItem().Text("Уплатено:");
                                        r.RelativeItem().AlignRight().Text(contract.PaidPrice.ToString("C2", CultureInfo.CreateSpecificCulture("mk-MK")));
                                    });
                                    col.Item().BorderTop(borderSize).PaddingTop(2, Unit.Millimetre).Row(r =>
                                    {
                                        double remaining = contract.TotalPrice - contract.PaidPrice;
                                        r.RelativeItem().Text("За доплата:").Bold();
                                        r.RelativeItem().AlignRight().Text(remaining.ToString("C2", CultureInfo.CreateSpecificCulture("mk-MK"))).Bold();
                                    });
                                });
                                table.Cell().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text("Забелешки");
                            });
                            x.Item().Padding(2);
                            x.Item().Border(borderSize).Padding(cellPadding, Unit.Millimetre).Text(contract.Footer);
                        });

                        page.Footer().PaddingBottom(5, Unit.Millimetre).Row(row =>
                        {
                            row.RelativeItem().Text("Потпис на патникот _______________________");
                            row.RelativeItem().AlignCenter().Text(string.Format("{0:dd/MM/yyyy} - {1}", contract.CreationDate, contract.Company.City));
                            row.RelativeItem().AlignRight().Text("Потпис на вработен _______________________");
                        });
                    });
                }).ShowInPreviewerAsync();
            });
        }
    }
}
