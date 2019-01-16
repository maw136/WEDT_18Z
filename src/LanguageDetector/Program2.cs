using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IoC;
using Unity;

namespace LanguageDetector
{
    internal class Program2
    {
        internal static async Task Main(string[] args)
        {
            var container = new UnityContainer();
            container.ConfigureContainer();
            var shell = container.Resolve<Shell>();

        }
    }
}
