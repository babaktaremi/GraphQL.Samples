using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using GraphQL.Samples.App;
using GraphQLSchemas.GraphQL;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddGetProductsQuery()
    .ConfigureHttpClient(client =>
    {
        client.BaseAddress = new Uri("https://localhost:7231/graphql/");
    });
    
await builder.Build().RunAsync();