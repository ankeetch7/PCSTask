using DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDALDependency(builder.Configuration);

builder.Services.AddSpaStaticFiles(options =>
{
    options.RootPath = "ClientApp/dist";
});

builder.Services.AddOpenApiDocument(document =>
{
    document.Title = "Employee Web API Project";
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
app.UseOpenApi();
app.UseSwaggerUi3(swagger =>
{
    swagger.Path = "/employeeapi";
    //swagger.DocumentPath = "/api/specification.json";
});
app.UseRouting();

app.UseAuthorization();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Default",
                                 pattern: "{controller}/{action=Index}/{id?}");
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "ClientApp";
    if (app.Environment.IsDevelopment())
    {
        spa.UseProxyToSpaDevelopmentServer("http://localhost:4200/");
    }
});

app.Run();
