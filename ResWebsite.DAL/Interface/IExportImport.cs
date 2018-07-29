using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IExportImport
    {
        IEnumerable<ExportImport> GetAllExportImport();
        bool AddExportImport(ExportImport exportImport);
        bool UpdateExportImport(ExportImport exportImport);
        bool DeleteExportImport(int exportImportId);
        ExportImport FindExportImport(int exportImportId);
    }
}
