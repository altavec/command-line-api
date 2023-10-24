// -----------------------------------------------------------------------
// <copyright file="NestedSynchronousCliAction.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine.Invocation;

/// <summary>
/// A nested <see cref="SynchronousCliAction"/>.
/// </summary>
/// <remarks>
/// Initialises a new instance of the <see cref="NestedSynchronousCliAction"/> class.
/// </remarks>
/// <param name="action">The <see cref="CliAction"/>.</param>
public class NestedSynchronousCliAction(SynchronousCliAction action) : SynchronousCliAction, INestedAction<SynchronousCliAction>
{
    /// <inheritdoc/>
    public SynchronousCliAction Action { get; } = action;

    /// <inheritdoc/>
    public override int Invoke(ParseResult parseResult) => this.Action.Invoke(parseResult);
}