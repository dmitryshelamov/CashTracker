using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;
using static System.Net.Mime.MediaTypeNames;
using System.Text.Unicode;

namespace CashTracker.Core
{
    public class TinkoffCsvReader
    {
        public List<TinkoffCsvModel> Read()
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            // var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            var config = new CsvConfiguration(new CultureInfo("ru-RU"))
            {
                Delimiter = ";",
                // Encoding = Encoding.GetEncoding("windows-1251")
                Encoding = Encoding.GetEncoding("utf-8")
            // Mode = CsvMode.NoEscape,
            // BadDataFound = context => badRecord.Add(context.RawRecord)
        };

            using (var reader = new StreamReader(@"C:\files\operations Thu Sep 01 08_44_20 MSK 2022-Fri Sep 30 15_42_10 MSK 2022.csv", Encoding.GetEncoding("windows-1251")))
            using (var csv = new CsvReader(reader, config))
            {
                var records = new List<TinkoffCsvModel>();
                csv.Read();
                csv.ReadHeader();
                while (csv.Read())
                {
                    var model = new TinkoffCsvModel();

             
                    model.Category = csv.GetField<string>(9);
                    model.OperationDate = csv.GetField<DateTime>(0);
                    model.CardNumber = csv.GetField<string>(2);
                    model.OperationAmount = csv.GetField<decimal>(4);
                    model.Currency = csv.GetField<string>(5);
                    model.MCC = csv.GetField<string>(10);
                    model.Description = csv.GetField<string>(11);


                    records.Add(model);
                }
                return records.ToList();
            }
        }

        static private string Win1251ToUTF8(string source)
        {
            Encoding utf8 = Encoding.GetEncoding("utf-8");
            Encoding win1251 = Encoding.GetEncoding("windows-1251");
            byte[] utf8Bytes = win1251.GetBytes(source);
            byte[] win1251Bytes = Encoding.Convert(win1251, utf8, utf8Bytes);
            source = win1251.GetString(win1251Bytes);
            return source;
        }
    }
}