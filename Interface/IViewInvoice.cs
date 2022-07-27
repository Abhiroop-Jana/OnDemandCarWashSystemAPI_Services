using OnDemandCarWashSystemAPI.Models;
using System.Collections.Generic;

namespace OnDemandCarWashSystemAPI.Interface
{
    public interface IViewInvoice
    {
        List<Invoice> ViewInvoiceAsync(int id);
    }
}
