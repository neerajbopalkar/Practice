using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace NeerServiceApp
{
    class Program
    {
        static void Main(string[] args)
        {

            StartUserService();
        }

        private static void StartUserService()
        {
            var myHost = new ServiceHost(
                typeof(UserService));

            var myEnd = myHost.AddServiceEndpoint(
                typeof(UserService),
                new WebHttpBinding(),
                "http://localhost:8889/UserService");

            myEnd.EndpointBehaviors.Add(new WebHttpBehavior());

            myHost.Open();
            Console.WriteLine("Service is running...");
            Console.ReadLine();
            myHost.Close();
        }
    }
}
