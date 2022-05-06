using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveMessageServiceBus1
{
    public class ReceiveMessage
    {
        static string connectionString = "Endpoint=sb://notificationservice0.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=b4ojYUDXIBKvtL6s1IN4JsNHUvG/KGVzIv33ta0nBHg=";

        static string topicName = "notification0";



        public async Task ReceiveMessageFromTopic()
        {
            await using var client = new ServiceBusClient(connectionString);
            // create the sender
            ServiceBusReceiver receiver = client.CreateReceiver(topicName);

            // the received message is a different type as it contains some service set properties
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();

            // get the message body as a string
            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);



            Console.WriteLine("Press any key to end the application");
            Console.ReadKey();
        }

    }
}
