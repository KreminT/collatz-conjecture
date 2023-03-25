using CollatzConjecture.Math;
using CollatzConjecture.Math.IO;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICollatzMathService, CollatzMathService>();
builder.Services.AddSingleton<ICollatzConjectureResolver, CollatzConjectureResolver>();
builder.Services.AddTransient<IResultProcessor, FileResultProcessor>();
var app = builder.Build();
app.UseHttpsRedirection();
app.UseRouting();
string staticFolder = String.Empty;
if (!app.Environment.IsDevelopment())
{
    staticFolder = Path.Combine(builder.Environment.ContentRootPath, "client");
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            Path.Combine(builder.Environment.ContentRootPath, "client", "static")),
        RequestPath = "/static"
    });
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(
            staticFolder),
        RequestPath = ""
    });

}
else
{
    app.UseSwagger();
    app.UseSwaggerUI();
    staticFolder = Path.Combine(builder.Environment.ContentRootPath, "../../../client/build");
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(Path.Combine(builder.Environment.ContentRootPath, "../../../client/build/static")),
        RequestPath = "/static"
    });
    app.UseStaticFiles(new StaticFileOptions
    {
        FileProvider = new PhysicalFileProvider(staticFolder),
        RequestPath = ""
    });
}

app.MapGet("/", async context =>
{
    await context.Response.WriteAsync(File.ReadAllText(Path.Combine(staticFolder, "index.html")));
});


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.Run();
