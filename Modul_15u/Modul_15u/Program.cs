using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Modul_15u
{    
    class Program
    {
        static void Main()
        {
            
            Type myClassType = typeof(MyClass);

            Console.WriteLine($"Имя класса: {myClassType.Name}");

            ConstructorInfo[] constructors = myClassType.GetConstructors();
            Console.WriteLine("\nСписок конструкторов:");
            foreach (ConstructorInfo constructor in constructors)
            {
                Console.WriteLine($"{constructor.Name}, Модификатор доступа: {constructor.Attributes}");
            }

            FieldInfo[] fields = myClassType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            PropertyInfo[] properties = myClassType.GetProperties(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);

            Console.WriteLine("\nСписок полей и свойств:");
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine($"{field.Name}, Тип: {field.FieldType}, Модификатор доступа: {field.Attributes}");
            }

            foreach (PropertyInfo property in properties)
            {
                Console.WriteLine($"{property.Name}, Тип: {property.PropertyType}, Модификатор доступа: {property.Attributes}");
            }

            MethodInfo[] methods = myClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            Console.WriteLine("\nСписок методов:");
            foreach (MethodInfo method in methods)
            {
                Console.WriteLine($"{method.Name}, Возвращаемый тип: {method.ReturnType}, Модификатор доступа: {method.Attributes}");
            }


            object myClassInstance = Activator.CreateInstance(myClassType);
            Console.WriteLine($"\nЭкземпляр MyClass создан: {myClassInstance}");


            PropertyInfo publicPropertyInfo = myClassType.GetProperty("PublicProperty");
            publicPropertyInfo.SetValue(myClassInstance, "New Value");
            Console.WriteLine($"Значение PublicProperty после изменения: {publicPropertyInfo.GetValue(myClassInstance)}");

            MethodInfo calculateSumMethod = myClassType.GetMethod("CalculateSum");
            object[] parameters = { 3, 5 };
            int sumResult = (int)calculateSumMethod.Invoke(myClassInstance, parameters);
            Console.WriteLine($"Результат вызова CalculateSum: {sumResult}");


            MethodInfo privateMethod = myClassType.GetMethod("PrivateMethod", BindingFlags.NonPublic | BindingFlags.Instance);
            privateMethod.Invoke(myClassInstance, null);
        }
    }

}
