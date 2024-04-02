using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Repository;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<PostRepository>();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlite($"Data Source=members_only.db"));
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<DataContext>();

// Add services to the container.
builder.Services.AddRazorPages(options => { options.Conventions.AuthorizePage("/Posts/Create"); });

WebApplication app = builder.Build();

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

app.Run();