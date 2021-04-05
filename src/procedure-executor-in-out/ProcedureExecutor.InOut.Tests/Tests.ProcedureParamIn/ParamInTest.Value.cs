#nullable enable

using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    partial class ProcedureParamInTest
    {
        [Theory]
        [MemberData(nameof(GetValuesTestSource))]
        public void Value_ExpectValueIsSameAsSourceValue(
            object? sourceValue)
        {
            var paramIn = new ProcedureParamIn(name: SomeString, value: sourceValue);

            var actual = paramIn.Value;
            Assert.Equal(sourceValue, actual);
        }
    }
}