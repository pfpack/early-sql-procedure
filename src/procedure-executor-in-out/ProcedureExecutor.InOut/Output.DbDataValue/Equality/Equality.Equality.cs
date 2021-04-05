#nullable enable

namespace PrimeFuncPack.Data
{
    partial struct DbDataValue
    {
        public static bool operator ==(DbDataValue left, DbDataValue right)
            =>
            left.Equals(right);

        public static bool operator !=(DbDataValue left, DbDataValue right)
            =>
            left.Equals(right) is false;
    }
}