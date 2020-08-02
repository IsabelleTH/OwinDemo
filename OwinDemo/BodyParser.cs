using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinDemo
{
    public class BodyParser<TModelType> : OwinMiddleware
        where TModelType : class, new()
    {
        public BodyParser(OwinMiddleware next) : base(next)
        {

        }

        public override Task Invoke(IOwinContext context)
        {
            using(var sr = new StreamReader(context.Request.Body))
            {
                var body = sr.ReadToEnd();
                Console.WriteLine(body);
            }

            return this.Next.Invoke(context);
        }
    }

   
}
