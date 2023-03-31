using FluentValidation.AspNetCore;
using Permit.Application;
using Permit.Persistence;
using System.Text.Json.Serialization;

const string AllowsAny = "_allowsAny";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddFluentValidation(config => config.RegisterValidatorsFromAssemblyContaining(typeof(Permit.Application.PermitTypes.Models.PermitTypeInputViewModel)))
        .AddJsonOptions(options =>
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()))
    .AddJsonOptions(options =>
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddMemoryCache();
builder.Services.AddApplication(builder.Configuration, builder.Environment.IsDevelopment());
builder.Services.AddCors(options =>
{
    options.AddPolicy(AllowsAny,
        builder =>
        {
            builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});

var app = builder.Build();

app.InitializeApplicationCaches();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseSwagger();

app.UseSwaggerUI();

app.UseCors(AllowsAny);

app.Run();
