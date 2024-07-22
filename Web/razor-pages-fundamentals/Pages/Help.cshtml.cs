using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WiredBrainCoffeeAdmin.Data;
using WiredBrainCoffeeAdmin.Data.Models;

namespace WiredBrainCoffeeAdmin.Pages
{
	public class HelpModel : PageModel
	{
		public ITicketService TicketService { get; }

		[BindProperty] public HelpTicket NewTicket { get; set; }

		public List<HelpTicket> HelpTickets { get; set; }

		public HelpModel(ITicketService ticketService)
		{
			this.TicketService = ticketService;
		}

		public async Task<IActionResult> OnGet()
		{
			HelpTickets = await TicketService.GetAll();
			return Page();
		}

		public async Task<IActionResult> OnPost()
		{

			return Page();
		}
	}
}
