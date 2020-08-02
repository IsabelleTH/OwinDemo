using Microsoft.Owin;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinDemo
{
    public static class AppBuilderExtension
    {
        public static IAppBuilder GetMethod(IAppBuilder app, string path, Func<IOwinContext, Func<Task>, Task> handler)
        {
            return app.Use((context, next) =>
            {
                if(context.Request.Method == "GET")
                {
                    return handler(context, next);
                }

                return next();
            });
        }
    }
}
