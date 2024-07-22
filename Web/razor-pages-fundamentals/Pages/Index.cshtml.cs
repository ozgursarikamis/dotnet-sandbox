using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public IHttpClientFactory ClientFactory { get; }
		public List<SurveyItem> SurveyResults { get; set; }
		public IDictionary<string, string> OrderStats { get; set; }

		public IndexModel(ILogger<IndexModel> logger, IHttpClientFactory clientFactory)
		{
			_logger = logger;
			this.ClientFactory = clientFactory;
		}

		public async Task<IActionResult> OnGet()
        {
            var rawJson = await System.IO.File.ReadAllTextAsync("wwwroot/sampledata/survey.json");
            SurveyResults = JsonSerializer.Deserialize<List<SurveyItem>>(rawJson);

            var client = ClientFactory.CreateClient();
            var response = await client.GetAsync("https://wiredbraincoffeeadmin.azurewebsites.net/api/orderStats");


			var responseData = await response.Content.ReadAsStringAsync();

            OrderStats = JsonSerializer.Deserialize<IDictionary<string, string>>(responseData);

            return Page();
        }
    }
}