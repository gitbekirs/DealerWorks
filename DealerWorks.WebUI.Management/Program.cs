using DealerWorks.Data;
using DealerWorks.Data.Infrastructure.Entities;
using DealerWorks.WebUI.Infrastructure.Rules;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//config

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json",optional:true,reloadOnChange:true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",optional:true)
    .AddEnvironmentVariables()
    .Build();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
}

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddOptions();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});


builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
 
//data
builder.Services.AddTransient<KategoriData>();




builder.Services.AddMvc(x =>
{
    x.EnableEndpointRouting = false;
}); 
builder.Services.Configure<RouteOptions>(routeOptions => routeOptions.AppendTrailingSlash = true);

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
}

app.UseDeveloperExceptionPage();

//app.UseEndpoints(enpoints =>
//{
//    enpoints.MapGet("/", async context =>
//    {
//        await context.Response.WriteAsync("Hello World");
//    });
//});
RedirectToHttpsWwwNonWwwRule rule = new RedirectToHttpsWwwNonWwwRule
{
    status_code = 301,
    redirect_to_https = true,
    redirect_to_www = false,
    redirect_to_non_www = true,
    append_slash = true
};
RewriteOptions options = new RewriteOptions();
options.Rules.Add(rule);
app.UseRewriter(options);
app.UseRouting();
app.UseStaticFiles();
app.UseMvc(routes =>
{
    //routes.MapRoute(name: "kategori", template: "kategori/{id}", defaults: new { controller = "kategori", action = "index", page = 1 });
    //routes.MapRoute(name: "kategoriWithPage", template: "kategori/sayfa/{page}", defaults: new { controller = "kategori", action = "index", page = 1 });
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});
//ders 7 de kald�m
//https://www.youtube.com/watch?v=e-BipURYZ-o&list=PLjn_v5iA99pkZvq4rvp4tM7unhX1dzlU2&index=7
app.Run();


