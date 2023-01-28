using CollatzConjecture.Math;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICollatzMathService, CollatzMathService>();
builder.Services.AddSingleton<ICollatzConjectureResolver, CollatzConjectureResolver>();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseRouting();
app.UseEndpoints(endpoints =>  endpoints.MapControllers());
app.Run();
