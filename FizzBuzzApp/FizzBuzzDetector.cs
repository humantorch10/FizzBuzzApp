using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FizzBuzzApp
{
    /// <summary>
    /// Provides functionality for processing a string and replacing every third word with "Fizz",
    /// every fifth word with "Buzz", and every word that qualifies as both with "FizzBuzz".
    /// </summary>
    public class FizzBuzzDetector
    {
        /// <summary>
        /// Processes the input string by replacing words at specific positions based on the rules:
        /// every 3rd word becomes "Fizz", every 5th word becomes "Buzz", and every 15th word becomes "FizzBuzz".
        /// Non-alphanumeric tokens (symbols, punctuation, and extra whitespace) are preserved but not counted.
        /// </summary>
        /// <param name="input">The input string to process. Must have a length between 7 and 100 (inclusive) and not be null.</param>
        /// <returns>
        /// A <see cref="FizzBuzzResult"/> instance containing:
        /// - <c>OutputString</c>: the string with appropriate replacements,
        /// - <c>Count</c>: the total number of replacements made.
        /// </returns>
        /// <exception cref="ArgumentNullException">Thrown when the input string is null.</exception>
        /// <exception cref="ArgumentException">Thrown when the input string length is outside the allowed range.</exception>
        public FizzBuzzResult GetOverlappings(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException(nameof(input), "Input string cannot be null.");
            }

            if (input.Length < 7 || input.Length > 100)
            {
                throw new ArgumentException("Input string length must be between 7 and 100 characters.", nameof(input));
            }

            // Counter for alphanumeric words encountered across the entire input.
            int wordCounter = 0;

            // Counter for the number of Fizz, Buzz, or FizzBuzz replacements made.
            int encounterCount = 0;

            // Regular expression to match alphanumeric words and single qoute character.
            // \b[A-Za-z0-9']+\b matches whole words composed of letters and digits and single qoute character.
            string pattern = @"\b[A-Za-z0-9']+\b";

            string result = Regex.Replace(input, pattern, match => {
                wordCounter++;
                bool isFizz = (wordCounter % 3 == 0);
                bool isBuzz = (wordCounter % 5 == 0);

                if (isFizz && isBuzz)
                {
                    encounterCount++;
                    return "FizzBuzz";
                }
                else if (isFizz)
                {
                    encounterCount++;
                    return "Fizz";
                }
                else if (isBuzz)
                {
                    encounterCount++;
                    return "Buzz";
                }
                else
                {
                    return match.Value;
                }
            });

            return new FizzBuzzResult
            {
                OutputString = result,
                Count = encounterCount
            };

        }
    }
}
