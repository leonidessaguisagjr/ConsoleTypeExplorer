ConsoleTypeExplorer
===================

Summary
-------

Utility for easily inspecting types and namespaces in a C# REPL (e.g. scriptcs).


Public Static Methods
---------------------

* `TypeExplorer.PrintTypeSummary(System.Type type, System.Boolean showAdditionalProperties)`
* `TypeExplorer.PrintTypeSummary(System.Type type)`
* `TypeExplorer.PrintTypeFields(System.Type type, System.Boolean showNonPublicFields)`
* `TypeExplorer.PrintTypeFields(System.Type type)`
* `TypeExplorer.PrintTypeProperties(System.Type type, System.Boolean showNonPublicProperties)`
* `TypeExplorer.PrintTypeProperties(System.Type type)`
* `TypeExplorer.PrintTypeMethods(System.Type type, System.Boolean showNonPublicMethods)`
* `TypeExplorer.PrintTypeMethods(System.Type type)`
* `TypeExplorer.PrintNamespaceTypes(System.String nameSpace, System.Boolean showNonPublicTypes)`
* `TypeExplorer.PrintNamespaceTypes(System.String nameSpace)`


Extension Methods
-----------------

* `TypeExtension.PrintSummary(this System.Type type, System.Boolean showAdditionalProperties)`
* `TypeExtension.PrintSummary(this System.Type type)`
* `TypeExtension.PrintPublicFields(this System.Type type)`
* `TypeExtension.PrintAllFields(this System.Type type)`
* `TypeExtension.PrintPublicProperties(this System.Type type)`
* `TypeExtension.PrintAllProperties(this System.Type type)`
* `TypeExtension.PrintPublicMethods(this System.Type type)`
* `TypeExtension.PrintAllMethods(this System.Type type)`


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

Extension method usage is as follows:

```
> scriptcs.exe
scriptcs (ctrl-c to exit or :help for help)

> #r ".\ConsoleTypeExplorer.dll"
> using Name.LeonidesSaguisagJr.ConsoleTypeExplorer;
> typeof(TypeExplorer).PrintSummary();
...
> typeof(TypeExplorer).PrintAllMethods();
```

Options
-------

By default, types are shown using the full type names i.e.:

```
> typeof(System.Type).PrintPublicFields();
Fields for type: Type
  public static readonly System.Reflection.MemberFilter FilterAttribute
  public static readonly System.Reflection.MemberFilter FilterName
  public static readonly System.Reflection.MemberFilter FilterNameIgnoreCase
  public static readonly System.Object Missing
  public static readonly System.Char Delimiter
  public static readonly System.Type[] EmptyTypes
>
```

To use short type names, set `TypeExplorer.Options["UseFullTypeNames"] = false;`.  For example:

```
> TypeExplorer.Options["UseFullTypeNames"] = false;
False
> typeof(System.Type).PrintPublicFields()
Fields for type: Type
  public static readonly MemberFilter FilterAttribute
  public static readonly MemberFilter FilterName
  public static readonly MemberFilter FilterNameIgnoreCase
  public static readonly Object Missing
  public static readonly Char Delimiter
  public static readonly Type[] EmptyTypes
>
```


Building
--------

Built using Microsoft Build Tools 2015 and MSBuild.  Should be compatible with Mono but this has not been tested yet.
