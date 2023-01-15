using Microsoft.EntityFrameworkCore;
using CHOM.Data;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CHOMContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("CHOMContext") ?? throw new InvalidOperationException("Connection string 'CHOMContext' not found.")));
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Admin/Login";
        options.ExpireTimeSpan = TimeSpan.FromHours(24);
    });
builder.Services.ConfigureApplicationCookie(opts =>
{
    opts.LoginPath = "/Admin/Login";
    opts.ExpireTimeSpan = TimeSpan.FromHours(24);
});
builder.Services.AddAntiforgery(o => o.HeaderName = "XSRF-TOKEN");
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<DbContext, CHOMContext>();
// Add services to the container.
builder.Services.AddSession();

builder.Services.AddControllersWithViews();


builder.Services.AddDistributedMemoryCache();

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
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapAreaControllerRoute(
        name: "admin",
        areaName: "Admin",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
});
app.Run();
