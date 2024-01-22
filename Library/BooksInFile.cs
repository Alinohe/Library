using System.Text;

namespace Library
{
    public class BooksInFile(string title, string writer) : BooksBase(title, writer)
    {
        private const string BookName = "BooksRates.txt";

        private string title;
        private string writer;
        private string fullBookName = $"{title}_{writer}{BookName}";

        public override string Title
        {
            get
            {
                return $"{char.ToUpper(title[0])}{title.Substring(1, title.Length - 1).ToLower()}";
            }
            set
            {
                title = value;
            }
        }

        public override string Writer
        {
            get
            {
                return $"{char.ToUpper(writer[0])}{writer.Substring(1, writer.Length - 1).ToLower()}";
            }
            set
            {
                writer = value;
            }
        }

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

        public override void AddRate(float rate)
        {
            throw new NotImplementedException();
        }

        public override void AddRate(int rate)
        {
            throw new NotImplementedException();
        }

        public override void AddRate(char rate)
        {
            throw new NotImplementedException();
        }
    }
}
