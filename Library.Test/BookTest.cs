using NUnit.Framework;

namespace Library.Test
{
    public class LibraryTest
    {
        [Test]
        public void CheckMaxValue()
        {

            var book = new BooksInMemory("Green Mile", "Stephen King");
            book.AddRate(9);
            book.AddRate(8);
            book.AddRate(7);

            var statistics = book.GetStatistics();

            Assert.That(statistics.Max, Is.EqualTo(9));
        }
        [Test]
        public void CheckMinValue()
        {

            var book = new BooksInMemory("Green Mile", "Stephen King");
            book.AddRate(9);
            book.AddRate(8);
            book.AddRate(7);

            var statistics = book.GetStatistics();

            Assert.That(statistics.Min, Is.EqualTo(7));
        }

        [Test]
        public void CheckAverageValue()
        {
            // arrange
            var book = new BooksInMemory("Green Mile", "Stephen King");
            book.AddRate(9);
            book.AddRate(8);
            book.AddRate(7);
            // act
            var statistics = book.GetStatistics();
            // assert
            Assert.That(statistics.Average, Is.EqualTo(8));
        }
    }
}
