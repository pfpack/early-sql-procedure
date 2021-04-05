#nullable enable

using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    partial class ProcedureRequestTest
    {
        [Theory]
        [InlineData(null, EmptyString)]
        [InlineData(EmptyString, EmptyString)]
        [InlineData(WhiteSpaceString, WhiteSpaceString)]
        [InlineData(MixedWhiteSpacesString, MixedWhiteSpacesString)]
        [InlineData(SomeString, SomeString)]
        public void ProcedureName_ExpectCorrectProcedureName(
            string? sourceProcedureName,
            string expectedProcedureName)
        {
            var request = new ProcedureRequest(
                procedureName: sourceProcedureName,
                paramsIn: new ProcedureParamIn[] { new(SomeString, new()) });

            var actual = request.ProcedureName;
            Assert.Equal(expectedProcedureName, actual);
        }

        [Theory]
        [InlineData(null, EmptyString)]
        [InlineData(EmptyString, EmptyString)]
        [InlineData(WhiteSpaceString, WhiteSpaceString)]
        [InlineData(MixedWhiteSpacesString, MixedWhiteSpacesString)]
        [InlineData(SomeString, SomeString)]
        public void ProcedureNameWithoutParamsIn_ExpectCorrectProcedureName(
            string? sourceProcedureName,
            string expectedProcedureName)
        {
            var request = new ProcedureRequest(procedureName: sourceProcedureName);

            var actual = request.ProcedureName;
            Assert.Equal(expectedProcedureName, actual);
        }
    }
}