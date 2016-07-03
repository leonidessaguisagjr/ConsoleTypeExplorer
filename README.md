ConsoleTypeExplorer
===============

Summary
-------

Utility for easily inspecting types and namespaces in a C# REPL (e.g. scriptcs).


Methods
-------

* `PrintTypeSummary`
* `PrintTypeFields`
* `PrintTypeProperties`
* `PrintTypeMethods`
* `PrintNamespaceTypes`


Usage
-----

Simply add an assembly reference, add a using directive and start calling the methods.  For example:

```
> scriptcs.exe
scriptcs (ctrl-c to exit or :help for help)

> #r ".\ConsoleTypeExplorer.dll"
> using Name.LeonidesSaguisagJr.ConsoleTypeExplorer;
> TypeExplorer.PrintTypeSummary(typeof(TypeExplorer), true);
...
> TypeExplorer.PrintTypeMethods(typeof(TypeExplorer), true);
...
> TypeExplorer.PrintNamespaceTypes("System.Globalization", true);
```

Building
--------

Built using Microsoft Build Tools 2015 and MSBuild.  Should be compatible with Mono but this has not been tested yet.
