// -----------------------------------------------------------------------
// <copyright file="INestedAction{T}.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine.Invocation;

/// <summary>
/// A nested <see cref="CliAction"/>.
/// </summary>
/// <typeparam name="T">The action type.</typeparam>
public interface INestedAction<out T>
    where T : CliAction
{
    /// <summary>
    /// Gets the action.
    /// </summary>
    T Action { get; }
}