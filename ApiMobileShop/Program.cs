using ApiMobileShop.Data;
using ApiMobileShop.Reponsitories;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "tedt API",
        Version = "v1",
        Description = "tedt Service."
    });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "test",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
    c.MapType(typeof(IFormFile), () => new OpenApiSchema() { Type = "file", Format = "binary" });
});

builder.Services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
{
    options.Authority = "https://localhost:7154/";
    options.TokenValidationParameters = new TokenValidationParameters { ValidateAudience = false };
    options.RequireHttpsMetadata = false;
});

builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

builder.Services.AddDbContext<MobileContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("MyMobileStore"));
});

builder.Services.AddScoped<IUsersResponsitory, UsersResponsitory>();
builder.Services.AddScoped<IShopResponsitory, ShopResponsitory>();
builder.Services.AddScoped<IShopCartResponsitory, ShopCardResponsitory>();
builder.Services.AddScoped<IShopProductResponsitory, ShopProductResponsitory>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.UseRouting();

app.Run();
