
using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class Program
    {
        static void Main(string[] args)
        {
            var table = new ConsoleTable("one", "two", "three");
            table.AddRow(1, 2, 3)
                 .AddRow("this line should be longerwwwwwwwwwwwwwwwwwwwww", "yes it is", "oh");
            Console.WriteLine(table.ToString());
        }
    }

}