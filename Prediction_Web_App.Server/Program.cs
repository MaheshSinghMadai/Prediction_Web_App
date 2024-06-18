using FinancePersonal.Infrastructure.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Prediction_Web_App.Core.Entities.Identity;
using Prediction_Web_App.Core.Interface;
using Prediction_Web_App.Infrastructure.Data;
using Prediction_Web_App.Infrastructure.Data.Identity;
using Prediction_Web_App.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
                      });
});

builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<ScorecardService>();

builder.Services.AddControllers().AddNewtonsoftJson(); ;
builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    // Identity options here
})
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AppIdentityServices(builder.Configuration);

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);
app.UseAuthorization();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

//using var scope = app.Services.CreateScope();
//var services = scope.ServiceProvider;
//var loggerFactory = services.GetRequiredService<ILoggerFactory>();
//try
//{
//    // Seeding identity data to identity database
//    var userManager = services.GetRequiredService<UserManager<AppUser>>();
//    var identityContext = services.GetRequiredService<AppIdentityDbContext>();
//    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
//    await identityContext.Database.MigrateAsync();
//    await AppIdentityDbContextSeed.SeedUserAsync(userManager);
//    await ContextSeed.SeedRolesAsync(userManager, roleManager);
//}
//catch (Exception ex)
//{
//    var logger = loggerFactory.CreateLogger<Program>();
//    logger.LogError(ex, "An error occurred seeding the DB.");
//}

app.Run();
