namespace test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person();
            Console.WriteLine(person.GetType().Name);
        }

    }

    internal class Person {

    }
}