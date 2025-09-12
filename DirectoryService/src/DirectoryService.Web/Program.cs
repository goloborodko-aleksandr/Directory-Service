using DirectoryService.Web;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddProgram(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(o => o.SwaggerEndpoint("/openapi/v1.json", "DirectoryService"));
}

app.MapControllers();
app.Run();