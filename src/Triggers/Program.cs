namespace Triggers
{
    using System;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("TeamCity Commit");
        }
    }

    public class FooBar
    {
        public string MyProp { get; private set; }

        public FooBar(string x)
        {
            MyProp = x;
        }
    }
}