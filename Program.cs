using DbApi;
using DbApi.Config;
using DbApi.Repositories;
using DbApi.Repositories.Interfaces;
using DbApi.Services;
using DbApi.Services.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi( op => 
{
    op.AddDocumentTransformer((doc, _, _) =>
    {
        doc.Components.SecuritySchemes = new Dictionary<string, IOpenApiSecurityScheme>();
        doc.Components.SecuritySchemes["Bearer"] = new OpenApiSecurityScheme
        {
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            Scheme = "bearer",
            BearerFormat = "Identity access token",
            In = ParameterLocation.Header,
            Description = "Cole apenas o accessToken retornado por /auth/login. O Swagger adiciona 'Bearer' automaticamente."
        };
        return Task.CompletedTask;
    });

    op.AddOperationTransformer((operation, context, _) =>
    {
        if (context.Description.ActionDescriptor.EndpointMetadata.Any(metadata => metadata is IAuthorizeData))
        {
            operation.Security ??= [];
            operation.Security.Add(new OpenApiSecurityRequirement
            {
                [new OpenApiSecuritySchemeReference("Bearer", context.Document, null)] = []
            });
        }

        return Task.CompletedTask;
    });

});

builder.Services.AddControllers();


string connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

builder.Services.AddIdentityApiEndpoints<IdentityUser>()
       .AddEntityFrameworkStores<AppDbContext>();

builder.Services.AddAuthorization();

builder.Services.AddScoped<IClientesRepository, ClientesRepository>();
builder.Services.AddScoped<IClientesService, ClientesServices>();

builder.Services.AddScoped<IFuncionariosRepository, FuncionariosRepository>();

var app = builder.Build();

app.UseMiddleware<ErrorMiddleware>();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI( op =>
    {
        op.SwaggerEndpoint("/openapi/v1.json", "v1");
    });
}

//app.UseHttpsRedirection();
app.MapControllers();
app.MapGroup("/auth").MapIdentityApi<IdentityUser>();


app.Run();