using System.Dynamic;

namespace CPPPPAdvancedProgramming7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Object Creation With Activator Class
            /*Type ObjTyp = typeof(MyClass);
            MyClass obj1 = (MyClass)Activator.CreateInstance(ObjTyp);*/


            //Object Creation With DynamicObject Class
            //This class gives us the ability to process the object||variable||whatever taken dynamically via dynamic keyword.
            //To utilize from the class, the instance of it should be assigned to a dynamic structure instead of the reference point of the same class.
            /*dynamic obj1 = new MyClass1();
            obj1.RandomProperty1 = 1;
            obj1.RandomProperty2 = "2";
            obj1.RandomProperty3 = true;*/ //TrySetMember() called. Don't forget that this ability is not something steming from operator =' overloading, operator = is not overloadable.


            //Optional, Temporary Object Creation With ExpandoObject Class
            //This topic might evoke anonymous types to you but do not forget that anonymous type temp objects are not created during runtime.
            
            /*dynamic tempObj1 = new ExpandoObject();
            tempObj1.property1 = 1;
            tempObj1.property2 = "1";
            tempObj1.property3 = false;*/

            //Anonymous Type Objects VS Dynamic Objects
            //----------------------------------------------------------------------------------------------------------------
            //Anonymous types in C# are resolved at compile-time and are strongly typed, ensuring type safety,
            //whereas dynamic types are resolved at runtime and are weakly typed.

            //Anonymous types cannot be modified after creation and do not allow adding new members,
            //while dynamic types can be modified at runtime and support adding new members dynamically.

            //Accessing anonymous type properties requires reflection, whereas dynamic types rely on runtime lookup instead.

            //In terms of performance, anonymous types are faster due to compile-time resolution,
            //whereas dynamic types are slower due to the overhead of runtime lookup.
            //----------------------------------------------------------------------------------------------------------------

        }
    }
    class MyClass { public MyClass() { Console.WriteLine("MyClass object created!"); } }
    class MyClass1 : DynamicObject { 
        public MyClass1() { 
            Console.WriteLine("MyClass1 object created!"); 
        }
        readonly private Dictionary<string, object> properties = new();
        public override bool TrySetMember(SetMemberBinder binder, object? value)
        //TrySetMember() calling when a random type property not declared in the relevant class body is created is kinda something that exists in the essence of C# Runtime Behaviour.
        //It is part of C#'s core dynamic binding system, which is implemented via the Dynamic Language Runtime (DLR).
        {
            properties.Add(binder.Name, value);
            return true;
        }
        public override bool TryGetMember(GetMemberBinder binder, out object? result)
        {
            return properties.TryGetValue(binder.Name, out result);
        }
    }
}
