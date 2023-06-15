using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSession();

builder.Services.AddRazorPages();

builder.Services.AddSession(); //toegevoegd

builder.Services.AddMvc(); // toegevoegd

// builder.Services.AddResponseCaching(); // toegevoegd

// builder.Services.AddSession(options =>
// {
//     options.IdleTimeout = TimeSpan.FromMinutes(30);
//     options.Cookie.Name = null; // toegevoegd
// }); 

var app = builder.Build();

Program.Configuration = app.Configuration;

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseDeveloperExceptionPage(); //toegevoegd
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.UseCookiePolicy();

app.MapRazorPages();

app.Run();


partial class Program
{
    public static IConfiguration Configuration { get; set; } = null!;
}