using DealerWorks.Data;
using DealerWorks.Data.Infrastructure.Entities;
using DealerWorks.WebUI.Infrastructure.Rules;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;

#region builder config
var builder = WebApplication.CreateBuilder(args);




//config
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
builder.Services.AddOptions();



builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
});

builder.Services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

builder.Services.AddMvc(x =>
{
    x.EnableEndpointRouting = false;
});

builder.Services.Configure<RouteOptions>(routeOptions => routeOptions.AppendTrailingSlash = true);
#endregion





if (builder.Environment.IsDevelopment())
{
    builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
}

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseStatusCodePages();
}



app.UseDeveloperExceptionPage();
app.UseRouting();
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
app.UseStaticFiles();
app.UseMvc(routes =>
{
    routes.MapRoute(name: "default", template: "{controller=Home}/{action=Index}/{id?}");
});

//ders 7 de kaldým
//https://www.youtube.com/watch?v=e-BipURYZ-o&list=PLjn_v5iA99pkZvq4rvp4tM7unhX1dzlU2&index=7


app.Run();