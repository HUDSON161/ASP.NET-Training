using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesApplication
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
            services.AddRazorPages();//добавляем поддержку Razor страниц
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //старт конвейера обработки запроса
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseAuthentication();//использовать авторизацию пользователя на основе cookie [Этот middleware я добавил самостоятельно]
            app.UseResponseCaching();//кешировать ответы на стороне клиента, для экономии трафика [Этот middleware я добавил самостоятельно]
            app.UseResponseCompression();//позволяет сжимать ответы при отправке на клиент, для экономии трафика [Этот middleware я добавил самостоятельно]

            app.UseHttpsRedirection();//судя по описанию метода, при http запросе, заменяет его на шифрованный hhtps
            app.UseStaticFiles();//разрешение на использование статических файлов (js скрипты,картинки,json файлы и др.)
            app.UseRouting();//определяет пути маршрутизации ( пути в адресной строке браузера (до конца не понял что это и зачем) )
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
