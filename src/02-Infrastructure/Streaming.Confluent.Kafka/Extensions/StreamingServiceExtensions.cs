using Microsoft.Extensions.DependencyInjection;
using Streaming.Contracts;

namespace Streaming.Confluent.Kafka.Extensions
{
	public static class StreamingServiceExtensions
	{
		public static IServiceCollection RegisterStreamingServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IStreamingService, StreamingService>();

			return serviceCollection;
		}
	}
}
