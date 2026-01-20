using Xunit;
using LIS.App;

namespace LIS.Tests
{
    public class LISFinderTests
    {
        [Fact]
        public void TestCase1()
        {
            var input = "6 1 5 9 2";
            var result = LISFinder.Find(input);
            Assert.Equal("1 5 9", result);
        }

        [Fact]
        public void TestCase2()
        {
            var input = "1710 2461 9288 10195 10431 12485";
            var result = LISFinder.Find(input);
            Assert.Equal("1710 2461 9288 10195 10431 12485", result);
        }
        [Fact]
        public void EmptyInput_ReturnsEmptySequence()
        {
            var result = LISFinder.Find("");

            Assert.Equal(string.Empty, result);
        }

        [Fact]
        public void SingleNumber_ReturnsThatNumber()
        {
            var result = LISFinder.Find("42");

            Assert.Equal("42", result);
        }
    }
}
