using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using QuizApp_BL.Options;
using QuizApp_BL.Services.TokenService;
using System.Text;
using QuizApp_DAL;
using QuizApp_DAL.RolesHelper;
using QuizApp_BL.Services.HashService;
using QuizApp_DAL.GenericRepository;
using QuizApp_BL.Services.AuthService;
using QuizApp_BL.Profiles;
using QuizApp_BL.Services.QuizService;
using QuizApp_DAL.BasicGenericRepository;
using QuizApp_Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<EfDbContext>(options
    => options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

var assemblies = new[]
{
    typeof(UserProfile).Assembly,
    typeof(QuestionProfile).Assembly
};

builder.Services.AddAutoMapper(assemblies);
builder.Services.AddHttpContextAccessor();

builder.Services.Configure<AuthOptions>(
    builder.Configuration.GetSection(nameof(AuthOptions)));
builder.Services.Configure<HashOptions>(
    builder.Configuration.GetSection(nameof(HashOptions)));

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IBasicGenericRepository<>), typeof(BasicGenericRepository<>));
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IQuizService, QuizService>();

builder.Services.AddSingleton<ITokenService, TokenService>();
builder.Services.AddSingleton<IRolesHelper, RolesHelper>();
builder.Services.AddSingleton<IHashService, HashService>();

builder.Services.AddCors(x =>
    x.AddDefaultPolicy(x => x
        .AllowAnyHeader()
        .AllowAnyOrigin()
        .AllowAnyMethod()));

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateLifetime = true,
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                .GetBytes(builder.Configuration
                .GetSection(nameof(AuthOptions))["Key"]!))
        };

        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) &&
                    (path.StartsWithSegments("/chat")))
                {
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "JWTToken_Auth_API",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var app = builder.Build();

app.UseCors();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MigrateDatabase();
app.Run();