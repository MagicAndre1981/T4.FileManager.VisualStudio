![Build Status](https://dev.azure.com/databinding/Building%20Blocks/_apis/build/status/T4.FileManager?branchName=master) [![Nuget](https://img.shields.io/nuget/v/T4.FileManager.VisualStudio?label=T4.FileManager.VisualStudio)](https://www.nuget.org/packages/T4.FileManager.VisualStudio/)

# Requirements

- Visual Studio 2017 or Visual Studio 2019

# Getting started

Install the File Manager with nuget.

## .NET Core and .NET Standard

```
Install-Package T4.FileManager.VisualStudio
```

Build or rebuild the project where the File Manager has been added as a package. After that `T4.FileManager.VisualStudio.ttinclude` is automatically added to the project root.

### Short note on compatibility with .NET Core/.NET Standard

Compatibility is not possible directly with .NET Core. But due to the fact that T4 can be executed independently from C# code, it is possible to add the File Manager to a .NET Core project. This results in a certain dependency on Visual Studio and restrictions to other platforms. The code generated by the File Manager can then easily be .NET Core capable. 

## .NET Framework

```
Install-Package T4.FileManager.VisualStudio
```

`T4.FileManager.VisualStudio.ttinclude` should be automatically added to your project root.

## Usage

1. [Include to text template](include-to-text-template.md)
2. [Create instance](create-instance.md)
3. [Start or create file](start-or-create-file.md)
4. [Add header to files](add-header-to-files.md)
5. [Proceed to generate files](proceed-to-generate-files.md)
6. [Features](features.md)

## Other infos

- [Generated file infos as json](generated-file-infos-as-json.md)