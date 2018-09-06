using System;
using System.Reflection;
using Library;

namespace CrashMono
{
    class Program
    {
        static void Main(string[] args)
        {
            var appDomain = AppDomain.CreateDomain("TestDomain", null, AppDomain.CurrentDomain.SetupInformation);
            var driver = (Remote)appDomain.CreateInstanceAndUnwrap(
                typeof(Remote).Assembly.FullName,
                typeof(Remote).FullName);
            driver.Test();
        }
    }

    class Remote : MarshalByRefObject
    {
        static Remote()
        {
            Console.WriteLine($"cctor in AppDomain {AppDomain.CurrentDomain.FriendlyName}");
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                Console.WriteLine($"{asm.FullName} (in {AppDomain.CurrentDomain.FriendlyName})");
            }

            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
            //Console.WriteLine($"{args.LoadedAssembly.FullName} loaded into {AppDomain.CurrentDomain.FriendlyName}");
        }

        internal void Test()
        {
            M<Class1>();
            //foo.Mbox();
        }

        private void M<T>()
        {
        }
    }
}
