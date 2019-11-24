# Sample Code: How to enable Server-Side Rendering on Client-Side Blazor App?

## Sammary

This sample code describe that how to enable server-side rendering on a client-side blazor application.

## Prerequired

- .NET Core 3.1 Preview 4
- A Client-Side Blazor application with ASP.NET Core hospted project.

## Migration Step

1. Remove "index.html" from client project, and add "_Host.cshtml" Razor Page file to server project, instead.  
The contents of "_Host.cshtml" is almost a copy of "index.html", however, it has server-side rendering instruction in the `<app>` element.

```html
<app>
  ...
  <component type="typeof(App)" render-mode="Static" />
```

2. Add Razor Pages feature to the server at server-side Startup class, and change fall back page specification to the url of "_Host.razor" Razeo Page.

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

However, automatic `HttpClient` injection at Blazor components mitght be failed when it's rendering in server-side.

Therefore, those Blazor components such as `Fetch.razor` have to change that implementation.

You can see one of the exmaple way at [the commit d75f8b62](https://github.com/sample-by-jsakamoto/Blazor-ClientSideBlazorSSR/commit/d75f8b627cf10cd64aa53a6ef8bfe5b6c4bda1d1).


# License

This sample code provides under [The Unlicense](LICENSE).