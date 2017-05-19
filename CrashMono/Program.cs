using System;
using System.Threading.Tasks;

namespace CrashMono
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run().Wait();
        }

        private async Task Run()
        {
            var appDomain = AppDomain.CreateDomain("Test subdomain", null, AppDomain.CurrentDomain.SetupInformation);
            var driver = (AppDomainTestDriver)appDomain.CreateInstanceAndUnwrap(
                typeof(AppDomainTestDriver).Assembly.FullName,
                typeof(AppDomainTestDriver).FullName);
            driver.Test();
        }
    }

    class AppDomainTestDriver : MarshalByRefObject
    {
        static AppDomainTestDriver()
        {
            AppDomain.CurrentDomain.AssemblyLoad += CurrentDomain_AssemblyLoad;
        }

        private static void CurrentDomain_AssemblyLoad(object sender, AssemblyLoadEventArgs args)
        {
        }

        internal void Test()
        {
            var foo = default(Library.Class1);
        }
    }
}
