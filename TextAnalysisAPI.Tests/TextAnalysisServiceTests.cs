using NUnit.Framework;
using TextAnalysisAPI.Services;

namespace TextAnalysisAPI.Tests
{
    [TestFixture]
    public class TextAnalysisServiceTests
    {
        private TextAnalysisService _service;

        [SetUp]
        public void Setup()
        {
            _service = new TextAnalysisService();
        }

        [Test]
        public void CountWords_ShouldReturnCorrectCount()
        {
            string input = "hello world hello,";
            string[] words = { "hello" };
            int result = _service.CountWords(input, words);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ContainsWords_ShouldReturnTrue_WhenWordIsPresent()
        {
            string input = "hello world";
            string[] words = { "world" };
            bool result = _service.ContainsWords(input, words);
            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsWords_ShouldReturnFalse_WhenWordIsAbsent()
        {
            string input = "hello world";
            string[] words = { "planet" };
            bool result = _service.ContainsWords(input, words);
            Assert.IsFalse(result);
        }

        [Test]
        public void CountLetters_ShouldReturnCorrectCount()
        {
            string input = "hello world";
            char[] letters = { 'o' };
            int result = _service.CountLetters(input, letters);
            Assert.AreEqual(2, result);
        }

        [Test]
        public void ContainsLetters_ShouldReturnTrue_WhenLetterIsPresent()
        {
            string input = "hello world";
            char[] letters = { 'h' };
            bool result = _service.ContainsLetters(input, letters);
            Assert.IsTrue(result);
        }

        [Test]
        public void ContainsLetters_ShouldReturnFalse_WhenLetterIsAbsent()
        {
            string input = "hello world";
            char[] letters = { 'z' };
            bool result = _service.ContainsLetters(input, letters);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsBase64String_ShouldReturnTrue_ForValidBase64()
        {
            string input = "SGVsbG8gd29ybGQ="; // "Hello world" in Base64
            bool result = _service.IsBase64String(input);
            Assert.IsTrue(result);
        }

        [Test]
        public void IsBase64String_ShouldReturnFalse_ForInvalidBase64()
        {
            string input = "NotBase64!";
            bool result = _service.IsBase64String(input);
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_ShouldReturnTrue_ForValidEmail()
        {
            string[] validEmails = {
                "test@example.com",
                "user.name+tag+sorting@example.com",
                "\"john..doe\"@example.org"
            };

            foreach (var email in validEmails)
            {
                bool result = _service.IsValidEmail(email);
                Assert.IsTrue(result, $"Failed for email: {email}");
            }
        }

        [Test]
        public void IsValidEmail_ShouldReturnFalse_ForInvalidEmail()
        {
            string[] invalidEmails = {
                "plainaddress",
                "@missingusername.com",
                "username@.com",
                "username@com"
            };

            foreach (var email in invalidEmails)
            {
                bool result = _service.IsValidEmail(email);
                Assert.IsFalse(result, $"Failed for email: {email}");
            }
        }


        [TestCase("1500,3025", ExpectedResult = "1500,3025")]
        [TestCase("1500.3025", ExpectedResult = "1500,3025")]
        [TestCase("1500, 3025", ExpectedResult = "1500,3025")]
        [TestCase("1500. 3025", ExpectedResult = "1500,3025")]
        [TestCase("1500,00302500", ExpectedResult = "1500,00302500")]
        [TestCase("1500.00302500", ExpectedResult = "1500,00302500")]
        [TestCase("1,500.3025", ExpectedResult = "1500,3025")]
        [TestCase("1.500.3025", ExpectedResult = "1500,3025")]
        [TestCase("1,600,500.3025", ExpectedResult = "1600500,3025")]
        [TestCase("1.600,500.3025", ExpectedResult = "1600500,3025")]
        [TestCase("1,6.00,500.3025", ExpectedResult = "1600500,3025")]
        [TestCase("1,6.00.500.3025", ExpectedResult = "1600500,3025")]
        [TestCase("1_6_00_500_3025", ExpectedResult = "16005003025")]
        [TestCase("1_6_00_500.3025", ExpectedResult = "1600500,3025")]
        [TestCase("1_6_00_500_3025.01", ExpectedResult = "16005003025,01")]
        [TestCase("1_6_00_500.3025.01", ExpectedResult = "16005003025,01")]
        [TestCase("1,6.00,500.3025m", ExpectedResult = "1600500,3025")]
        [TestCase("1,6.00.500.3025m", ExpectedResult = "1600500,3025")]
        [TestCase("f1,600,500.3025", ExpectedResult = "0")]
        [TestCase("f1.600,500.3025", ExpectedResult = "0")]
        [TestCase(" ", ExpectedResult = "0")]
        public string ConvertStringToDecimal_Test(string input)
        {
            return _service.ConvertStringToDecimal(input);
        }
    }
}
