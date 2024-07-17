using System.Text.Json;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
	public class IndexModel : PageModel
	{
		private readonly ILogger<IndexModel> _logger;
		public List<SurveyItem> SurveyResults { get; set; }

	public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            var rawJson = System.IO.File.ReadAllText("wwwroot/sampledata/survey.json");
            SurveyResults = JsonSerializer.Deserialize<List<SurveyItem>>(rawJson);
		}
    }
}