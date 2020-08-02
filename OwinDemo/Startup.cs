using Owin;
using OwinDemo;
using System.Web.Http;

class BarBody
{
    public string Value { get; set; }
}
 class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        
        //Register our middleware by passing thorugh the middleware we 
        // want to register
        app.Use<BodyParser<BarBody>>();
        app.Map("/foo", config =>
        {
            config.Run(async (hej) =>
            {
               await hej.Response.WriteAsync("Hey foo");
            });
        });

        app.Use((context, next) =>
        {
            if (context.Request.Method == "POST")
            {
                var form = context.Get<BarBody>("Body");
                return context.Response.WriteAsync("Post recieved: " + form.Value);
            }

            return next();
        });

        //Configure HttpConfiguration for routing
        HttpConfiguration configuration = new HttpConfiguration();
        configuration.Routes.MapHttpRoute(
            name: "DefaultAPI",
            routeTemplate: "API/{controller}/{action}/{id}",
            defaults: new { id = RouteParameter.Optional }
            );

        app.UseWebApi(configuration);


        // GET : /bar
        AppBuilderExtension.GetMethod(
            app,
            "/bar",
            (context, next) => context.Response.WriteAsync("Get bar")
            );


        app.Use((context, next) => context.Response.WriteAsync("Hello from OWIN"));
    }
    }





