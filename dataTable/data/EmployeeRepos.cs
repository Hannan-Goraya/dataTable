using Dapper;
using dataTable.Dtos;
using dataTable.Models;
using Microsoft.Data.SqlClient;
using System.Data;


namespace dataTable.data
{
    public class EmployeeRepos :  IEmployeeRepos
    {
        private IbaseRepo _dapper;

        public EmployeeRepos(IbaseRepo ibase)
           
        {
            _dapper = ibase;
        }

        public async Task<List<EmployeePartial>> GetEmployeeAsync(EmployeeListingRequest request)
        {
            try
            {
               
                var parameters = new DynamicParameters();
                parameters.Add("SearchValue", request.SearchValue, DbType.String);
                parameters.Add("PageNo", request.PageNo, DbType.Int32);
                parameters.Add("PageSize", request.PageSize, DbType.Int32);
                parameters.Add("SortColumn", request.SortColumn, DbType.Int32);
                parameters.Add("SortDirection", request.SortDirection, DbType.String);

             
                 return _dapper.ReturnList<EmployeePartial>("SpGetEmployeeList", parameters).ToList();

               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }






        


      
    }
}
