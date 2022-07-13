using Microsoft.EntityFrameworkCore;
using PortalBL.Interface;
using PortalBL.Mapper;
using PortalBL.Reposatroy;
using PortalDAL.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();


// Enhancement ConnectionString
var connectionString = builder.Configuration.GetConnectionString("ApplicationConnection");

builder.Services.AddDbContext<ApplicationContext>(options =>
options.UseSqlServer(connectionString));


// Auto Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));


// Add Scoped
builder.Services.AddScoped<IEmployee, EmployeeRep>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



//1) At Configure Service

           builder.Services.AddCors();






var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


//2) At Configure


app.UseCors(options => options
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
