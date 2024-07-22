using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Data
{
	public class TicketService : ITicketService
	{
		public HttpClient Client { get; }

		public TicketService(HttpClient client)
		{
			this.Client = client;
		}

		public async Task<string> Add(HelpTicket ticket)
		{
			var response = await Client.PostAsJsonAsync<HelpTicket>("/api/ticket", ticket);
			return await response.Content.ReadAsStringAsync();
		}

		public async Task<List<HelpTicket>> GetAll()
		{
			return await Client.GetFromJsonAsync<List<HelpTicket>>("/api/tickets");
		}

		public async Task<string> Create(HelpTicket ticket)
		{
			var response = await Client.PostAsJsonAsync("api/ticket", ticket);
			return await response.Content.ReadAsStringAsync();
		}
	}
}
