using LevelUp_1.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("http://localhost:3000", "https://calm-water-04859b403.azurestaticapps.net");
        });
});

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swaggerGenOptions =>
{
    swaggerGenOptions.SwaggerDoc("v1", new OpenApiInfo { Title = "LevelUp", Version = "v1" });
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(swaggerUIOptions =>
{
    swaggerUIOptions.DocumentTitle = "Level Up";
    swaggerUIOptions.SwaggerEndpoint("/swagger/v1/swagger.json", "Web API serving a very simple Post model.");
    swaggerUIOptions.RoutePrefix = string.Empty;
});

app.UseHttpsRedirection();

app.UseCors("CORSPolicy");


//To get all the users

app.MapGet("/get-all-users", async () => await UserRepository.GetUsersAsync())
.WithTags("Users");

app.MapGet("/get-all-domain", async () => await UserRepository.GetDomains())
.WithTags("Assessment Endpoints");

//To sign up

app.MapPost("/Sign-Up", async (User user) =>
{
    bool createSuccessful = await UserRepository.SignUp(user);

    if (createSuccessful)
    {
        return Results.Ok("Create successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Sign Up");

//Login
app.MapPost("/Log-In/{mailid,password}", async (string mailId,string password) =>
{
    User userData = await UserRepository.Login(mailId,password);

    if (userData!=null)
    {
        return Results.Ok("Log In successful.");
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Log In");

app.MapGet("/questionsByDomainId/{domainId}", async (int domainId) =>
{
    demo questions = await AssessmentRepository.GetQuestionsByDomId(domainId);

    if (questions != null)
    {
        return Results.Ok(questions);
    }
    else
    {
        return Results.BadRequest();
    }
}).WithTags("Questions By Domain");


app.MapGet("/QnAs/{domainId}", async (int domainId) =>
{
    List<QnA> questions = await AssessmentRepository.GetQnA(domainId);

    if (questions != null)
    {
        return Results.Ok(questions);
    }
    else
    {
        return Results.BadRequest();
    }
})
.WithTags("QnA");

app.Run();
