﻿using static Library.BooksBase;
namespace Library
{
    namespace Books
    {
        public interface IBooks
        {
            string Title { get; set; }
            string Writer { get; set; }
            void AddRate(double rate);
            void AddRate(string rate);
            void ShowRates();

            Statistics GetStatistics();
            void ShowStatistics();
        }
    }
}