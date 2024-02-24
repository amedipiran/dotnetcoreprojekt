using Microsoft.EntityFrameworkCore;
using Projekt.Data;
using Projekt.Repository;
using Projekt.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Facebook;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultDbString"))
);
builder.Services.AddRazorPages();
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddScoped<IUnitOfWork, unitOfwork>(); 

/* // Lägg till autentisering med Facebook
builder.Services.AddAuthentication().AddFacebook(options =>
{
    options.AppId = builder.Configuration["Authentication:Facebook:AppId"]; // Uppdatera med dina Facebook App Id-inställningar
    options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"]; // Uppdatera med dina Facebook App Secret-inställningar
}); */

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.Run();
