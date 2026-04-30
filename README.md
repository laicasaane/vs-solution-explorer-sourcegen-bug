# Visual Studio Solution Explorer SourceGen Bug

## Environment

- Unity 6000.3.13f1
- Visual Studio 2026 (18.5.2)

## Description

In the screenshot below, there are two groups of source generator dlls:
1. Green group: The dlls come from Unity installation directory.
2. Red group: The dlls come from the project's `Library/PackageCache` directory.

The generators in the Green group are listed in the Solution Explorer when we expand the reference dlls, while the ones in the Red group are not listed.

![Some Source Generators are not listed in the Solution Explorer](imgs/solution-explorer.png)

## Steps to Reproduce

1. Have an instance of Unity 6000.3.13f1 installed.
2. Clone this repository and open the project in Unity.
3. Open the generated Visual Studio solution.
4. Navigate to the Solution Explorer and expand "Analyzers" category under "Dependencies".
5. Expand each reference dll and observe whether the source generators are listed.
6. Navigate to the `Assets/Game.Runtime/EntitySystem.cs` file.
7. Right-click on the `EntitySystem` struct, then use "Go to Definition" context menu.
8. Observe the result panel.
    - The generators from the Red group do work as expected, even though they are not listed in the Solution Explorer.

![Use "Go to Definition" to navigate to generated code](imgs/go-to-definition.png)
