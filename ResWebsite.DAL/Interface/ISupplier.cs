using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface ISupplier
    {
        IEnumerable<Supplier> GgetAllSupplier();
        bool AaddSupplier(Supplier supplier);
        bool UpdateSupplier(Supplier supplier);
        bool DeleteSupplier(int supplierId);
        Supplier FindSupplier(int ssupplierId);
    }
}
