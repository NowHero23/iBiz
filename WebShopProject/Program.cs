using Microsoft.EntityFrameworkCore;
using WebShopProject.Data;
using WebShopProject.Data.Domain.Repositories.Abstract;
using WebShopProject.Data.Domain.Repositories.EntityFramework;
using WebShopProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conn = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseNpgsql(conn));

// Add repositories
builder.Services.AddScoped<IUserRepository, EFUserRepository>();
builder.Services.AddScoped<JwtService>();




/*builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    builder => 
    { 
        builder.WithOrigins("http://client:3000")// - React/Next.js
        .WithOrigins("http://localhost:3000");
        
        //.WithOrigins("http://client:8080") - Vue
        //.WithOrigins("http://client:3000") - Angular
    }));*/



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Check database connection and apply migrations
using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
    if (dbContext.Database.CanConnect())
    {
        if (dbContext.Database.GetPendingMigrations().Any())
        {
            dbContext.Database.Migrate();
        }  
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(options => options
    //.WithOrigins("CorsPolicy")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials()
    );

app.UseAuthorization();

app.MapControllers();




app.Run();
