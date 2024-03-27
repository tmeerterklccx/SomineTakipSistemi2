using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IAboutDal, EfAboutDal>();
builder.Services.AddScoped<IAboutService, AboutManager>();
builder.Services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementManager>();
builder.Services.AddScoped<IContactInfoDal, EfContactInfoDal>();
builder.Services.AddScoped<IContactInfoService, ContactInfoManager>();
builder.Services.AddScoped<IGetContactDal, EfGetContactDal>();
builder.Services.AddScoped<IGetContactService, GetContactManager>();
builder.Services.AddScoped<IMainTopDal, EfMainTopDal>();
builder.Services.AddScoped<IMainTopService, MainTopManager>();
builder.Services.AddScoped<IMoreAsqQuestionDal, EfMoreAskQuestionDal>();
builder.Services.AddScoped<IMoreAskQuestionService, MoreAskQuestionManager>();
builder.Services.AddScoped<IOurInfoDal, EfOurInfoDal>();
builder.Services.AddScoped<IOurInfoService, OurInfoManager>();
builder.Services.AddScoped<IProductDal, EfProductDal>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<IServiceDal, EfServiceDal>();
builder.Services.AddScoped<IServiceService, ServiceManager>();
builder.Services.AddScoped<ITestiMonialDal, EfTestiMonialDal>();
builder.Services.AddScoped<ITestiMonialService, TestiMonialManager>();


var app = builder.Build();

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
    name: "Admin",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "User",
    pattern: "{area:exists}/{controller=Default}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Default}/{action=Index}/{id?}");

app.Run();
