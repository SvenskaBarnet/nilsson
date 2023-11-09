using nilsson;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
double salary = 159.45;
double weekOB = salary * 1.5;
double weekendOB = salary * 2;
double pay = 0;
double monthPay = 0;
string displayMonthPay;
string[] excelFiles = Directory.GetFiles($"{Directory.GetCurrentDirectory()}/", "*.xls");
double fixedOut = 0;
double food = 0;
double tax = 0.218005681404327;
if (excelFiles.Length == 0)
{
    Console.WriteLine("Lägg Excelfilen i mappen Nilsson!");
    Thread.Sleep(2000);
    Environment.Exit(1000);
}
else if (excelFiles.Length > 1)
{
    Console.WriteLine("Bara en Excelfil hörru!");
    Environment.Exit(1337);
}
else
{
    bool validInput;
    do
    {
        validInput = true;
        Console.WriteLine("Hur mycket är dina fasta utgifter?\n(Tryck ENTER för att komma vidare)");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            fixedOut = value;
        }
        else
        {
            Console.WriteLine("Vet att du har diskalkyli men bara siffror tack");
            Thread.Sleep(1000);
            validInput = false;
        }
    } while (!validInput);
    do
    {
        validInput = true;
        Console.WriteLine("Hur många pengar vill du äta upp de närmsta fyra veckorna?\n(Tryck ENTER för att komma vidare)");
        if (int.TryParse(Console.ReadLine(), out int value))
        {
            food = value;
        }
        else
        {
            Console.WriteLine("Vet att du har diskalkyli men bara siffror tack");
            Thread.Sleep(1000);
            validInput = false;
        }

    } while (!validInput);

    Excel.ConvertToCsv(excelFiles[0]);
    Console.WriteLine("Pernillas schema");
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
    string[] schema = File.ReadAllLines("data.csv");

    for (int i = 0; i < schema.Length; i++)
    {
        Console.WriteLine($"Vecka {i + 1}\n");
        string line = schema[i];
        if (line[0].Equals('P'))
        {
            int day;
            string[] hours;
            string[] nilssonschema = line.Split(',');
            double weekPay = 0;
            string displayDay;
            string displayDayOff;
            string displayWeekPay;

            for (int j = 0; j < 8 - 1; j++)
            {
                switch (j)
                {
                    case 0:
                        day = (int)Weekday.Måndag;
                        if (nilssonschema[1].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[1].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[1], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 1:
                        day = (int)Weekday.Tisdag;
                        if (nilssonschema[3].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[3].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[3], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 2:
                        day = (int)Weekday.Onsdag;
                        if (nilssonschema[5].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[5].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[5], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 3:
                        day = (int)Weekday.Torsdag;
                        if (nilssonschema[7].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[7].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[7], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 4:
                        day = (int)Weekday.Fredag;
                        if (nilssonschema[9].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[9].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[9], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 5:
                        day = (int)Weekday.Lördag;
                        if (nilssonschema[11].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[11].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[11], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;
                    case 6:
                        day = (int)Weekday.Söndag;
                        if (nilssonschema[13].ToLower().Equals("ledig"))
                        {
                            displayDayOff = string.Format("{0,-10} {1,-10}", $"{(Weekday)day}:", "Ledig!");
                            Console.WriteLine(displayDayOff);
                        }
                        else
                        {
                            hours = nilssonschema[13].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            displayDay = String.Format("{0,-10} {1,-10} {2,10}", $"{(Weekday)day}:", nilssonschema[13], $"{pay.ToString("0.00")}kr");
                            Console.WriteLine(displayDay);
                        }
                        pay = 0;
                        break;

                }
            }
            monthPay += weekPay;
            displayWeekPay = String.Format("\n{0,-11} {1,10} {2,10}", "Veckolön", "", $"{Math.Round(weekPay, 2, MidpointRounding.AwayFromZero).ToString("0.00")}kr\n\n");
            Console.WriteLine(displayWeekPay);

        }
    }
    displayMonthPay = String.Format("{0,-10} {1,10} {2,10}", "Månadslön", "", $"{Math.Round(monthPay, 2, MidpointRounding.AwayFromZero).ToString("0.00")}kr\n\n");
    double brutto = Math.Round(monthPay * (1 - tax), 2, MidpointRounding.AwayFromZero);
    Console.WriteLine(displayMonthPay);
    Console.WriteLine($"Månadslön efter skatt: {brutto}kr");
    Console.WriteLine($"Fasta utgifter: {fixedOut}kr");
    Console.WriteLine($"Matbudget: {food}kr");
    Console.WriteLine($"Pengar kvar efter utgifter: {brutto - fixedOut - food}kr");
    File.Delete("data.csv");
}


double CalculatePay(string[] hours, int weekday)
{
    double start = 0;
    double finish = 0;
    double daypay = 0;
    double breakTime = 0.5;
    if (hours[0].Contains('.'))
    {
        string[] startHour = hours[0].Split('.');
        start = int.Parse(startHour[0]) + 0.5;
    }
    else
    {
        start = int.Parse(hours[0]);
    }
    if (hours[1].Contains('.'))
    {
        string[] finishHour = hours[1].Split('.');
        finish = int.Parse(finishHour[1]) + 0.5;
    }
    else
    {
        finish = int.Parse(hours[1]);
    }
    if (finish - start <= 5)
    {
        breakTime = 0;
    }

    switch (weekday)
    {
        case < 5:
            if (start > 18)
            {
                daypay = (finish - start - breakTime) * weekOB;
            }
            else if (finish <= 18)
            {
                daypay = (finish - start - breakTime) * salary;
            }
            else
            {
                daypay = (((18.25 - start - breakTime) * salary) + ((finish - 18.25) * weekOB));
            }
            break;
        case 5:
            if (start >= 12)
            {
                daypay = (finish - start - breakTime) * weekendOB;
            }
            else if (finish <= 12)
            {
                daypay = (finish - start - breakTime) * salary;
            }
            else
            {
                daypay = (((12 - start) * salary) + ((finish - 12 - breakTime) * weekendOB));
            }
            break;
        case 6:
            daypay = (finish - start - breakTime) * weekendOB;
            break;

    }
    return daypay;
}