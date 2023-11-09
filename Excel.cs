using ExcelDataReader;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace nilsson;

public class Excel
{
    public static void ConvertToCsv(string filepath)
    {
        System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
        using (var streamval = File.Open(filepath, FileMode.Open, FileAccess.Read))
        {
            using (var reader = ExcelReaderFactory.CreateReader(streamval))
            {
                int j = 0;
                do
                {
                    while (reader.Read())
                    {
                        string cell = string.Empty;
                        if (j is > 4 and < 9)
                        {
                            if ($"{reader.GetValue(0)}".Equals("Pernilla"))
                            {
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    cell = $"{reader.GetValue(i)}".Replace(',', '.');
                                    if (i < reader.FieldCount - 1)
                                    {
                                        File.AppendAllText("data.csv", $"{cell},");
                                    }
                                    else
                                    {
                                        File.AppendAllText("data.csv", $"{cell}{Environment.NewLine}");
                                    }
                                }
                            }
                        }
                    }
                    j++;
                } while (reader.NextResult());
            }
        }

    }
}