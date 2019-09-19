using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InvoiceMaker
{
    public class Md5HashModule : IHttpModule
    {
        public void Dispose()
        {
           
        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleBeginRequest;
        }

        private void HandleBeginRequest(object sender, EventArgs e)
        {
            InvoiceMakerApplication app = (InvoiceMakerApplication)sender;
            string url = app.Context.Request.FilePath;

            if (url.StartsWith("/api/hash/"))
            {
                string path = url.Replace("/api/hash/", string.Empty);
                app.Context.RewritePath($"/{path}.hash");
            } else if (url.StartsWith("/api/binhash/"))
            {
                string path = url.Replace("/api/binhash/", string.Empty);
                app.Context.RewritePath($"/{path}.binhash");
            }
        }
    }
}