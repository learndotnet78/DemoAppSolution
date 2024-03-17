using DemoCoreAPI.BackgroundWorker;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddSwaggerGen();
builder.Services.AddHostedService<BgWorkerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseAuthorization();

app.MapControllers();

app.Run();
