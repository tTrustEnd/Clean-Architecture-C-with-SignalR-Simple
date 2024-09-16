using CleanArchitectureSignalR.Core.Entities;
using CleanArchitectureSignalR.Core.UseCases.GetMessageUseCase;
using CleanArchitectureSignalR.Core.UseCases.Repositories;
using CleanArchitectureSignalR.Core.UseCases.SendMessageUseCase;
using CleanArchitectureSignalR.Core.UseCases.Services;
using CleanArchitectureSignalR.Infrastructure.SpLite.Data;
using CleanArchitectureSignalR.Infrastructure.SpLite.Repositories;
using CleanArchitectureSignalR.Presentation.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Thêm dịch vụ vào container
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); // Thêm dịch vụ SignalR

// Cấu hình các dịch vụ khác, chẳng hạn như Entity Framework, Authentication, Authorization, v.v.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Filename=splitedb1")); // Sửa tên file phù hợp
builder.Services.AddTransient<ISendMessageUseCase, SendMessageUseCase>();
builder.Services.AddTransient<IGetMessageUseCase, GetMessageUseCase>();

builder.Services.AddTransient<IMessageRepository, MessageRepository>();
builder.Services.AddTransient<IMessageService>(services => new MessageService(
    services.GetRequiredService<ISendMessageUseCase>(),
    services.GetRequiredService<IGetMessageUseCase>()));



var app = builder.Build();

using var scope = app.Services.CreateScope();
var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
await dbContext.Database.EnsureCreatedAsync();

// Cấu hình HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Map SignalR Hub routes
app.MapHub<ChatHub>("/chathub");

// Map các controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
