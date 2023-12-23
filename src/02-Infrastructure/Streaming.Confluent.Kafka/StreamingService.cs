using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Streaming.Contracts;
using System.Text.Json;

namespace Streaming.Confluent.Kafka
{
	internal class StreamingService : IStreamingService
	{
		private readonly IConfiguration _configuration;
		public StreamingService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public void AppendToStreamAsync(string topic, string type, object message)
		{
			var streamingConfiguration = _configuration.GetSection("KafkaStreaming")
				.GetChildren()
				.ToDictionary(q => q.Key, q => q.Value);

			using (var producer = new ProducerBuilder<string, string>(streamingConfiguration).Build())
			{
				producer.Produce(topic, new Message<string, string>
				{
					Key = type,
					Value = JsonSerializer.Serialize(message)
				},

				deliveryReport =>
				{
					if (deliveryReport.Error.Code != ErrorCode.NoError)
					{
						throw new ArgumentException();
					}
				});

				producer.Flush();
			}
		}
	}
}
