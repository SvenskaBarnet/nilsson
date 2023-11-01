using nilsson;
using System.Runtime.CompilerServices;
//timlön = 159,45
//ob50% - mån-fre 18.15 -
//ob70% - mån-fre 20-
//ob100% - lör 12 -, hela sön +  helgdag
double salary = 159.45;
double weekOB = salary * 1.5;
double weekendOB = salary * 2;
double pay = 0;
string[] files = Directory.GetFiles("../../../files/");
double monthPay = 0;
string displayMonthPay;
Console.WriteLine("Pernillas schema");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
foreach (string file in files)
{
    string[] schema = File.ReadAllLines(file);
    Console.WriteLine($"{Path.GetFileName(file).Substring(0, 3)}\n");

    foreach (string line in schema)
    {
        if (line[0].Equals('P'))
        {
            int day;
            string[] hours;
            string[] nilssonschema = line.Split(',');
            double weekPay = 0;
            string displayDay;
            string displayDayOff;
            string displayWeekPay;

            for (int i = 0; i < 8 - 1; i++)
            {
                switch (i)
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
}
displayMonthPay = String.Format("{0,-10} {1,10} {2,10}", "Månadslön", "", $"{Math.Round(monthPay, 2, MidpointRounding.AwayFromZero).ToString("0.00")}kr\n\n");
Console.WriteLine(displayMonthPay);


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