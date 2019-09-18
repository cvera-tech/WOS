using InvoiceMaker.Data;

namespace InvoiceMaker.Repositories
{
    public abstract class BaseRepository
    {
        protected Context _context;
        
        protected BaseRepository(Context context)
        {
            _context = context;
        }
    }
}