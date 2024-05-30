using Microsoft.EntityFrameworkCore;
using System.Configuration;
using WebCTAoDai30.Models;

var builder = WebApplication.CreateBuilder(args);
//Connectiondb
builder.Services.AddDbContext<CtaoDaiContext>(options =>
{
	options.UseSqlServer(builder.Configuration["ConnectionStrings: DbConnection"]);
});

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
	options.IdleTimeout = TimeSpan.FromSeconds(30);
	options.Cookie.IsEssential = true;
});

var app = builder.Build();

app.UseStatusCodePagesWithRedirects("/Home/NotFound?statuscode=0");
app.UseSession();
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
	name: "Areas",
	pattern: "{area:exists}/{controller=Product}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
