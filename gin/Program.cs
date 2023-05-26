
using DocumentFormat.OpenXml.Drawing.Charts;
using gin.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ZDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ZDBConnection"));
});
builder.Services.AddDistributedMemoryCache();



builder.Services.AddSession(options =>
{
    options.Cookie.Name = "LoginUser";
    options.IdleTimeout = TimeSpan.FromHours(8);
});

builder.Services.AddControllers().AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

//Cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.AccessDeniedPath = new PathString("/Home/index");
        options.LoginPath = new PathString("/Login/LoginList");
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("CustomPolicy", policy =>
    {
        policy.RequireClaim(ClaimTypes.Role, "KY-AirCompList0", "KY-AirCompList1", "admin", "BL-AirCompList0", "BL-AirCompList1", "QX-AirCompList0", "QX-AirCompList1", "ZB-AirCompList0", "ZB-AirCompList1", "KH-AirCompList0", "KH-AirCompList1", "LD-AirCompList0", "LD-AirCompList1", "LZ-AirCompList0", "LZ-AirCompList1", "HL-AirCompList0", "HL-AirCompList1");
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Policy");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();// (≈Á√“µn§J)
app.UseAuthorization();// (±¬≈v)


app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
