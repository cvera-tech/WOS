using InvoiceMaker.Data;
using System.Web.Mvc;

namespace InvoiceMaker.Controllers
{
    public abstract class BaseController : Controller
    {
        protected Context _context;
        protected bool _disposed;
        protected BaseController()
        {
            _context = new Context();
            _disposed = false;
        }
        
        protected override void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
            _disposed = true;
        }
    }
}