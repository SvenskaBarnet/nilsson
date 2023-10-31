using nilsson;
//timlön = 159,45
//ob50% - mån-fre 18.15 -
//ob70% - mån-fre 20-
//ob100% - lör 12 -, hela sön +  helgdag
double salary = 159.45;
string[] files = Directory.GetFiles("../../../files/");
Console.WriteLine("Pernillas schema");
Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~");
foreach (string file in files)
{
    string[] schema = File.ReadAllLines(file);

    foreach (string line in schema)
    {
        string week = Path.GetFileName(file).Substring(0, 3);
        if (line[0].Equals('P'))
        {
            Enum day;
            int start = 0;
            int finish = 0;
            double pay = 0;
            string[] hours;
            string[] nilssonschema = line.Split(',');
            
            for (int i = 0; i < 8 - 1; i++)
            {
                switch (i)
                {
                    case 0:
                        day = Weekday.Måndag;
                        hours = nilssonschema[1].Split('-');
                        start = int.Parse(hours[0]);
                        finish = int.Parse(hours[1]);

                        break;
                    case 1:
                        day = Weekday.Tisdag;
                        break;
                    case 2:
                        day = Weekday.Onsdag;
                        break;
                    case 3:
                        day = Weekday.Torsdag;
                        break;
                    case 4:
                        day = Weekday.Fredag;
                        break;
                    case 5:
                        day = Weekday.Lördag;
                        break;
                    case 6:
                        day = Weekday.Söndag;
                        pay = float.Parse(nilssonschema[14]) * salary * 2; 
                        break;
    
                }
            }
            Console.WriteLine(week);
            Console.WriteLine($"Måndag: {nilssonschema[1]}, {nilssonschema[2]}h");
            Console.WriteLine($"Tisdag: {nilssonschema[3]}, {nilssonschema[4]}h");
            Console.WriteLine($"Onsdag: {nilssonschema[5]}, {nilssonschema[6]}h");
            Console.WriteLine($"Torsdag: {nilssonschema[7]}, {nilssonschema[8]}h");
            Console.WriteLine($"Fredag: {nilssonschema[9]}, {nilssonschema[10]}h");
            Console.WriteLine($"Lördag: {nilssonschema[11]}, {nilssonschema[12]}h");
            Console.WriteLine($"Söndag: {nilssonschema[13]}, {nilssonschema[14]}h\n");
        }
    }
}