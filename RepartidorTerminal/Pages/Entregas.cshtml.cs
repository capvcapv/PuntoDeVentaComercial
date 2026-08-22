using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Modelos.Negocio;
using RepartidorTerminal.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RepartidorTerminal.Pages
{
    public class EntregasModel : PageModel
    {
        private readonly ILogger<EntregasModel> _logger;

        public ChoferSesion ChoferActual { get; set; }
        public List<EnviosProgramados> EnviosPendientes { get; set; } = new();
        public List<DireccionEnvios> Direcciones { get; set; } = new();
        public List<Vehiculos> Vehiculos { get; set; } = new();

        public EntregasModel(ILogger<EntregasModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            var choferJson = HttpContext.Session.GetString("ChoferAutenticado");
            if (string.IsNullOrEmpty(choferJson))
            {
                return RedirectToPage("/Index");
            }

            ChoferActual = JsonSerializer.Deserialize<ChoferSesion>(choferJson);
            int choferID = HttpContext.Session.GetInt32("ChoferID") ?? 0;

            CargarEnvios(choferID);
            return Page();
        }

        private void CargarEnvios(int choferID)
        {
            try
            {
                string cadena = "Server=localhost\\SQLEXPRESS;Database=PuntoVentaComercial;User Id=sa;Password=supervisor;";
                var todosEnvios = new EnviosProgramados().obtenerTodos(cadena);
                
                EnviosPendientes = todosEnvios
                    .Where(e => e.Chofer == choferID && e.Estado == 0)
                    .OrderBy(e => e.FechaProgramada)
                    .ToList();

                Direcciones = new DireccionEnvios().obtenerTodos(cadena);
                Vehiculos = new Vehiculos().obtenerTodos(cadena);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al cargar envíos");
                EnviosPendientes = new List<EnviosProgramados>();
            }
        }

        public async Task<IActionResult> OnPostMarcarEntregado()
        {
            _logger.LogInformation("OnPostMarcarEntregado iniciado");

            var choferJson = HttpContext.Session.GetString("ChoferAutenticado");
            if (string.IsNullOrEmpty(choferJson))
            {
                _logger.LogWarning("Sesión expirada");
                return new JsonResult(new ApiResponse { success = false, message = "Sesión expirada" }) 
                { 
                    StatusCode = 401 
                };
            }

            try
            {
                _logger.LogInformation($"Content-Type: {HttpContext.Request.ContentType}");
                _logger.LogInformation($"Content-Length: {HttpContext.Request.ContentLength}");

                // Habilitar lectura del body
                HttpContext.Request.EnableBuffering();
                
                // Leer el cuerpo
                string body;
                using (var reader = new StreamReader(HttpContext.Request.Body, System.Text.Encoding.UTF8, true, 1024, true))
                {
                    body = await reader.ReadToEndAsync();
                }

                _logger.LogInformation($"Body recibido - Longitud: {body.Length}");
                _logger.LogInformation($"Body preview: {body.Substring(0, Math.Min(200, body.Length))}...");

                if (string.IsNullOrWhiteSpace(body))
                {
                    _logger.LogWarning("Body vacío");
                    return new JsonResult(new ApiResponse { success = false, message = "Cuerpo vacío" }) 
                    { 
                        StatusCode = 400 
                    };
                }

                var options = new JsonSerializerOptions 
                { 
                    PropertyNameCaseInsensitive = true,
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };

                EntregaRequest request = null;
                try
                {
                    request = JsonSerializer.Deserialize<EntregaRequest>(body, options);
                    _logger.LogInformation($"Request deserializado - envioID: {request?.envioID}, evidencia length: {request?.evidencia?.Length ?? 0}");
                }
                catch (JsonException jsonEx)
                {
                    _logger.LogError(jsonEx, "Error deserializando JSON");
                    return new JsonResult(new ApiResponse { success = false, message = $"JSON inválido: {jsonEx.Message}" }) 
                    { 
                        StatusCode = 400 
                    };
                }

                if (request == null || request.envioID <= 0)
                {
                    _logger.LogWarning("ID de envío inválido");
                    return new JsonResult(new ApiResponse { success = false, message = "ID de envío inválido" }) 
                    { 
                        StatusCode = 400 
                    };
                }

                if (string.IsNullOrWhiteSpace(request.evidencia))
                {
                    _logger.LogWarning("Evidencia vacía");
                    return new JsonResult(new ApiResponse { success = false, message = "Foto de evidencia requerida" }) 
                    { 
                        StatusCode = 400 
                    };
                }

                string cadena = "Server=localhost\\SQLEXPRESS;Database=PuntoVentaComercial;User Id=sa;Password=supervisor;";
                var envio = new EnviosProgramados().obtenerTodos(cadena)
                    .FirstOrDefault(e => e.Id == request.envioID);

                if (envio != null && envio.Estado == 0)
                {
                    envio.Estado = 1;
                    envio.Evidencia = request.evidencia;
                    envio.actualizar(cadena);
                    
                    _logger.LogInformation($"Envío {request.envioID} actualizado exitosamente");
                    return new JsonResult(new ApiResponse { success = true, message = "Entrega registrada correctamente" });
                }

                _logger.LogWarning($"Envío {request.envioID} no encontrado o ya fue entregado");
                return new JsonResult(new ApiResponse { success = false, message = "Envío no encontrado o ya fue entregado" }) 
                { 
                    StatusCode = 404 
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error en OnPostMarcarEntregado");
                return new JsonResult(new ApiResponse { success = false, message = $"Error: {ex.Message}" }) 
                { 
                    StatusCode = 500 
                };
            }
        }
    }

    public class EntregaRequest
    {
        [JsonPropertyName("envioID")]
        public int envioID { get; set; }
        
        [JsonPropertyName("evidencia")]
        public string evidencia { get; set; }
    }

    public class ApiResponse
    {
        [JsonPropertyName("success")]
        public bool success { get; set; }
        
        [JsonPropertyName("message")]
        public string message { get; set; }
    }
}