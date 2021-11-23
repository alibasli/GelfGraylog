using Gelf.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging((context, builder) => builder
.AddConsole()
.AddGelf(options =>
{
    options.LogSource = context.HostingEnvironment.ApplicationName;
    options.AdditionalFields["machine_name"] = Environment.MachineName;
}));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
