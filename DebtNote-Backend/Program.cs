using DebtNote.Extensions;
using Microsoft.AspNetCore.HttpOverrides;
using NLog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureLoggerService();
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.AddAutoMapper(typeof(Program));


builder.Services.AddControllers().AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly); ;
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.

LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));

if (app.Environment.IsDevelopment())
    app.UseDeveloperExceptionPage();
else
    app.UseHsts();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseCors("CorsPolicy");
app.UseAuthorization();

//app.UseEndpoints(endpoints =>
//{
//    endpoints.MapControllers();
//});

//app.Use(async (context, next) =>
//{
//    Console.WriteLine($"Logic before executing the next delegate in the Use method");
//    await next.Invoke();
//    Console.WriteLine($"Logic after executing the next delegate in the Use method");
//});

//app.Map("/usingmapbranch", builder =>
//{
//    builder.Use(async (context, next) =>
//    {
//        Console.WriteLine("Map branch logic in the Use method before the next delegate");

//        await next.Invoke();
//        Console.WriteLine("Map branch logic in the Use method after the next delegate");
//    });
//    builder.Run(async context =>
//    {
//        Console.WriteLine($"Map branch response to the client in the Run method");
//        await context.Response.WriteAsync("Hello from the map branch.");
//    });
//});

//app.MapWhen(context => context.Request.Query.ContainsKey("testquerystring"), builder =>
//{
//    builder.Run(async context =>
//    {
//        await context.Response.WriteAsync("Hello from the MapWhen branch.");
//    });
//});
//app.Run(async context =>
//{
//    Console.WriteLine($"Writing the response to the client in the Run method");
//    await context.Response.WriteAsync("Hello from the middleware component.");
//});
app.MapControllers();
app.Run();



