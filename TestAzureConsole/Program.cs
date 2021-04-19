using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;

namespace TestAzureConsole
{
    class Program
    {
        //private static MessagingFactory messagingFactory;

        static string connectionString = "Endpoint=sb://<>.servicebus.windows.net/;SharedAccessKeyName=<>;SharedAccessKey=<>;EntityPath=<>";

        static void Main(string[] args)
        {
            var client = QueueClient.CreateFromConnectionString(connectionString);

            string message = "Send Message1";

            while (true)
            {
                client.Send(new BrokeredMessage(message));
                Console.WriteLine("Sent: " + message.ToString());
                Console.WriteLine("Enter a message to send");
                message = Console.ReadLine();
            }
        }
    }
}
