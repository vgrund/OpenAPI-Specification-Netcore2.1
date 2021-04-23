## Gerando a OpenApi Spec automaticamente a partir do código

A solução proposta utiliza o [Swashbuckle](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) para gerar a 
OpenApi Spec.

## Configurando a aplicação

A configuração começa no Startup.cs

Linhas 27 a 42 - Definição ...

Linha 67 e 68 - Definição ...

```c# - Startup.cs
public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

        services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Title = "Users", 
                    Version = "v1",
                    Description = "API REST Users em netcore 5",
                    Contact = new OpenApiContact
                    {
                        Name = "Squad X",
                        Email = "squadx@email.com",
                        Url = new Uri("https://gitlab.com/meurepo")
                    }
                });
            }
        );
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users v1"));
    }
}
```

Nas controllers definimos informações de cada recurso da API como: "rotas, verbos, statuscodes de response, response body, headers, operation id além de outras informações".

```c# - controller

```


Swashbuckle CLI

https://github.com/domaindrivendev/Swashbuckle.AspNetCore#swashbuckleaspnetcorecli




#### Using the tool with the .NET Core 2.1 SDK

1. Install as a [global tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools#install-a-global-tool)

    ```
    dotnet tool install -g --version 6.1.2 Swashbuckle.AspNetCore.Cli
    ```

2. Verify that the tool was installed correctly

    ```
    swagger tofile --help
    ```

3. Generate a Swagger/ OpenAPI document from your application's startup assembly

	```
	swagger tofile --output [output] [startupassembly] [swaggerdoc]
	```

	Where ...
	* [output] is the relative path where the Swagger JSON will be output to
	* [startupassembly] is the relative path to your application's startup assembly
	* [swaggerdoc] is the name of the swagger document you want to retrieve, as configured in your startup class

#### Using the tool with the .NET Core 3.0 SDK or later

1. In your project root, create a tool manifest file:

    ```
    dotnet new tool-manifest
    ```

2. Install as a [local tool](https://docs.microsoft.com/en-us/dotnet/core/tools/global-tools#install-a-local-tool)

    ```
    dotnet tool install --version 6.1.2 Swashbuckle.AspNetCore.Cli
    ```

3. Verify that the tool was installed correctly

    ```
    dotnet swagger tofile --help
    ```

4. Generate a Swagger / OpenAPI document from your application's startup assembly

	```
	dotnet swagger tofile --output [output] [startupassembly] [swaggerdoc]
	```

	Where ...
	* [output] is the relative path where the Swagger JSON will be output to
	* [startupassembly] is the relative path to your application's startup assembly
	* [swaggerdoc] is the name of the swagger document you want to retrieve, as configured in your startup class

### Use the CLI Tool with a Custom Host Configuration

Out-of-the-box, the tool will execute in the context of a "default" web host. However, in some cases you may want to bring your own host environment, for example if you've configured a custom DI container such as Autofac. For this scenario, the Swashbuckle CLI tool exposes a convention-based hook for your application.

That is, if your application contains a class that meets either of the following naming conventions, then that class will be used to provide a host for the CLI tool to run in.