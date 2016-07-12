ConsoleTypeExplorer
===================

Summary
-------

Utility library for easily inspecting types and namespaces in a C# REPL (e.g. scriptcs).


Public Static Methods
---------------------

This library provides the following public static methods:

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

This library provides the following extension methods to `System.Type`:

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

Simply add an assembly reference, add a using directive and start calling the methods.  For example, the static methods could be used as follows:

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

Extension methods could be used as follows:

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

By default, members and types are displayed with modifiers i.e.:

```
> typeof(System.Int32).PrintPublicMethods();
Public methods for type: Int32
  public sealed virtual new Int32 CompareTo(Object value)
  public sealed virtual new Int32 CompareTo(Int32 value)
  public virtual new Boolean Equals(Object obj)
  public sealed virtual new Boolean Equals(Int32 obj)
  public virtual new Int32 GetHashCode()
  public virtual new String ToString()
  public new String ToString(String format)
  public sealed virtual new String ToString(IFormatProvider provider)
  public sealed virtual new String ToString(String format, IFormatProvider provider)
  public static new Int32 Parse(String s)
  public static new Int32 Parse(String s, NumberStyles style)
  public static new Int32 Parse(String s, IFormatProvider provider)
  public static new Int32 Parse(String s, NumberStyles style, IFormatProvider provider)
  public static new Boolean TryParse(String s, Int32& result)
  public static new Boolean TryParse(String s, NumberStyles style, IFormatProvider provider, Int32& result)
  public sealed virtual new TypeCode GetTypeCode()
>
```

To prevent displaying the modifiers, set `TypeExplorer.Options["ShowMemberModifiers"] = false;`.  For example:
```
> TypeExplorer.Options["ShowMemberModifiers"] = false;
False
> typeof(System.Int32).PrintPublicMethods();
Public methods for type: Int32
  Int32 CompareTo(Object value)
  Int32 CompareTo(Int32 value)
  Boolean Equals(Object obj)
  Boolean Equals(Int32 obj)
  Int32 GetHashCode()
  String ToString()
  String ToString(String format)
  String ToString(IFormatProvider provider)
  String ToString(String format, IFormatProvider provider)
  Int32 Parse(String s)
  Int32 Parse(String s, NumberStyles style)
  Int32 Parse(String s, IFormatProvider provider)
  Int32 Parse(String s, NumberStyles style, IFormatProvider provider)
  Boolean TryParse(String s, Int32& result)
  Boolean TryParse(String s, NumberStyles style, IFormatProvider provider, Int32& result)
  TypeCode GetTypeCode()
```


Building
--------

This utility library has been built using Microsoft Build Tools 2015 and MSBuild.  It should theoretically be compatible with Mono and .NET Core but this has not been tested yet.

Simply invoke MSBuild with no options to build.

```
C:\src\github\ConsoleTypeExplorer>msbuild
Microsoft (R) Build Engine version 14.0.25420.1
Copyright (C) Microsoft Corporation. All rights reserved.

Build started 7/12/2016 12:02:49 AM.
Project "C:\src\github\ConsoleTypeExplorer\ConsoleTypeExplorer.proj" on node 1 (default targets).
CreateDirs:
  Creating directory "build\".
  Creating directory "build\bin\".
Build:
  C:\Program Files (x86)\MSBuild\14.0\bin\csc.exe /debug:full /out:build\bin\ConsoleTypeExplorer.dll /target:library As
  semblyInfo.cs ConsoleTypeExplorer.cs
Done Building Project "C:\src\github\ConsoleTypeExplorer\ConsoleTypeExplorer.proj" (default targets).


Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:02.82

C:\src\github\ConsoleTypeExplorer>
```

To remove the compiled binaries and any intermediate files, invoke MSBuild with the `/t:clean` switch.

```
C:\src\github\ConsoleTypeExplorer>msbuild /t:clean
Microsoft (R) Build Engine version 14.0.25420.1
Copyright (C) Microsoft Corporation. All rights reserved.

Build started 7/12/2016 12:03:51 AM.
Project "C:\src\github\ConsoleTypeExplorer\ConsoleTypeExplorer.proj" on node 1 (clean target(s)).
Clean:
  Removing directory "build\".
Done Building Project "C:\src\github\ConsoleTypeExplorer\ConsoleTypeExplorer.proj" (clean target(s)).


Build succeeded.
    0 Warning(s)
    0 Error(s)

Time Elapsed 00:00:00.08

C:\src\github\ConsoleTypeExplorer>
```

Changelog
---------

1.0.0.0 (2016-07-12): Initial release
