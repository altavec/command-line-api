// -----------------------------------------------------------------------
// <copyright file="NullScope.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine.Logging.Internal;

/// <summary>
/// An empty scope without any logic.
/// </summary>
internal sealed class NullScope : IDisposable
{
    private NullScope()
    {
    }

    /// <summary>
    /// Gets a cached instance of <see cref="NullScope"/>.
    /// </summary>
    public static NullScope Instance { get; } = new NullScope();

    /// <inheritdoc />
    public void Dispose()
    {
    }
}