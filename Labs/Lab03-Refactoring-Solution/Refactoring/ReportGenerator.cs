using System;
using System.Collections.Generic;
using System.Linq;

public class ReportGenerator
{
    private const double Threshold = 42.42;

    public void PrintSummary(IEnumerable<int> numbers, string userName, bool debug = false)
    {
        if (numbers is null)
        {
            Console.WriteLine("NULL");
            return;
        }

        var list = numbers.ToList();
        if (!list.Any())
        {
            Console.WriteLine("EMPTY");
            return;
        }

        var average = list.Average();
        if (debug) Console.WriteLine($"AVG={average}");
        if (!string.IsNullOrWhiteSpace(userName)) Console.WriteLine($"User:{userName}");
        Console.WriteLine(average > Threshold ? "ok" : "not ok");
    }
}
