var builder = WebApplication.CreateBuilder(args);

// Adiciona suporte a controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI();

// Descomente se quiser usar HTTPS (opcional)
// Descomente se quiser usar HTTPS (opcional)
// app.UseHttpsRedirection();

app.UseAuthorization();

// Mapeia os endpoints dos controllers
app.MapControllers();

app.Run();
