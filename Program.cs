﻿using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.ServiceBus;

namespace az204svcbusSend
{
    class Program
    {
        const string ServiceBusConnectionString = "Endpoint=sb://az204sbnamespace01.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=7HBbceI6AIeRj2+4CggxXIZ3swUGOdabW+MWdYBJOJ4=";
        const string QueueName = "az204queue";
        static IQueueClient queueClient;
        public static async Task Main(string[] args)
        {
           const int numberOfMessages = 10;
            queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
            Console.WriteLine("======================================================");
            Console.WriteLine("Press ENTER key to exit after sending all the messages.");
            Console.WriteLine("======================================================");
            // Send messages.
            await SendMessagesAsync(numberOfMessages);
            Console.ReadKey();
            await queueClient.CloseAsync();
        }

        static async Task MainAsync()
        {
                const int numberOfMessages = 10;
                queueClient = new QueueClient(ServiceBusConnectionString, QueueName);
                Console.WriteLine("======================================================");
                Console.WriteLine("Press ENTER key to exit after sending all the messages.");
                Console.WriteLine("======================================================");
                // Send messages.
                await SendMessagesAsync(numberOfMessages);
                Console.ReadKey();
                await queueClient.CloseAsync();
        }

        static async Task SendMessagesAsync(int numberOfMessagesToSend)
        {
            try
            {
            for (var i = 0; i < numberOfMessagesToSend; i++)
            {
            // Create a new message to send to the queue.
            string messageBody = $"Message {i}";
            var message = new Message(Encoding.UTF8.GetBytes(messageBody));
            // Write the body of the message to the console.
            Console.WriteLine($"Sending message: {messageBody}");
            // Send the message to the queue.
            await queueClient.SendAsync(message);
            }
            }
            catch (Exception exception)
            {
            Console.WriteLine($"{DateTime.Now} :: Exception: {exception.Message}");
            }
        }
    }
}
