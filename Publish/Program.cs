// See https://aka.ms/new-console-template for more information
using NATS.Client;
using System.Text;



// Define as variables
var subject = "order";
var message = "{ amount: 100.0 }";

//// Get the connection
var connection = GetConnection();

//// Publish the message
connection.Publish(subject, Encoding.UTF8.GetBytes(message));

Console.WriteLine($"{DateTime.Now:F} - Subscription: {subject} -  Send: {message}");



/// <summary>
/// Get a new connection
/// </summary>
/// <returns>New connection with NATs.io</returns>
static IConnection GetConnection()
{
    var cf = new ConnectionFactory();
    var c = cf.CreateConnection();

    return c;
}
