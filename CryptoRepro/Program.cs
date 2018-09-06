using System.IO;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        var assembly = Assembly.Load("Microsoft.CodeAnalysis.Workspaces");
        var checksum = assembly.GetType("Microsoft.CodeAnalysis.Checksum");
        var create = checksum.GetMethod("Create", new[] { typeof(Stream) });
        var result = create.Invoke(null, new object[] { new MemoryStream() });
    }
}