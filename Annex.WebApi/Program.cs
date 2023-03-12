

using System.Reflection;

using System.Text;

using System.Net;
using Annex.DataLayer.Contex;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Annex.InterfaceService.InterfacesBase;
using Annex.Service.ServiceBase;


var builder = WebApplication.CreateBuilder(args);



var SqlConnectionString = builder.Configuration.GetConnectionString("AppDbAnnex");
builder.Services.AddDbContext<ContextAnnex>(x => x.UseSqlServer(SqlConnectionString,
    sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); }).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());



// Add services to the container.

builder.Services.AddScoped<IUnitOfWorkAnnexService, UnitOfWorkAnnexService>();
 



builder.Services.AddControllers();



builder.Services.AddEndpointsApiExplorer();





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigin",
        builder => builder
           //.SetIsOriginAllowed( _ => true)
           //.AllowAnyOrigin()
           .WithOrigins("https://localhost:3000", "https://www.asetcoyadak.com", "https://uc.asetcoyadak.com", "https://god-asetco.netlify.app", "https://api.asetcoyadak.com")
          .AllowAnyMethod()
          .AllowAnyHeader()
          .AllowCredentials()
    .Build());
});


builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Version = "v1", Title = "AsetCo Web API" });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization ",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"

                            },
                        },
                        new String[]{}
                    }
                });
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
//{
//    options.TokenValidationParameters = new TokenValidationParameters
//    {
//        ValidateIssuer = true,
//        ValidateAudience = true,
//        ValidateLifetime = true,
//        ValidateIssuerSigningKey = true,
//        ValidIssuer = builder.Configuration["Jwt:Issuer"],
//        ValidAudience = builder.Configuration["Jwt:Audience"],
//        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
//    };
//});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "AsetCo Web API");

    });

}


app.UseDeveloperExceptionPage();

app.UseCors("AllowOrigin");



app.UseHttpsRedirection();

app.MapControllers();


app.UseAuthentication();
app.UseAuthorization();




app.Run();



