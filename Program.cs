using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Nextwo23.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<Nextwo23_DBContext>(options => { options.UseSqlServer(builder.Configuration.GetConnectionString("serverName")); });

builder.Services.AddIdentity<IdentityUser,IdentityRole>().AddEntityFrameworkStores<Nextwo23_DBContext>();
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
