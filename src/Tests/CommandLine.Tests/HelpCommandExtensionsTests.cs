﻿// -----------------------------------------------------------------------
// <copyright file="HelpCommandExtensionsTests.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine;

public class HelpCommandExtensionsTests
{
    [Test]
    public async Task ConfigureHelp()
    {
        Help.HelpBuilder? builder = default;
        RootCommand command = [];
        _ = command.ConfigureHelp(b => builder = b);

        _ = await Assert.That(builder).IsNotNull();
    }

    [Test]
    public async Task NoHelpAction()
    {
        Help.HelpBuilder? builder = default;
        RootCommand command = [];
        command.Options.Clear();
        command.Directives.Clear();

        _ = command.ConfigureHelp(b => builder = b);

        _ = await Assert.That(builder).IsNull();
    }

    [Test]
    public async Task NoRootCommand()
    {
        Help.HelpBuilder? builder = default;
        Command command = new(nameof(NoRootCommand));
        _ = command.ConfigureHelp(b => builder = b);

        _ = await Assert.That(builder).IsNull();
    }

    [Test]
    public async Task NestedCommand()
    {
        Help.HelpBuilder? builder = default;
        Command command = new(nameof(NestedCommand));
        _ = new RootCommand { command };

        _ = command.ConfigureHelp(b => builder = b);

        _ = await Assert.That(builder).IsNotNull();
    }
}