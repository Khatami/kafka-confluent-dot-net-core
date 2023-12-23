using Microsoft.AspNetCore.Mvc;
using Streaming.Contracts;

namespace Producer.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StreamingController : ControllerBase
	{
		private readonly IStreamingService _streamingService;

		public StreamingController(IStreamingService streamingService)
		{
			_streamingService = streamingService;
		}

		[HttpPost]
		public IActionResult Produce()
		{
			_streamingService.Publish("test", typeof(TestEvent).ToString(), new TestEvent() { Id = 1, Name = "Hamed Khatami" });

			return Ok();
		}
	}

	public class TestEvent
	{
        public long Id { get; set; }

        public string Name { get; set; }
    }
}
