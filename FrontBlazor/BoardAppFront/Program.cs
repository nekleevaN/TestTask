using BoardAppFront.Interfaces;
using BoardAppFront.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<IBoardApiService, BoardApiService>();

builder.Services.AddHttpClient<IBoardApiService, BoardApiService>(client =>
{
    client.BaseAddress = new Uri("https://localhost:7163");
});
builder.Services.AddRazorPages();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
