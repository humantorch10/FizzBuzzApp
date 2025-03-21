# FizzBuzz Detector

This repository contains a solution for a FizzBuzz-like problem where the application processes a given string and replaces every third alphanumeric word with **Fizz**, every fifth word with **Buzz**, and every word qualifying as both (i.e., every 15th word) with **FizzBuzz**. It also counts the number of these replacements.

## Table of Contents
- [Overview](#overview)
- [Project Structure](#project-structure)
- [Requirements](#requirements)
- [Installation](#installation)
- [Usage](#usage)
- [Running the Tests](#running-the-tests)
- [Code Style and Conventions](#code-style-and-conventions)

## Overview

The main functionality is provided by the `FizzBuzzDetector` class, which exposes the `getOverlappings` method. This method:
- Validates the input string (must be non-null and have a length between 7 and 100 characters).
- Processes only alphanumeric words (ignoring punctuation and extra whitespaces).
- Replaces every third word with **Fizz**, every fifth word with **Buzz**, and every fifteenth word with **FizzBuzz**.
- Returns an object containing:
  - The processed output string.
  - The count of replacements made.

Additionally, the solution includes a comprehensive suite of unit tests written using NUnit. These tests cover various cases such as:
- Standard multi-line input.
- Input containing punctuation.
- Edge cases with minimum (7 characters) and maximum (100 characters) input lengths.
- Null input (which should throw an exception).

## Project Structure

The solution is structured as follows:

```
FizzBuzzTask/
├── FizzBuzzApp/
│   ├── FizzBuzzDetector.cs   // Main implementation of the FizzBuzz logic
│   ├── FizzBuzzResult.cs     // Result class for getOverlappings method
├── FizzBuzzApp.Tests/
│   ├── FizzBuzzDetectorTests.cs  // NUnit test cases for the implementation
└── FizzBuzzTask.sln      // Visual Studio solution file
```

## Requirements

To build and run this project, ensure you have the following installed:

- [.NET SDK](https://dotnet.microsoft.com/download) (version 8.0)
- [NUnit](https://nunit.org/) for unit testing
- [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter/)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/)

## Installation

1. **Clone the repository:**
   ```bash
   git clone https://github.com/humantorch10/FizzBuzzApp.git
   cd FizzBuzzApp
   ```
2. **Build the project:**
   ```bash
   dotnet build
   ```

## Usage

To run the FizzBuzzDetector with a sample input, you can create a simple console application that calls `FizzBuzzDetector.getOverlappings(inputString)`.

```csharp
using System;

class Program
{
    static void Main()
    {
        string input = "Mary had a little lamb. Little lamb, little lamb.";
        FizzBuzzDetector detector = new FizzBuzzDetector();
        var result = detector.getOverlappings(input);
        Console.WriteLine("Output String: " + result.OutputString);
        Console.WriteLine("Count: " + result.Count);
    }
}
```

## Running the Tests

To run the unit tests using NUnit:

```bash
dotnet test
```

## Code Style and Conventions

This project follows Google's C# style guide. Key conventions include:
- Descriptive variable and method names.
- XML documentation comments for public methods.
- Consistent indentation and spacing.

