using Microsoft.EntityFrameworkCore;
using PortalBL.Interface;
using PortalBL.Mapper;
using PortalBL.Reposatroy;
using PortalDAL.Database;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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


//Add Transint

//builder.Services.AddTransient<IDepartment, DepartmentRep>();


//Add Scopped

//builder.Services.AddScoped<IDepartment, DepartmentRep>();


//Add SingleTone

//builder.Services.AddSingleton<IDepartment, DepartmentRep>();




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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
