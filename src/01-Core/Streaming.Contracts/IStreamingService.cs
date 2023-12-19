namespace Streaming.Contracts
{
	public interface IStreamingService
	{
		void Publish(string topic, string type, object message);
	}
}
