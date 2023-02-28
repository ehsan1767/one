using System.Security.Cryptography;

namespace SingeltonAbstractClass
{
    public class Program
    {
        static void Main(string[] args)
        {
            //The client code.
            Console.WriteLine("Test ThreadSafe in class Singleton1");

            Console.WriteLine("Enter a value for instance1");
            Singleton1 s1 = Singleton1.GetInstance(Console.ReadLine());
            Console.WriteLine("change value for instance1");
            s1.ChangeValueInstance();
            Console.WriteLine($"change value Instance1: {s1.Value}");

            Console.WriteLine("Enter a value for instance2");
            Singleton1 s2 = Singleton1.GetInstance(Console.ReadLine());
            Console.WriteLine($"value instance2: {s2.Value}");

            if (s1 == s2)
            {
                Console.WriteLine("singleton works, both variables contain the same instance.");
            }
            else
            {
                Console.WriteLine("singleton failed, variables contain different instances.");
            }
            

            Console.WriteLine("\nTest ThreadSafe in class Singleton2,Please Press key\n");
            Console.ReadKey();
            Console.WriteLine(
                "{0}\n{1}\n\n{2}\n",
                "If you see the same value, then singleton was reused (The singleton implementation is correct!)",
                "If you see different values, then 2 singletons were created (The singleton implementation is incorrect!!)",
                "RESULT:"
            );

            Thread process1 = new Thread(() =>
            {
                TestSingleton("1234");
            });
            Thread process2 = new Thread(() =>
            {
                TestSingleton("BEHSA");
            });

            process1.Start();
            process2.Start();

            process1.Join();
            process2.Join();

        }
    
        public static void TestSingleton(string value)
        {
            Singleton2 _singleton = Singleton2.GetInstance(value);
            Console.WriteLine(_singleton.Value);
        }
    }

}       
        

    
