var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // 注册控制器服务
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// 用于托管 Angular 静态文件
app.UseDefaultFiles();// 查找 index.html
app.UseStaticFiles();// 默认只处理 wwwroot 下文件

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// 支持 Angular 路由
app.MapFallbackToFile("/index.html");

app.Run();
