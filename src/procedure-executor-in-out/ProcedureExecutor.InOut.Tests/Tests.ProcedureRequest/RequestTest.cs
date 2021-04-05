#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    public sealed partial class ProcedureRequestTest
    {
        private static IEnumerable<object[]> GetNotNullableParametersInTestSource()
            =>
            new IReadOnlyCollection<ProcedureParamIn>[]
            {
                Array.Empty<ProcedureParamIn>(),
                new ProcedureParamIn[]
                {
                    new(null, PlusFifteenIdSomeStringNameRecord),
                    new(SomeString, MinusFifteenIdRefType),
                    new(SomeString, null)
                }
            }
            .Select(v => new object[] { v });
    }
}