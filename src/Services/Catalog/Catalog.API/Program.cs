var builder = WebApplication.CreateBuilder(args);

// Add Services to the Container by Add Services
builder.Services.AddCarter();
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(typeof(Program).Assembly);
});
var app = builder.Build();

// Configure the Http Request Pipeline by UsingMethod
app.MapCarter();

app.Run();
