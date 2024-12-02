
using Microsoft.EntityFrameworkCore;
using Model.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<TeploobmenContext>(o=> o.UseSqlite("Data Source = Teploobmen.db;"));

var app = builder.Build();

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

app.Run();

//int h = 5;
//int T_material = 10;
//int T_gas = 650
//double C_gas = 1.35;
//double C_material = 1.49;
//double G = 1.68;
//double d = 2.2
//double w = 0.74;
//double av = 2440