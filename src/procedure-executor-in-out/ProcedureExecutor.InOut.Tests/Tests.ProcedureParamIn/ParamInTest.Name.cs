#nullable enable

using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    partial class ProcedureParamInTest
    {
        [Theory]
        [InlineData(null, EmptyString)]
        [InlineData(EmptyString, EmptyString)]
        [InlineData(WhiteSpaceString, WhiteSpaceString)]
        [InlineData(MixedWhiteSpacesString, MixedWhiteSpacesString)]
        [InlineData(SomeString, SomeString)]
        public void Name_ExpectCorrectNameValue(
            string? sourceNameValue,
            string expectedNameValue)
        {
            var paramIn = new ProcedureParamIn(name: sourceNameValue, value: new());

            var actual = paramIn.Name;
            Assert.Equal(expectedNameValue, actual);
        }
    }
}