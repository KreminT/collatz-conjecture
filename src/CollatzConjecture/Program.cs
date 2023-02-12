using CollatzConjecture.Math;
using CollatzConjecture.Math.IO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICollatzMathService, CollatzMathService>();
builder.Services.AddSingleton<ICollatzConjectureResolver, CollatzConjectureResolver>();
builder.Services.AddTransient<IResultProcessor, FileResultProcessor>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>  endpoints.MapControllers());
app.Run();
