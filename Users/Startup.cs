using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NSwag;

namespace Users
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseOpenApi();
            app.UseSwaggerUi3();
        }
    }
}
