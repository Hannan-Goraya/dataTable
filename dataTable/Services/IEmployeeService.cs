using dataTable.Dtos;
using dataTable.Models;
using dataTable.Models.Dt;

namespace dataTable.Services
{
    public interface IEmployeeService
    {
         Task<DataTableRespose<EmployeePartial>> GetEmployeesAsync(DataTableRequest request);

        Employee DeleteEmp(int EmployeeId);
        Employee EditEmployee(int EmployeeId, Employee employee);
        Employee GetEmpById(int EmployeeId);
        Employee AddEmp(Employee emp);

        Task<DataTableRespose<DTEmployee>> GetAllDt(DtRequest req);

    }
}
