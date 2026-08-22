using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RepartidorTerminal.Models;
using System.Text.Json;

namespace RepartidorTerminal.Pages
{
    public class DashboardModel : PageModel
    {
        public ChoferSesion ChoferActual { get; set; }

        public IActionResult OnGet()
        {
            var choferJson = HttpContext.Session.GetString("ChoferAutenticado");
            if (string.IsNullOrEmpty(choferJson))
            {
                return RedirectToPage("/Index");
            }

            ChoferActual = JsonSerializer.Deserialize<ChoferSesion>(choferJson);
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}