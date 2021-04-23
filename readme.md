Gerando a OpenApi Spec automaticamente a partir do código
---

A solução foi criada utilizando o netcore 2.1 e como proposta utilizamos o [Nswag](https://github.com/RicoSuter/NSwag) para gerar a OpenApi Spec.

Pacotes usados:

* NSwag.Annotations
* NSwag.AspNetCore

### Configurando a aplicação

Na classe startup configuramos os middlewares e geramos a doc da spec.

```c# - Startup.cs
public class Startup
{
    ...

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        ...

        services.AddOpenApiDocument(c =>
        {
            c.PostProcess = document =>
            {
                document.Info.Version = "v1";
                document.Info.Title = "Users";
                document.Info.Description = "API REST Users em netcore 2.1";
                document.Info.Contact = new OpenApiContact
                {
                    Name = "Squad X",
                    Email = "squadx@email.com",
                    Url = "https://gitlab.com/meurepo"
                };
            };
            c.UseRouteNameAsOperationId = false;
        });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        ...

        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Users v1"));
    }
}
```

Nas controllers definimos informações de cada recurso da API como: "rotas, verbos, statuscodes de response, response body, headers, operation id além de outras informações".

```c# - controller

```
