namespace RepartidorTerminal.Middleware
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var path = context.Request.Path.Value.ToLower();
            var paginasPublicas = new[] { "/", "/index" };

            if (!paginasPublicas.Any(p => path.StartsWith(p)))
            {
                var choferAutenticado = context.Session.GetString("ChoferAutenticado");
                if (string.IsNullOrEmpty(choferAutenticado))
                {
                    context.Response.Redirect("/");
                    return;
                }
            }

            await _next(context);
        }
    }
}