﻿using Azure.Messaging.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReceiveMessageServiceBus1
{
    public class ReceiveMessage
    {
        static string connectionString = "*****";

        static string topicName = "notification0";



        public async Task ReceiveMessageFromTopic()
        {
            await using var client = new ServiceBusClient(connectionString);
            
            ServiceBusReceiver receiver = client.CreateReceiver(topicName, "subscriber1", new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});
            
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            
            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);

            Console.WriteLine("Received Message from topic subscription 1.");
            Console.ReadKey();
        }

    }
}
