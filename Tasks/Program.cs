using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Tasks.API.Repositories.Implementation;
using Tasks.API.Repositories.Interface;
using Tasks.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("TasksConnectionString"));
});

builder.Services.AddScoped<IDutyRepository, DutyRepository>();

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("/identity").MapIdentityApi<IdentityUser>();
app.MapGroup("/api/Tasks").RequireAuthorization();

app.UseAuthorization();

app.MapControllers();

app.Run();
