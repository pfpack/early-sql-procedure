#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static bool Equals(DbDataValue left, DbDataValue right)
            =>
            left.Equals(right);

        public override bool Equals(object? obj)
            =>
            obj is DbDataValue other && Equals(other);
    }
}