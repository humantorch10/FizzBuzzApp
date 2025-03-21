using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzzApp
{
    /// <summary>
    /// Represents the result of the FizzBuzz detection process.
    /// </summary>
    public class FizzBuzzResult
    {
        /// <summary>
        /// Gets or sets the output string with the replaced words.
        /// </summary>
        public string OutputString { get; set; }

        /// <summary>
        /// Gets or sets the total count of replacements (Fizz, Buzz, or FizzBuzz).
        /// </summary>
        public int Count { get; set; }

    }
}
