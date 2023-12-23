namespace Streaming.Contracts
{
	public interface IStreamingService
	{
		void AppendToStreamAsync(string topic, string type, object message);
	}
}
