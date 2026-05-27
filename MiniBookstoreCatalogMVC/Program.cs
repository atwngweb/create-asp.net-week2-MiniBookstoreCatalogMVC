using MiniBookstoreCatalogMVC.Services;

var builder = WebApplication.CreateBuilder(args);

// ── Đăng ký Services ────────────────────────────────────────
// AddControllersWithViews: thêm MVC pipeline (Controller + Razor View)
builder.Services.AddControllersWithViews();

// Đăng ký IBookService → BookService với DI container
// AddScoped: tạo mới 1 instance mỗi HTTP request
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

// ── Middleware Pipeline ──────────────────────────────────────
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Phục vụ file tĩnh (CSS, JS, images trong wwwroot)
app.UseStaticFiles();

app.UseRouting();
app.UseAuthorization();

// ── Cấu hình MVC Route mặc định ─────────────────────────────
// Route pattern: {controller}/{action}/{id?}
// Mặc định: HomeController → Index()
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
