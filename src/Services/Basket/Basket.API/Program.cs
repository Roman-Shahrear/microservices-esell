var builder = WebApplication.CreateBuilder(args);

// Add services to the container

//Application Services
var assembly = typeof(Program).Assembly;
builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssembly(assembly);
    config.AddOpenBehavior(typeof(ValidationBehavior<,>));
    config.AddOpenBehavior(typeof(LoggingBehaviour<,>));
});

builder.Services.AddCarter();

var app = builder.Build();

// configure the HTTP request pipeline
app.MapCarter();

app.Run();
