using System;
using System.Web;

namespace InvoiceMaker
{
    public class Md5HashModule : IHttpModule
    {
        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += HandleBeginRequest;
        }

        private void HandleBeginRequest(object sender, EventArgs e)
        {
            InvoiceMakerApplication application = sender as InvoiceMakerApplication;
            HttpContext context = application.Context;
            HttpRequest request = context.Request;
            Uri uri = request.Url;
            string absolutePath = uri.AbsolutePath;
            string newPath = "/";
            if (absolutePath.StartsWith("/api/hash/"))
            {
                newPath += $"{absolutePath.Substring(10)}.hash";
                context.RewritePath(newPath);
            }
            else if (absolutePath.StartsWith("/api/binhash/"))
            {
                newPath += $"{absolutePath.Substring(13)}.binhash";
                context.RewritePath(newPath);
            }
        }
    }
}