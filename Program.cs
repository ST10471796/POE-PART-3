var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

// Point to the API (7182)
builder.Services.AddHttpClient("RaceDayApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7182/api/");
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<RaceDay.Web.Services.ApiService>();
builder.Services.AddSession();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseSession();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();