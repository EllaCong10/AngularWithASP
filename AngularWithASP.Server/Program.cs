var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(); // ע�����������
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


// �����й� Angular ��̬�ļ�
app.UseDefaultFiles();// ���� index.html
app.UseStaticFiles();// Ĭ��ֻ���� wwwroot ���ļ�

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// ֧�� Angular ·��
app.MapFallbackToFile("/index.html");

app.Run();
