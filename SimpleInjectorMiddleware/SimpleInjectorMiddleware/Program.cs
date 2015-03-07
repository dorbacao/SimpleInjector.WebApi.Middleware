using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleInjectorMiddleware
{
    class Program
    {
        static void Main(string[] args)
        {
            const string url = "http://localhost:9004";

            Console.Title = "Teste Middleware SimpleInjector";

            using (WebApp.Start<StartUp>(url))
            {
                //Process.Start(url);

                Console.WriteLine("Pressione <ENTER> para sair...");
                Console.ReadLine();
            }
        }
    }
}
