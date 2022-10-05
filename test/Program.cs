namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Create new student");
            Console.WriteLine("<ID>, <Name>, <Age>, <Grade>");
            Console.WriteLine("Example: 102, Phan Nhat Linh, 20, 8.5");
            var info = Console.ReadLine();
            var infoArr = info.Split(", ");
            foreach (var item in infoArr)
            {
                Console.WriteLine(item);
            }
        }
    }
}