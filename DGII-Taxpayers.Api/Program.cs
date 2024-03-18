using DGII_Taxpayers.Api.ExceptionHandler;
using DGII_Taxpayers.Application;
using DGII_Taxpayers.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddInfrastructure(builder.Environment);
    builder.Services.AddApplication();
    builder.Services.AddControllers();
    builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
    builder.Services.AddProblemDetails();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Configuration.AddUserSecrets<Program>(optional:false,reloadOnChange:true);
}


var app = builder.Build();
{ 
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
        await app.Services.InitializeDatabaseAsync();
    }

    app.UseHttpsRedirection();

    app.UseExceptionHandler();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

