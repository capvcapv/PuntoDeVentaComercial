using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos.Negocio;
using RepartidorTerminal.Models;
using System.Text.Json;

namespace RepartidorTerminal.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string Nombre { get; set; }

        [BindProperty]
        public string Clave { get; set; }

        public string MensajeError { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (HttpContext.Session.GetString("ChoferAutenticado") != null)
            {
                RedirectToPage("/Dashboard");
            }
        }

        public IActionResult OnPost()
        {
            if (string.IsNullOrWhiteSpace(Nombre) || string.IsNullOrWhiteSpace(Clave))
            {
                MensajeError = "Por favor completa todos los campos";
                return Page();
            }

            try
            {

                string cadena = "Server=localhost\\SQLEXPRESS;Database=PuntoVentaComercial;User Id=sa;Password=supervisor;";

                var chofer = new Choferes().obtenerTodos(cadena)
                    .FirstOrDefault(c => c.Nombre == Nombre && c.Clave == Clave);

                if (chofer != null)
                {
                    var sesion = ChoferSesion.DesdeChofer(chofer);
                    HttpContext.Session.SetString("ChoferAutenticado", JsonSerializer.Serialize(sesion));
                    HttpContext.Session.SetInt32("ChoferID", chofer.Id);
                    return RedirectToPage("/Dashboard");
                }
                else
                {
                    MensajeError = "Usuario o contraseña incorrectos";
                }
            }
            catch (Exception ex)
            {
                MensajeError = $"Error en la autenticación: {ex.Message}";
                _logger.LogError(ex, "Error durante autenticación");
            }

            return Page();
        }
    }
}
