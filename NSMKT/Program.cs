using Hangfire;
using HangfireBasicAuthenticationFilter;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using NSMKT.Context;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;



var HFconnectionString = builder.Configuration.GetConnectionString("HangfireConnection");
var MKTconnectionString = builder.Configuration.GetConnectionString("NSMktConnection");

builder.Services.AddHangfire(Configuration =>
  Configuration.SetDataCompatibilityLevel(CompatibilityLevel.Version_170)
  .UseSimpleAssemblyNameTypeSerializer()
  .UseRecommendedSerializerSettings()
  .UseSqlServerStorage(HFconnectionString, new Hangfire.SqlServer.SqlServerStorageOptions
  {
      CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
      SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
      QueuePollInterval = TimeSpan.Zero,
      UseRecommendedIsolationLevel = true,
      DisableGlobalLocks = true
  })
);
builder.Services.AddHangfireServer();


// For Entity Framework
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AppConnectionString")));

// For Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidAudience = configuration["JWT:ValidAudience"],
            ValidIssuer = configuration["JWT:ValidIssuer"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
    });


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddRouting();

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

app.MapControllerRoute(name: "default",pattern: "{controller=Home}/{action=Index}/{id?}");

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//    endpoints.MapHangfireDashboard();
//});


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.UseSwagger();
app.UseSwaggerUI();
app.Run();
