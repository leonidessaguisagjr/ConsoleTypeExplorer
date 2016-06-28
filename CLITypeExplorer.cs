/*
 * How to use:
 * > #r ".\CLITypeExplorer.dll"
 * > using Name.LeonidesSaguisagJr.CLITypeExplorer;
 * > TypeExplorer.ShowTypeSummary(typeof(TypeExplorer), true);
 * > TypeExplorer.ShowTypeMethods(typeof(TypeExplorer), true);
 * > TypeExplorer.ListNamespaceTypes("System.Globalization", true);
 */

namespace Name.LeonidesSaguisagJr.CLITypeExplorer {
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Resources;
    using System.Text;

    public sealed class TypeExplorer {
        public static void ShowTypeSummary(System.Type type, System.Boolean showAdditionalProperties) {
            Console.WriteLine("Information for Type: {0}", type.Name);
            Console.WriteLine("  FullName: {0}", type.FullName);
            Console.WriteLine("  AssemblyQualifiedName: {0}", type.AssemblyQualifiedName);
            Console.WriteLine("  BaseType: {0}", type.BaseType);
            Console.WriteLine("  Namespace: {0}", type.Namespace);
            Console.WriteLine("  Assembly: {0}", type.Assembly);

            if (showAdditionalProperties) {
                foreach (System.Reflection.PropertyInfo propInfo in typeof(System.Reflection.TypeInfo).GetProperties()) {
                    if (propInfo.Name.StartsWith("Is")) {
                        Console.WriteLine("  {0}: {1}", propInfo.Name, propInfo.GetValue(type));
                    }
                }
            }
        }

        public static void ShowTypeSummary(System.Type type) {
            ShowTypeSummary(type, false);
        }

/*
        public static void ShowTypeInfo(System.String typeName, System.Boolean showAdditionalProperties) {
            System.Type type = System.Type.GetType(typeName);
            if (null == type) {
                Console.WriteLine("ERROR: Unrecognized type: {0}", typeName);
                Console.WriteLine("Type names are case-sensitive and should be fully qualified.");
            } else {
                ShowInfo(type);
            }
        }

        public static void ShowTypeInfo(System.String typeName) {
            ShowInfo(typeName, false);
        }
*/

        private static System.String GetFieldAttributes(System.Reflection.FieldInfo fi) {
            System.Text.StringBuilder attributes = new System.Text.StringBuilder();
            if (fi.IsPrivate) {
                attributes.Append("private ");
            } else if (fi.IsFamily) {
                attributes.Append("protected ");
            } else if (fi.IsAssembly) {
                attributes.Append("internal ");
            } else if (fi.IsPublic) {
                attributes.Append("public ");
            }

            if (fi.IsStatic) {
                attributes.Append("static ");
            }

            if (fi.IsInitOnly) {
                attributes.Append("readonly ");
            }

            return attributes.ToString();
        }

        private static System.String GetFieldSignature(System.Reflection.FieldInfo fi, System.Int32 indent) {
            System.Text.StringBuilder fieldSignature = new System.Text.StringBuilder(new System.String(' ', indent));
            fieldSignature.Append(GetFieldAttributes(fi));
            fieldSignature.Append(string.Format(CultureInfo.CurrentCulture, "{0} {1}", fi.FieldType.FullName, fi.Name));
            return fieldSignature.ToString();
        }

        public static void ShowTypeFields(System.Type type, System.Boolean showNonPublicFields) {
            Console.WriteLine("Fields for type: {0}", type.Name);
            IEnumerable<System.Reflection.FieldInfo> publicFieldList = from fi in type
                .GetFields(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.Public) select fi;
            foreach (System.Reflection.FieldInfo fi in publicFieldList) {
                Console.WriteLine(GetFieldSignature(fi, 2));
            }
            if (showNonPublicFields) {
                IEnumerable<System.Reflection.FieldInfo> nonPublicFieldList = from fi in type
                    .GetFields(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.NonPublic) select fi;
                foreach (System.Reflection.FieldInfo fi in nonPublicFieldList) {
                    Console.WriteLine(GetFieldSignature(fi, 2));
                }
            }
        }

        public static void ShowTypeFields(System.Type type) {
            ShowTypeFields(type, false);
        }

        private static System.String GetPropertySignature(System.Reflection.PropertyInfo pi, System.Int32 indent) {
            System.Text.StringBuilder propertySignature = new System.Text.StringBuilder(new System.String(' ', indent));
            propertySignature.Append(string.Format(CultureInfo.CurrentCulture, "{0} {1} {{ ", pi.PropertyType.FullName, pi.Name));
            if (!pi.CanRead) {
                propertySignature.Append("private ");
            }
            propertySignature.Append("get; ");
            if (!pi.CanWrite) {
                propertySignature.Append("private ");
            }
            propertySignature.Append("set; }");
            return propertySignature.ToString();
        }

        public static void ShowTypeProperties(System.Type type, System.Boolean showNonPublicProperties) {
            Console.WriteLine("Public properties for type: {0}", type.Name);
            IEnumerable<System.Reflection.PropertyInfo> publicPropertyList = from pi in type
                .GetProperties(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.Public) select pi;
            foreach (System.Reflection.PropertyInfo pi in publicPropertyList) {
                Console.WriteLine(GetPropertySignature(pi, 2));
            }
            if (showNonPublicProperties) {
                Console.WriteLine("Non-public properties for type: {0}", type.Name);
                IEnumerable<System.Reflection.PropertyInfo> nonPublicPropertyList = from pi in type
                    .GetProperties(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.NonPublic) select pi;
                foreach (System.Reflection.PropertyInfo pi in nonPublicPropertyList) {
                    Console.WriteLine(GetPropertySignature(pi, 2));
                }
            }
        }

        public static void ShowTypeProperties(System.Type type) {
            ShowTypeProperties(type, false);
        }

        private static System.String GetMethodAttributes(System.Reflection.MethodInfo mi) {
            System.Text.StringBuilder attributes = new System.Text.StringBuilder();
            if (mi.IsPrivate) {
                attributes.Append("private ");
            } else if (mi.IsFamily) {
                attributes.Append("protected ");
            } else if (mi.IsAssembly) {
                attributes.Append("internal ");
            } else if (mi.IsPublic) {
                attributes.Append("public ");
            }

            if (mi.IsAbstract) {
                attributes.Append("abstract ");
            }

            if (mi.IsFinal) {
                attributes.Append("sealed ");
            }

            if (mi.IsVirtual) {
                attributes.Append("virtual ");
            }

            if (mi.IsStatic) {
                attributes.Append("static ");
            }

            if (mi.IsHideBySig) {
                attributes.Append("new ");
            }

            return attributes.ToString();
        }

        private static System.String GetMethodSignature(System.Reflection.MethodInfo mi, System.Int32 indent) {
            System.Text.StringBuilder methodSignature = new System.Text.StringBuilder(new System.String(' ', indent));
            methodSignature.Append(GetMethodAttributes(mi));
            methodSignature.Append(string.Format(CultureInfo.CurrentCulture, "{0} {1}", mi.ReturnType.FullName, mi.Name));
            methodSignature.Append("(");
            List<string> paramList = new List<string>();
            foreach (System.Reflection.ParameterInfo paramInfo in mi.GetParameters()) {
                paramList.Add(string.Format(CultureInfo.CurrentCulture, "{0} {1}", paramInfo.ParameterType.FullName, paramInfo.Name));
            }
            methodSignature.Append(System.String.Join(", ", paramList));
            methodSignature.Append(")");
            return methodSignature.ToString();

        }

        public static void ShowTypeMethods(System.Type type, System.Boolean showNonPublicMethods) {
            Console.WriteLine("Public methods for type: {0}", type.Name);
            IEnumerable<System.Reflection.MethodInfo> publicMethodList = from mi in type
                .GetMethods(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.Public) select mi;
            foreach (System.Reflection.MethodInfo mi in publicMethodList) {
                Console.WriteLine(GetMethodSignature(mi, 2));
            }
            if (showNonPublicMethods) {
                Console.WriteLine("Non-public methods for type: {0}", type.Name);
                IEnumerable<System.Reflection.MethodInfo> nonPublicMethodList = from mi in type
                    .GetMethods(BindingFlags.Instance|BindingFlags.Static|BindingFlags.DeclaredOnly|BindingFlags.NonPublic) select mi;
                foreach (System.Reflection.MethodInfo mi in nonPublicMethodList) {
                    Console.WriteLine(GetMethodSignature(mi, 2));
                }
            }
        }

        public static void ShowTypeMethods(System.Type type) {
            ShowTypeMethods(type, false);
        }

        private static System.String GetTypeSignature(System.Type type, System.Int32 indent) {
            System.Text.StringBuilder typeSignature = new System.Text.StringBuilder(new System.String(' ', indent));
            System.Reflection.TypeAttributes attributes = type.Attributes;
            System.Reflection.TypeAttributes visibility = attributes & System.Reflection.TypeAttributes.VisibilityMask;
            switch (visibility) {
                case TypeAttributes.NotPublic:
                    typeSignature.Append("private ");
                    break;
                case TypeAttributes.Public:
                    typeSignature.Append("public ");
                    break;
                case TypeAttributes.NestedFamily:
                    typeSignature.Append("protected ");
                    break;
                case TypeAttributes.NestedAssembly:
                    typeSignature.Append("internal");
                    break;
                case TypeAttributes.NestedFamORAssem:
                    typeSignature.Append("protected internal");
                    break;
            }


            if (type.IsAbstract) {
                typeSignature.Append("abstract ");
            }

            if (type.IsSealed) {
                typeSignature.Append("sealed ");
            }

            if (type.IsEnum) {
                typeSignature.Append("enum ");
            }

            if (type.IsInterface) {
                typeSignature.Append("interface ");
            }

            if (type.IsClass) {
                typeSignature.Append("class ");
            }

            typeSignature.Append(type.Name);

            if (type.IsArray) {
                typeSignature.Append("[]");
            }

            if ((type.BaseType != null) || (type.GetInterfaces().Length != 0)) {
                typeSignature.Append(" : ");
                List<System.String> baseTypeAndInterfaces = new List<System.String>();
                if (type.BaseType != null) {
                    baseTypeAndInterfaces.Add(type.BaseType.FullName);
                }
                System.Type[] interfaceList = type.GetInterfaces();
                if (interfaceList.Length != 0) {
                    foreach (System.Type currInterface in interfaceList) {
                        baseTypeAndInterfaces.Add(currInterface.FullName);
                    }
                }
                typeSignature.Append(String.Join(", ", baseTypeAndInterfaces));
            }

            return typeSignature.ToString();
        }

        public static void ListNamespaceTypes(System.String nameSpace, System.Boolean showNonPublicTypes) {
            Console.WriteLine("Types defined in namespace: {0}", nameSpace);
            IEnumerable<System.Type> publicTypes = from asm in AppDomain.CurrentDomain.GetAssemblies()
                from t in asm.GetTypes() where t.Namespace == nameSpace && t.IsPublic select t;
            foreach (System.Type type in publicTypes) {
                Console.WriteLine(GetTypeSignature(type, 2));
            }
            if (showNonPublicTypes) {
                IEnumerable<System.Type> nonPublicTypes = from asm in AppDomain.CurrentDomain.GetAssemblies()
                    from t in asm.GetTypes() where t.Namespace == nameSpace && !(t.IsPublic) select t;
                foreach (System.Type type in nonPublicTypes) {
                    Console.WriteLine(GetTypeSignature(type, 2));
                }
            }
        }

/*
        public static void Main() {
            // ShowInfo(typeof(System.Collections.Generic.List<System.String>), true);
            // ShowMethods(typeof(System.Collections.Generic.List<System.String>), true);
            // ShowFields(typeof(System.Collections.Generic.List<System.String>), true);
            // ShowProperties(typeof(System.Collections.Generic.List<System.String>), true);
            ListNamespaceTypes("System.Globalization", false);
        }
*/
    }
}
