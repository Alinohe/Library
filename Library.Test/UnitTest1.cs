namespace Library.Test
{
    internal class BookTest
    {
        private string title;
        private string writer;

        public BookTest(string title, string writer)
        {
            this.title = title;
            this.writer = writer;
        }

        [Test]

        public void TEST()
        {
            var book = GetBook("Green Mile", "Stephen King");
            var book1 = GetBook("The Fifth Profession", "David Morrel");

            Assert.That(book1, Is.Not.EqualTo(book));
        }
        private BooksInMemory GetBook(string title, string writer)
        {
            return new BooksInMemory(title, writer);
        }      
    }
}
