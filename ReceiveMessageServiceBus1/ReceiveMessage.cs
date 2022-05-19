using Azure.Messaging.ServiceBus;

namespace ReceiveMessageServiceBus1
{
    public class ReceiveMessage
    {
        static string connectionString = "ServiceBus namespace connection";

        static string topicName = "mytopic";

        public async Task ReceiveMessageFromTopic()
        {
            await using var client = new ServiceBusClient(connectionString);
            
            ServiceBusReceiver receiver = client.CreateReceiver(topicName, "consumer1", new ServiceBusReceiverOptions { ReceiveMode = ServiceBusReceiveMode.ReceiveAndDelete});
            
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            
            string body = receivedMessage.Body.ToString();
            Console.WriteLine(body);
        }

    }
}
