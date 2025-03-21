namespace FizzBuzzApp.Tests
{
    [TestFixture]
    public class FizzBuzzDetectorTests
    {
        private FizzBuzzDetector _detector;

        [SetUp]
        public void Setup()
        {
            _detector = new FizzBuzzDetector();
        }

        /// <summary>
        /// Tests the standard input as provided in the example.
        /// </summary>
        [Test]
        public void GetOverlappings_StandardInput_ReturnsExpectedOutputAndCount()
        {
            string input = @"Mary had a little lamb Little lamb, little lamb Mary had a little lamb It's fleece was white as snow";

            string expectedOutput = @"Mary had Fizz little Buzz Fizz lamb, little Fizz Buzz had Fizz little lamb FizzBuzz fleece was Fizz as Buzz";
            var result = _detector.GetOverlappings(input);

            Assert.AreEqual(expectedOutput, result.OutputString);
            Assert.AreEqual(9, result.Count);
        }

        /// <summary>
        /// Tests that punctuation is preserved while replacements occur on alphanumeric words.
        /// </summary>
        [Test]
        public void GetOverlappings_InputWithPunctuation_PreservesPunctuation()
        {
            string input = "Hello, world! This is test.";
            // Alphanumeric words extracted: 
            // 1: Hello, 2: world, 3: This (Fizz), 4: is, 5: test (Buzz)
            string expectedOutput = "Hello, world! Fizz is Buzz.";
            var result = _detector.GetOverlappings(input);

            Assert.AreEqual(expectedOutput, result.OutputString);
            Assert.AreEqual(2, result.Count);
        }

        /// <summary>
        /// Tests that a string of exactly 7 characters (minimum allowed length) is processed without error.
        /// </summary>
        [Test]
        public void GetOverlappings_MinimumLengthInput_ProcessedSuccessfully()
        {
            string input = "abc1234";  // Exactly 7 characters, one alphanumeric word.
            var result = _detector.GetOverlappings(input);

            // Since there's only one word, no replacement is expected.
            Assert.AreEqual("abc1234", result.OutputString);
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests that a string of exactly 100 characters (maximum allowed length) is processed correctly.
        /// This example constructs a string by repeating "abcdefg " 12 times (96 characters) then appending "abcd" to reach 100.
        /// </summary>
        [Test]
        public void GetOverlappings_MaximumLengthInput_ProcessedSuccessfully()
        {
            // Build a string of exactly 100 characters.
            // "abcdefg " is 8 characters. Repeating it 12 times gives 96 characters.
            // Append "abcd" to reach exactly 100 characters.
            string repeated = string.Empty;
            for (int i = 0; i < 12; i++)
            {
                repeated += "abcdefg ";
            }
            string input = repeated + "abcd"; // total length = 100

            // Expected behavior:
            // The input will be split into 13 words:
            // Words 1-12: "abcdefg" and word 13: "abcd".
            // Replacements occur at:
            // 3 -> Fizz, 5 -> Buzz, 6 -> Fizz, 9 -> Fizz, 10 -> Buzz, 12 -> Fizz.
            // Word 13 remains unchanged.
            string expectedOutput =
                "abcdefg abcdefg Fizz abcdefg Buzz Fizz abcdefg abcdefg Fizz Buzz abcdefg Fizz abcd";
            var result = _detector.GetOverlappings(input);

            Assert.AreEqual(expectedOutput, result.OutputString);
            // There are 6 replacements in total.
            Assert.AreEqual(6, result.Count);
        }

        /// <summary>
        /// Tests that passing a null input string throws an ArgumentNullException.
        /// </summary>
        [Test]
        public void GetOverlappings_NullInput_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _detector.GetOverlappings(null));
        }
    }
}