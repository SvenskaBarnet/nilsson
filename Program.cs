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

            for (int i = 0; i < 8 - 1; i++)
            {
                switch (i)
                {
                    case 0:
                        day = (int)Weekday.Måndag;
                        if (nilssonschema[1].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[1].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[1]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 1:
                        day = (int)Weekday.Tisdag;
                        if (nilssonschema[3].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[3].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[3]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 2:
                        day = (int)Weekday.Onsdag;
                        if (nilssonschema[5].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[5].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[5]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 3:
                        day = (int)Weekday.Torsdag;
                        if (nilssonschema[7].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[7].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[7]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 4:
                        day = (int)Weekday.Fredag;
                        if (nilssonschema[9].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[9].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[9]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 5:
                        day = (int)Weekday.Lördag;
                        if (nilssonschema[11].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[11].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[11]}, {pay}kr");
                        }
                        pay = 0;
                        break;
                    case 6:
                        day = (int)Weekday.Söndag;
                        if (nilssonschema[11].Equals("Ledig"))
                        {
                            Console.WriteLine($"{(Weekday)day}: Ledig!");
                        }
                        else
                        {
                            hours = nilssonschema[11].Split('-');
                            pay = Math.Round(CalculatePay(hours, day), 2, MidpointRounding.AwayFromZero);
                            weekPay += pay;
                            Console.WriteLine($"{(Weekday)day}: {nilssonschema[11]}, {pay}kr");
                        }
                        pay = 0;
                        break;

                }
            }
            monthPay += weekPay;
            Console.WriteLine($"\nVeckolön: {Math.Round(weekPay, 2, MidpointRounding.AwayFromZero)}kr\n\n");

        }
    }
}
Console.WriteLine($"\nMånadslön: {Math.Round(monthPay, 2, MidpointRounding.AwayFromZero)}kr\n\n");


double CalculatePay(string[] hours, int weekday)
{
    double start = 0;
    double finish = 0;
    double daypay = 0;
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

    switch (weekday)
    {
        case < 5:
            if (start > 18)
            {
                daypay = (finish - start - 0.5) * weekOB;
            }
            else if (finish <= 18)
            {
                daypay = (finish - start - 0.5) * salary;
            }
            else
            {
                daypay = (((18.25 - start - 0.5) * salary) + ((finish - 18.25) * weekOB));
            }
            break;
        case 5:
            if (start >= 12)
            {
                daypay = (finish - start - 0.5) * weekendOB;
            }
            else if (finish <= 12)
            {
                daypay = (finish - start - 0.5) * salary;
            }
            else
            {
                daypay = (((12 - start - 0.5) * salary) + ((finish - 12) * weekendOB));
            }
            break;
        case 6:
            daypay = (finish - start - 0.5) * weekendOB;
            break;

    }
    return daypay;
}