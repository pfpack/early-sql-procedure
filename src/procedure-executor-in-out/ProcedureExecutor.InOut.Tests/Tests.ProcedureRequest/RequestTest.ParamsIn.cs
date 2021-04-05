#nullable enable

using System.Collections.Generic;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    partial class ProcedureRequestTest
    {
        [Theory]
        [MemberData(nameof(GetNotNullableParametersInTestSource))]
        public void ParamsIn_SourceValueIsNotNull_ExpectParamsInAreSameAsSource(
            IReadOnlyCollection<ProcedureParamIn> sourceParamsIn)
        {
            var request = new ProcedureRequest(procedureName: LowerSomeString, paramsIn: sourceParamsIn);

            var actual = request.ParamsIn;
            Assert.Same(sourceParamsIn, actual);
        }

        [Fact]
        public void ParamsIn_SourceValueIsNull_ExpectParamsInAreEmpty()
        {
            var request = new ProcedureRequest(procedureName: SomeString, paramsIn: null);

            var actual = request.ParamsIn;
            Assert.Empty(actual);
        }

        [Fact]
        public void ParamsInWithoutParamsIn_ExpectParamsInAreEmpty()
        {
            var request = new ProcedureRequest(procedureName: SomeString);

            var actual = request.ParamsIn;
            Assert.Empty(actual);
        }
    }
}