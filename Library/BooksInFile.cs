using System.Reflection;
using System.Text;
namespace Library
{
    public class BooksInFile : BooksBase
    {
        private const string BookName = "BooksRates.txt";

        private string fullBookName
        {
            get { return $"{Title}_{Writer}{BookName}"; }
        }

        public BooksInFile(string title, string writer) : base(title, writer) { }

        public override void AddRate(double rate)
        {
            if (rate > 0 && rate <= 9)
            {
                using (var writeIN = File.AppendText($"{fullBookName}"))
                using (var writeIN2 = File.AppendText($"audit.txt"))
                {
                    writeIN.WriteLine(rate);
                    writeIN2.WriteLine($"{Title} {Writer} - {rate}        {DateTime.UtcNow}");
                }
            }
            else
            {
                throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 6 are allowed!");
            }
        }

        public override void ShowRates()
        {
            StringBuilder sb = new StringBuilder($"{this.Title} {this.Writer} rates are: ");

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