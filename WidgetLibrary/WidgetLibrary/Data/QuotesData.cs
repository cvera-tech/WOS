using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WidgetLibrary.Data
{
    /// <summary>
    /// Static class that provides quotes data.
    /// </summary>
    public static class QuotesData
    {
        // Quotes taken from the website Wisdom Quotes (http://wisdomquotes.com/famous-quotes/)
        private static List<string> _quotes = new List<string>
       {
           "It always seems impossible until it&#8217;s done. Nelson Mandela",
           "The unexamined life is not worth living. Socrates",
           "Our life is frittered away by detail&#8230; simplify, simplify. Henry David Thoreau",
           "Try not to become a man of success but rather to become a man of value. Albert Einstein",
           "The weak can never forgive. Forgiveness is the attribute of the strong. Mahatma Gandhi",
           "No matter who you are or what you look like, how you started off, or how and who you love, America is a place where you can write your own destiny. Barack Obama",
           "Turn your wounds into wisdom. Oprah Winfrey",
           "I don’t think of all the misery but of the beauty that still remains. Anne Frank",
           "Whatever you are, be a good one. Abraham Lincoln",
           "Do what you can, with what you have, where you are. Theodore Roosevelt",
           "Little by little, one travels far. J.R.R. Tolkien",
           "It&#8217;s not how much you have that makes people look up to you, it&#8217;s who you are. Elvis Presley",
           "I fear not the man who has practiced 10,000 kicks once, but I fear the man who has practiced one kick 10,000 times. Bruce Lee",
           "A man who stands for nothing will fall for anything. Malcolm X",
           "In order to be irreplaceable one must always be different. Coco Chanel",
           "You have power over your mind – not outside events. Realize this, and you will find strength. Marcus Aurelius",
           "Love all, trust a few, do wrong to none. William Shakespeare",
           "I have a dream that one day little black boys and girls will be holding hands with little white boys and girls. Martin Luther King Jr",
           "Imperfection is beauty, madness is genius and it&#8217;s better to be absolutely ridiculous than absolutely boring. Marilyn Monroe",
           "The path to success is to take massive, determined action. Tony Robbins",
           "Be kind whenever possible. It is always possible. Dalai Lama",
           "Life is a flower of which love is the honey. Victor Hugo",
           "Love the life you live. Live the life you love. Bob Marley",
           "God helps those that help themselves. Benjamin Franklin",
           "By failing to prepare, you are preparing to fail. Benjamin Franklin",
           "I came, I saw, I conquered. Julius Caesar",
           "I think, therefore I am. René Descartes",
           "To be, or not to be, that is the question. William Shakespeare",
           "That&#8217;s one small step for a man, one giant leap for mankind. Neil Armstrong",
           "The only thing that interferes with my learning is my education. Albert Einstein",
           "Ask not what your country can do for you, but what you can do for your country. John F. Kennedy",
       };

        /// <summary>
        /// Returns the quote of the day.
        /// </summary>
        /// <returns>A quote as a string.</returns>
        public static string GetQuoteOfTheDay()
        {
            int day = DateTime.Today.Day;
            return _quotes[day - 1];
        }

        /// <summary>
        /// Global random object.
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Global random lock object.
        /// </summary>
        private static object _randomLock = new object();

        /// <summary>
        /// Returns a random quote (useful for testing).
        /// </summary>
        /// <returns>A quote as a string.</returns>
        public static string GetRandomQuote()
        {
            var index = 0;

            // The Random class isn't thread safe
            // so we need to restrict access to it
            // using the C# `lock` keyword.
            lock (_randomLock)
            {
                index = _random.Next(0, 30);
            }

            return _quotes[index];
        }
    }
}