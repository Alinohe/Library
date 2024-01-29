using System.Reflection;
using System.Text;
namespace Library
{
    public class BooksInFile(string title, string writer) : BooksBase(title, writer)
    {
        private const string BookName = "BooksRates.txt";

        private string title;
        private string writer;
        private string fullBookName = $"{title}_{writer}{BookName}";

        public override void AddRate(double rate)
        {
            if (rate > 0 && rate <= 9)
            {
                using (var writeIN = File.AppendText($"{fullBookName}"))
                using (var writeIN2 = File.AppendText($"audit.txt"))
                {
                    writeIN.WriteLine(rate);
                    writeIN2.WriteLine($"{title} {writer} - {rate}        {DateTime.UtcNow}");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 6 are allowed!");
            }
        }

        public override void ShowRates()
        {
            StringBuilder sb = new StringBuilder($"{this.title} {this.writer} rates are: ");

            using (var reader = File.OpenText(($"{fullBookName}")))
            {
                var line = reader.ReadLine();
                while (line != null)
                {
                    sb.Append($"{line}; ");
                    line = reader.ReadLine();
                }
            }
            Console.WriteLine($"\n{sb}");
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();
            if (File.Exists($"{fullBookName}"))
            {
                using (var reader = File.OpenText($"{fullBookName}"))
                {
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        var number = double.Parse(line);
                        result.Add(number);
                        line = reader.ReadLine();
                    }
                }
            }
            return result;
        }

    }
}