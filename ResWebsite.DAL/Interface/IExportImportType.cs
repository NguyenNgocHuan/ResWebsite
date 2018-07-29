using ResWebsite.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResWebsite.DAL.Interface
{
    public interface IExportImportType
    {
        IEnumerable<ExportImportType> GetAllExportImportType();
        bool AddExportImportType(ExportImportType exportImportType);
        bool UpdateExportImportType(ExportImportType exportImportType);
        bool DeleteExportImportType(int exportImportTypeId);
        ExportImportType FindExportImportType(int exportImportTypeId);
    }
}
