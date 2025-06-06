# remove any current values
$results = "$PSScriptRoot/coverage/results"
if (Test-Path -Path $results -Type Container) {
	Remove-Item $results -Force -Recurse
}

# Run dotnet test
dotnet test $PSScriptRoot\src --no-build -- --results-directory $results --coverage --coverage-output-format cobertura

# install the report generator
dotnet tool install -g dotnet-reportgenerator-globaltool

$reports = "$PSScriptRoot/coverage/reports"
if (Test-Path -Path $reports -Type Container) {
	Remove-Item $reports -Force -Recurse
}

# run the report generator
reportGenerator -reports:"$results/*.cobertura.xml" -targetdir:$reports -reporttypes:"HtmlInline;Cobertura;MarkdownSummary" -verbosity:Verbose