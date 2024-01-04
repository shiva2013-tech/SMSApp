using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using SMSApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(Options =>
{ Options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")); });
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/admin/login";
        options.AccessDeniedPath = "/admin/access-denied";
        options.Cookie.HttpOnly = true;
        options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
        options.SlidingExpiration = true;
    });
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
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
  {
      // Admin routes
      endpoints.MapControllerRoute(
          name: "adminLogin",
          pattern: "admin/login",
          defaults: new { controller = "Admin", action = "Login" });

      endpoints.MapControllerRoute(
    name: "adminDashboard",
    pattern: "admin/dashboard",
    defaults: new { controller = "Admin", action = "Dashboard" })
    .RequireAuthorization(); // Requires authorization for this route

      endpoints.MapControllerRoute(
    name: "adminLoadQualifications",
    pattern: "Admin/LoadQualifications",
    defaults: new { controller = "Admin", action = "LoadQualifications" });


      endpoints.MapControllerRoute(
              name: "default",
              pattern: "Student/Registration",
              defaults: new { controller = "Student", action = "Create" });

  });

app.Run();
