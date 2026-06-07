using VerstaOrderPrjoect.Data;

var builder = WebApplication.CreateBuilder(args);

builder.WebHost.UseKestrel(options =>
{
    options.ListenLocalhost(5001);
});

builder.Services.AddAuthentication();
builder.Services.AddAuthorization();

builder.Services.AddControllersWithViews();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpLogging();

//builder.Services.AddScoped<OrdersContext>();
builder.Services.AddSqlite<OrdersContext>("Data Source=./DataBaseSqlite/OrdersProject.db");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpLogging();

app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=OrdersMvc}/{action=Index}/{id?}");

app.MigrateDb();

app.Run();

