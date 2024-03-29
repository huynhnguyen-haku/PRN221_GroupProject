using BussinessObject;
using Microsoft.EntityFrameworkCore;
using Service.Implementation;
using Service.Interface;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<IBlogService, BlogService>();
builder.Services.AddScoped<IInteriorService, InteriorService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<IQuotationService, QuotationService>();
builder.Services.AddScoped<IStyleService, StyleService>();


builder.Services.AddSession();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
