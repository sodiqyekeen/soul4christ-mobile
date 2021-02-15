using System;
using System.Collections.Generic;
using System.Text;

namespace Soul4Christ.Helpers
{
    public static class StringExtensions
    {
        public static string RemoveTranslation(this string book)
        {
            while (!char.IsDigit(book[book.Length-1]))
            {
                book = book.Substring(0, book.Length - 1);
            }
            return book;
        }
    }
}
