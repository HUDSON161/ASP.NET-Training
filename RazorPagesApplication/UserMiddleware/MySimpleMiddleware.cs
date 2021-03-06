using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesApplication.UserMiddleware
{
    public class MySimpleMiddleware//мой пользовательский, тренировочный компонент Middleware
    {
        //выполняет роль ссылки на следующий компонент конвейера запросов
        private readonly RequestDelegate next;

        //конструктор ( по идее автоматически должен получать RequestDelegate с помощью Dependency Injection)
        public MySimpleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //синхронный метод при вызове которого будем перенаправляться на секретные страницы(секретные страницы буду делать чтобы потренироваться в верстке)
        public Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("AP1"))
            {
                context.Response.Redirect(@"\AuxiliaryPage1");
                return Task.CompletedTask;
            }
            else
            {
                next.Invoke(context);//если не поймали нужное условие то передаем управление следующему компоненту Middleware
                return Task.CompletedTask;
            }
        }

        /*асинхронный метод при вызове которого будем перенаправляться на секретные страницы ( секретные страницы буду делать чтобы потренироваться в верстке )
        public async void InvokeAsync(HttpContext context)
        {
            if ( context.Request.Path.Value.Contains("AuxiliaryPage1") )
            {
                await Task.Run( () => context.Response.Redirect(@"\UserPages\AuxiliaryPage1") );
            }
            else
            {
                await next.Invoke(context);//если не поймали нужное условие то передаем управление следующему компоненту Middleware
            }
        }
        */
    }
}
