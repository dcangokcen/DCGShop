using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace DCGShop.RabbitMQMessageApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MessageController : ControllerBase
	{
		[HttpPost]
		public IActionResult CreateMessage()
		{
			var connectionFactory = new ConnectionFactory
			{
				HostName = "localhost"

			};

			var connection = connectionFactory.CreateConnection();

			var channel = connection.CreateModel();

			channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);

			var messageContet = "Merhaba, haftasonu hava soğuk olacak.";

			var byteMessageContent = Encoding.UTF8.GetBytes(messageContet);

			channel.BasicPublish(exchange: "", routingKey: "Kuyruk2", basicProperties: null, body: byteMessageContent);

			return Ok("Mesajınız kuyruğa alınmıştır.");
		}

		private static string message;
		[HttpGet]
		public IActionResult GetMessage()
		{
			var connectionFactory = new ConnectionFactory
			{
				HostName = "localhost"
			};

			var connection = connectionFactory.CreateConnection();

			var channel = connection.CreateModel();

			var consumer = new EventingBasicConsumer(channel);

			consumer.Received += (model, x) =>
			{
				var byteMessageContent = x.Body.ToArray();
				message = Encoding.UTF8.GetString(byteMessageContent);
			};

			channel.BasicConsume(queue: "Kuyruk1", autoAck: false, consumer: consumer);

			if(string.IsNullOrEmpty(message))
			{
				return NoContent();
			}
			else
			{
				return Ok(message);
			}
		}
	}
}
