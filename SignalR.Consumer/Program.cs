using System;
using System.Threading.Tasks;
using Mediator.Domain.Notifications;
using Microsoft.AspNetCore.SignalR.Client;

namespace SignalR.Consumer
{
    class Program
    {
        public static HubConnection Connection;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Starting client  https://localhost:5001/notification-hub");
            Connection = new HubConnectionBuilder()
                .WithUrl("http://localhost:5000/notification-hub")
                .Build();

            Console.WriteLine($"Connection state {Connection.State}");

            try
            {
                await Connection.StartAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine($"Connection state {Connection.State}");

            Connection.On<EmployeeAddedEvent>("NewUserCreated", (message) =>
            {
                Console.WriteLine($"Employee {message.Employee} with user Id {message.EmployeeId} added.");
            });

            Connection.On<EmployeeRemovedEvent>("UserRemoved", (message) =>
            {
                Console.WriteLine($"Employee with user Id {message.EmployeeId} has been removed.");
            });

            Connection.Closed += async (error) =>
            {
                Console.WriteLine($"Connection state {Connection.State}");
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await Connection.StartAsync();
            };

            Console.ReadKey(true);
            await Connection.StopAsync();
        }
    }
}
