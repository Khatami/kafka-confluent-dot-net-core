using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Streaming.Contracts;

namespace Streaming.Confluent.Kafka
{
	internal class StreamingService : IStreamingService
	{
		private readonly IConfiguration _configuration;
		public StreamingService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void Publish(string topic, string type, object message)
		{
			var streamingConfiguration = _configuration.GetSection("Streaming")
				.GetChildren()
				.ToDictionary(q => q.Key, q => q.Value);

			using (var producer = new ProducerBuilder<string, string>(streamingConfiguration).Build())
			{
				producer.Produce(topic, new Message<string, string>
				{
					Key = type,
					Value = System.Text.Json.JsonSerializer.Serialize(message)
				},
				(deliveryReport) =>
				{
					if (deliveryReport.Error.Code != ErrorCode.NoError)
					{
					}
					else
					{
					}
				});

				producer.Flush();
			}
		}
	}
}
