using DonwloadManager.Persistance;
using DownloadManager.Presentation.Modules;
using DownloadManager.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplicationPersistanceLayer();
builder.Services.AddApplicationServiceLayer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddHistoryModule();
app.AddDownloadModule();
app.AddConfigurationModule();
//app.AddMiddleWare();


app.UseHttpsRedirection();

app.Run();