using ASM_GS.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace ASM_GS.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly GeminiSettings _authSettings;
        public HomeController(ILogger<HomeController> logger, IOptions<GeminiSettings> authSettings)
        {
            _authSettings = authSettings.Value;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class GeminiAPI
        {
            public string GoogleAPIUrl { get; set; }
            public string GoogleAPIKey { get; set; }
        }

        public class GeminiSettings
        {
            public GeminiAPI Google { get; set; }
        }
        [HttpPost]
        public async Task<IActionResult> TraLoi([FromBody] string userInput)
        {
            var Test = userInput;
            var GoogleAPIKey = _authSettings.Google.GoogleAPIKey;
            var GoogleAPIUrl = _authSettings.Google.GoogleAPIUrl;
            var requestBody = new
            {
                contents = new[]
                {
                new
                {
                    parts = new[]
                    {
                        new { text ="Hãy xưng hô với tôi là Chủ nhân còn bạn là Rem và trả lời giúp tôi câu hỏi sau: " +userInput }
                    },
                }
            }
            };

            var jsonRequestBody = JsonConvert.SerializeObject(requestBody);
            var content = new StringContent(jsonRequestBody, Encoding.UTF8, "application/json");


            using (var client = new HttpClient())
            {
                var response = await client.PostAsync($"https://generativelanguage.googleapis.com/v1beta/models/gemini-1.5-flash-latest:generateContent?key={GoogleAPIKey}", content);
                var responseString = await response.Content.ReadAsStringAsync();
                var responseObject = JsonConvert.DeserializeObject<dynamic>(responseString);


                string answer = responseObject?.candidates[0].content?.parts[0]?.text ?? "Xin lỗi, câu hỏi của chủ nhân đã vi phạm chính sách của Google hoặc câu trở lời quá dài nên Rem không hiển thị cho bạn được";
                return Json(new { response = answer });
            }
        }
    }
}
