using Modelos.Negocio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// Agregar servicios de controladores para API
builder.Services.AddControllers();

// Configurar límite de tamaño de solicitud (importante para fotos en base64)
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = 52428800; // 50MB
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = 52428800; // 50MB
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
else
{
    // En desarrollo, agregar middleware para logging
    app.Use(async (context, next) =>
    {
        if (context.Request.Method == "POST" && context.Request.Path.StartsWithSegments("/Entregas"))
        {
            context.Request.EnableBuffering();
            var body = await new StreamReader(context.Request.Body).ReadToEndAsync();
            context.Request.Body.Position = 0;
            
            System.Diagnostics.Debug.WriteLine($"POST Request - Path: {context.Request.Path}");
            System.Diagnostics.Debug.WriteLine($"Content-Type: {context.Request.ContentType}");
            System.Diagnostics.Debug.WriteLine($"Body length: {body.Length}");
            System.Diagnostics.Debug.WriteLine($"Body: {body.Substring(0, Math.Min(200, body.Length))}...");
        }
        await next();
    });
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
   .WithStaticAssets();

app.Run();
