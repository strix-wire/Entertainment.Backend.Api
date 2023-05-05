using Entertainment.Application;
using Entertainment.Application.Common.Mappings;
using Entertainment.Application.Interfaces;
using Entertainment.Persistence;
using Microsoft.Extensions.Hosting;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel();

//Add services to the container.
builder.Services.AddControllers();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddAutoMapper(config =>
{
    //Get information about current assembly in progress
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IEntertainmentDbContext).Assembly));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;
    try
    {
        //Call initialize DB
        var context = serviceProvider.GetRequiredService<EntertainmentDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception exception)
    {
        //Если база не была успешно создана
        //Log.Fatal(exception, "An error occurred while app initialization");
    }
}

//Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{

}

app.UseRouting();
app.UseStaticFiles();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
