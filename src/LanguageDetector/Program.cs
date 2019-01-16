using System.Threading.Tasks;
using IoC;
using Unity;

namespace LanguageDetector
{
    internal class Program
    {
        internal static async Task Main(string[] args)
        {
            var container = new UnityContainer();
            container.ConfigureContainer();
            var shell = container.Resolve<Shell>();
            shell.RunInteractive();
        }
    }
}
