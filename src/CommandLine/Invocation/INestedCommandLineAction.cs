// -----------------------------------------------------------------------
// <copyright file="INestedCommandLineAction.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine.Invocation;

/// <summary>
/// A nested <see cref="Action"/>.
/// </summary>
public interface INestedCommandLineAction
{
    /// <summary>
    /// Gets the action.
    /// </summary>
    CommandLineAction Action { get; }
}