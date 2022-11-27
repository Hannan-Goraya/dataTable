using Dapper;
using dataTable.Models.Dt;

namespace dataTable.data
{
    public interface IbaseRepo
    {
        IEnumerable<T> ReturnList<T>(string procrdureName, DynamicParameters parameter);

        int ReturnInt(string procrdureName, DynamicParameters parameter = null);

        T ExecuteReturnScalar<T>(string procrdureName, DynamicParameters param = null);

        Task<Result> ReturnMultipule(string procrdureName, DynamicParameters parameter);

        int ReturnIntPro(string procrdureName, DynamicParameters parameter = null);

        Task<ResultP> ReturnMultipuleDtp(string procrdureName, DynamicParameters parameter);

    }

}
