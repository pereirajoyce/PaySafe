#!/usr/bin/env pwsh

[CmdletBinding()]
Param(
    [string]$Target = "Default",
    [string]$Configuration = "Release",
    [ValidateSet("Quiet", "Minimal", "Normal", "Verbose", "Diagnostic")]
    [string]$Verbosity = "Normal",
    [switch]$ShowDescription,
    [Alias("WhatIf", "Noop")]
    [switch]$DryRun,
    [switch]$Exclusive,
    [switch]$SkipToolPackageRestore,
    [Parameter(Position=0,Mandatory=$false,ValueFromRemainingArguments=$true)]
    [string[]]$ScriptArgs
)

# Attempt to set highest encryption available for SecurityProtocol.
# PowerShell will not set this by default (until maybe .NET 4.6.x). This
# will typically produce a message for PowerShell v2 (just an info
# message though)
try {
    # Set TLS 1.2 (3072), then TLS 1.1 (768), then TLS 1.0 (192)
    # Use integers because the enumeration values for TLS 1.2 and TLS 1.1 won't
    # exist in .NET 4.0, even though they are addressable if .NET 4.5+ is
    # installed (.NET 4.5 is an in-place upgrade).
    [System.Net.ServicePointManager]::SecurityProtocol = 3072 -bor 768 -bor 192
  } catch {
    Write-Output 'Unable to set PowerShell to use TLS 1.2 and TLS 1.1 due to old .NET Framework installed. If you see underlying connection closed or trust errors, you may need to upgrade to .NET Framework 4.5+ and PowerShell v3'
  }

###########################################################################
# CONFIGURATION
###########################################################################

$PSScriptRoot = Split-Path $MyInvocation.MyCommand.Path -Parent

$ToolsDir = Join-Path $PSScriptRoot "tools"
$CakeVersion = "4.0.0"
$DotNetInstallerUri = "https://dot.net/v1/dotnet-install.ps1"
$NugetUrl = "https://api.nuget.org/v3-flatcontainer/cake.tool/$CakeVersion/cake.tool.$CakeVersion.nupkg"

# Make sure tools folder exists
if ((Test-Path $PSScriptRoot) -and !(Test-Path $ToolsDir)) {
    Write-Verbose -Message "Creating tools directory..."
    New-Item -Path $ToolsDir -Type Directory | out-null
}

###########################################################################
# EXECUTION
###########################################################################

if (!$SkipToolPackageRestore) {
    # Restore tools from manifest
    Push-Location
    Set-Location $PSScriptRoot
    if (Test-Path "./.config/dotnet-tools.json") {
        dotnet tool restore
    }
    Pop-Location
}

# Build Cake arguments
$cakeArguments = @("$Target");
if ($Configuration) { $cakeArguments += "--configuration=$Configuration" }
if ($Verbosity) { $cakeArguments += "--verbosity=$Verbosity" }
if ($ShowDescription) { $cakeArguments += "--showdescription" }
if ($DryRun) { $cakeArguments += "--dryrun" }
if ($Exclusive) { $cakeArguments += "--exclusive" }
$cakeArguments += $ScriptArgs

# Start Cake
Write-Host "Running build script..." -ForegroundColor Cyan
(dotnet cake @cakeArguments)
exit $LASTEXITCODE