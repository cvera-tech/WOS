using System.Web;

namespace InvoiceMaker
{
    public class Md5HashHandler : IHttpHandler
    {
        public bool IsReusable
        {
            get
            {
                return true;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.Write("Hey!");
        }
    }
}