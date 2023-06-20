using DonwloadManager.Persistance;
using DownloadManager.Presentation.Middleware;
using DownloadManager.Presentation.Modules;
using DownloadManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<ExceptionHandlingMiddleware>();
builder.Services.AddApplicationPersistanceLayer(builder.Configuration);
builder.Services.AddApplicationServiceLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddCustomMiddleware();

app.UseHttpsRedirection();
app.AddHistoryModule();
app.AddDownloadModule();
app.AddConfigurationModule();
app.UseHttpsRedirection();

app.Run();