using NATS.Client;
using NATS.Client.Rx;
using NATS.Client.Rx.Ops;
using System.Text;

// Get the connection
var connection = GetConnection();

// Signature
var sAsyncAll = connection.Observe("order").Select(s => s.Data);

sAsyncAll.Subscribe(message => Console.WriteLine($"{DateTime.Now:F} - All: "
    + Encoding.UTF8.GetString(message)));

// Wait for a key to be pressed
Console.ReadLine();

// Disconnecting
connection.Drain();
connection.Close();



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
