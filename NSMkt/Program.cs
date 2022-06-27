using Hangfire;
using Hangfire.SqlServer;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using NSMkt.Data;
using NSMkt.Models;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var HFconnectionString = builder.Configuration.GetConnectionString("HangfireConnection")?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
var configuration = builder.Configuration;

//Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

//Context,HF
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddHangfire(configuration => configuration
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(HFconnectionString, new SqlServerStorageOptions
            {
                CommandBatchMaxTimeout =TimeSpan.FromMinutes(5),
                SlidingInvisibilityTimeout=TimeSpan.FromMinutes(5),
                QueuePollInterval=TimeSpan.Zero,
                DisableGlobalLocks=true
            }));
builder.Services.AddHangfireServer();

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
//    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddSession(o => { o.Cookie.Name="NSMkt"; o.IdleTimeout=TimeSpan.FromMinutes(10); o.Cookie.HttpOnly=true; o.Cookie.IsEssential=true; });

#region GoogleAuth
builder.Services.AddAuthentication()
                .AddGoogle(googleOptions => {
                    googleOptions.ClientId = configuration["Authentication:Google:ClientId"];
                    googleOptions.ClientSecret = configuration["Authentication:Google:ClientSecret"];
                });
#endregion


//Swagger
#region SwaggerAPIKEY_Config

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("ApiKey", new OpenApiSecurityScheme
    {
        Description = "ApiKey must appear in header",
        Type = SecuritySchemeType.ApiKey,
        Name = "ApiKey",
        In = ParameterLocation.Header,
        Scheme = "ApiKeyScheme"
    });
    var key = new OpenApiSecurityScheme()
    {
        Reference = new OpenApiReference
        {
            Type = ReferenceType.SecurityScheme,
            Id = "ApiKey"
        },
        In = ParameterLocation.Header
    };
    var requirement = new OpenApiSecurityRequirement
                    {
                             { key, new List<string>() }
                    };
    options.AddSecurityRequirement(requirement);
    options.SwaggerDoc("v1", new OpenApiInfo
    {

        Version = "v1",
        Title = "NSMKT API",
        Description = "An NSE Mkt API data ",
        TermsOfService = new Uri("https://NSMKT.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "NSMKT Contact",
            Url = new Uri("https://NSMKT.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "NSMKT License",
            Url = new Uri("https://NSMKT.com/license")
        }
    });
}

);
#endregion



var app = builder.Build();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    DashboardTitle = "NSMarket",
    Authorization = new[] {
 new HangfireCustomBasicAuthenticationFilter
 {

        User=builder.Configuration.GetSection("HangfireSettings:UserName").Value,
        Pass=builder.Configuration.GetSection("HangfireSettings:Password").Value
 }
}
});

#region Identity
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await ContextSeed.SeedRolesAsync(userManager, roleManager);
        await ContextSeed.SeedSuperAdminAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}
#endregion



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwaggerUI(options =>
{
    // options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    // options.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();


app.MapControllerRoute(name: "default", "{controller}/{action}/{id}",                         
                new { controller = "Home", action = "Index", id = "" });// pattern: "{controller=Home}/{action=RefIndex}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapHangfireDashboard();
});
app.MapRazorPages();
app.Run();
