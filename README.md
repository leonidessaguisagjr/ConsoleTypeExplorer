CLITypeExplorer
===============

Summary
-------

Utility for easily inspecting types and namespaces in a C# REPL (e.g. scriptcs).


Methods
-------

* `ShowTypeSummary`
* `ShowTypeFields`
* `ShowTypeProperties`
* `ShowTypeMethods`
* `ListNamespaceTypes`


Usage
-----

Simply add an assembly reference, add a using directive and start calling the methods.  For example:

```
> scriptcs.exe
scriptcs (ctrl-c to exit or :help for help)

> #r ".\CLITypeExplorer.dll"
> using Name.LeonidesSaguisagJr.CLITypeExplorer;
> TypeExplorer.ShowTypeSummary(typeof(TypeExplorer), true);
...
> TypeExplorer.ShowTypeMethods(typeof(TypeExplorer), true);
...
> TypeExplorer.ListNamespaceTypes("System.Globalization", true);
```

Building
--------

Built using Microsoft Build Tools 2015 and MSBuild.  Should be compatible with Mono but this has not been tested yet.
