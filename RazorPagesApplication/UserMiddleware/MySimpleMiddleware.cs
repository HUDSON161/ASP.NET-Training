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
        MySimpleMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        //синхронный метод при вызове которого будем перенаправляться на секретные страницы(секретные страницы буду делать чтобы потренироваться в верстке)
        public void Invoke(HttpContext context)
        {
            if (context.Request.Path.Value.Contains("AuxiliaryPage1"))
            {
                context.Response.Redirect(@"\UserPages\AuxiliaryPage1");
            }
            else
            {
                next.Invoke(context);//если не поймали нужное условие то передаем управление следующему компоненту Middleware
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
