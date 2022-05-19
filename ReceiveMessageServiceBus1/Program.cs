using ReceiveMessageServiceBus1;

ReceiveMessage receiveMessage = new ReceiveMessage();
for (int i = 0; i < 10; i++)
{
    await receiveMessage.ReceiveMessageFromTopic();
    Thread.Sleep(3000);
}

Console.WriteLine("Received Message from topic subscription 1.");
Console.ReadKey();