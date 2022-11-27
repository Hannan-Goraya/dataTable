using Dapper;
using dataTable.data;
using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;
using NuGet.Protocol;
using System.Data;
using System.Drawing.Printing;
using System.Security.AccessControl;
using System.Xml;

namespace dataTable.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IbaseRepo _dapper;
        private readonly IEmployeeRepos _emRepository;

        public EmployeeService(IEmployeeRepos emRepository, IbaseRepo ibase)
        {
            _dapper = ibase;
            _emRepository = emRepository;
        }

        public async Task<DataTableRespose<EmployeePartial>> GetEmployeesAsync(DataTableRequest request)
        {
            var req = new EmployeeListingRequest()
            {
                PageNo = request.Start,
                PageSize = request.Length,
                SortColumn = request.Order[0].Column,
                SortDirection = request.Order[0].Dir,
                SearchValue = request.Search != null ? request.Search.Value.Trim() : ""
            };

            var employee = await _emRepository.GetEmployeeAsync(req);

            return new DataTableRespose<EmployeePartial>()
            {
                Draw = request.Draw,
                RecordsTotal = employee[0].TotalCount,
                RecordsFiltered = employee[0].FilteredCount,
                Data = employee,
                Error = ""
            };

        }


        public Employee AddEmp(Employee emp)
        {
            DynamicParameters parameter = new DynamicParameters();

            parameter.Add("@EmployeeId", -1, dbType: DbType.Int32, direction: ParameterDirection.Output);
            parameter.Add("@EmployeeFirstName", emp.EmployeeFirstName);
            parameter.Add("@EmployeeLastName", emp.EmployeeLastName);
            parameter.Add("@Salary", emp.Salary);
            parameter.Add("@Designation", emp.Designation);


            var ewq = _dapper.ExecuteReturnScalar<Employee>("AddEmployee", parameter);
            return ewq;

        }


        public Employee GetEmpById(int EmployeeId)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@EmployeeId", EmployeeId);

            var emp = _dapper.ExecuteReturnScalar<Employee>("GetEmployeeById", parameters);

            return emp;

        }



        public Employee EditEmployee(int EmployeeId, Employee employee)
        {
            DynamicParameters parameters = new DynamicParameters();

            parameters.Add("@EmployeeId", EmployeeId);
            parameters.Add("@EmployeeFristName", employee.EmployeeFirstName);
            parameters.Add("@EmployeeLastName", employee.EmployeeLastName);
            parameters.Add("@Salary", employee.Salary);
            parameters.Add("@Designation", employee.Designation);

            var emp = _dapper.ExecuteReturnScalar<Employee>("EditEmployee", parameters);

            return emp;
        }


        public Employee DeleteEmp(int EmployeeId)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@EmployeeId", EmployeeId);


            var emp =  _dapper.ExecuteReturnScalar<Employee>("DeleteEmployee");
            return emp;
        }






























        public async Task<DataTableRespose<DTEmployee>> GetAllDt (DtRequest req)
        {
            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@SearchText", req.SearchText);
            parameters.Add("@SortExpression", req.SortExpression);
            parameters.Add("@StartRowIndex", req.StartRowIndex);
            parameters.Add("@PageSize", req.PageSize);


           var employee =  _dapper.ReturnMultipule("GetAllEmployeeDT", parameters);

            var Response = new DataTableRespose<DTEmployee>()
            {
                Draw = req.draw,
                Data = employee.Result.Rec,
                RecordsTotal = employee.Result.TotalRec,
                RecordsFiltered = employee.Result.TotalRec,
                Error = ""

                


            };
            return Response;





        }





    }
    }
