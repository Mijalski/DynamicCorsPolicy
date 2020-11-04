# About

Default ASP.NET Core Cors package does not allow to change CORS origins at runtime, this package allows to add custom implementation of CORS policy checking as a fallback when origin does not match any of the ones specified at startup. It can be used to retrieve origins from cache, database, file or to apply custom logic like allowing all when debug mode is on.

## Installation

Use nuget to [download the package](https://www.nuget.org/packages/Mijalski.DynamicCorsPolicy).

```PM
Install-Package Mijalski.DynamicCorsPolicy
```

## Usage

Firstly, create a class implementing interface `IDynamicCorsPolicyResolver`.

In Startup.ConfigureServices

replace: `services.AddCors();` with `services.AddDynamicCors<ExampleCorsPolicyResolver>();`.

Lastly in Startup.Configure

replace: `app.UseCors();` with `app.UseDynamicCorsMiddleware();`.

## Example

DynamicCorsPolicyResolver.cs:
```csharp
public class DynamicCorsPolicyResolver : IDynamicCorsPolicyResolver
{

    private readonly ICorsCache _corsCache;

    public DynamicCorsPolicyResolver(ICorsCache corsCache)
    {
         _corsCache = corsCache;
    }

    public async Task<bool> ResolveForOrigin(string origin)
    {
        return await _corsCache.GetAsync(origin) != null;
    }
}

```

Startup.cs:
```csharp
public void ConfigureServices(IServiceCollection services)
{
    // ...
    services.AddDynamicCors<DynamicCorsPolicyResolver>(options =>
    {
        options.AddPolicy(name: CorsPoliciesEnums.DynamicCorsPolicyName, builder =>
        {
            builder.WithOrigins("http://localhost:4200");
        });
     });
}

public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
{
     // ...
     app.UseDynamicCorsMiddleware();
}
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)
