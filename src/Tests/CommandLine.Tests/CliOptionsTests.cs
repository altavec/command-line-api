// -----------------------------------------------------------------------
// <copyright file="CliOptionsTests.cs" company="Altavec">
// Copyright (c) Altavec. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace System.CommandLine;

public class CliOptionsTests
{
    [Fact]
    public void Verbosity()
    {
        VerbosityOption verbosity = new();
        _ = verbosity.Recursive.Should().BeTrue();
        _ = verbosity.HasDefaultValue.Should().BeTrue();
        _ = verbosity.DefaultValueFactory.Should().NotBeNull();
    }
}