using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;
using Portal.PL.Languages;
using PortalBL.Interface;
using PortalBL.Mapper;
using PortalBL.Reposatroy;
using PortalDAL.Database;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews().AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
.AddDataAnnotationsLocalization(options =>
{
    options.DataAnnotationLocalizerProvider = (type, factory) =>
        factory.Create(typeof(SharedResource));
}).AddNewtonsoftJson(opt => {
    opt.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

// Enhancement ConnectionString
var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connectionString));

// Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));



// Add Transient ==> Will take instance with every operation
//builder.Services.AddTransient<IDepaertmentRep, DepartmentRep>();


// Add Scoped
builder.Services.AddScoped<IDepartment, DepartmentRep>();
builder.Services.AddScoped<IEmployee, EmployeeRep>();

builder.Services.AddScoped<ICountry, CountryRep>();
builder.Services.AddScoped<ICity, CityRep>();
builder.Services.AddScoped<IDistric, DistricRep>();


//Add Transint

//builder.Services.AddTransient<IDepartment, DepartmentRep>();


//Add Scopped

//builder.Services.AddScoped<IDepartment, DepartmentRep>();


//Add SingleTone

//builder.Services.AddSingleton<IDepartment, DepartmentRep>();




var app = builder.Build();

var supportedCultures = new[] {
                      new CultureInfo("ar-EG"),
                      new CultureInfo("en-US"),
                };

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en-US"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures,
    RequestCultureProviders = new List<IRequestCultureProvider>
                {
                new QueryStringRequestCultureProvider(),
                new CookieRequestCultureProvider()
                }
});
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
