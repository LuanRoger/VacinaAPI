using Infrastructure;
using VacinaAPI;
using VacinaAPI.Endpoints.PostosVacinacao;
using VacinaAPI.Endpoints.Vacinas;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddInfrastructure();
builder.Services.AddApplication();

WebApplication app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using (IServiceScope scope = app.Services.CreateScope())
{
    AppDbContext dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    dbContext.Database.EnsureCreated();
}

app.UseHttpsRedirection();

RouteGroupBuilder vacinasGroup = app
    .MapGroup("/vacinas")
    .WithTags("Vacinas");
vacinasGroup.MapVacinasEndpoints();

RouteGroupBuilder postosGroup = app
    .MapGroup("/postos")
    .WithTags("Postos");
postosGroup.MapPostosVacinacaoEndpoints();

app.Run();