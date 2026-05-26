using katano.Presentations.Extensions;
<<<<<<< HEAD

var builder = WebApplication.CreateBuilder(args);
=======
using katano.Presentations.Middlewares;

var builder = WebApplication.CreateBuilder(args);

>>>>>>> 85ca7ab (代々優勝)
// ControllerやViewの依存関係を構築する
builder.Services.AddControllersWithViews();

// アプリケーションの依存関係を構築する
builder.Services.SettingDependencyInjection(builder.Configuration);

var app = builder.Build();

<<<<<<< HEAD
=======
// IngternalExceptionをハンドリングするミドルウェアを有効にする
app.UseMiddleware<InternalExceptionLoggingMiddleware>();



>>>>>>> 85ca7ab (代々優勝)
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
