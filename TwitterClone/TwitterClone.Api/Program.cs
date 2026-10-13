using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Services;

using TwitterClone.Infrastructure.Repositories;


var builder = WebApplication.CreateBuilder(args);


//Registering the Repositories
builder.Services.AddSingleton<ITweetRepository, TweetRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();


builder.Services.AddScoped<ITweetService, TweetService>();
builder.Services.AddScoped<IUserService, UserService>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddHttpClient();




var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "Twitter Clone API v1");
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
