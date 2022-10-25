using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    internal class class1
    {
        private void test1()
        {
            Console.WriteLine("test");
        }

        public void test2()
        {
            Console.WriteLine("Ở đây gọi test 1 được");
            test1();
        }
    }
}
