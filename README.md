# FindTheDesktop

A command-line utility for searching `.desktop` files in XDG application directories on Unix/Linux systems.

## Description

FindTheDesktop searches through all directories specified in the `XDG_DATA_DIRS` environment variable for `.desktop`
files that match your search terms. This is useful for finding application launchers, examining desktop entries, or
debugging XDG desktop integration.

## Prerequisites

- .NET 10.0 SDK or runtime
- A Unix/Linux system with XDG directories configured (most Linux distributions)

OR

- Nix

## Building from Source
 - `dotnet run`

## Running on a system with `nix` installed:

`nix run github:Krutonium/FindTheDesktop -- search term here`

You can also add it to your flake if you wish.
