using System;

class Program
{
    static void Main(string[] args)
    {
        var t = typeof(Foo);

        string a = typeof(Foo).Assembly.FullName, b = typeof(Foo).FullName;
    }
}

class Foo
{
    static Foo()
    {
        Console.WriteLine("cctor");
    }

    public static void Noop() { }
}