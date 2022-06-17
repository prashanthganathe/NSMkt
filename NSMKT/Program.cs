using Hangfire;
using HangfireBasicAuthenticationFilter;
using Swashbuckle.AspNetCore.Swagger;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();
builder.Services.AddLogging();
builder.Services.AddRouting();

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
