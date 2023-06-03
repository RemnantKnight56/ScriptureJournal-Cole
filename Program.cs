using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ScriptureJournal_Cole.Data;
using ScriptureJournal_Cole.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddDbContext<ScriptureJournal_ColeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ScriptureJournal_ColeContext") ?? throw new InvalidOperationException("Connection string 'ScriptureJournal_ColeContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
