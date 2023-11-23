public class SalesCompany
{
    public int Id { get; set; }
    public DateTimeOffset Date { get; set; }
    public string MoveState { get; set; }
    public int Total { get; set; }
    public int Cost { get; set; }
    public int CurrencyId { get; set; }
    public Currency Currency { get; set; }
}

public class Report
{
    public DateTime Date { get; set; }
    public int TotalSales { get; set; }
    public int TotalCost { get; set; }
}

public class Currency
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Symbol { get; set; }
}

public class Calculate
{
    public static void Main()
    {
        DateTime currentDate = new DateTime(2023, 11, 20); // Current date
        DateTime lastWeekEndDate = new DateTime(2023, 11, 14); // Last week's end date
        DateTime currentUtcDate = currentDate.ToUniversalTime().AddHours(+3); // Convert current date to GMT
        DateTime lastWeekEndUtcDate = lastWeekEndDate.ToUniversalTime().AddHours(+3); // Convert last week's end date to GMT

        List<SalesCompany> sales = new List<SalesCompany>()
        {

            new SalesCompany { Id = 24, Date = new DateTimeOffset(2023, 11, 14, 1, 28, 27, TimeSpan.Zero), MoveState = "draft", Cost = 20, Total = 24, CurrencyId = 7 },
            new SalesCompany { Id = 24, Date = new DateTimeOffset(2023, 11, 13, 4, 28, 27, TimeSpan.Zero), MoveState = "draft", Cost = 20, Total = 24, CurrencyId = 7 },
            new SalesCompany { Id = 25, Date = new DateTimeOffset(2023, 11, 15, 0, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 20, Total = 15, CurrencyId = 8 },
            new SalesCompany { Id = 66, Date = new DateTimeOffset(2023, 11, 15, 4, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 57, Total = 66, CurrencyId = 9 },
            new SalesCompany { Id = 63, Date = new DateTimeOffset(2023, 11, 15, 7, 0, 27, TimeSpan.Zero), MoveState = "posted", Cost = 59, Total = 63, CurrencyId = 10 },
            new SalesCompany { Id = 330, Date = new DateTimeOffset(2023, 11, 15, 2, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 344, Total = 330, CurrencyId = 11 },
            new SalesCompany { Id = 20, Date = new DateTimeOffset(2023, 11, 15, 20, 28, 27, TimeSpan.Zero), MoveState = "draft", Cost = 16, Total = 20, CurrencyId = 12 },
            new SalesCompany { Id = 106, Date = new DateTimeOffset(2023, 11, 15, 23, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 94, Total = 106, CurrencyId = 13 },
            new SalesCompany { Id = 30, Date = new DateTimeOffset(2023, 11, 16, 20, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 26, Total = 30, CurrencyId = 14 },
            new SalesCompany { Id = 25, Date = new DateTimeOffset(2023, 11, 17, 20, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 19, Total = 25, CurrencyId = 15 },
            new SalesCompany { Id = 40, Date = new DateTimeOffset(2023, 11, 18, 1, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 34, Total = 40, CurrencyId = 16 },
            new SalesCompany { Id = 35, Date = new DateTimeOffset(2023, 11, 18, 7, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 28, Total = 35, CurrencyId = 17 },
            new SalesCompany { Id = 95, Date = new DateTimeOffset(2023, 11, 18, 20, 28, 27, TimeSpan.Zero), MoveState = "draft", Cost = 84, Total = 95, CurrencyId = 18 },
            new SalesCompany { Id = 14, Date = new DateTimeOffset(2023, 11, 18, 22, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 9, Total = 14, CurrencyId = 19 },
            new SalesCompany { Id = 55, Date = new DateTimeOffset(2023, 11, 18, 23, 28, 27, TimeSpan.Zero), MoveState = "posted", Cost = 48, Total = 55, CurrencyId = 20 },
        };


        sales.ForEach(item => item.Date = item.Date.AddHours(3));

        List<Report> weeklySalesReport = Enumerable.Range(0, (currentUtcDate - lastWeekEndUtcDate).Days + 1)
            .Select(offset => new Report
            {
                Date = lastWeekEndUtcDate.AddDays(offset),
                TotalSales = sales.Where(s => s.Date.Date == lastWeekEndUtcDate.AddDays(offset).Date).Sum(s => s.Total),
                TotalCost = sales.Where(s => s.Date.Date == lastWeekEndUtcDate.AddDays(offset).Date).Sum(s => s.Cost)
            })
            .ToList();

        // Print the sales report
        weeklySalesReport.ForEach(report => Console.WriteLine($"Date: {report.Date.ToShortDateString()}, Total Sales: {report.TotalSales}, Total Cost: {report.TotalCost}"));



        //List<Report> weeklySalesReport = new List<Report>();

        //for (DateTime date = lastWeekEndUtcDate.Date; date <= currentUtcDate.Date; date = date.AddDays(1))
        //{
        //    var totalSalesForDay = sales.Where(s => s.Date.Date == date).Sum(s => s.Total);
        //    var costSalesForDay = sales.Where(s => s.Date.Date == date).Sum(s => s.Cost);

        //    var report = new Report
        //    {
        //        Date = date,
        //        TotalSales = totalSalesForDay,
        //        TotalCost = costSalesForDay,
        //    };

        //    weeklySalesReport.Add(report);
        //}

        //// Print the sales report
        //foreach (var report in weeklySalesReport)
        //{
        //    Console.WriteLine($"Date: {report.Date.ToShortDateString()}, Total Sales: {report.TotalSales}, Total Cost {report.TotalCost}");
        //}

    }
}