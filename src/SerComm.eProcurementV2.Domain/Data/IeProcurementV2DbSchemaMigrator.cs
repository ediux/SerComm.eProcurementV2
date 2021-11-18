using System.Threading.Tasks;

namespace SerComm.eProcurementV2.Data
{
    public interface IeProcurementV2DbSchemaMigrator
    {
        Task MigrateAsync();
    }
}
