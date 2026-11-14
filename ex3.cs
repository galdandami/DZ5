using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] temperature = new int[12, 30];
        Random random = new Random();

        for (int month = 0; month < 12; month++)
        {
            for (int day = 0; day < 30; day++)
            {
                temperature[month, day] = random.Next(-30, 36);
            }
        }

        double[] averageTemperatures = CalculateAverageTemperatures(temperature);

        string[] monthNames =
        {
            "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь",
            "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь"
        };

        Console.WriteLine("Средняя температура по месяцам:");
        for (int i = 0; i < 12; i++)
        {
            Console.WriteLine($"{monthNames[i],-10}: {averageTemperatures[i],6:F2}");
        }

        Array.Sort(averageTemperatures);

        Console.WriteLine();
        Console.WriteLine("Отсортированные средние температуры по возрастанию:");
        for (int i = 0; i < averageTemperatures.Length; i++)
        {
            Console.WriteLine($"{averageTemperatures[i],6:F2}");
        }

        Console.ReadLine();
    }

    static double[] CalculateAverageTemperatures(int[,] temperature)
    {
        int months = temperature.GetLength(0);
        int days = temperature.GetLength(1);
        double[] averages = new double[months];

        for (int month = 0; month < months; month++)
        {
            int sum = 0;
            for (int day = 0; day < days; day++)
            {
                sum += temperature[month, day];
            }
            averages[month] = (double)sum / days;
        }

        return averages;
    }
}