using dataTable.Dtos;
using dataTable.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dataTable.data
{
    public interface IEmployeeRepos
    {
        
            Task<List<EmployeePartial>> GetEmployeeAsync(EmployeeListingRequest request);
        
    }
}
