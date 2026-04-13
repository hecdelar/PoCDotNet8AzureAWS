using AdminRequest.poc.Utils.Controller;
using AdminRequest.poc.WebAPI.ApplicationCore.Command;
using AdminRequest.WebAPI.ApplicationCore.Interfaces;
using AdminRequest.WebAPI.Infraestructure.AWSSQS.Messaging;
using AdminRequest.WebAPI.Infraestructure.AWSSQS.Utils;
using AdminRequest.WebAPI.Infraestructure.DynamoDB.Repository;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.SQS;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region CORS

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("AdminRequest_CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin()
               .WithMethods("GET", "POST", "PUT")
               .WithHeaders("uuId", "timestamp", "systemId");
    });
});

#endregion

#region Service Swagger Configuration

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(swagger =>
{
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1.0.0",
        Title = "Microservicio Mensajeria en AWS", //TODO: Agregar titulo
        Description = "Microservicio encargado de crear y obtener la información de mensajes en aws", //TODO: Agregar descripción
        Contact = new OpenApiContact
        {
            Name = "Hector Fabio Mercado", //TODO: Agregar nombre de contacto
            Email = "hecdelar@hotmail.com"
        }
    });

    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "CustomTokenFormat",
        In = ParameterLocation.Header,
        Description = "Por favor envíe el token en la cabecera de la petición",
    });

    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});

// Convenciones para nombres de controladores en Swagger
builder.Services.AddMvc(mvc =>
{
    mvc.Conventions.Add(new ControllerNameAttributeConvention());
});

#endregion Service Swagger Configuration

#region MediatR

builder.Services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(MessageByIdHandler).Assembly));

#endregion MediatR

#region HealthCkecks

builder.Services.AddHealthChecks();

#endregion

#region AWSConfig
builder.Services.AddDefaultAWSOptions(
    builder.Configuration.GetAWSOptions()
    );
#endregion

#region DynamoContext
builder.Services.AddAWSService<IAmazonDynamoDB>();
builder.Services.AddScoped<IDynamoDBContext, DynamoDBContext>();
#endregion


#region AWSSQS
builder.Services.AddAWSService<IAmazonSQS>();
builder.Services.Configure<SqsOptions>(
    builder.Configuration.GetSection("Messaging:Sqs"));
#endregion

#region DI
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IMessageBus, MessageBus>();
builder.Services.AddHttpContextAccessor().AddHttpClient();
#endregion


var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/Health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.UseCors("AdminRequest_CorsPolicy");

app.Run();
