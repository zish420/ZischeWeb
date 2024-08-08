using ContractService.Abstraction;
using ContractService.Implementation;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MudBlazor.Services;
using ZischeWeb;
using ZischeWeb.ContractsService.Abstraction;
using ZischeWeb.ContractsService.Implementation;
using ZischeWeb.Shared.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<SmtpSettings>(builder.Configuration.GetSection("Smtp"));

builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();

builder.Services.AddMudServices();
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Zische", Version = "v1" });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
//app.UseSwagger();
//app.UseSwaggerUI(options =>
//{
//    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Zische v1");
//    options.RoutePrefix = "swagger"; // Or any other route prefix you prefer
//});

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();