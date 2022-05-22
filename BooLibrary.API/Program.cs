using BooLibrary.Abstractions.Helper;
using BooLibrary.Abstractions.Services.Business;
using BooLibrary.Abstractions.Services.Data;
using BooLibrary.Business;
using BooLibrary.Data;
using BooLibrary.Data.Data;
using BooLibrary.Data.Mock;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));

});

builder.Services.AddScoped<ICategoryService, CategoryService>();

var getSection = builder.Configuration;
var appSettingsSection = getSection.GetSection("AppSettings");
var appSettings = appSettingsSection.Get<AppSettings>();

if (appSettings.UseMock)
{
   
    builder.Services.AddScoped<ICategoryDataService, MockCategoryDataService>();


}
else
{
    
    builder.Services.AddScoped<ICategoryDataService, CategoryDataService>();
    
}



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
