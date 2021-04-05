#nullable enable

using System;

namespace PrimeFuncPack.Data
{
    public delegate InvalidCastException CastExceptionFactory(
        Type expectedType,
        Type? actualType);
}