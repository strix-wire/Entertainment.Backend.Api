using Entertainment.Application.Common.Mappings;
using Entertainment.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.WebHost.UseKestrel();

//Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddAutoMapper(config =>
{
    //Get information about current assembly in progress
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
});

var app = builder.Build();

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
