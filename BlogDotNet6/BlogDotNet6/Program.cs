using System.IO.Compression;
using System.Text;
using System.Text.Json.Serialization;
using BlogDotNet6;
using BlogDotNet6.Data;
using BlogDotNet6.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

ConfigureMvc(builder);
ConfigureAuthentication(builder);
ConfigureServices(builder);

var app = builder.Build();

app.UseHttpsRedirection();
app.MapControllers();
LoadConfiguration(app);
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

void LoadConfiguration(WebApplication app)
{
    
    Configuration.JwtKey = app.Configuration.GetValue<string>("JwtKey");
    Configuration.ApiKey = app.Configuration.GetValue<string>("ApiKey");
    Configuration.ApiKeyName = app.Configuration.GetValue<string>("ApiKey");

    var smtp = new Configuration.SmtpConfiguration();
    app.Configuration.GetSection("Smtp").Bind("Smtp", smtp);
    Configuration.Smtp = smtp;

}

void ConfigureMvc(WebApplicationBuilder builder)
{
    builder.Services
        .AddMemoryCache()
        .AddResponseCompression(options =>
        {
            options.Providers.Add<GzipCompressionProvider>();
        })
        .Configure<GzipCompressionProviderOptions>(options =>
        {
            options.Level = CompressionLevel.Optimal;
        })
        .AddControllers()
        .ConfigureApiBehaviorOptions(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        })
        .AddJsonOptions(x =>
        {
            x.JsonSerializerOptions.IgnoreNullValues = true;
            x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        });
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(x =>
        {
        
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration.JwtKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection"); 
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();
    builder.Services.AddDbContext<BlogDataContext>(
        options => options.UseSqlServer(connectionString));
}