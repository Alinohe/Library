using Library.Books;
namespace Library
{
    public abstract class BooksBase : IBooks
    {
        private string _title;
        private string _writer;

        public string Title
        {
            get
            {
                return $"{char.ToUpper(_title[0])} {_title.Substring(1, _title.Length - 1).ToLower()}";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _title = value;
                }
            }
        }

        public string Writer
        {
            get
            {
                return $"{char.ToUpper(_writer[0])}.";
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    _writer = value;
                }
            }
        }

        protected BooksBase(string title, string writer)
        {
            _title = title;
            _writer = writer;
        }

        public abstract void AddRate(double rate);

        public void AddRate(string rate)
        {
            double convertedRateToDouble = char.GetNumericValue(rate[0]);
            if (rate.Length == 2 && char.IsDigit(rate[0]) && rate[0] <= '9' && (rate[1] == '+' || rate[1] == '-'))
            {
                switch (rate[1])
                {
                    case '+':
                        double ratePlus = convertedRateToDouble + 0.50;
                        if (ratePlus > 1 && ratePlus <= 9)
                        {
                            AddRate(ratePlus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                        }
                        break;

                    case '-':
                        double rateMinus = convertedRateToDouble - 0.250;

                        if ((rateMinus > 1 && rateMinus <= 9))
                        {
                            AddRate(rateMinus);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                        }
                        break;

                    default:
                        throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                }
            }
            else
            {
                double rateDouble = 0;
                var isParsed = double.TryParse(rate, out rateDouble);
                if (isParsed && rateDouble > 0 && rateDouble <= 9)
                {
                    AddRate(rateDouble);
                }
                else
                {
                    throw new ArgumentException($"Invalid argument: {nameof(rate)}. Only grades from 1 to 9 are allowed!");
                }
            }
        }

        public abstract void ShowRates();
        public abstract Statistics GetStatistics();


        public void ShowStatistics()
        {
            var stat = GetStatistics();
            if (stat.Count != 0)
            {
                ShowRates();
                Console.WriteLine($"{Title} {Writer} statistics:");
                Console.WriteLine($"Total grades: {stat.Count}");
                Console.WriteLine($"Highest grade: {stat.Max:N2}");
                Console.WriteLine($"Lowest grade: {stat.Min:N2}");
                Console.WriteLine($"Average: {stat.Average:N2}");
                Console.WriteLine();
            }

            else
            {
                Console.WriteLine($"Couldn't get statistics for {this.Title} {this.Writer} because no grade has been added.");
            }
        }
    }
}