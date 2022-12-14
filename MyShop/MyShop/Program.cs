using MyShop.Configuration;
using MyShop.Interfaces;
using MyShop.Models;
using MyShop.Models.ViewModel;
using MyShop.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//IoC
builder.Services.AddScoped(typeof(IRepository<CatalogItem>), typeof(LocalCatalogItemRepository));
builder.Services.AddScoped<ICatalogItemViewModelService, CatalogItemViewModelService>();
builder.Services.AddCoreServices();

var app = builder.Build();

app.Logger.LogInformation("App created!");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Logger.LogDebug("Starting the app!");
app.Run();
