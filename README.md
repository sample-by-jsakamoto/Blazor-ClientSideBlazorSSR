# Sample Code: How to enable Server-Side Rendering on Client-Side Blazor App?

## Summary

This sample code describes that how to enable server-side rendering on a client-side blazor application.

## Pre required

- [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)
- A Client-Side Blazor application with ASP.NET Core hosted project.

## Migration Step

1. Remove "index.html" from the client project, and add "_Host.cshtml" Razor Page file to the server project, instead.  
The contents of "_Host.cshtml" is almost a copy of "index.html", however, it has server-side rendering instruction in the `<app>` element.

```html
<app>
  ...
  <component type="typeof(App)" render-mode="Static" />
```

2. Add Razor Pages feature to the server at server-side Startup class, and change the fallback page specification to the URL of "_Host.razor" Razor Page.

```csharp
public class Startup
{
  public void ConfigureServices(IServiceCollection services)
  {
    services.AddRazorPages();
    ...
  }

  public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
  {
    ...
    app.UseEndpoints(endpoints =>
    {
      ...
      endpoints.MapFallbackToPage("/_Host");
    });
    ...
```

That's all!

## Appendix

However, the `HttpClient` dependency injection at Blazor components might be failed when it's rendering in server-side.

Therefore, those Blazor components such as `Fetch.razor` have to change that implementation.

You can see one of the examples ways at [the commit 18298a37](https://github.com/sample-by-jsakamoto/Blazor-ClientSideBlazorSSR/commit/18298a37fe85c274431fba83d0b2127f7265ff6a).


# License

This sample code provides under [The Unlicense](LICENSE).