using Modelos.Negocio;

namespace RepartidorTerminal.Models
{
    public class ChoferSesion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Clave { get; set; }

        public static ChoferSesion DesdeChofer(Choferes chofer)
        {
            return new ChoferSesion
            {
                Id = chofer.Id,
                Nombre = chofer.Nombre,
                Clave = chofer.Clave
            };
        }
    }
}