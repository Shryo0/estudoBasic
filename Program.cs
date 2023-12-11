using Microsoft.EntityFrameworkCore;
using Prova.Data;
var builder = WebApplication.CreateBuilder(args);
// Configurando o contexto do banco de dados usando SQLite
builder.Services.AddDbContext<AppDataContext>(
    options => options.UseSqlite("Data Source=folha.db;Cache=shared")
);
// Adicionando serviços necessários para controladores
builder.Services.AddControllers();
// Adicionando suporte à documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
// Configuração do Swagger apenas no ambiente de desenvolvimento
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// Configuração de CORS para permitir qualquer origem, método e cabeçalho
app.UseCors(
    cors => cors.AllowAnyOrigin().
        AllowAnyMethod().
        AllowAnyHeader()
);
// Redirecionamento HTTPS
app.UseHttpsRedirection();
// Configuração da autorização
app.UseAuthorization();
// Mapeamento dos controladores
app.MapControllers();
// Execução da aplicação
app.Run();
