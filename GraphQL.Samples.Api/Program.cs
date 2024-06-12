using GraphQL.Samples.Api.Database.Context;
using GraphQL.Samples.Api.Queries;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policyBuilder =>
    {
        policyBuilder.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
    });
});

builder.Services.AddDbContext<AdventureWorksContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("AdventureWorksDb"));
});

builder.Services.AddGraphQLServer()
    .RegisterDbContext<AdventureWorksContext>(DbContextKind.Pooled)
    .AddQueryType<ProductsQuery>()
    .AddFiltering()
    .AddSorting()
    .AddProjections();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapGraphQL();

app.Run();

