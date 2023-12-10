using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul_15u
{
    public class MyClass
    {
        private int privateField;
        public string PublicProperty { get; set; }


        public MyClass(string initialValue)
        {
            PublicProperty = initialValue;
        }

        private void PrivateMethod()
        {
            Console.WriteLine("Private method called.");
        }

        public void PublicMethod()
        {
            Console.WriteLine("Public method called.");
        }

        public int CalculateSum(int a, int b)
        {
            return a + b;
        }
    }

}
