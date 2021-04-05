#nullable enable

using System.Collections.Generic;
using System.Linq;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    public sealed partial class ProcedureParamInTest
    {
        private static IEnumerable<object?[]> GetValuesTestSource()
            =>
            new object?[]
            {
                null,
                new(),
                new { Id =  PlusFifteen, Name = SomeString },
                MinusFifteenIdSomeStringNameRecord,
                PlusFifteenIdRefType,
                SomeTextStructType
            }
            .Select(v => new[] { v });
    }
}