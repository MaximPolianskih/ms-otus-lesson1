using Microsoft.EntityFrameworkCore;
using SimpleApi.DataContext;
using SimpleApi.Interfaces;
using SimpleApi.Mapping;
using SimpleApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetValue<string>("ConnectionStrings:Default");
builder.Services.AddDbContext<ApplicationDbContext>(
            options =>
            {
                options.UseNpgsql(
                    connectionString,
                    o =>
                    {
                        o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery);
                    })
                    .UseSnakeCaseNamingConvention();
            },
            ServiceLifetime.Scoped,
            ServiceLifetime.Singleton);

builder.Services.AddAutoMapper(typeof(ApplicationMappingProfile));
builder.Services.AddTransient<ISimpleApiService, SimpleApiService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    dbcontext.Database.EnsureDeleted();
    dbcontext.Database.Migrate();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
