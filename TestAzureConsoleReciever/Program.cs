using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.ServiceBus.Messaging;
//using Microsoft.ServiceBus.Messaging;

namespace TestAzureConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var queueConnectionString = "Endpoint=sb://<>.servicebus.windows.net/;SharedAccessKeyName=<>;SharedAccessKey=<>;EntityPath=<>";

            Action<BrokeredMessage> onMessage = (bm) => {
                var message = bm.GetBody<string>();
                Console.WriteLine(message.ToString());
                bm.Complete();
            };

            var options = new OnMessageOptions()
            {
                AutoComplete = false
            };

            var client = QueueClient.CreateFromConnectionString(queueConnectionString);

            client.OnMessage(onMessage, options);

            Console.WriteLine("End of receiver program");
            Console.ReadLine();

        }
    }
}
