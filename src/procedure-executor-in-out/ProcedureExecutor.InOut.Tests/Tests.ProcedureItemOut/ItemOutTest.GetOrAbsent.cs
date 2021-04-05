#nullable enable

using System;
using System.Collections.Generic;
using PrimeFuncPack.UnitTest;
using Xunit;
using static PrimeFuncPack.UnitTest.TestData;

namespace PrimeFuncPack.Data.ProcedureExecutor.InOut.Tests
{
    public sealed partial class ProcedureItemOutTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(WhiteSpaceString)]
        [InlineData(MixedWhiteSpacesString)]
        [InlineData(SomeString)]
        public void GetNotNullOrAbsent_SourceDataSetIsNull_ExpectKeyNotFoundException(
            string? fieldName)
        {
            var itemOut = new ProcedureItemOut(null);

            var ex = Assert.Throws<KeyNotFoundException>(() => _ = itemOut.GetNotNullOrAbsent<RefType>(fieldName));
            Assert.Contains(fieldName.OrEmpty(), ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(EmptyString)]
        [InlineData(WhiteSpaceString)]
        [InlineData(MixedWhiteSpacesString)]
        [InlineData(SomeString)]
        public void GetNotNullOrAbsent_SourceDataSetDoesNotContainRequiredField_ExpectKeyNotFoundException(
            string? fieldName)
        {
            var sourceDataSet = new Dictionary<string, object?>
            {
                [LowerSomeString] = PlusFifteenIdRefType
            };

            var itemOut = new ProcedureItemOut(sourceDataSet);

            var ex = Assert.Throws<KeyNotFoundException>(() => _ = itemOut.GetNotNullOrAbsent<RefType>(fieldName));
            Assert.Contains(fieldName.OrEmpty(), ex.Message);
        }

        [Fact]
        public void GetNotNullOrAbsent_TheFieldValueIsNull_ExpectAbsent()
        {
            var fieldName = SomeString;

            var sourceDataSet = new Dictionary<string, object?>
            {
                [LowerSomeString] = PlusFifteenIdRefType,
                [fieldName] = null,
                [UpperSomeString] = MinusFifteenIdNullNameRecord
            };

            var itemOut = new ProcedureItemOut(sourceDataSet);
            var actual = itemOut.GetNotNullOrAbsent<string>(fieldName);

            var expected = Optional<string>.Absent;
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void GetNotNullOrAbsent_TheFieldValueIsDBNull_ExpectAbsent()
        {
            var fieldName = SomeString;

            var sourceDataSet = new Dictionary<string, object?>
            {
                [fieldName] = DBNull.Value
            };

            var itemOut = new ProcedureItemOut(sourceDataSet);
            var actual = itemOut.GetNotNullOrAbsent<RefType>(fieldName);

            var expected = Optional<RefType>.Absent;
            Assert.Equal(expected, actual);
        }
    }
}