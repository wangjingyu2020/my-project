using my_cs_project.Services;
using Microsoft.AspNetCore.Mvc;

namespace my_cs_project.Controllers
{
    [Route("chat/[controller]/[action]")]
    [ApiController]
    public class OpenAiController : ControllerBase
    {
        private IOpenAiService _openAiService;
        private readonly ILogger<OpenAiController> _logger;

        public OpenAiController(ILogger<OpenAiController> logger, IOpenAiService openAiService)
        {
            _logger = logger;
            _openAiService = openAiService;
        }

        [HttpGet]
        public async Task<ActionResult<String>> talkWithGPT(string prompt)
        {
            //return Ok(await _openAiService.talkWithGPT(prompt));
            return Ok("hello");


        }
    }
}
