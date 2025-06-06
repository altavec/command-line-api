﻿// -----------------------------------------------------------------------
// <copyright file="AnsiConsoleCommandExtensionsTests.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine.Spectre;

using TUnit.Assertions.AssertConditions.Throws;

public class AnsiConsoleCommandExtensionsTests
{
    [Test]
    public async Task AddFigletToRoot()
    {
        TestConsole console = new();
        RootCommand command = [];
        _ = command.AddFiglet("value", Color.Blue, console);

        CommandLineConfiguration configuration = new(command);

        _ = await configuration.Parse("--help").InvokeAsync();

        _ = await Assert.That(console.Lines.Skip(1)).IsNotEmpty();
    }

    [Test]
    public async Task AddFigletTooEarly()
    {
        Command command = new(nameof(AddFigletTooEarly));
        _ = await Assert.That(() => command.AddFiglet("value", Color.Blue)).Throws<InvalidOperationException>();
    }

    [Test]
    public async Task AddFigletToSubCommand()
    {
        TestConsole console = new();
        Command command = new(nameof(AddFigletToSubCommand));

        CommandLineConfiguration configuration = new(new RootCommand { command });
        _ = command.AddFiglet("value", Color.Blue, console);

        _ = await configuration.Parse($"{nameof(AddFigletToSubCommand)} --help").InvokeAsync();

        _ = await Assert.That(console.Lines.Skip(1)).IsNotEmpty();
    }

    [Test]
    public async Task AddFigletToSubCommandAndInvokeRoot()
    {
        TestConsole console = new();
        Command command = new(nameof(AddFigletToSubCommandAndInvokeRoot));

        CommandLineConfiguration configuration = new(new RootCommand { command });
        _ = command.AddFiglet("value", Color.Blue, console);

        _ = await configuration.Parse("--help").InvokeAsync();

        _ = await Assert.That(console.Lines.Skip(1)).IsEmpty();
    }
}